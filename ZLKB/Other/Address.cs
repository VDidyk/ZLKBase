using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ZLKB.Other
{
    public class Address
    {
        private MySqlConnection con;
        public int Id { set; get; }
        public string Street { set; get; }
        public string HouseNumber { set; get; }
        public string FlatNumber { set; get; }
        private int CityId = 0;
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Address()
        {

        }
        /// <summary>
        /// Конструктор, с инициализацией имени, кода и области
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="code">Код города</param>
        /// <param name="region">Область</param>
        public Address(string street,string housenumber,string flatnumber,City city)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `Address`(`City_Id`, `Street`, `HouseNumber`, `FlatNumber`) VALUES ('{0}','{1}',{2},{3}); SELECT * FROM `Address` order by id desc; ",city.Id.ToString(),street, housenumber, flatnumber);
                var reader = command.ExecuteReader();
                this.Street = street;
                this.FlatNumber = flatnumber;
                this.HouseNumber = housenumber;
                this.CityId = city.Id;
                while (reader.Read())
                {
                    this.Id = Convert.ToInt32(reader["Id"].ToString());
                    break;
                }
                con.Close();
            }
            catch (Exception error)
            {

            }
        }
        /// <summary>
        /// Выдает массив всех адресов, которые есть в БД
        /// </summary>
        /// <returns>Массив адресов</returns>
        static public Address[] GetAddresses()
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Address");
                var reader = command.ExecuteReader();
                List<Address> s = new List<Address>();
                while (reader.Read())
                {
                    s.Add(new Address() { Id = Convert.ToInt32(reader["Id"].ToString()), Street = reader["Street"].ToString(), HouseNumber = reader["HouseNumber"].ToString(), FlatNumber = reader["FlatNumber"].ToString(), CityId = Convert.ToInt32(reader["City_Id"].ToString()) });
                }
                con.Close();
                return s.ToArray();
            }
            catch (Exception error)
            {
                return null;
            }
        }
        /// <summary>
        /// Возвращает масив адресов, по Id. Если такого ID нету, то метод возвращает Null
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Масив адресов</returns>
        static public Address[] GetAddresses(int id)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Address where Id={0}", id.ToString());
                var reader = command.ExecuteReader();
                List<Address> s = new List<Address>();
                while (reader.Read())
                {
                    s.Add(new Address() { Id = Convert.ToInt32(reader["Id"].ToString()), Street = reader["Street"].ToString(), HouseNumber = reader["HouseNumber"].ToString(), FlatNumber = reader["FlatNumber"].ToString(), CityId = Convert.ToInt32(reader["City_Id"].ToString()) });


                }
                con.Close();
                return s.ToArray();
            }
            catch (Exception error)
            {
                return null;
            }
        }
        /// <summary>
        /// Город адреса
        /// </summary>
        public City CityField
        {
            set { CityId = value.Id; }
            get { return Other.City.GetCities(this.CityId)[0]; }
        }
        /// <summary>
        /// Персона, проживающая по этому адрессу
        /// </summary>
        public Human HumanOwner { 
            get {
                try
                {
                    DataBaseWorker db = new DataBaseWorker();
                    MySqlConnection con = db.con;
                    MySqlCommand command = con.CreateCommand();
                    command.CommandText = string.Format("Select * from Human where AddressId = {0}", this.Id.ToString());
                    var reader = command.ExecuteReader();
                    List<Human> s = new List<Human>();
                    while (reader.Read())
                    {
                        s.Add(new Human() { Id = Convert.ToInt32(reader["Id"].ToString()), FName = reader["FName"].ToString(), LName = reader["LName"].ToString(), MName = reader["MName"].ToString(), Date = Convert.ToDateTime(reader["CreateDate"].ToString()), BirthdayDate = Convert.ToDateTime(reader["Birthday"].ToString()), AddressId = Convert.ToInt32(reader["AddressId"].ToString()), Photopass = reader["PhotoPath"].ToString() });
                    }
                    con.Close();
                    return s.ToArray()[0];
                }
                catch
                {
                    return null;
                }
            ;} 
        }
    }
}
