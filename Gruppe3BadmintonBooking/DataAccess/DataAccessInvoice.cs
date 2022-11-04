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
           bool isSuccesfull = false;

            SqlConnection con = new(conStr.ConnectionString);

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "DELETE FROM Invoice WHERE Id = @id";
                string sql = "DELETE FROM invoice WHERE id = @id";

                SqlCommand cmd = new SqlCommand(sql, con);
                //Passing the value using cmd
                cmd.Parameters.AddWithValue("@id", id);

                //Open sql Connection
                con.Open();

               int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then the value of rows will be greater than zero
                //else it will be less than 0
                if(rows > 0)
                {
                    //Query Executed Successfully
                    isSuccesfull = true;
                } 
                else
                {
                    //Faied to Execute Query
                    isSuccesfull = false;
                }
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
        }

        public Invoice GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Invoice entity)
        {
            throw new NotImplementedException();
        }
    }
}
