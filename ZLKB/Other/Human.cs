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
    public class Human
    {
        private MySqlConnection con;
        public int Id { set; get; }
        public string FName { set; get; }
        public string LName { set; get; }
        public string MName { set; get; }
        public DateTime Date { set; get; }
        public DateTime? BirthdayDate { set; get; }
        public int AddressId { set; get; }
        public string Photopass { set; get; }
        public List<int> PhonesId { set; get; }
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public Human()
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
        public Human(string FName, string LName, string MName, DateTime? BirthdayDate, Address Address, string Photopass, List<string> Phones)
        {
            try
            {
                Date = DateTime.Now;
                string bd = "";
                string address = "";
                this.FName = FName;
                this.LName = LName;
                this.MName = MName;
                this.BirthdayDate = BirthdayDate;
                this.Address = Address;
                this.Photopass = Photopass;
                if (BirthdayDate != null)
                {
                    bd = BirthdayDate.ToString();
                }
                if (Address != null)
                {
                    address = Address.Id.ToString();
                }
                DataBaseWorker db = new DataBaseWorker();
                con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("INSERT INTO `Human`( `FName`, `LName`, `MName`, `Birthday`, `AddressId`, `PhotoPath`, `CreateDate`) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}') SELECT * FROM `Human` order by id desc; ", FName, LName, MName, bd, address, Photopass, Date.ToString());
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    this.Id = Convert.ToInt32(reader["Id"].ToString());
                    break;
                }
                if (Phones != null)
                {
                    foreach (var i in Phones)
                    {
                        Phone p = new Phone(i, this);
                    }
                }
                con.Close();
            }
            catch (Exception error)
            {

            }
        }
        /// <summary>
        /// Выдает массив всех людей, которые есть в БД
        /// </summary>
        /// <returns>Массив людей</returns>
        static public Human[] GetHumans()
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Human");
                var reader = command.ExecuteReader();
                List<Human> s = new List<Human>();
                while (reader.Read())
                {
                    s.Add(new Human() { Id = Convert.ToInt32(reader["Id"].ToString()), FName = reader["FName"].ToString(), LName = reader["LName"].ToString(), MName = reader["MName"].ToString(), Date = Convert.ToDateTime(reader["CreateDate"].ToString()), BirthdayDate = Convert.ToDateTime(reader["Birthday"].ToString()), AddressId = Convert.ToInt32(reader["AddressId"].ToString()), Photopass = reader["PhotoPath"].ToString() });
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
        /// Возвращает масив людей, по Id. Если такого ID нету, то метод возвращает Null
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Масив людей</returns>
        static public Human[] GetHumans(int id)
        {
            try
            {
                DataBaseWorker db = new DataBaseWorker();
                MySqlConnection con = db.con;
                MySqlCommand command = con.CreateCommand();
                command.CommandText = string.Format("Select * from Address where Id={0}", id.ToString());
                var reader = command.ExecuteReader();
                List<Human> s = new List<Human>();
                while (reader.Read())
                {
                    s.Add(new Human() { Id = Convert.ToInt32(reader["Id"].ToString()), FName = reader["FName"].ToString(), LName = reader["LName"].ToString(), MName = reader["MName"].ToString(), Date = Convert.ToDateTime(reader["CreateDate"].ToString()), BirthdayDate = Convert.ToDateTime(reader["Birthday"].ToString()), AddressId = Convert.ToInt32(reader["AddressId"].ToString()), Photopass = reader["PhotoPath"].ToString() });
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
        public Address Address { set { AddressId = value.Id; } get { return Other.Address.GetAddresses(this.AddressId)[0]; } }
        /// <summary>
        /// Все телефоны человека
        /// </summary>
        public List<Phone> Phones
        {
            get
            {
               return Other.Phone.GetPhonesByHumanId(this).ToList();   
            }
        }
    }
}
