using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Tests
{
    
    public class TestDataAccess
    {
        /// <summary>
        /// Test to connect to the database
        /// </summary>
        [Fact]
        public void TestConnectToDatabase()
        {
            //Arrange
            SqlConnectionStringBuilder conStr = new();
            conStr.DataSource = "hildur.ucn.dk";
            conStr.InitialCatalog = "DMA-CSD-S212_10407522";
            conStr.Encrypt = false;
            conStr.UserID = "DMA-CSD-S212_10407522";
            conStr.Password = "Password1!";

            int expected = 1;

            SqlConnection con = new(conStr.ConnectionString);
            SqlCommand cmd = new SqlCommand("select 1", con);
            //Act
            con.Open();
            int actual = (int) cmd.ExecuteScalar();
            con.Close();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
