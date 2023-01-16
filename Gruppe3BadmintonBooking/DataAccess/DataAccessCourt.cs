using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using Model;

namespace DataAccess
{
    public class DataAccessCourt : IDaoCourt
    {
        private SqlConnectionStringBuilder conStr;
        public DataAccessCourt()
        {
            conStr = DbConnection.conStr;
        }

        // Bliver ikke brugt
        public int Create(Court court)
        {
            SqlConnection con = new(conStr.ConnectionString);
            con.Open();

            throw new NotImplementedException();
        }

        // Bliver ikke brugt
        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        // Lavet men bliver ikke brugt i WebServer eller Desktop endnu
        public IEnumerable<Court> GetAll()
        {
            SqlConnection con = new(conStr.ConnectionString);
            con.Open();

            List<Court> list = new List<Court>();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * from Court";
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Court court = new Court()
                {
                    id = reader.GetInt32(0),
                };
                list.Add(court);
            }
            con.Close();
            return list;
        }

        public Court GetById(int id)
        {
            Court court = null;
            SqlConnection con = new(conStr.ConnectionString);       
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = " SELECT * FROM Court where court.court_no = @id";
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                court = new Court();
                court.id = reader.GetInt32(0);
            }
            con.Close();
            return court;
        }
        
        public bool Update(Court entity)
        {
            throw new NotImplementedException();
        }
    }
}
