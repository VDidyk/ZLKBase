using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ZLKB.Other
{
    public class Phone
    {
        private MySqlConnection con;
        public int Id { set; get; }
        public string Number { set; get; }
        public int HumanId { set; get; }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Phone()
        {
            
        }
        /// <summary>
        /// Конструктор, который сразу создает новый объект и записывает его в БД
        /// </summary>
        /// <param name="number">Номер телефона</param>
        public Phone(string number)
        {
            try
            {
                DataBaseWorker db=new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `Phone`(`number`) VALUES ('{0}');SELECT * FROM `Phone` order by id desc;", number);
                this.Number = number;
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
                    Phone p=Phone.GetPhones(number)[0];
                    this.Number = p.Number;
                    this.HumanId = p.HumanId;
                }
                con.Close();

            }
        }
        public Phone(string number,Human human)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                string id = "";
                if(human!=null)
                {
                    id = human.Id.ToString();
                    this.HumanId = human.Id;
                }
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `Phone`(`number`,`HumanId`) VALUES ('{0}','{1}');SELECT * FROM `Phone` order by id desc;",number,id);
                this.Number = number;
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
                    Phone p = Phone.GetPhones(number)[0];
                    this.Number = p.Number;
                    this.HumanId = p.HumanId;
                }
                con.Close();
            }
        }
        /// <summary>
        /// Выдает массив всех телефонов, которые есть в БД
        /// </summary>
        /// <returns>Массив телефонов</returns>
        static public Phone[] GetPhones()
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Phone");
                var reader = command.ExecuteReader();
                List<Phone> s = new List<Phone>();
                while (reader.Read())
                {
                    s.Add(new Phone() { Id = Convert.ToInt32(reader["Id"].ToString()), Number = reader["Number"].ToString()});
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
        /// Возвращает масив телефонов, по Id. Если такого ID нету, то метод возвращает Null
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Масив телефонов</returns>
        static public Phone[] GetPhones(int id)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Phone where Id={0}",id.ToString());
                var reader = command.ExecuteReader();
                List<Phone> s = new List<Phone>();
                while (reader.Read())
                {
                    s.Add(new Phone() { Id = Convert.ToInt32(reader["Id"].ToString()), Number = reader["Number"].ToString() });
                }
                con.Close();
                return s.ToArray();
            }
            catch (Exception error)
            {
                return null;
            }
        }
        static public  Other.Phone[] GetPhones(string number)
        {
             try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Phone where number='{0}'",number);
                var reader = command.ExecuteReader();
                List<Phone> s = new List<Phone>();
                while (reader.Read())
                {
                    s.Add(new Phone() { Id = Convert.ToInt32(reader["Id"].ToString()), Number = reader["Number"].ToString() });
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
        /// Сохраняет объект в БД
        /// </summary>
        /// <returns>Возвращает сохранило или нет</returns>
        public bool SavePhone()
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                string id = "";
                if(this.HumanId!=null)
                {
                    id = this.HumanId.ToString();
                }
                command.CommandText = string.Format("INSERT INTO `Phone`(`number`,`HumanId`) VALUES ('{0}','{1}');SELECT * FROM `Phone` order by id desc;", this.Number, id);
                this.Number = this.Number;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.Id = Convert.ToInt32(reader["Id"].ToString());
                    break;
                }
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }
        public Human Human { set { HumanId = value.Id; } get { return Other.Human.GetHumans(HumanId)[0]; } }
        /// <summary>
        /// Выдает все телефоны, которые пренадлежат человеку
        /// </summary>
        /// <param name="human">Человек</param>
        /// <returns>Масив телефонов</returns>
        static public Phone[] GetPhonesByHumanId(Human human)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Phone where HumanId='{0}'", human.Id.ToString());
                var reader = command.ExecuteReader();
                List<Phone> s = new List<Phone>();
                while (reader.Read())
                {
                    s.Add(new Phone() { Id = Convert.ToInt32(reader["Id"].ToString()), Number = reader["Number"].ToString() });
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
