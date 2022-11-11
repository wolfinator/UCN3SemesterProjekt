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
                    cmdDeleteReservation.ExecuteNonQuery();
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
            List<Reservation> list = new();
            using (SqlConnection con = new(conStr.ConnectionString))
            {
                SqlCommand cmdGetAll = new(cmdTextGetAll, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmdGetAll.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            Reservation reservation = new()
                            {
                                dateTime = (DateTime)reader["date_time"],
                                courtNo = (int)reader["court_id"],
                                isEquipment = (bool)reader["is_equipment"]
                            };
                            list.Add(reservation);
                        }
                    }
                }
                catch
                {
                    throw new Exception();
                }
            }
            return list;
        }

        public Reservation GetById(int id)
        {
            string cmdTextGetById = "select * from Reservation where id = @Id";
            Reservation reservation = new();
            using (SqlConnection con = new(conStr.ConnectionString))
            {
                SqlCommand cmdGetById = new(cmdTextGetById, con);
                cmdGetById.Parameters.AddWithValue("@Id", id);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmdGetById.ExecuteReader();
                    {
                        if (reader.Read())
                        {
                            reservation = new()
                            {
                                dateTime = (DateTime)reader["date_time"],
                                courtNo = (int)reader["court_id"],
                                isEquipment = (bool)reader["is_equipment"]
                            };
                        }
                    }
                }
                catch
                {
                    throw new NotImplementedException();
                }
            }
            return reservation;
        }

        public bool Update(Reservation entity)
        {
            bool updated = false;
            string cmdTextUpdate = "update Reservation set date_time = @DateTime, court_id = @CourtId, is_equipment = @IsEquipemnt " +
                "where id = @Id";
            using (SqlConnection con = new(conStr.ConnectionString))
            {
                SqlCommand cmdUpdate = new(cmdTextUpdate, con);
                cmdUpdate.Parameters.AddWithValue("@DateTime", entity.dateTime);
                cmdUpdate.Parameters.AddWithValue("@IsEquipment", entity.isEquipment);
                cmdUpdate.Parameters.AddWithValue("@CourtId", entity.courtNo);
                cmdUpdate.Parameters.AddWithValue("@Id", entity); // TODO fix ID input i query

                con.Open();

                try
                {
                    cmdUpdate.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    throw new NotImplementedException(); //TODO SKRIV throw ting
                }
            }
            return updated;
        }
    }
}
