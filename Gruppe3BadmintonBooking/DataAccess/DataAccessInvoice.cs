using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

        public bool Create(Invoice entity)
        {
            SqlConnection con = new(conStr.ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Invoice VALUES (@totalPrice, @reservationId)";
            cmd.Parameters.AddWithValue("totalPrice", entity.totalPrice);
            cmd.Parameters.AddWithValue("reservationId", entity.reservation.Id);


            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }

        public bool DeleteById(int id)
        {
            SqlConnection con = new(conStr.ConnectionString);

            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Invoice WHERE Id = @id";
            cmd.Parameters.AddWithValue("id", @id);

            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;
        }


        public IEnumerable<Invoice> GetAll()
        {
            throw new NotImplementedException();


            SqlConnection con = new(conStr.ConnectionString);
            con.Open();

            List<Invoice> list = new List<Invoice>();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT Invoice.total_price, Reservation.start_time, Reservation.end_time, Reservation.shuttle_reserved, Court.id, Customer.f_name" +
                              " FROM Invoice, Reservation, Court, Customer WHERE Invoice.reservation_id = Reservation.id " +
                              "AND Reservation.court_id = Court.id AND Reservation.customer_id = Customer.id"; // AND Reservation.employee_id = Person.id";
            SqlDataReader reader = cmd.ExecuteReader();



            while (reader.Read())
            {
                Invoice invoice = new()
                {
                    totalPrice = reader.GetDecimal(0),


                    reservation = new Reservation()
                    {
                        startTime = reader.GetDateTime(1),
                        endTime = reader.GetDateTime(2),
                        shuttleReserved = reader.GetBoolean(3),


                        court = new Court()
                        {
                            id = reader.GetInt32(4),
                        },

                        customer = new Customer()
                        {
                            firstName = reader.GetString(5),
                        }
                    }
                };


                list.Add(invoice);
            }


            con.Close();

            return list;
        }
        public Invoice GetById(int id)
        {
            SqlConnection con = new(conStr.ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT Invoice.total_price, Reservation.start_time, Reservation.end_time, Reservation.shuttle_reserved, Court.id, Customer.f_name" +
                              " FROM Invoice, Reservation, Court, Customer WHERE Invoice.id = @id";
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Invoice invoice = new()
                {
                    totalPrice = reader.GetDecimal(0),


                    reservation = new Reservation()
                    {
                        startTime = reader.GetDateTime(1),
                        endTime= reader.GetDateTime(2),
                        shuttleReserved = reader.GetBoolean(3),

                        court = new Court()
                        {
                            id = reader.GetInt32(4),
                        },

                        customer = new Customer()
                        {
                            firstName = reader.GetString(5),
                        }
                    }
                };
                return invoice;
            }
            return null;
        }

        public bool Update(Invoice entity)
        {
            SqlConnection con = new(conStr.ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Invoice SET total_price = @totalPrice WHERE Id = @id";
            cmd.Parameters.AddWithValue("total_price", entity.totalPrice);
            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected == 1;

        }
    }
}

