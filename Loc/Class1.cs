using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templates;
namespace Loc
{
    /// <summary>
    /// Область
    /// </summary>
    public class Region: iRegion
    {
        /// <summary>
        /// ИД
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { set; get; }
    }
    /// <summary>
    /// Город
    /// </summary>
    public class City: iCity
    {
        /// <summary>
        /// ИД
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Область
        /// </summary>
        public iRegion Region { set; get; }
        /// <summary>
        /// Код города
        /// </summary>
        public string Code { set; get; }
    }
    /// <summary>
    /// Адресс
    /// </summary>
    public class Address : iAddress
    {
        /// <summary>
        /// ИД
        /// </summary>
        public int ID { set; get; }
        /// <summary>
        /// Город
        /// </summary>
        public iCity City { set; get; }
        /// <summary>
        /// Название улицы
        /// </summary>
        public string Street { set; get; }
        /// <summary>
        /// Номер дома
        /// </summary>
        public string HouseNumber { set; get; }
        /// <summary>
        /// Номер квартиры
        /// </summary>
        public string Flat { set; get; }
        /// <summary>
        /// Разрешается ли показывать информацию
        /// </summary>
        public bool AlowShowInformation { set; get; }
        /// <summary>
        /// Возвращает строку с информацией про адресс
        /// </summary>
        /// <returns>Информация про адресс</returns>
        public string GetAddressInformatin()
        {
            if(AlowShowInformation==true)
            {
                return City.Region.Name + " область " + City.Name + ". Номер дома: " + HouseNumber + ", кв. " + Flat + ".";
            }
            else
            {
                return City.Region.Name + " область " + City.Name + ".";
            }
        }
    }
    
}
