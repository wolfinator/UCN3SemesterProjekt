using DataAccess.Interfaces;
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
            conStr = DbConnection.conStr;
        }
        public int Create(Customer customer)
        {
            // Setup
            int customerId = -1;
            SqlConnection con = new(conStr.ConnectionString);

            string cmdTextCustomer = "insert into Customer (f_name, l_name, email, phone_no) output INSERTED.ID " +
                                   "values (@Fname, @Lname, @Email, @PhoneNo)";
            string cmdTextAddress = "insert into _Address (street, house_no, city_zipcode, customer_id) " +
                                    "values (@Street, @HouseNo, @CityZipcode, @CustomerId)";
            SqlCommand cmdCustomer = new(cmdTextCustomer, con);
            SqlCommand cmdAddress = new(cmdTextAddress, con);

            cmdCustomer.Parameters.AddWithValue("@Fname", customer.firstName);
            cmdCustomer.Parameters.AddWithValue("@Lname", customer.lastName);
            cmdCustomer.Parameters.AddWithValue("@Email", customer.email);
            cmdCustomer.Parameters.AddWithValue("@PhoneNo", customer.phoneNo);
            cmdAddress.Parameters.AddWithValue("@Street", customer.street);
            cmdAddress.Parameters.AddWithValue("@HouseNo", customer.houseNo);
            cmdAddress.Parameters.AddWithValue("@CityZipcode", customer.zipcode);
            // Åben forbindelsen, og lav en transaktion (da vi både sætter ind i person og i addresse tabellerne
            try
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        // Justér kommandoerne til at være i transaktionen
                        cmdCustomer.Transaction = trans;
                        cmdAddress.Transaction = trans;
                        // Indsæt customer og få et ID tilbage ("output inserted.id" i querien)
                        customerId = (int)cmdCustomer.ExecuteScalar();
                        // Hvis adressen ikke er sat (eftersom det ikke er implementeret i webserver og desktop)
                        // så sætter vi ikke nogen adresse ind.
                        if (customer.street != "" && customer.houseNo != "" && customer.zipcode != "")
                        {
                            cmdAddress.Parameters.AddWithValue("@CustomerId", customerId);
                            cmdAddress.ExecuteNonQuery();
                        }
                    }
                    catch (SqlException)
                    {
                        trans.Rollback();
                        throw;
                    }

                    trans.Commit();
                }
            }
            catch (Exception)
            {
                // TODO exception handling
                throw;
            }
            finally
            {
                con.Close();
            }

            return customerId;
        }

        public bool DeleteById(int id)
        {
            bool isDeleted = false;

            SqlConnection con = new(conStr.ConnectionString);
            // Selvom vi indsætter BÅDE customer og adresse i Create metoden,
            // så er databasen indstillet til on cascade delete på fremmednøglen,
            // og har derfor kun brug for én delete

            string cmdTextDelete = "delete from customer where id = @Id";
            SqlCommand cmdDelete = new(cmdTextDelete, con);

            try
            {
                con.Open();
                cmdDelete.Parameters.AddWithValue("@Id", id);
                // Tjek om der er blevet slettet præcis 1 customer
                // Ideelt set skulle den nok også tjekke adresse tabellen, men det overlader vi til databasen med cascade delete
                isDeleted = (cmdDelete.ExecuteNonQuery() >= 1);
            }
            catch (SqlException)
            {
                //TODO handle exception
                throw;
            }
            finally
            {
                con.Close();
            }

            return isDeleted;
        }
        public IEnumerable<Customer> GetAll()
        {
            // Initialisér retur variablen som null i stedet for en tom liste, så der er forskel på en fejl og en tom tabel i databasen
            List<Customer> customers = null;

            SqlConnection con = new(conStr.ConnectionString);
            string cmdTextGelAll = "select * from Customer c left join _address a on a.customer_id = c.id";
            SqlCommand cmdGetAll = new(cmdTextGelAll, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmdGetAll.ExecuteReader();
                customers = BuildObjects(reader);
                reader.Close();
            }
            catch (SqlException)
            {
                //TODO handle exception
                throw;
            }
            finally
            {
                con.Close();
            }

            return customers;
        }
        public Customer GetById(int id)
        {
            Customer customer = null;
            SqlConnection con = new(conStr.ConnectionString);
            string cmdTextGetById = "select * from Customer c left join _address a on a.customer_id = c.id where c.id = @Id";
            SqlCommand cmdGetById = new(cmdTextGetById, con);

            cmdGetById.Parameters.AddWithValue("@Id", id);

            try
            {
                con.Open();
                SqlDataReader reader = cmdGetById.ExecuteReader();
                if (reader.Read()) customer = BuildObject(reader);
                reader.Close();
            }
            catch (SqlException)
            {
                //TODO handle exception
                throw;
            }
            finally
            {
                con.Close();
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
            cmdUpdateCustomer.Parameters.AddWithValue("@Id", entity.id);

            cmdUpdateAddress.Parameters.AddWithValue("@Street", entity.street);
            cmdUpdateAddress.Parameters.AddWithValue("@HouseNo", entity.houseNo);
            cmdUpdateAddress.Parameters.AddWithValue("@CityZipcode", entity.zipcode);
            cmdUpdateAddress.Parameters.AddWithValue("@CustomerId", entity.id);

            try
            {
                con.Open();
                using (var trans = con.BeginTransaction())
                {
                    try
                    {
                        cmdUpdateCustomer.Transaction = trans;
                        cmdUpdateAddress.Transaction = trans;

                        int updatedCustomer = cmdUpdateCustomer.ExecuteNonQuery();
                        int updatedAddress = cmdUpdateAddress.ExecuteNonQuery();

                        // Tjekker at begge tabeller er blevet updateret
                        isUpdated = updatedAddress + updatedAddress == 2;
                    }
                    catch (SqlException)
                    {
                        trans.Rollback();
                        throw;
                    }

                    trans.Commit();
                }
            }
            catch (Exception)
            {
                //TODO exception handling
                throw;
            }
            finally
            {
                con.Close();
            }

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

            customer = new Customer();
            customer.id = reader.GetInt32(0);
            customer.firstName = reader.GetString(1);
            customer.lastName = reader.GetString(2);
            customer.email = reader.GetString(3);
            customer.phoneNo = reader.GetString(4);
            // Tjek om adressen kunne hentes fra databasen eller ej,
            // hvis den første (kolonne nr 6) er null er de næste (7 og 8) også,
            // og hvis adressen kan hentes putter vi det selvfølgelig ind i objektet
            if (!reader.IsDBNull(6))
            {
                customer.street = reader.GetString(6);
                customer.houseNo = reader.GetString(7);
                customer.zipcode = reader.GetString(8);
            }
            else
            {
                customer.street = "";
                customer.houseNo = "";
                customer.zipcode = "";
            }

            return customer;
        }
    }
}

