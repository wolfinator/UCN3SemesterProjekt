using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Model;

namespace DataAccess
{
    public class DataAccessReservation : IDataAccess<Reservation>
    {
        private SqlConnectionStringBuilder conStr;
        public DataAccessReservation()
        {
            conStr = Connection.conStr;
        }
        public bool Create(Reservation reservation)
        {
            bool created = false;
            string cmdTextCreate = "insert into Reservation(creation_date, start_time, end_time, shuttle_reserved, number_of_rackets, court_court_no, customer_id) " +
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

                con.Open();
                try
                {
                    created = cmdReservation.ExecuteNonQuery() == 1;
                }
                catch (SqlException)
                {
                    throw; //TODO SKRIV throw ting
                }
            }
            return created;
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
                }
                catch (SqlException)
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

                cmdUpdate.Parameters.AddWithValue("@Id", reservation.Id);

                con.Open();
                try
                {
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
            reservation.Id = reader.GetInt32(0);
            reservation.creationDate = reader.GetDateTime(1);
            reservation.startTime = reader.GetDateTime(2);
            reservation.endTime = reader.GetDateTime(3);
            reservation.shuttleReserved = reader.GetBoolean(4);
            reservation.numberOfRackets = reader.GetInt32(5);
            reservation.court = new Court() { id = reader.GetInt32(6) };
            reservation.customer = new Customer() {id = reader.GetInt32(7) };
            
            return reservation;
        }
    }
}
