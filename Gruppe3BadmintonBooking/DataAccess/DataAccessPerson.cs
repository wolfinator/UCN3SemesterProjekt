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
        public int GetPersonType(Person person)
        {
            int persontype = -1;
            if (person is Employee)
            {
                persontype = 0;
            }
            else if (person is Guest)
            {
                persontype = 1;
            }
            else if (person is Member)
            {
                persontype = 2;
            }
            return persontype;
        }
        public void Create(Person entity)
        {
            int persontype = GetPersonType(entity);
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

            cmdAddress.Parameters.AddWithValue("@Street", entity.street);
            cmdAddress.Parameters.AddWithValue("@HouseNo", entity.houseNo);
            cmdAddress.Parameters.AddWithValue("@CityZipcode", entity.zipcode);

            con.Open();
            using (var trans = con.BeginTransaction())
            {
                try
                {
                    cmdPerson.Transaction = trans;
                    cmdAddress.Transaction = trans;
                    int addressId = (int)cmdAddress.ExecuteScalar();
                    cmdPerson.Parameters.AddWithValue("@AddressId", addressId);
                    cmdPerson.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    trans.Rollback();
                    throw;
                }

                trans.Commit();
            }
            con.Close();
        }

        public void DeleteById(int id)
        {
            SqlConnection con = new(conStr.ConnectionString);
            string cmdTextDelete = "delete from person where id = @Id";
            SqlCommand cmdDelete = new(cmdTextDelete, con);
            cmdDelete.Parameters.AddWithValue("@Id", id);

            con.Open();
            try
            {
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                //TODO handle exception
                throw;
            }
            con.Close();
        }
        public IEnumerable<Person> GetAll()
        {
            List<Person> persons = null;

            SqlConnection con = new(conStr.ConnectionString);
            string cmdTextGelAll = "select * from Person p, _Address a where p.address_id = a.id";
            SqlCommand cmdGetAll = new(cmdTextGelAll, con);

            con.Open();
            try
            {
                SqlDataReader reader = cmdGetAll.ExecuteReader();
                persons = BuildObjects(reader);
            }
            catch (SqlException)
            {
                //TODO handle exception
                throw;
            }
            con.Close();
            return persons;
        }
        public Person GetById(int id)
        {
            Person person = null;
            SqlConnection con = new(conStr.ConnectionString);
            string cmdTextGetById = "select * from Person p, _Address a where p.address_id = a.id and p.id = @Id";
            SqlCommand cmdGetById = new(cmdTextGetById, con);

            cmdGetById.Parameters.AddWithValue("@Id", id);

            con.Open();
            try
            {
                SqlDataReader reader = cmdGetById.ExecuteReader();
                if (reader.Read()) person = BuildObject(reader);
            }
            catch (SqlException)
            {
                //TODO handle exception
                throw;
            }

            return person;
        }

        public void Update(Person entity)
        {
            int persontype = GetPersonType(entity);
            SqlConnection con = new(conStr.ConnectionString);
            string cmdTextUpdatePerson = "update person set f_name = @Fname, l_name = @Lname, email = @Email, phone_no = @PhoneNo, person_type = @PersonType where id = @Id";
            string cmdTextUpdateAddress = "update _address set street = @Street, house_no = @HouseNo, city_zipcode = @CityZipcode " +
                "from Person p, _Address a where a.id = p.address_id";
            SqlCommand cmdUpdatePerson = new(cmdTextUpdatePerson, con);
            SqlCommand cmdUpdateAddress = new(cmdTextUpdateAddress, con);

            cmdUpdatePerson.Parameters.AddWithValue("@Fname", entity.firstName);
            cmdUpdatePerson.Parameters.AddWithValue("@Lname", entity.lastName);
            cmdUpdatePerson.Parameters.AddWithValue("@Email", entity.email);
            cmdUpdatePerson.Parameters.AddWithValue("@PhoneNo", entity.phoneNo);
            cmdUpdatePerson.Parameters.AddWithValue("@PersonType", persontype);
            cmdUpdatePerson.Parameters.AddWithValue("@Id", entity.id);

            cmdUpdateAddress.Parameters.AddWithValue("@Street", entity.street);
            cmdUpdateAddress.Parameters.AddWithValue("@HouseNo", entity.houseNo);
            cmdUpdateAddress.Parameters.AddWithValue("@CityZipcode", entity.zipcode);

            con.Open();
            using (var trans = con.BeginTransaction())
            {
                try
                {
                    cmdUpdatePerson.Transaction = trans;
                    cmdUpdateAddress.Transaction = trans;

                    cmdUpdatePerson.ExecuteNonQuery();
                    cmdUpdateAddress.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    trans.Rollback();
                    throw;
                }

                trans.Commit();
            }
            con.Close();
        }

        private List<Person>? BuildObjects(SqlDataReader reader)
        {
            List<Person> persons = new();
            try
            {
                while (reader.Read())
                {
                    Person person = BuildObject(reader);
                    persons.Add(person);
                }
            }
            catch (SqlException)
            {
                //TODO Handle exception
                throw;
            } 
            return persons;
        }

        private Person BuildObject(SqlDataReader reader)
        {
            Person person = null;
            try
            {
                int personType = reader.GetInt32(5);
                switch (personType)
                {
                    case 0: person = new Employee();
                        break;
                    case 1: person = new Guest();
                        break;
                    case 2: person = new Member();
                        break;
                    default: throw new NotImplementedException();
                        break;
                }

                person.firstName = reader.GetString(1);
                person.lastName = reader.GetString(2);
                person.email = reader.GetString(3);
                person.phoneNo = reader.GetString(4);
                person.street = reader.GetString(8);
                person.houseNo = reader.GetString(9);
                person.zipcode = reader.GetString(10);

                //TODO if member add all reservations to object
            }
            catch (InvalidCastException ex)
            {

                throw;
            }
            return person;
        }
    }
    
}