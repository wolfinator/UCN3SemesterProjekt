using Microsoft.Data.SqlClient;
using Model;

namespace DataAccess
{
    public class DataAccessCustomer : IDataAccess<Customer>
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
        public bool Create(Customer entity)
        {
            bool created = false;
            // int persontype = GetPersonType(entity);
            SqlConnection con = new(conStr.ConnectionString);

            string cmdTextCustomer = "insert into Customer (f_name, l_name, email, phone_no, address_id) " +
                                   "values (@Fname, @Lname, @Email, @PhoneNo, @AddressId)";
            string cmdTextAddress = "insert into _Address (street, house_no, city_zipcode) output INSERTED.ID " +
                                    "values (@Street, @HouseNo, @CityZipcode)";
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
                    int addressId = (int)cmdAddress.ExecuteScalar();
                    cmdCustomer.Parameters.AddWithValue("@AddressId", addressId);
                    created = cmdCustomer.ExecuteNonQuery() == 1;
                }
                catch (SqlException)
                {
                    trans.Rollback();
                    throw;
                }

                trans.Commit();
            }
            con.Close();
            return created;
        }

        public bool DeleteById(int id)
        {
            bool isDeleted = false;

            SqlConnection con = new(conStr.ConnectionString);
            string cmdTextDelete = "delete from customer output deleted.address_id where id = @Id";
            string cmdTextDeleteAddress = "delete from _address where id = @AddressId";
            SqlCommand cmdDelete = new(cmdTextDelete, con);
            cmdDelete.Parameters.AddWithValue("@Id", id);

            con.Open();
            try
            {
                // Skal nok ændres hvis vi laver cascade på person og _address, er lidt kringlet
                var addressId = cmdDelete.ExecuteScalar();
                //int addressId = (int) cmdDelete.ExecuteScalar();
                if (addressId != null)
                {
                    isDeleted = true;
                    cmdDelete.CommandText = cmdTextDeleteAddress;
                    cmdDelete.Parameters.AddWithValue("@AddressId", addressId);
                    isDeleted = isDeleted && cmdDelete.ExecuteNonQuery() == 1;
                }
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
            string cmdTextGelAll = "select * from Customer p, _Address a where p.address_id = a.id";
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
            string cmdTextGetById = "select * from Customer p, _Address a where p.address_id = a.id and p.id = @Id";
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
            string cmdTextUpdateCustomer = "update customer set f_name = @Fname, l_name = @Lname, email = @Email, phone_no = @PhoneNo where id = @Id";
            string cmdTextUpdateAddress = "update _address set street = @Street, house_no = @HouseNo, city_zipcode = @CityZipcode " +
                "from Customer c, _Address a where a.id = c.address_id and c.id = @Id";
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
            cmdUpdateAddress.Parameters.AddWithValue("@Id", entity.id);

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
            //try
            //{
            //    int personType = int.Parse(reader.GetString(5));
            //switch (personType)
            //{
            //            case 0:
            //                person = new Employee();
            //                break;
            //            case 1:
            //                person = new Guest();
            //                break;
            //            case 2:
            //                person = new Member();
            //                break;
            //            default:
            //                throw new NotImplementedException(); // Todo handle exception
            //                break;
            //}
            try
            {
                customer = new Customer();
                customer.id = reader.GetInt32(0);
                customer.firstName = reader.GetString(1);
                customer.lastName = reader.GetString(2);
                customer.email = reader.GetString(3);
                customer.phoneNo = reader.GetString(4);
                customer.street = reader.GetString(7);
                customer.houseNo = reader.GetString(8);
                customer.zipcode = reader.GetString(9);
            }
            catch (Exception)
            {

            }
            

            //TODO if member add all reservations to object
            return customer;
        }
    }
}
    
