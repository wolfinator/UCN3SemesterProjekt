using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Model;

namespace DataAccess
{
    public class DataAccessReservation : IDaoReservation
    {
        private SqlConnectionStringBuilder conStr;
        private IDaoCrud<Customer> _customerDao;
        private IDaoCrud<Invoice> _invoiceDao;
        public DataAccessReservation()
        {
            conStr = DbConnection.conStr;
            _customerDao = new DataAccessCustomer();
            _invoiceDao = new DataAccessInvoice();
        }
        public int Create(Reservation reservation)
        {
            int reservationId = -1;
            string cmdTextCreate = "insert into Reservation(creation_date, start_time, end_time, shuttle_reserved, number_of_rackets, court_court_no, customer_id) output INSERTED.ID " +
                                            "values (@CreationTime, @StartTime, @EndTime, @ShuttleReserved, @NumberOfRackets, @CourtId, @CustomerId)";
            using (SqlConnection con = new(conStr.ConnectionString))
            { 
                SqlCommand cmdReservation = new(cmdTextCreate, con);
                cmdReservation.Parameters.AddWithValue("@CreationTime", reservation.creationDate);
                cmdReservation.Parameters.AddWithValue("@StartTime", reservation.startTime);
                cmdReservation.Parameters.AddWithValue("@EndTime", reservation.endTime);
                cmdReservation.Parameters.AddWithValue("@ShuttleReserved", reservation.shuttleReserved);
                cmdReservation.Parameters.AddWithValue("@NumberOfRackets", reservation.numberOfRackets);
                cmdReservation.Parameters.AddWithValue("@CourtId", reservation.courtNo);
                cmdReservation.Parameters.AddWithValue("@CustomerId", reservation.customer.id);
                //cmdReservation.Parameters.AddWithValue("@EmployeeId", reservation.employee.id);
                
                try
                {
                    con.Open();
                    reservationId = (int) cmdReservation.ExecuteScalar();
                }
                catch (SqlException)
                {
                    throw; //TODO SKRIV throw ting
                }
            }
            return reservationId;
        }

        public bool DeleteById(int id)
        {
            bool deleted = false;
            using (SqlConnection con = new(conStr.ConnectionString))
            {
                string cmdTextDeleteReservation = "delete from Reservation where id = @Id";
                SqlCommand cmdDeleteReservation = new(cmdTextDeleteReservation, con);
                cmdDeleteReservation.Parameters.AddWithValue("@Id", id);

                con.Open();
                try
                {
                    deleted = cmdDeleteReservation.ExecuteNonQuery() == 1;
                }
                catch (SqlException ex)
                {
                    throw; //TODO SKRIV throw ting
                }
            }
            return deleted;
        }

        public IEnumerable<Reservation> GetAll()
        {
            string cmdTextGetAll = "select * from Reservation";
            IEnumerable<Reservation> list = null;
            using (SqlConnection con = new(conStr.ConnectionString))
            {
                SqlCommand cmdGetAll = new(cmdTextGetAll, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmdGetAll.ExecuteReader();
                    list = BuildObjects(reader);
                    reader.Close();
                }
                catch (Exception)
                {
                    // Todo Handle Exception
                    throw;
                }
            }
            return list;
        }

        public IEnumerable<Reservation> GetAllByDate()
        {
            string cmdTextGetByDate = "select * from Reservation where";
            IEnumerable<Reservation> list = null;
                return null;
        }

        public Reservation GetById(int id)
        {
            string cmdTextGetById = "select * from Reservation where id = @Id";
            Reservation reservation = null;
            using (SqlConnection con = new(conStr.ConnectionString))
            {
                SqlCommand cmdGetById = new(cmdTextGetById, con);
                cmdGetById.Parameters.AddWithValue("@Id", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmdGetById.ExecuteReader();
                    if (reader.Read())
                    {
                        reservation = BuildObject(reader);
                    }
                }
                catch
                {
                    throw;
                }
            }
            return reservation;
        }

        public bool Update(Reservation reservation)
        {
            bool updated = false;
            string cmdTextUpdate = "update Reservation set " +
                "creation_date = @CreationDate, " +
                "start_time = @StartTime, " +
                "end_time = @EndTime, " +
                "shuttle_reserved = @ShuttleReserved, " +
                "number_of_rackets = @NumberOfRackets, " +
                "customer_id = @CustomerId, " +
                "court_court_no = @CourtId " +
                "where id = @Id";
            using (SqlConnection con = new(conStr.ConnectionString))
            {
                SqlCommand cmdUpdate = new(cmdTextUpdate, con);
                cmdUpdate.Parameters.AddWithValue("@CreationDate", reservation.creationDate);
                cmdUpdate.Parameters.AddWithValue("@StartTime", reservation.startTime);
                cmdUpdate.Parameters.AddWithValue("@EndTime", reservation.endTime);
                cmdUpdate.Parameters.AddWithValue("@ShuttleReserved", reservation.shuttleReserved ? 1 : 0);
                cmdUpdate.Parameters.AddWithValue("@NumberOfRackets", reservation.numberOfRackets);
                cmdUpdate.Parameters.AddWithValue("@CustomerId", reservation.customer.id);
                cmdUpdate.Parameters.AddWithValue("@CourtId", reservation.courtNo);
                
                //cmdUpdate.Parameters.AddWithValue("@EmployeeId", reservation.employee.id);

                cmdUpdate.Parameters.AddWithValue("@Id", reservation.id);

                try
                {
                    con.Open();
                    updated = cmdUpdate.ExecuteNonQuery() == 1;
                }
                catch (SqlException)
                {
                    throw; //TODO SKRIV throw ting
                }
            }
            return updated;
        }

        private IEnumerable<Reservation> BuildObjects(SqlDataReader reader)
        {
            List<Reservation> reservations = null;
            try
            {
                reservations = new();
                while (reader.Read())
                {
                    Reservation reservation = BuildObject(reader);
                    reservations.Add(reservation);
                }
            }
            catch (SqlException)
            {
                // TODO Handle exception
                throw;
            }
            return reservations;
        }

        private Reservation BuildObject(SqlDataReader reader)
        {
            Reservation reservation = new();
            reservation.id = reader.GetInt32(0);
            reservation.creationDate = reader.GetDateTime(1);
            reservation.startTime = reader.GetDateTime(2);
            reservation.endTime = reader.GetDateTime(3);
            reservation.shuttleReserved = reader.GetBoolean(4);
            reservation.numberOfRackets = reader.GetInt32(5);
            //reservation.court = new Court() { id = reader.GetInt32(6) };
            reservation.courtNo = reader.GetInt32(6);
            reservation.customer = _customerDao.GetById(reader.GetInt32(7));
            
            return reservation;
        }

        public bool DeleteAllByCustomerId(int customerId)
        {
            bool deleted = false;
            using (SqlConnection con = new(conStr.ConnectionString))
            {
                string cmdTextDeleteReservation = "delete from Reservation where customer_id = @CustomerId";
                SqlCommand cmdDeleteReservation = new(cmdTextDeleteReservation, con);
                cmdDeleteReservation.Parameters.AddWithValue("@CustomerId", customerId);

                con.Open();
                try
                {
                    deleted = cmdDeleteReservation.ExecuteNonQuery() == 1;
                }
                catch (SqlException ex)
                {
                    
                    throw; //TODO SKRIV throw ting
                }
            }
            return deleted;
        }

        public List<object[]> GetAvailableTimes(DateTime date)
        {
            List<object[]> list = new();

            using (SqlConnection con = new(DbConnection.conStr.ConnectionString))
            {
                string cmdText = "select c.court_no, t.time_slot from Court c, timeslot t except(select c.court_no, t.time_slot from Court c, timeslot t, reservation r where @current_date < r.start_time and r.end_time < @current_date+1 and c.court_no = r.court_court_no and cast(r.start_time as time) = t.time_slot )";
                SqlCommand cmdAvailableTimes = new(cmdText, con);
                cmdAvailableTimes.Parameters.AddWithValue("@current_date", date);

                con.Open();
                SqlDataReader reader = cmdAvailableTimes.ExecuteReader();
                while (reader.Read())
                {
                    object[] availableTime = { reader.GetInt32(0), reader.GetTimeSpan(1) };
                    list.Add(availableTime);
                }
            }
            
            return list;
        }

        public IEnumerable<Reservation> GetAllByPhoneNo(string phoneNo)
        {
            IEnumerable<Reservation> reservations = null;
            SqlConnection con = new(DbConnection.conStr.ConnectionString);

            string cmdText = "select r.id, r.creation_date, r.start_time, r.end_time, " +
                "r.shuttle_reserved, r.number_of_rackets, r.court_court_no, r.customer_id " +
                "from Reservation r, Customer c " +
                "where c.phone_no = @PhoneNo " +
                "and r.customer_id = c.id";
            SqlCommand cmdGetAllByPhoneNo = new(cmdText, con);

            cmdGetAllByPhoneNo.Parameters.AddWithValue("@PhoneNo", phoneNo);
            
            try
            {
                con.Open();
                SqlDataReader reader = cmdGetAllByPhoneNo.ExecuteReader();
                reservations = BuildObjects(reader);
            }
            catch (Exception)
            {
                //Todo handle exception
                throw;
            }
            finally
            {
                con.Close();
            }          
            return reservations;
        }
    }
}
