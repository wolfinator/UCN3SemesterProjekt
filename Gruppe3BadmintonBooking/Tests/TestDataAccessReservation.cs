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
        public int customerId1 { get; set; }
        public int customerId2 { get; set; }
        public int customerId3 { get; set; }

        private SqlCommand cmdRemoveTestCityZip;
        private SqlCommand cmdRemoveTestAddress;
        private SqlCommand cmdRemoveTestPersons;
        public ReservationDbFixture()
        {
            // Setting up the connection
            con = new SqlConnection(DbConnection.conStr.ConnectionString);
            con.Open();

            // Setting up clean up queries to delete test data
            cmdRemoveTestCityZip = new("delete from CityZip where zipcode = 'rese'", con);
            cmdRemoveTestAddress = new("delete from _address where street = 'reservation'", con);
            cmdRemoveTestPersons = new("delete from customer where email = 'reservation@test.test'", con);

            SqlCommand cmdAddTestCityZip = new("insert into CityZip values ('rese', 'rvation')", con);
            SqlCommand cmdAddTestAddress = new("insert into _address values ('reservation', 'test', 'rese', @CustomerId)", con);
            SqlCommand cmdAddTestCustomer1 = new("insert into customer output inserted.id values " +
                "('TestReservation', 'Customer1', 'reservation@test.test', '12345678')", con);
            SqlCommand cmdAddTestCustomer2 = new("insert into customer output inserted.id values " +
                "('TestReservation', 'Customer2', 'reservation@test.test', '87654321')", con);
            SqlCommand cmdAddTestCustomer3 = new("insert into customer output inserted.id values " +
                "('TestReservation', 'Customer3', 'reservation@test.test', '12348765')", con);

            // Removing existing test data if there is any, e.g. tests failed and left some test data
            cmdRemoveTestPersons.ExecuteNonQuery();
            cmdRemoveTestAddress.ExecuteNonQuery();
            cmdRemoveTestCityZip.ExecuteNonQuery();

            // Add test data nessecary to set up reservations in the database
            cmdAddTestCityZip.ExecuteNonQuery();

            // Getting the inserted ids for the persons for easy access when inserting reservations
            customerId1 = (int)cmdAddTestCustomer1.ExecuteScalar();
            customerId2 = (int)cmdAddTestCustomer2.ExecuteScalar();
            customerId3 = (int)cmdAddTestCustomer3.ExecuteScalar();

            for (int i = 0; i < 3; i++)
            {
                cmdAddTestAddress.Parameters.Clear();
                int customerId = 0;
                switch (i)
                {
                    case 0:
                        customerId = customerId1;
                        break;
                    case 1:
                        customerId = customerId2;
                        break;
                    case 2:
                        customerId = customerId3;
                        break;
                }
                cmdAddTestAddress.Parameters.AddWithValue("@CustomerId", customerId);
                cmdAddTestAddress.ExecuteNonQuery();
            }
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
                creationDate = DateTime.Now.AddYears(-10),
                startTime = DateTime.Now.AddYears(-9).Date.AddHours(13),
                endTime = DateTime.Now.AddYears(-9).Date.AddHours(14),
                shuttleReserved = true,
                numberOfRackets = 4,
                courtNo = 1,
                customer = new() { id = fixture.customerId1 },
            };

            SqlConnection con = fixture.con;

            SqlCommand cleanupReservation = new("delete from reservation where id = @Id", con);
            SqlCommand cmdTestSelect = new("select * from Reservation where " +
                "creation_date = @CreationDate and " +
                "start_time = @StartTime and " +
                "end_time = @EndTime and " +
                "shuttle_reserved = @ShuttleReserved and " +
                "number_of_rackets = @NumberOfRackets and " +
                "court_court_no = 1 and " +
                "customer_id = @CustomerId"
                , con);

            cmdTestSelect.Parameters.AddWithValue("@CreationDate", reservation.creationDate);
            cmdTestSelect.Parameters.AddWithValue("@StartTime", reservation.startTime);
            cmdTestSelect.Parameters.AddWithValue("@EndTime", reservation.endTime);
            cmdTestSelect.Parameters.AddWithValue("@ShuttleReserved", reservation.shuttleReserved ? 1 : 0);
            cmdTestSelect.Parameters.AddWithValue("@NumberOfRackets", reservation.numberOfRackets);
            cmdTestSelect.Parameters.AddWithValue("@CustomerId", reservation.customer.id);
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
            SqlCommand cmdInsertReservation = new("insert into reservation output inserted.id values " +
                "(@CreationDate, @StartTime, @EndTime, 0, 2, 3, @CustomerId)", con);
            cmdInsertReservation.Parameters.AddWithValue("@CreationDate", dateTime.Date.AddYears(-10).AddHours(1));
            cmdInsertReservation.Parameters.AddWithValue("@StartTime", dateTime.Date.AddYears(-10).AddHours(15));
            cmdInsertReservation.Parameters.AddWithValue("@EndTime", dateTime.Date.AddYears(-10).AddHours(16));
            cmdInsertReservation.Parameters.AddWithValue("@CustomerId", fixture.customerId2);

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
            var dateTime = DateTime.Now;
            SqlCommand cmdInsertReservation;
            SqlCommand cleanupReservations;
            int[] reservationIds = new int[3];
            for (int i = 0; i <= 2; i++)
            {
                cmdInsertReservation = new("insert into reservation output inserted.id values " +
                "(@CreationDate, @StartTime, @EndTime, 0, 4, 2, @CustomerId)", con);
                cmdInsertReservation.Parameters.AddWithValue("@CreationDate", dateTime.Date.AddYears(-11).AddHours(1));
                cmdInsertReservation.Parameters.AddWithValue("@StartTime", dateTime.Date.AddYears(-11).AddHours(15 + i));
                cmdInsertReservation.Parameters.AddWithValue("@EndTime", dateTime.Date.AddYears(-11).AddHours(16 + i));
                cmdInsertReservation.Parameters.AddWithValue("@CustomerId", fixture.customerId2);

                reservationIds[i] = (int)cmdInsertReservation.ExecuteScalar();
            }

            //Act
            List<Reservation> reservations = dataAccess.GetAll().ToList();

            //Assert
            Assert.NotNull(reservations);
            Assert.Contains(reservations, reservation => reservation.Id == reservationIds[0]);
            Assert.Contains(reservations, reservation => reservation.Id == reservationIds[1]);
            Assert.Contains(reservations, reservation => reservation.Id == reservationIds[2]);

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
            var dateTime = DateTime.Now;

            SqlCommand cmdInsertReservation = new("insert into reservation output inserted.id values " +
                "(@CreationDate, @StartTime, @EndTime, 0, 2, 1, @CustomerId)", con);
            SqlCommand cleanupReservation = new("delete from reservation where id = @Id", con);

            cmdInsertReservation.Parameters.AddWithValue("@CreationDate", dateTime.Date.AddYears(-12).AddHours(1));
            cmdInsertReservation.Parameters.AddWithValue("@StartTime", dateTime.Date.AddYears(-12).AddHours(15));
            cmdInsertReservation.Parameters.AddWithValue("@EndTime", dateTime.Date.AddYears(-12).AddHours(16));
            cmdInsertReservation.Parameters.AddWithValue("@CustomerId", fixture.customerId3);

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
            var dateTime = DateTime.Now;

            SqlCommand cmdInsertReservation = new("insert into reservation output inserted.id values " +
                "(@CreationDate, @StartTime, @EndTime, 0, 2, 1, @CustomerId)", con);
            SqlCommand cleanupReservation = new("delete from reservation where id = @Id", con);

            cmdInsertReservation.Parameters.AddWithValue("@CreationDate", dateTime.Date.AddYears(-12).AddHours(1));
            cmdInsertReservation.Parameters.AddWithValue("@StartTime", dateTime.Date.AddYears(-12).AddHours(9));
            cmdInsertReservation.Parameters.AddWithValue("@EndTime", dateTime.Date.AddYears(-12).AddHours(10));
            cmdInsertReservation.Parameters.AddWithValue("@CustomerId", fixture.customerId3);

            int reservationId;
            reservationId = (int)cmdInsertReservation.ExecuteScalar();

            Reservation reservationUpdate = new()
            {
                Id = reservationId,
                creationDate = dateTime.Date.AddYears(-12).AddHours(1),
                startTime = dateTime.Date.AddYears(-12).AddHours(10),
                endTime = dateTime.Date.AddYears(-12).AddHours(11),
                shuttleReserved = false,
                numberOfRackets = 2,
                courtNo = 2,
                customer = new() { id = fixture.customerId3 },
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
