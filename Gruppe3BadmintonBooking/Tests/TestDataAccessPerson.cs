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
            Person employee = new Employee();
            Person guest = new Guest();
            Person member = new Member();
            Person person = new Person();

            int expectedEmployee = 0;
            //Act

            //Assert
            
        }
    }
}
