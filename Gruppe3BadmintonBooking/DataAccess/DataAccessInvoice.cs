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
    public class DataAccessInvoice : IDaoInvoice
    {
        private SqlConnectionStringBuilder conStr;

        public DataAccessInvoice()
        {
            conStr = Connection.conStr;
        }

        public int Create(Invoice entity)
        {
            SqlConnection con = new(conStr.ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Invoice output INSERTED.ID VALUES (@totalPrice, @reservationId) ";
            cmd.Parameters.AddWithValue("totalPrice", entity.totalPrice);
            cmd.Parameters.AddWithValue("reservationId", entity.reservation.Id);


            int createdId = (int) cmd.ExecuteScalar();

            return createdId;
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
            SqlConnection con = new(conStr.ConnectionString);
            con.Open();

            List<Invoice> list = null;

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT Invoice.total_price, Reservation.start_time, Reservation.end_time, Reservation.shuttle_reserved, Court.court_no, Customer.f_name, Reservation.id, Customer.id, Invoice.id " +
                              "FROM Invoice, Reservation, Court, Customer WHERE Invoice.reservation_id = Reservation.id " +
                              "AND Reservation.court_court_no = Court.court_no AND Reservation.customer_id = Customer.id"; // AND Reservation.employee_id = Person.id";
            SqlDataReader reader = cmd.ExecuteReader();

            list = BuildObjects(reader);
            con.Close();

            return list;
        }
        public Invoice GetById(int id)
        {
            Invoice invoice = null;

            SqlConnection con = new(conStr.ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT Invoice.total_price, Reservation.start_time, Reservation.end_time, Reservation.shuttle_reserved, Court.court_no, Customer.f_name, Reservation.id, Customer.id, Invoice.id " +
                              "FROM Invoice, Reservation, Court, Customer WHERE Invoice.reservation_id = Reservation.id " +
                              "AND Reservation.court_court_no = Court.court_no AND Reservation.customer_id = Customer.id and invoice.id = @Id"; // AND Reservation.employee_id = Person.id";
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read()) invoice = BuildObject(reader); 
            
            return invoice;
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

        private List<Invoice>? BuildObjects(SqlDataReader reader)
        {
            List<Invoice> invoices = new();
            try
            {
                while (reader.Read())
                {
                    Invoice invoice = BuildObject(reader);
                    invoices.Add(invoice);
                }
            }
            catch (SqlException)
            {
                //TODO Handle exception
                throw;
            }
            return invoices;
        }

        private Invoice BuildObject(SqlDataReader reader)
        {
            Invoice invoice = null;

            try
            {
                invoice = new()
                {
                    id = reader.GetInt32(8),
                    totalPrice = reader.GetDecimal(0),


                    reservation = new Reservation()
                    {
                        Id = reader.GetInt32(6),
                        startTime = reader.GetDateTime(1),
                        endTime = reader.GetDateTime(2),
                        shuttleReserved = reader.GetBoolean(3),

                        court = new Court()
                        {
                            id = reader.GetInt32(4),
                        },

                        customer = new Customer()
                        {
                            id = reader.GetInt32(7),
                            firstName = reader.GetString(5),
                        }
                    }
                };
            }
            catch (Exception)
            {
                // TODO Handle exception
            }
            return invoice;
        }
    }
}

