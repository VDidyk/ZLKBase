using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templates;
namespace HumanLib
{
    /// <summary>
    /// Клас человека
    /// </summary>
    public class Human
    {
        /// <summary>
        /// ИД
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FName { set; get; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LName { set; get; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MName { set; get; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDay { set; get; }
        /// <summary>
        /// Путь к фото
        /// </summary>
        public string Photo { set; get; }
        /// <summary>
        /// Адресс
        /// </summary>
        public iAddress Address { set; get; }
        /// <summary>
        /// Телефоны
        /// </summary>
        public ICollection<iPhone> Phones { set; get; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Human()
        {
            Phones=new List<iPhone>();
        }
        /// <summary>
        /// Возвращает строку Имя и Фамилию
        /// </summary>
        /// <returns>Возвращает строку Имя и Фамилию</returns>
        string GetShortName()
        {
            return FName + " " + LName;
        }
        /// <summary>
        /// Возвращает строку Имя и Фамилию и Отчество
        /// </summary>
        /// <returns>Возвращает строку Имя и Фамилию и Отчество</returns>
        string GetLongName()
        {
            return FName + " " + LName+" "+MName;
        }
    }
}
