using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ZLKB.Other
{
    public class User
    {
        private MySqlConnection con;
        public int Id { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public DateTime Date { set; get; }
        public bool Admin { set; get; }
        public int HumanId { set; get; }
        public int Positionid { set; get; }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public User()
        {
            Date = DateTime.Now;
        }
        /// <summary>
        /// Констуктор с инициализаций всех полей. Можно ставалять пустую строку, но не нулевую
        /// </summary>
        /// <param name="FName">Имя</param>
        /// <param name="LName">Фамилия</param>
        /// <param name="MName">Отчество</param>
        /// <param name="BirthdayDate">Дата рождения</param>
        /// <param name="Address">Адресс</param>
        /// <param name="Photopass">Путь к фото</param>
        /// <param name="Phone">Телефон</param>
        public User(string Login, string Password, bool Admin, Human human,Position position)
        {
            try
            {
                Date = DateTime.Now;
                string humanid = "";
                string pos = "";
                this.Password = Password;
                this.HumanId = human.Id;
                this.Login = Login;
                this.Admin = Admin;
                if (human != null)
                {
                    humanid = human.ToString();
                    this.HumanId = human.Id;
                }
                if(position!=null)
                {
                    pos = position.Id.ToString();
                    this.Positionid = position.Id;
                }
                DataBaseWorker db = new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `User`(`Login`, `Password`, `RegisterData`, `Admin`, `HumanId`, `Positionid`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');SELECT * FROM `User` order by id desc;", Login, Password, Date.ToString(), humanid,pos);
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
                    User u = User.GetUsers(Login)[0];
                    this.Admin = u.Admin;
                    this.Date = u.Date;
                    this.HumanId = u.HumanId;
                    this.Login = u.Login;
                    this.Password = u.Password;
                }
                con.Close();

            }
        }
        /// <summary>
        /// Выдает массив всех пользователей, которые есть в БД
        /// </summary>
        /// <returns>Массив пользователей</returns>
        static public User[] GetUsers()
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from User");
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
        /// Возвращает масив пользователей, по Id. Если такого ID нету, то метод возвращает Null
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Масив пользователей</returns>
        static public User[] GetUsers(int id)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Address where Id={0}", id.ToString());
                var reader = command.ExecuteReader();
                List<User> s = new List<User>();
                while (reader.Read())
                {
                    s.Add(new User() { Id = Convert.ToInt32(reader["Id"].ToString()), Login = reader["Login"].ToString(), Password = reader["Password"].ToString(), Admin = Convert.ToBoolean(reader["Admin"].ToString()), Date = Convert.ToDateTime(reader["RegisterData"].ToString()), HumanId = Convert.ToInt32(reader["HumanId"].ToString()), Positionid = Convert.ToInt32(reader["Positionid"].ToString()) });
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
        /// Возвращает масив пользователей, по логину. Если такого ID нету, то метод возвращает Null
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns>Пользователь</returns>
        static public User[] GetUsers(string login)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Address where Login='{0}'", login);
                var reader = command.ExecuteReader();
                List<User> s = new List<User>();
                while (reader.Read())
                {
                    s.Add(new User() { Id = Convert.ToInt32(reader["Id"].ToString()), Login = reader["Login"].ToString(), Password = reader["Password"].ToString(), Admin = Convert.ToBoolean(reader["Admin"].ToString()), Date = Convert.ToDateTime(reader["RegisterData"].ToString()), HumanId = Convert.ToInt32(reader["HumanId"].ToString()), Positionid = Convert.ToInt32(reader["Positionid"].ToString()) });
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
        /// Адресс
        /// </summary>
        public Human Human { set { HumanId = value.Id; } get { return Other.Human.GetHumans(this.HumanId)[0]; } }

    }
}
