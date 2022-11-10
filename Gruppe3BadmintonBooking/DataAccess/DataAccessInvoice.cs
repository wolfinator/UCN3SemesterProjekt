using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessInvoice : IDataAccess<Invoice>
    {
        private SqlConnectionStringBuilder conStr;

        public DataAccessInvoice()
        {
            conStr = Connection.conStr;
        }

        public void Create(Invoice entity)
        {
            SqlConnection con = new(conStr.ConnectionString);

            string cmdTextInvoice = "insert into Invoice(total_price, person_id, reservation_id) " +
                                     "values (@TotalPrice, @PersonId, @ReservationId) ";

            SqlCommand cmdInvoice = new(cmdTextInvoice, con);

            cmdInvoice.Parameters.AddWithValue("@totalPrice", entity.totalPrice);
            cmdInvoice.Parameters.AddWithValue("@PersonId", entity.employee.id);
            cmdInvoice.Parameters.AddWithValue("@ReservationId", entity.reservation);


            con.Open();
            try
            {
                cmdInvoice.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
                //TODO Skriv hvad der skal kastes
            }
            con.Close();


        }

        public bool DeleteById(int id)
        {
            bool isSuccess = false;

            SqlConnection con = new(conStr.ConnectionString);

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Invoice WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                int rows = cmd.ExecuteNonQuery();
                //If the query is executd successfully then the value of rows will be greater than zero else it will be less than 0

                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }

            }
            catch (SqlException)
            {
                //Faied to Execute Query
                isSuccess = false;

            }

            con.Close();

            return isSuccess;
        }


        public IEnumerable<Invoice> GetAll()
        {
            throw new NotImplementedException();

                      SqlConnection con = new(conStr.ConnectionString);
                        con.Open();

                        SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT Invoice.total_price, Reservation.date_time, Reservation.is_equipment, Reservation.from_time, Court.id, Court.hall_no, Person.f_name" +
                              " FROM Invoice, Reservation, Court, Person WHERE Invoice.reservation_id = Reservation.id AND Reservation.court_id = Court.id AND Reservation.person_id = Person.id";

                        SqlDataReader reader = cmd.ExecuteReader();

                        List<Invoice> list = new List<Invoice>();

                        while (reader.Read())
                        {
                            Invoice invoice = new()
                            {   
                             
                            }

                          

        }


        public Invoice GetById(int id)
        {



            throw new NotImplementedException();
        }


        public bool Update(Invoice entity)
        {
            SqlConnection con = new(conStr.ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Invoice SET totalPrice = @TotalPrice WHERE Id = @id";


            throw new NotImplementedException();

                return true;
        }
    }
}
