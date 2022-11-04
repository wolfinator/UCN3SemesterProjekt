using Microsoft.Data.SqlClient;
using Model;

namespace DataAccess
{
    public class DataAccessPerson : IDataAccess<Person>
    {
        private SqlConnectionStringBuilder conStr;
        public DataAccessPerson()
        {
            conStr = Connection.conStr;
        }
        public void Create(Person entity)
        {
            int persontype = -1;
            if (entity is Employee)
            {
                persontype = 0;
            }
            else if (entity is Guest)
            {
                persontype = 1;
            }
            else if (entity is Member)
            {
                persontype = 2;
            }

            SqlConnection con = new(conStr.ConnectionString);

            string cmdTextPerson = "insert into Person (f_name, l_name, email, phone_no, person_type, address_id) " +
                                   "values (@Fname, @Lname, @Email, @PhoneNo, @PersonType, @AddressId)";
            string cmdTextAddress = "insert into _Address (street, house_no, city_zipcode) output INSERTED.ID " +
                                    "values (@Street, @HouseNo, @CityZipcode)";
            SqlCommand cmdPerson = new(cmdTextPerson, con);
            SqlCommand cmdAddress = new(cmdTextAddress, con);
            cmdPerson.Parameters.AddWithValue("@Fname", entity.firstName);
            cmdPerson.Parameters.AddWithValue("@Lname", entity.lastName);
            cmdPerson.Parameters.AddWithValue("@Email", entity.email);
            cmdPerson.Parameters.AddWithValue("@PhoneNo", entity.phoneNo);
            cmdPerson.Parameters.AddWithValue("@PersonType", persontype);

            cmdAddress.Parameters.AddWithValue("@Street", entity.address);
            cmdAddress.Parameters.AddWithValue("@HouseNo", "1"); // todo be able to split address into street and hosue no
            cmdAddress.Parameters.AddWithValue("@CityZipcode", "9220"); // zipcode?????
            con.Open();
            using (var trans = con.BeginTransaction())
            {
                try
                {
                    int addressId = (int)cmdAddress.ExecuteScalar();
                    cmdPerson.Parameters.AddWithValue("@AddresId", addressId);
                    cmdPerson.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    trans.Rollback();
                    throw;
                }

                trans.Commit();
            }
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
    
}