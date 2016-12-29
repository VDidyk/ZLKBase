using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ZLKB.Other
{
    public class Position
    {
        private MySqlConnection con;
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime Date { set; get; }
        public Position()
        {
            Date = DateTime.Now;
        }
        public Position(string Name)
        {
            try
            {
                Date = DateTime.Now;
                DataBaseWorker db = new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `Positions`(`Name`, `Creationdate`) VALUES ('{0}',{'1'});SELECT * FROM `Positions` order by id desc;", Name, Date.ToString());
                this.Name = Name;
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
                if (error.Message.Contains("Duplicate entry"))
                {
                    Position p = Position.GetPositions(Name)[0];
                    this.Id = p.Id;
                    this.Name = p.Name;
                    this.Date = p.Date;
                }
                con.Close();
            }
        }
        /// <summary>
        /// Возвращает всех пользователей этой должности
        /// </summary>
        /// <returns>Пользователи</returns>
        public User[] GetUsers()
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from User where PositionId='{0}'", this.Id.ToString());
                var reader = command.ExecuteReader();
                List<User> s = new List<User>();
                while (reader.Read())
                {
                    s.Add(new User() { Id = Convert.ToInt32(reader["Id"].ToString()), Login = reader["Login"].ToString(), Password = reader["Password"].ToString(), Admin = Convert.ToBoolean(reader["Admin"].ToString()), Date = Convert.ToDateTime(reader["RegisterData"].ToString()), HumanId = Convert.ToInt32(reader["HumanId"].ToString()) });
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
        /// Возвращает должности по ID
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Должности</returns>
        static public Position[] GetPositions(int id)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Positions where Id={0}", id.ToString());
                var reader = command.ExecuteReader();
                List<Position> s = new List<Position>();
                while (reader.Read())
                {
                    s.Add(new Position() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString(), Date = Convert.ToDateTime(reader["Creationdate"].ToString()) });
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
        /// Возвращает должности по имени
        /// </summary>
        /// <param name="name">Имя</param>
        /// <returns>Должности</returns>
        static public Position[] GetPositions(string name)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Positions where Name='{0}'", name);
                var reader = command.ExecuteReader();
                List<Position> s = new List<Position>();
                while (reader.Read())
                {
                    s.Add(new Position() { Id = Convert.ToInt32(reader["Id"].ToString()), Name = reader["Name"].ToString(), Date = Convert.ToDateTime(reader["Creationdate"].ToString()) });
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
