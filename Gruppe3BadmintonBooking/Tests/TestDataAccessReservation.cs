using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Model;

namespace Tests
{
    public class TestDataAccessReservation
    {
        private SqlConnectionStringBuilder conStr;

        public void TestCreateReservation()
        {
            //Arrange
            TestDataAccessReservation dataAccessReservation = new();
            Reservation reservation = new()
            {
                dateTime = DateTime.Now,
                courtNo = 1,
                isEquipment = true,

                //customer = new Person(),
                //employee = new Employee(),

            };
            SqlConnection con = new(conStr.ConnectionString);
            SqlCommand cmdTest = new("select * from Reservation where id");


            //string cmdTextReservationTest = "insert into Reservation(date_time, is_equipment, court_id) " +
            //                                "values (@DateTime, @IsEquipment, @CourtId)";
            //SqlCommand cmdReservationTest = new(cmdTextReservationTest, con);
            //cmdReservationTest.Parameters.AddWithValue("@DateTime", reservation.dateTime);
            //cmdReservationTest.Parameters.AddWithValue("@IsEquipment", reservation.isEquipment);
            //cmdReservationTest.Parameters.AddWithValue("@CourtId", reservation.courtNo);


            //Act
            

            con.Open();

            try
            {
                cmdTest.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw new NotImplementedException(); //TODO SKRIV throw ting
            }
            //Assert

        }

        public void TestDeleteById()
        {

        }

        public void TestGetAll()
        {

        }

        public void TestGetById()
        {

        }

        public void TestUpdate()
        {

        }
    }
}
