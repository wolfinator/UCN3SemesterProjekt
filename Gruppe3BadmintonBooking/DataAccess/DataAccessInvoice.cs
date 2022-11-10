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

        public void DeleteById(int id)
        {

            SqlConnection con = new(conStr.ConnectionString);

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Invoice WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                int rows = cmd.ExecuteNonQuery();

            }
            catch (SqlException)
            {
                throw;
            }

            con.Close();

        }


        public IEnumerable<Invoice> GetAll()
        {
            throw new NotImplementedException();

            /*            SqlConnection con = new(conStr.ConnectionString);
                        con.Open();

                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT * FROM Invoice I, Person P, Reservation R WHERE I.person_id = " +
                                            "p.id AND I.reservation_id = R.id\n";

                        SqlDataReader reader = cmd.ExecuteReader();

                        List<Invoice> list = new List<Invoice>();

                        while (reader.Read())
                        {
                            Invoice invoice = new()

                            {
                                id = reader.GetInt32(0),
                                totalPrice = reader.GetDecimal(1),

                                employee = new Employee()
                                {
                                    id = reader.GetInt32(3),
                                    firstName = reader.GetString(5)
                                }

                                reservation = new Reservation()
                                {
                                    id = reader.GetInt32(2),
                                    dateTime = reader.GetDateTime(12),

                            }
                        } */

        }


        public Invoice GetById(int id)
        {
          


            throw new NotImplementedException();
        }


        public void Update(Invoice entity)
        {
            SqlConnection con = new(conStr.ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Invoice SET totalPrice = @TotalPrice WHERE Id = @id";


            throw new NotImplementedException();
        }
    }
}
