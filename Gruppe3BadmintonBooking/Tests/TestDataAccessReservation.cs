using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Model;

namespace Tests
{
    public class ReservationDbFixture : IDisposable
    {
        //https://xunit.net/docs/shared-context
        public SqlConnection con { get; private set; }
        public int employeeId { get; set; }
        public int memberId { get; set; }
        public int guestId { get; set; }

        private SqlCommand cmdRemoveTestCityZip;
        private SqlCommand cmdRemoveTestAddress;
        private SqlCommand cmdRemoveTestPersons;
        public ReservationDbFixture()
        {
            // Setting up the connection
            con = new SqlConnection(Connection.conStr.ConnectionString);
            con.Open();

            // Setting up clean up queries to delete test data
            cmdRemoveTestCityZip = new("delete from CityZip where zipcode = 'rese'", con);
            cmdRemoveTestAddress = new("delete from _address where street = 'reservation'", con);
            cmdRemoveTestPersons = new("delete from person where email = 'reservation@test.test'", con);

            SqlCommand cmdAddTestCityZip = new("insert into CityZip values ('rese', 'rvation')", con);
            SqlCommand cmdAddTestAddress = new("insert into _address output inserted.id values ('reservation', 'test', 'rese')", con);
            SqlCommand cmdAddTestEmployee = new("insert into person output inserted.id values " +
                "('TestReservation', 'Employee', 'reservation@test.test', '12345678' , '0', @AddressId)", con);
            SqlCommand cmdAddTestMember = new("insert into person output inserted.id values " +
                "('TestReservation', 'Member', 'reservation@test.test', '87654321', '2', @AddressId)", con);
            SqlCommand cmdAddTestGuest = new("insert into person output inserted.id values " +
                "('TestReservation', 'Guest', 'reservation@test.test', '12348765', '1', @AddressId)", con);

            // Removing existing test data if there is any, e.g. tests failed and left some test data
            cmdRemoveTestPersons.ExecuteNonQuery();
            cmdRemoveTestAddress.ExecuteNonQuery();
            cmdRemoveTestCityZip.ExecuteNonQuery();

            // Add test data nessecary to set up reservations in the database
            cmdAddTestCityZip.ExecuteNonQuery();
            int addressId = (int)cmdAddTestAddress.ExecuteScalar(); // Getting the id for the address to add on the person
            cmdAddTestEmployee.Parameters.AddWithValue("@AddressId", addressId);
            cmdAddTestMember.Parameters.AddWithValue("@AddressId", addressId);
            cmdAddTestGuest.Parameters.AddWithValue("@AddressId", addressId);

            // Getting the inserted ids for the persons for easy access when inserting reservations
            employeeId = (int)cmdAddTestEmployee.ExecuteScalar();
            memberId = (int)cmdAddTestMember.ExecuteScalar();
            guestId = (int)cmdAddTestGuest.ExecuteScalar();
        }
        public void Dispose()
        {
            // Remove all test data from the test
            cmdRemoveTestPersons.ExecuteNonQuery();
            cmdRemoveTestAddress.ExecuteNonQuery();
            cmdRemoveTestCityZip.ExecuteNonQuery();
            con.Close();
        }
    }
    public class TestDataAccessReservation : IClassFixture<ReservationDbFixture>
    {
        ReservationDbFixture fixture;

        DataAccessReservation dataAccess;

        // Dependency injection for the fixture class that runs everytime we run a test in the test class
        public TestDataAccessReservation(ReservationDbFixture dbFixture)
        {
            this.fixture = dbFixture;
            dataAccess = new();
        }

        [Fact]
        public void TestCreateReservation()
        {
            //Arrange
            Reservation reservation = new()
            {
                dateTime = DateTime.Now.AddYears(-10),
                isEquipment = true,
                fromTime = TimeSpan.FromSeconds(3600),
                courtNo = 1,
                customer = new() { id = fixture.memberId },
                employee = new() { id = fixture.employeeId }
            };

            SqlConnection con = fixture.con;

            SqlCommand cmdTestSelect = new("select * from Reservation where " +
                "date_time = @DateTime and " +
                "is_equipment = @IsEquipment and " +
                "from_time = @FromTime and " +
                "court_id = 1 and " +
                "customer_id = @CustomerId and " +
                "employee_id = @EmployeeId", con);
            SqlCommand cleanupReservation = new("delete from Reservation where id = @Id", con);

            cmdTestSelect.Parameters.AddWithValue("@DateTime", reservation.dateTime);
            cmdTestSelect.Parameters.AddWithValue("@IsEquipment", reservation.isEquipment ? 1 : 0);
            cmdTestSelect.Parameters.AddWithValue("@FromTime", reservation.fromTime);
            cmdTestSelect.Parameters.AddWithValue("@CustomerId", reservation.customer.id);
            cmdTestSelect.Parameters.AddWithValue("@EmployeeId", reservation.employee.id);
            //Act
            dataAccess.Create(reservation);
            SqlDataReader reader = cmdTestSelect.ExecuteReader();

            //Assert
            Assert.True(reader.Read());

            //Cleanup
            cleanupReservation.Parameters.AddWithValue("@Id", reader.GetInt32(0));
            reader.Close();
            cleanupReservation.ExecuteNonQuery();
        }
        [Fact]
        public void TestReservationDeleteById()
        {
            //Arrange
            SqlConnection con = fixture.con;

            var dateTime = DateTime.Now;
            var timeSpan = TimeSpan.FromSeconds(3600);
            SqlCommand cmdInsertReservation = new("insert into reservation output inserted.id values " +
                "(@DateTime, 0, @FromTime, 1, @CustomerId, @EmployeeId)", con);
            cmdInsertReservation.Parameters.AddWithValue("@DateTime", dateTime);
            cmdInsertReservation.Parameters.AddWithValue("@FromTime", timeSpan);
            cmdInsertReservation.Parameters.AddWithValue("@CustomerId", fixture.guestId);
            cmdInsertReservation.Parameters.AddWithValue("@EmployeeId", fixture.employeeId);
            //Act
            int reservationId = (int)cmdInsertReservation.ExecuteScalar();
            bool deleted = dataAccess.DeleteById(reservationId);

            //Assert
            Assert.True(deleted);
        }

        [Fact]
        public void TestReservationGetAll()
        {
            //Arrange
            var con = fixture.con;
            SqlCommand cmdInsertReservation;
            SqlCommand cleanupReservations;
            int[] reservationIds = new int[3];
            for (int i = 0; i <= 2; i++)
            {
                cmdInsertReservation = new("insert into reservation output inserted.id values " +
                "(@DateTime, 0, @FromTime, 1, @CustomerId, @EmployeeId)", con);
                cmdInsertReservation.Parameters.AddWithValue("@DateTime", DateTime.Now.AddYears(-10 - i));
                cmdInsertReservation.Parameters.AddWithValue("@FromTime", TimeSpan.FromSeconds(3600));
                cmdInsertReservation.Parameters.AddWithValue("@CustomerId", fixture.memberId);
                cmdInsertReservation.Parameters.AddWithValue("@EmployeeId", fixture.employeeId);
                reservationIds[i] = (int)cmdInsertReservation.ExecuteScalar();

            }

            //Act
            List<Reservation> reservations = dataAccess.GetAll().ToList();

            //Assert
            Assert.NotNull(reservations);
            Assert.True(reservations.Any(reservation => reservation.Id == reservationIds[0]));
            Assert.True(reservations.Any(reservation => reservation.Id == reservationIds[1]));
            Assert.True(reservations.Any(reservation => reservation.Id == reservationIds[2]));

            //Cleanup
            for (int i = 0; i < reservationIds.Length; i++)
            {
                cleanupReservations = new("delete from reservation where id = @Id", con);
                cleanupReservations.Parameters.AddWithValue("@Id", reservationIds[i]);
                cleanupReservations.ExecuteNonQuery();
            }
        }

        [Fact]
        public void TestGetById()
        {
            //Arrange
            var con = fixture.con;

            SqlCommand cmdInsertReservation = new("insert into reservation output inserted.id values " +
                "(@DateTime, 0, @FromTime, 1, @CustomerId, @EmployeeId)", con);
            SqlCommand cleanupReservation = new("delete from reservation where id = @Id", con);

            cmdInsertReservation.Parameters.AddWithValue("@DateTime", DateTime.Now.AddYears(-10));
            cmdInsertReservation.Parameters.AddWithValue("@FromTime", TimeSpan.FromSeconds(3600));
            cmdInsertReservation.Parameters.AddWithValue("@CustomerId", fixture.memberId);
            cmdInsertReservation.Parameters.AddWithValue("@EmployeeId", fixture.employeeId);

            int reservationId;
            //Act
            reservationId = (int)cmdInsertReservation.ExecuteScalar();
            Reservation reservation = dataAccess.GetById(reservationId);

            //Assert
            Assert.NotNull(reservation);
            Assert.Equal(reservation.Id, reservationId);

            //Cleanup
            cleanupReservation.Parameters.AddWithValue("@Id", reservationId);
            cleanupReservation.ExecuteNonQuery();
        }

        [Fact]
        public void TestUpdate()
        {
            //Arrange
            var con = fixture.con;

            SqlCommand cmdInsertReservation = new("insert into reservation output inserted.id values " +
                "(@DateTime, 0, @FromTime, 1, @CustomerId, @EmployeeId)", con);
            SqlCommand cleanupReservation = new("delete from reservation where id = @Id", con);

            cmdInsertReservation.Parameters.AddWithValue("@DateTime", DateTime.Now.AddYears(-10));
            cmdInsertReservation.Parameters.AddWithValue("@FromTime", TimeSpan.FromSeconds(3600));
            cmdInsertReservation.Parameters.AddWithValue("@CustomerId", fixture.memberId);
            cmdInsertReservation.Parameters.AddWithValue("@EmployeeId", fixture.employeeId);

            int reservationId;
            reservationId = (int)cmdInsertReservation.ExecuteScalar();

            Reservation reservationUpdate = new()
            {
                Id = reservationId,
                dateTime = DateTime.Now.AddYears(-15),
                isEquipment = true,
                fromTime = TimeSpan.FromSeconds(3600),
                courtNo = 1,
                customer = new Person() { id = fixture.memberId },
                employee = new Employee() { id = fixture.employeeId }
            };
            //Act
            bool updated = dataAccess.Update(reservationUpdate);

            //Assert
            Assert.True(updated);

            //Cleanup
            cleanupReservation.Parameters.AddWithValue("@Id", reservationId);
            cleanupReservation.ExecuteNonQuery();
        }
    }
}