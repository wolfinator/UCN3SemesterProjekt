using Microsoft.Data.SqlClient;
using Model;
using System.Diagnostics;

namespace DataAccess
{
    public class DataAccessCustomer : IDaoCustomer
    {
        private SqlConnectionStringBuilder conStr;
        public DataAccessCustomer()
        {
            conStr = Connection.conStr;
        }
        //public int GetPersonType(Customer person)
        //{
        //    int persontype = -1;
        //    if (person is Employee)
        //    {
        //        persontype = 0;
        //    }
        //    else if (person is Guest)
        //    {
        //        persontype = 1;
        //    }
        //    else if (person is Member)
        //    {
        //        persontype = 2;
        //    }
        //    return persontype;
        //}
        public int Create(Customer entity)
        {
            int customerId = -1;
            // int persontype = GetPersonType(entity);
            SqlConnection con = new(conStr.ConnectionString);

            string cmdTextCustomer = "insert into Customer (f_name, l_name, email, phone_no) output INSERTED.ID " +
                                   "values (@Fname, @Lname, @Email, @PhoneNo)";
            string cmdTextAddress = "insert into _Address (street, house_no, city_zipcode, customer_id) " +
                                    "values (@Street, @HouseNo, @CityZipcode, @CustomerId)";
            SqlCommand cmdCustomer = new(cmdTextCustomer, con);
            SqlCommand cmdAddress = new(cmdTextAddress, con);

            cmdCustomer.Parameters.AddWithValue("@Fname", entity.firstName);
            cmdCustomer.Parameters.AddWithValue("@Lname", entity.lastName);
            cmdCustomer.Parameters.AddWithValue("@Email", entity.email);
            cmdCustomer.Parameters.AddWithValue("@PhoneNo", entity.phoneNo);
            //cmdPerson.Parameters.AddWithValue("@PersonType", persontype);

            cmdAddress.Parameters.AddWithValue("@Street", entity.street);
            cmdAddress.Parameters.AddWithValue("@HouseNo", entity.houseNo);
            cmdAddress.Parameters.AddWithValue("@CityZipcode", entity.zipcode);

            con.Open();
            using (var trans = con.BeginTransaction())
            {
                try
                {
                    cmdCustomer.Transaction = trans;
                    cmdAddress.Transaction = trans;
                    customerId = (int)cmdCustomer.ExecuteScalar();
                    cmdAddress.Parameters.AddWithValue("@CustomerId", customerId);
                    cmdAddress.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    trans.Rollback();
                    throw;
                }

                trans.Commit();
            }
            con.Close();
            return customerId;
        }

        public bool DeleteById(int id)
        {
            bool isDeleted = false;

            SqlConnection con = new(conStr.ConnectionString);
            string cmdTextDelete = "delete from customer where id = @Id";
            //string cmdTextDeleteAddress = "delete from _address where id = @AddressId";
            //string cmdTextDeleteReservations = "delete from reservation where customer_id = @CustomerId";
            SqlCommand cmdDelete = new(cmdTextDelete, con);

            con.Open();
            try
            {
                // Skal nok ændres hvis vi laver cascade på person og _address, er lidt kringlet
                cmdDelete.Parameters.AddWithValue("@Id", id);
                isDeleted = cmdDelete.ExecuteNonQuery() >= 1;
            }
            catch (SqlException)
            {
                //TODO handle exception
                throw;
            }

            con.Close();
            return isDeleted;
        }
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customers = null;

            SqlConnection con = new(conStr.ConnectionString);
            string cmdTextGelAll = "select * from Customer p, _Address a where p.id = a.customer_id";
            SqlCommand cmdGetAll = new(cmdTextGelAll, con);

            con.Open();
            try
            {
                SqlDataReader reader = cmdGetAll.ExecuteReader();
                customers = BuildObjects(reader);
            }
            catch (SqlException)
            {
                //TODO handle exception
                throw;
            }
            con.Close();
            return customers;
        }
        public Customer GetById(int id)
        {
            Customer customer = null;
            SqlConnection con = new(conStr.ConnectionString);
            string cmdTextGetById = "select * from Customer p, _Address a where p.id = a.customer_id and p.id = @Id";
            SqlCommand cmdGetById = new(cmdTextGetById, con);

            cmdGetById.Parameters.AddWithValue("@Id", id);

            con.Open();
            try
            {
                SqlDataReader reader = cmdGetById.ExecuteReader();
                if (reader.Read()) customer = BuildObject(reader);
            }
            catch (SqlException)
            {
                //TODO handle exception
                throw;
            }

            return customer;
        }

        public bool Update(Customer entity)
        {
            bool isUpdated = false;

            //int persontype = GetPersonType(entity);
            SqlConnection con = new(conStr.ConnectionString);
            string cmdTextUpdateCustomer = "update customer set " +
                "f_name = @Fname, " +
                "l_name = @Lname, " +
                "email = @Email, " +
                "phone_no = @PhoneNo " +
                "where id = @Id";
            string cmdTextUpdateAddress = "update _address set " +
                "street = @Street, " +
                "house_no = @HouseNo, " +
                "city_zipcode = @CityZipcode " +
                "where customer_id = @CustomerId";
            SqlCommand cmdUpdateCustomer = new(cmdTextUpdateCustomer, con);
            SqlCommand cmdUpdateAddress = new(cmdTextUpdateAddress, con);

            cmdUpdateCustomer.Parameters.AddWithValue("@Fname", entity.firstName);
            cmdUpdateCustomer.Parameters.AddWithValue("@Lname", entity.lastName);
            cmdUpdateCustomer.Parameters.AddWithValue("@Email", entity.email);
            cmdUpdateCustomer.Parameters.AddWithValue("@PhoneNo", entity.phoneNo);
            // cmdUpdatePerson.Parameters.AddWithValue("@PersonType", persontype);
            cmdUpdateCustomer.Parameters.AddWithValue("@Id", entity.id);

            cmdUpdateAddress.Parameters.AddWithValue("@Street", entity.street);
            cmdUpdateAddress.Parameters.AddWithValue("@HouseNo", entity.houseNo);
            cmdUpdateAddress.Parameters.AddWithValue("@CityZipcode", entity.zipcode);
            cmdUpdateAddress.Parameters.AddWithValue("@CustomerId", entity.id);

            con.Open();
            using (var trans = con.BeginTransaction())
            {
                try
                {
                    cmdUpdateCustomer.Transaction = trans;
                    cmdUpdateAddress.Transaction = trans;

                    int updatedCustomer = cmdUpdateCustomer.ExecuteNonQuery();
                    int updatedAddress = cmdUpdateAddress.ExecuteNonQuery();

                    // Checks if both the person and address tables are updated
                    isUpdated = updatedAddress + updatedAddress == 2;
                }
                catch (SqlException)
                {
                    trans.Rollback();
                    throw;
                }

                trans.Commit();
            }
            con.Close();

            return isUpdated;
        }

        private List<Customer>? BuildObjects(SqlDataReader reader)
        {
            List<Customer> customers = new();
            try
            {
                while (reader.Read())
                {
                    Customer customer = BuildObject(reader);
                    customers.Add(customer);
                }
            }
            catch (SqlException)
            {
                //TODO Handle exception
                throw;
            }
            return customers;
        }

        private Customer BuildObject(SqlDataReader reader)
        {
            Customer customer = null;

            try
            {
                customer = new Customer();
                customer.id = reader.GetInt32(0);
                customer.firstName = reader.GetString(1);
                customer.lastName = reader.GetString(2);
                customer.email = reader.GetString(3);
                customer.phoneNo = reader.GetString(4);
                customer.street = reader.GetString(6);
                customer.houseNo = reader.GetString(7);
                customer.zipcode = reader.GetString(8);
            }
            catch (Exception)
            {

            }
            

            //TODO if member add all reservations to object
            return customer;
        }
    }
}
    
