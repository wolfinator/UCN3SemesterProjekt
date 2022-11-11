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
    public class TestDataAccessInvoice
    {
        [Fact]
        public void TestCreateInvoice()
        {
            //Arrange
            DataAccessInvoice dataAccessInvoice = new();
            //Invoice invoice = new() { totalPrice = 200, courtNo = 5, dateTime = DateTime.Now,orderNo = 1001,  
                                      //name = "Karen Blixen", phoneNo = "302229982", employee = new Employee(), reservation = new Reservation()};
         
            SqlConnection con = new(Connection.conStr.ConnectionString);
            //SqlCommand cmd = new(select * from Invoice);

            //Act
           // dataAccessInvoice.Create(invoice);
            

            //Assert

            //todo
        }
        [Fact]
        public void TestGetPersonId()
        {
            //todo
        }

        public void getReservationId()
        {
            //todo
        }

    }
}
