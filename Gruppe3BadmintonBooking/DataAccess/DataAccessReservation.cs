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
            string cmdTextCreate = "insert into Reservation(date_time, is_equipment, from_time, court_id, customer_id, employee_id) " +
                                            "values (@DateTime, @IsEquipment, @FromTime, @CourtId, @CustomerId, @EmployeeId)";
            using (SqlConnection con = new(conStr.ConnectionString))
            { 
                SqlCommand cmdReservation = new(cmdTextCreate, con);
                cmdReservation.Parameters.AddWithValue("@DateTime", reservation.dateTime);
                cmdReservation.Parameters.AddWithValue("@IsEquipment", reservation.isEquipment);
                cmdReservation.Parameters.AddWithValue("@FromTime", reservation.fromTime);
                cmdReservation.Parameters.AddWithValue("@CourtId", reservation.courtNo);
                cmdReservation.Parameters.AddWithValue("@CustomerId", reservation.customer.id);
                cmdReservation.Parameters.AddWithValue("@EmployeeId", reservation.employee.id);

                con.Open();
                try
                {
                    created = cmdReservation.ExecuteNonQuery() == 1;
                }
                catch (SqlException)
                {
                    throw new NotImplementedException(); //TODO SKRIV throw ting
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
                catch (SqlException)
                {
                    throw new NotImplementedException(); //TODO SKRIV throw ting
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
                    throw new NotImplementedException();
                }
            }
            return reservation;
        }

        public bool Update(Reservation reservation)
        {
            bool updated = false;
            string cmdTextUpdate = "update Reservation set date_time = @DateTime, court_id = @CourtId, is_equipment = @IsEquipment, " +
                "from_time = @FromTime, customer_id = @CustomerId, employee_id = @EmployeeId " +
                "where id = @Id";
            using (SqlConnection con = new(conStr.ConnectionString))
            {
                SqlCommand cmdUpdate = new(cmdTextUpdate, con);
                cmdUpdate.Parameters.AddWithValue("@DateTime", reservation.dateTime);
                cmdUpdate.Parameters.AddWithValue("@IsEquipment", reservation.isEquipment ? 1 : 0);
                cmdUpdate.Parameters.AddWithValue("@FromTime", reservation.fromTime);
                cmdUpdate.Parameters.AddWithValue("@CourtId", reservation.courtNo);
                cmdUpdate.Parameters.AddWithValue("@CustomerId", reservation.customer.id);
                cmdUpdate.Parameters.AddWithValue("@EmployeeId", reservation.employee.id);

                cmdUpdate.Parameters.AddWithValue("@Id", reservation.Id);

                con.Open();
                try
                {
                    updated = cmdUpdate.ExecuteNonQuery() == 1;
                }
                catch (SqlException)
                {
                    throw new NotImplementedException(); //TODO SKRIV throw ting
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
            reservation.dateTime = reader.GetDateTime(1);
            reservation.isEquipment = reader.GetBoolean(2);
            reservation.fromTime = reader.GetTimeSpan(3);
            reservation.court = new Court() { id = reader.GetInt32(4) };
            reservation.customer = new Person() {id = reader.GetInt32(5) };
            try
            {
                reservation.employee = new Employee() { id = reader.GetInt32(6) };
            }
            catch (Exception)
            {
                reservation.employee = null;
            }
            
            return reservation;
        }
    }
}
