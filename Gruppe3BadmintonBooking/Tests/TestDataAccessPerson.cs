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
            DataAccessPerson dataAccessPerson = new();
            Person member = new Member() {firstName = "test", lastName = "Wazowski", email = "wazowski@mail.dk", phoneNo = "12345678", street = "Mike Wazowskis Vej", houseNo = "45", zipcode = "9220"};

            SqlConnection con = new(Connection.conStr.ConnectionString);
            SqlCommand cmd = new("select * from Person where f_name = 'test' and email = 'wazowski@mail.dk'", con);
            SqlCommand cleanup = new("delete from Person where f_name = 'test' and email = 'wazowski@mail.dk'", con);
            //Act
            dataAccessPerson.Create(member);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            //Assert
            Assert.True(reader.Read());

            //Cleanup
            reader.Close();
            cleanup.ExecuteNonQuery();
            con.Close();
        }
    }
}
