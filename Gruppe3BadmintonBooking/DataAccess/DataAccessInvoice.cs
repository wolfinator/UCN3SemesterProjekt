<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿using Microsoft.Data.SqlClient;
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

            return rowsAffected == 1 ;
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

                        SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT Invoice.total_price, Reservation.date_time, Reservation.is_equipment, Reservation.from_time, Court.id, Court.hall_no, Person.f_name" +
                              " FROM Invoice, Reservation, Court, Person WHERE Invoice.reservation_id = Reservation.id " +
                              "AND Reservation.court_id = Court.id AND Reservation.customer_id = Person.id AND Reservation.employee_id = Person.id";

                        SqlDataReader reader = cmd.ExecuteReader();
         
                        List<Invoice> list = new List<Invoice>();

            while (reader.Read())
            {
                Invoice invoice = new()
                {
                    totalPrice = reader.GetDecimal(0),


                    reservation = new Reservation()
                    {
                        dateTime = reader.GetDateTime(1),
                        isEquipment = reader.GetBoolean(2),
                        //Todo get fromtime Fra reservation
                       // fromTime = reader.GetTimeSpan(3).



                        court = new Court()
                        {
                            id = reader.GetInt32(4),
                            hallNo = reader.GetInt32(5),
                        },

                        customer = new Person()
                        {
                            firstName = reader.GetString(6),
            }
                    }
                };


                list.Add(invoice);
            }

            con.Close();

                return list;
        }

           
           
            SqlConnection con = new(conStr.ConnectionString);

        public Invoice? GetById(int id)
            {
            SqlConnection con = new(conStr.ConnectionString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT Invoice.total_price, Reservation.date_time, Reservation.is_equipment, Reservation.from_time, Court.id, Court.hall_no, Person.f_name" +
                              " FROM Invoice, Reservation, Court, Person WHERE Invoice.id = @id";
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Invoice invoice = new()
            {
                    totalPrice = reader.GetDecimal(0),

            con.Close();

                    reservation = new Reservation()
                    {
                        dateTime = reader.GetDateTime(1),
                        isEquipment = reader.GetBoolean(2),
                        //Todo get fromtime Fra reservation
                        // fromTime = reader.GetTimeSpan(3).
         

        }

                        court = new Court()
        {
                            id = reader.GetInt32(4),
                            hallNo = reader.GetInt32(5),
                        },

                        customer = new Person()
        {
                            firstName = reader.GetString(6),
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
=======
﻿using Microsoft.Data.SqlClient;
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
>>>>>>> DataaccessInvoice mangler lidt crud,, og test for invoice påbegyndt
=======
﻿using Microsoft.Data.SqlClient;
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
>>>>>>> Update DataAccessInvoice.cs
=======
﻿using Microsoft.Data.SqlClient;
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
>>>>>>> DataaccessInvoice mangler lidt crud,, og test for invoice påbegyndt
=======
﻿using Microsoft.Data.SqlClient;
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
>>>>>>> Update DataAccessInvoice.cs
=======
﻿using Microsoft.Data.SqlClient;
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

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT Invoice.total_price, Reservation.date_time, Reservation.is_equipment, Reservation.from_time, Court.id, Court.hall_no, Person.f_name" +
                              " FROM Invoice, Reservation, Court, Person WHERE Invoice.reservation_id = Reservation.id " +
                              "AND Reservation.court_id = Court.id AND Reservation.customer_id = Person.id AND Reservation.employee_id = Person.id";

            SqlDataReader reader = cmd.ExecuteReader();

            List<Invoice> list = new List<Invoice>();

            while (reader.Read())
            {
                Invoice invoice = new()
                {
                    totalPrice = reader.GetDecimal(0),


                    reservation = new Reservation()
                    {
                        dateTime = reader.GetDateTime(1),
                        isEquipment = reader.GetBoolean(2),
                        //Todo get fromtime Fra reservation
                        // fromTime = reader.GetTimeSpan(3).



                        court = new Court()
                        {
                            id = reader.GetInt32(4),
                            hallNo = reader.GetInt32(5),
                        },

                        customer = new Person()
                        {
                            firstName = reader.GetString(6),
                        }
                    }
                };


                list.Add(invoice);
            }

            con.Close();

            return list;
        }




        public Invoice? GetById(int id)
        {
            SqlConnection con = new(conStr.ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT Invoice.total_price, Reservation.date_time, Reservation.is_equipment, Reservation.from_time, Court.id, Court.hall_no, Person.f_name" +
                              " FROM Invoice, Reservation, Court, Person WHERE Invoice.id = @id";
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Invoice invoice = new()
                {
                    totalPrice = reader.GetDecimal(0),


                    reservation = new Reservation()
                    {
                        dateTime = reader.GetDateTime(1),
                        isEquipment = reader.GetBoolean(2),
                        //Todo get fromtime Fra reservation
                        // fromTime = reader.GetTimeSpan(3).



                        court = new Court()
                        {
                            id = reader.GetInt32(4),
                            hallNo = reader.GetInt32(5),
                        },

                        customer = new Person()
                        {
                            firstName = reader.GetString(6),
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
>>>>>>> copied dataaccessinvoice
