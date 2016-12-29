using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ZLKB.Other
{
    public class City
    {
        public string Name { set; get; }
        private MySqlConnection con;
        public int Id { set; get; }
        public string Code { set; get; }
        private int RegionId = 0;
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public City()
        {

        }
        /// <summary>
        /// Конструктор, с инициализацией имени
        /// </summary>
        /// <param name="name">Имя</param>
        public City(string name)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `City`(`Name`) VALUES ('{0}','{1}'); SELECT * FROM `City` order by id desc; ", name);
                var reader = command.ExecuteReader();
                this.Name = name;
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
        /// Конструктор, с инициализацией имени, кода
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="code">Код города</param>
        public City(string name, string code)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `City`(`Name`, `Code`) VALUES ('{0}','{1}'); SELECT * FROM `City` order by id desc; ", name, code);
                var reader = command.ExecuteReader();
                this.Code = code;
                this.Name = name;
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
        /// Конструктор, с инициализацией имени, кода и области
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="code">Код города</param>
        /// <param name="region">Область</param>
        public City(string name, string code, Other.Region region)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `City`(`Name`, `Code`, `Region_id`) VALUES ('{0}','{1}',{2}); SELECT * FROM `City` order by id desc; ", name, code, region.Id.ToString());
                var reader = command.ExecuteReader();
                this.Code = code;
                this.Name = name;
                this.RegionId = region.Id;
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
        /// Конструктор, с инициализацией имени, области
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="region">Область</param>
        public City(string name, Other.Region region)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `City`(`Name`, `Region_id`) VALUES ('{0}',{2}); SELECT * FROM `City` order by id desc; ", name, region.Id.ToString());
                var reader = command.ExecuteReader();
                this.Name = name;
                this.RegionId = region.Id;
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
        /// Выдает массив всех городов, которые есть в БД
        /// </summary>
        /// <returns>Массив городов</returns>
        static public City[] GetCities()
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from City");
                var reader = command.ExecuteReader();
                List<City> s = new List<City>();
                while (reader.Read())
                {
                    s.Add(new City() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString(), Code = reader["Code"].ToString(), RegionId = Convert.ToInt32(reader["Region_id"].ToString()) });
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
        /// Возвращает масив городов, по Id. Если такого ID нету, то метод возвращает Null
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Масив городов</returns>
        static public City[] GetCities(int id)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from City where Id={0}", id.ToString());
                var reader = command.ExecuteReader();
                List<City> s = new List<City>();
                while (reader.Read())
                {
                    s.Add(new City() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString(), Code = reader["Code"].ToString(), RegionId = Convert.ToInt32(reader["Region_id"].ToString()) });

                }
                con.Close();
                return s.ToArray();
            }
            catch (Exception error)
            {
                return null;
            }
        }
        public Region RegionField
        {
            set { RegionId = value.Id; }
            get { return Other.Region.GetRegions(this.RegionId)[0]; }
        }
        /// <summary>
        /// Сохраняет объект в БД
        /// </summary>
        /// <returns>Возвращает сохранило или нет</returns>
        public bool SaveCity()
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `City`(`Name`, `Code`, `Region_id`) VALUES ('{0}','{1}',{2}); SELECT * FROM `City` order by id desc; ", this.Name, this.Code, this.RegionId.ToString());
                this.Name = this.Name;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.Id = Convert.ToInt32(reader["Id"].ToString());
                    break;
                }
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }
        public Address[] GetAddresses
        {
            get
            {
                try
                {
                    DataBaseWorker db = new DataBaseWorker();
                    MySqlConnection con = db.con;
                    MySqlCommand command = con.CreateCommand();
                    command.CommandText = string.Format("Select * from Address where City_Id={0}", Id.ToString());
                    var reader = command.ExecuteReader();
                    List<Address> s = new List<Address>();
                    while (reader.Read())
                    {
                        Address c = Other.Address.GetAddresses(Convert.ToInt32(reader["Id"].ToString()))[0];
                        s.Add(c);
                    }
                    con.Close();
                    return s.ToArray();
                }
                catch (Exception error)
                {
                    return null;
                }
            }


        }
    }
}
