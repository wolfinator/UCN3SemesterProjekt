using DataAccess;
using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class DatabaseFixture : IDisposable
    {
        //https://xunit.net/docs/shared-context
        public SqlConnection con { get; private set; }
        public DatabaseFixture()
        {
            con = new SqlConnection(Connection.conStr.ConnectionString);
            con.Open();
            SqlCommand cmdAddTestCityZip = new("insert into CityZip values ('test', 'cityzip')", con);
            
            cmdAddTestCityZip.ExecuteNonQuery();
        }
        public void Dispose()
        {
            SqlCommand cmdRemoveTestCityZip = new("delete from CityZip where zipcode = 'test'", con);

            cmdRemoveTestCityZip.ExecuteNonQuery();
            con.Close();
        }
    }
    public class TestDataAccessPerson : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture fixture;

        public TestDataAccessPerson(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        private Member testMember = new Member()
        {
            firstName = "test",
            lastName = "member",
            email = "test@mail.dk",
            phoneNo = "testtest",
            street = "test",
            houseNo = "2",
            zipcode = "test"
        };
        private Employee testEmployee = new Employee()
        {
            firstName = "test",
            lastName = "employee",
            email = "test@mail.dk",
            phoneNo = "testtest",
            street = "test",
            houseNo = "0",
            zipcode = "test"
        };
        private Guest testGuest = new Guest()
    {
            firstName = "test",
            lastName = "guest",
            email = "test@mail.dk",
            phoneNo = "testtest",
            street = "test",
            houseNo = "1",
            zipcode = "test"
        };

        private DataAccessCustomer dataAccess = new();

        [Fact]
        public void TestGetPersonType()
        {
            //Arrange
            DataAccessCustomer dataAccessPerson = new();

            Customer employee = new Employee();
            Customer guest = new Guest();
            Customer member = new Member();
            Customer person = new Customer();

            int expectedEmployee = 0;
            int expectedGuest = 1;
            int expectedMember = 2;
            int expectedPerson = -1;
            //Act
            int actualEmployee = dataAccessPerson.GetPersonType(employee);
            int actualGuest = dataAccessPerson.GetPersonType(guest);
            int actualMember = dataAccessPerson.GetPersonType(member);
            int actualPerson = dataAccessPerson.GetPersonType(person); ;

            //Assert
            Assert.Equal(expectedEmployee, actualEmployee);
            Assert.Equal(expectedGuest, actualGuest);
            Assert.Equal(expectedMember, actualMember);
            Assert.Equal(expectedPerson, actualPerson);
        }
        [Fact]
        public void TestCreateMember()
        {
            //Arrange
            SqlConnection con = fixture.con;
            SqlCommand cmd = new("select * from Person p, _Address a where p.f_name = 'test' and p.l_name = 'member' and p.address_id = a.id", con);
            SqlCommand cleanupPerson = new("delete from Person where f_name = 'test' and l_name = 'member'", con);
            SqlCommand cleanupAddress = new("delete from _Address where street = 'test' and house_no = '2'", con);
            //Act
            dataAccess.Create(testMember);
            SqlDataReader reader = cmd.ExecuteReader();

            //Assert
            Assert.True(reader.Read());
            Assert.True(int.Parse(reader.GetString(5)) == 2);
            Assert.True(reader.GetString(1).Equals("test"));
            Assert.True(reader.GetString(2).Equals("member"));
            Assert.True(reader.GetString(8).Equals("test"));
            Assert.True(reader.GetString(9).Equals("2"));

            //Cleanup
            reader.Close();
            cleanupPerson.ExecuteNonQuery();
            cleanupAddress.ExecuteNonQuery();
        }
        [Fact]
        public void TestCreateEmployee()
        {
            //Arrange
            SqlConnection con = fixture.con;
            SqlCommand cmd = new("select * from Person p, _Address a where p.f_name = 'test' and p.l_name = 'employee' and p.address_id = a.id", con);
            SqlCommand cleanupPerson = new("delete from Person where f_name = 'test' and l_name = 'employee'", con);
            SqlCommand cleanupAddress = new("delete from _Address where street = 'test' and house_no = '0'", con);
            //Act
            dataAccess.Create(testEmployee);
            SqlDataReader reader = cmd.ExecuteReader();

            //Assert
            Assert.True(reader.Read());
            Assert.True(int.Parse(reader.GetString(5)) == 0);
            Assert.True(reader.GetString(1).Equals("test"));
            Assert.True(reader.GetString(2).Equals("employee"));
            Assert.True(reader.GetString(8).Equals("test"));
            Assert.True(reader.GetString(9).Equals("0"));
            
            //Cleanup
            reader.Close();
            cleanupPerson.ExecuteNonQuery();
            cleanupAddress.ExecuteNonQuery();   
        }
        [Fact]
        public void TestCreateGuest()
        {
            //Arrange
            SqlConnection con = fixture.con;
            SqlCommand cmd = new("select * from Person p, _Address a where p.f_name = 'test' and p.l_name = 'guest' and p.address_id = a.id", con);
            SqlCommand cleanupPerson = new("delete from Person where f_name = 'test' and l_name = 'guest'", con);
            SqlCommand cleanupAddress = new("delete from _Address where street = 'test' and house_no = '1'", con);
            //Act
            dataAccess.Create(testGuest);
            SqlDataReader reader = cmd.ExecuteReader();

            //Assert
            Assert.True(reader.Read());
            Assert.True(int.Parse(reader.GetString(5)) == 1);
            Assert.True(reader.GetString(1).Equals("test"));
            Assert.True(reader.GetString(2).Equals("guest"));
            Assert.True(reader.GetString(8).Equals("test"));
            Assert.True(reader.GetString(9).Equals("1"));

            //Cleanup
            reader.Close();
            cleanupPerson.ExecuteNonQuery();
            cleanupAddress.ExecuteNonQuery();
        }
        [Fact]
        public void TestDeleteByIdPerson()
        {
            //Arrange
            SqlConnection con = fixture.con;
            SqlCommand cmdInsertAddress = new("insert into _Address output INSERTED.ID values ('test', '9', 'test')", con);
            SqlCommand cmdInsertPerson = new("insert into Person output INSERTED.ID values ('test', 'delete', 'test@mail.dk', 'testtest', '9', @Id)", con);
            SqlCommand cmdCheckDeletedPerson = new("select * from Person p where p.f_name = 'test' and p.l_name = 'delete'", con);
            SqlCommand cmdCheckDeletedAddress = new("select * from _Address where street = 'test' and house_no = '9'", con);

            //Act
            int addressId = (int)cmdInsertAddress.ExecuteScalar();
            cmdInsertPerson.Parameters.AddWithValue("@Id", addressId);
            int personId = (int)cmdInsertPerson.ExecuteScalar();
            bool deleted = dataAccess.DeleteById(personId);

            SqlDataReader reader = cmdCheckDeletedPerson.ExecuteReader();
            bool personDeleted = !reader.Read();
            reader.Close();
            reader = cmdCheckDeletedAddress.ExecuteReader();
            bool addressDeleted = !reader.Read();
            reader.Close();

            //Assert
            Assert.True(personDeleted && addressDeleted); //Asserts if the person has been deleted
            Assert.True(deleted);
        }

        [Fact]
        public void TestDeleteByIdPersonNotFound()
        {
            //Arrange
            SqlConnection con = fixture.con;
            SqlCommand cmdInsertAddress = new("insert into _Address output INSERTED.ID values ('test', '9', 'test')", con);
            SqlCommand cmdInsertPerson = new("insert into Person output INSERTED.ID values ('test', 'delete', 'test@mail.dk', 'testtest', '9', @Id)", con);
            SqlCommand cmdCheckDeletedPerson = new("select * from Person p where p.f_name = 'test' and p.l_name = 'delete'", con);
            SqlCommand cmdCheckDeletedAddress = new("select * from _Address where street = 'test' and house_no = '9'", con);

            //Act
            int addressId = (int)cmdInsertAddress.ExecuteScalar();
            cmdInsertPerson.Parameters.AddWithValue("@Id", addressId);
            int personId = (int)cmdInsertPerson.ExecuteScalar();
            bool deleted = dataAccess.DeleteById(-1);

            SqlDataReader reader = cmdCheckDeletedPerson.ExecuteReader();
            bool personDeleted = !reader.Read();
            reader.Close();
            reader = cmdCheckDeletedAddress.ExecuteReader();
            bool addressDeleted = !reader.Read();
            reader.Close();

            //Assert
            Assert.False(personDeleted && addressDeleted); //Asserts if the person has been deleted
            Assert.False(deleted);

            //Cleanup
            dataAccess.DeleteById(personId);
        }

        [Fact]
        public void TestGetByIdPerson()
        {
            //Arrange
            SqlConnection con = fixture.con;
            SqlCommand cmdInsertPerson = new("insert into Person output INSERTED.ID values ('test', 'getById', 'test@mail.dk', 'testtest', '2', @Id)", con);
            SqlCommand cmdInsertAddress = new("insert into _Address output INSERTED.ID values ('test', '8', 'test')", con);
            SqlCommand cleanupPerson = new("delete from Person where f_name = 'test' and l_name = 'getById'", con);
            SqlCommand cleanupAddress = new("delete from _Address where id = @AddressId", con);

            //Act
            int addressId = (int)cmdInsertAddress.ExecuteScalar();
            cmdInsertPerson.Parameters.AddWithValue("@Id", addressId);
            cleanupAddress.Parameters.AddWithValue("@AddressId", addressId);
            int personId = (int)cmdInsertPerson.ExecuteScalar();

            Customer person = dataAccess.GetById(personId);

            //Assert
            Assert.Equal("test", person.firstName);
            Assert.Equal("getById", person.lastName);

            //Cleanup
            cleanupPerson.ExecuteNonQuery();
            cleanupAddress.ExecuteNonQuery();
        }

        [Fact]
        public void TestGetByIdPersonNotFound()
        {
            //Arrange
            SqlConnection con = fixture.con;
            SqlCommand cmdInsertPerson = new("insert into Person output INSERTED.ID values ('test', 'getByIdNotFound', 'test@mail.dk', 'testtest', '2', @Id)", con);
            SqlCommand cmdInsertAddress = new("insert into _Address output INSERTED.ID values ('test', '8', 'test')", con);
            SqlCommand cleanupPerson = new("delete from Person where f_name = 'test' and l_name = 'getByIdNotFound'", con);
            SqlCommand cleanupAddress = new("delete from _Address where id = @AddressId", con);

            //Act
            int addressId = (int)cmdInsertAddress.ExecuteScalar();
            cmdInsertPerson.Parameters.AddWithValue("@Id", addressId);
            cleanupAddress.Parameters.AddWithValue("@AddressId", addressId);
            int personId = (int)cmdInsertPerson.ExecuteScalar();

            Customer person = dataAccess.GetById(-1);

            //Assert
            Assert.Null(person);

            //Cleanup
            cleanupPerson.ExecuteNonQuery();
            cleanupAddress.ExecuteNonQuery();
        }

        [Fact]
        public void TestGetAllPerson()
        {
            //Arrange
            SqlConnection con = fixture.con;
            SqlCommand cmdInsertPerson = new("insert into Person output INSERTED.ID values ('test', 'getAll', 'test@mail.dk', 'testtest', @PersonType, @Id)", con);
            SqlCommand cmdInsertAddress = new("insert into _Address output INSERTED.ID values ('test', '7', 'test')", con);
            SqlCommand cleanupPerson = new("delete from Person where f_name = 'test' and l_name = 'getAll'", con);
            SqlCommand cleanupAddress = new("delete from _Address where id = @AddressId", con);

            //Act
            int addressId = (int)cmdInsertAddress.ExecuteScalar();
            cleanupAddress.Parameters.AddWithValue("@AddressId", addressId);
            for (int i = 0; i <= 2; i++)
            {
                cmdInsertPerson.Parameters.Clear();
                cmdInsertPerson.Parameters.AddWithValue("@Id", addressId);
                cmdInsertPerson.Parameters.AddWithValue("@PersonType", i);
                cmdInsertPerson.ExecuteNonQuery();
            }

            List<Customer> persons = dataAccess.GetAll().ToList();

            //Assert
            Assert.True(persons.Where(person => person.lastName == "getAll").Count() == 3);

            //Cleanup
            cleanupPerson.ExecuteNonQuery();
            cleanupAddress.ExecuteNonQuery();
        }
        [Fact]
        public void TestUpdatePerson()
        {
            //Arrange
            SqlConnection con = fixture.con;
            SqlCommand cmdInsertPerson = new("insert into Person output INSERTED.ID values ('test', 'update', 'test@mail.dk', 'testtest', '2', @Id)", con);
            SqlCommand cmdInsertAddress = new("insert into _Address output INSERTED.ID values ('test', '6', 'test')", con);
            SqlCommand cleanupPerson = new("delete from Person where id = @Id", con);
            SqlCommand cleanupAddress = new("delete from _Address where id = @AddressId", con);

            //Act
            int addressId = (int)cmdInsertAddress.ExecuteScalar();
            cleanupAddress.Parameters.AddWithValue("@AddressId", addressId);
            cmdInsertPerson.Parameters.AddWithValue("@Id", addressId);
            int personId = (int)cmdInsertPerson.ExecuteScalar();
            cleanupPerson.Parameters.AddWithValue("@Id", personId);

            Customer person = new Member() 
            {
                id = personId, 
                firstName = "test", 
                lastName = "updated", 
                email = "test@mail.dk", 
                phoneNo = "testtest", 
                street = "test", 
                houseNo = "6", 
                zipcode = "test" 
            };
            dataAccess.Update(person);
            Customer updatedPerson = dataAccess.GetById(personId);

            //Assert
            Assert.True(updatedPerson != null, "Couldn't find person");
            Assert.False(updatedPerson.firstName == "update", "Person was not updated");

            //Cleanup
            cleanupPerson.ExecuteNonQuery();
            cleanupAddress.ExecuteNonQuery();
        }
    }
}
