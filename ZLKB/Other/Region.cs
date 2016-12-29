using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ZLKB.Other
{
    public class Region
    {
        public string Name { set; get; }
        private MySqlConnection con;
        public int Id { set; get; }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Region()
        {

        }
        /// <summary>
        /// Конструктор, который сразу создает новый объект и записывает его в БД
        /// </summary>
        /// <param name="number">Название области</param>
        public Region(string name)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `Region`(`name`) VALUES ('{0}'); SELECT * FROM `Region` order by id desc;", name);
                this.Name = name;
                var reader = command.ExecuteReader();
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
        /// Выдает массив всех областей, которые есть в БД
        /// </summary>
        /// <returns>Массив областей</returns>
        static public Region[] GetRegions()
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Region");
                var reader = command.ExecuteReader();
                List<Region> s = new List<Region>();
                while (reader.Read())
                {
                    s.Add(new Region() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
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
        /// Возвращает масив областей, по Id. Если такого ID нету, то метод возвращает Null
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Масив областей</returns>
        static public Region[] GetRegions(int id)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Region where Id={0}", id.ToString());
                var reader = command.ExecuteReader();
                List<Region> s = new List<Region>();
                while (reader.Read())
                {
                    s.Add(new Region() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString() });
                }
                con.Close();
                return s.ToArray();
            }
            catch (Exception error)
            {
                return null;
            }
        }
        public City[] GetCities
        {
            get
            {
                try
                {
                    DataBaseWorker db = new DataBaseWorker();
                    MySqlConnection con = db.con;
                    MySqlCommand command = con.CreateCommand();
                    command.CommandText = string.Format("Select * from City where Region_id={0}", Id.ToString());
                    var reader = command.ExecuteReader();
                    List<City> s = new List<City>();
                    while (reader.Read())
                    {
                        City c = Other.City.GetCities(Convert.ToInt32(reader["Id"].ToString()))[0];
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
        /// <summary>
        /// Сохраняет объект в БД
        /// </summary>
        /// <returns>Возвращает сохранило или нет</returns>
        public bool SaveRegion()
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `Region`(`name`) VALUES ('{0}'); SELECT * FROM `Region` order by id desc;", this.Name);
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
    }
}

