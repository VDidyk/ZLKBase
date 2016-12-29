using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templates;
namespace Contacts
{
    /// <summary>
    /// Телефон
    /// </summary>
    public class Phone:iPhone
    {
        /// <summary>
        /// ИД
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// Телефонный номер
        /// </summary>
        public string Number { set; get; }
    }
    /// <summary>
    /// Email
    /// </summary>
    public class Email: iEmail
    {
        /// <summary>
        /// Email
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// Емеил
        /// </summary>
        public string Name { set; get; }
    }
}
