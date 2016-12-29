using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templates;
namespace UserWPFLib
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : iUser
    {
        /// <summary>
        /// ИД
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// Человек
        /// </summary>
        public iHuman Human { set; get; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { set; get; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { set; get; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime? RegisterDate { set; get; }
        /// <summary>
        /// Админ или нет
        /// </summary>
        public bool Admin { set; get; }
        /// <summary>
        /// Должность
        /// </summary>
        public iPosition Position { set; get; }
    }
    /// <summary>
    /// Класс Должность
    /// </summary>
    public class Position : iPosition
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// ДатаСоздания
        /// </summary>
        public DateTime? CreationDate { set; get; }

    }
}
