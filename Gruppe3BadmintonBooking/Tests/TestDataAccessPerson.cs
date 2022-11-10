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
    public class TestDataAccessPerson
    {
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

        private DataAccessPerson dataAccess = new();

        [Fact]
        public void TestGetPersonType()
        {
            //Arrange
            DataAccessPerson dataAccessPerson = new();

            Person employee = new Employee();
            Person guest = new Guest();
            Person member = new Member();
            Person person = new Person();

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
            SqlConnection con = new(Connection.conStr.ConnectionString);
            SqlCommand cmd = new("select * from Person p, _Address a where p.f_name = 'test' and p.l_name = 'member' and p.address_id = a.id", con);
            SqlCommand cleanupPerson = new("delete from Person where f_name = 'test' and l_name = 'member'", con);
            SqlCommand cleanupAddress = new("delete from _Address where street = 'test' and house_no = '2'", con);
            //Act
            dataAccess.Create(testMember);
            con.Open();
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
            con.Close();
        }
        [Fact]
        public void TestCreateEmployee()
        {
            //Arrange
            SqlConnection con = new(Connection.conStr.ConnectionString);
            SqlCommand cmd = new("select * from Person p, _Address a where p.f_name = 'test' and p.l_name = 'employee' and p.address_id = a.id", con);
            SqlCommand cleanupPerson = new("delete from Person where f_name = 'test' and l_name = 'employee'", con);
            SqlCommand cleanupAddress = new("delete from _Address where street = 'test' and house_no = '0'", con);
            //Act
            dataAccess.Create(testEmployee);
            con.Open();
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
            con.Close();
        }
        [Fact]
        public void TestCreateGuest()
        {
            //Arrange
            SqlConnection con = new(Connection.conStr.ConnectionString);
            SqlCommand cmd = new("select * from Person p, _Address a where p.f_name = 'test' and p.l_name = 'guest' and p.address_id = a.id", con);
            SqlCommand cleanupPerson = new("delete from Person where f_name = 'test' and l_name = 'guest'", con);
            SqlCommand cleanupAddress = new("delete from _Address where street = 'test' and house_no = '1'", con);
            //Act
            dataAccess.Create(testGuest);
            con.Open();
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
            con.Close();
        }
        [Fact]
        public void TestDeleteByIdPerson()
        {
            //Arrange
            SqlConnection con = new(Connection.conStr.ConnectionString);
            SqlCommand cmdInsertAddress = new("insert into _Address output INSERTED.ID values ('test', '-1', 'test')", con);
            SqlCommand cmdInsertPerson = new("insert into Person output INSERTED.ID values ('test', 'delete', 'test@mail.dk', 'testtest', '-1', @Id)", con);
            SqlCommand cmdCheckDeletedPerson = new("select * from Person p where p.f_name = 'test' and p.l_name = 'delete", con);
            SqlCommand cmdCheckDeletedAddress = new("select * from _Address where street = 'test' and house_no = '-1'", con);

            //Act
            con.Open();
            int addressId = (int) cmdInsertAddress.ExecuteScalar();
            cmdInsertPerson.Parameters.AddWithValue("@Id", addressId);
            int personId = (int) cmdInsertPerson.ExecuteScalar();
            dataAccess.DeleteById(personId);

            SqlDataReader reader = cmdCheckDeletedPerson.ExecuteReader();
            bool personDeleted = !reader.Read();
            reader.Close();
            reader = cmdCheckDeletedAddress.ExecuteReader();
            bool addressDeleted = !reader.Read();

            //Assert
            Assert.True(personDeleted && addressDeleted); //Asserts if the person has been deleted
        }
    }
}
