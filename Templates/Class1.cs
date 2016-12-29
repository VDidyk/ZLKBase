using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    /// <summary>
    /// Интерфейс Человек
    /// </summary>
    public interface iHuman
    {
        /// <summary>
        /// ИД
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Имя
        /// </summary>
        string FName { set; get; }
        /// <summary>
        /// Фамилия
        /// </summary>
        string LName { set; get; }
        /// <summary>
        /// Отчество
        /// </summary>
        string MName { set; get; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        DateTime? BirthDay { set; get; }
        /// <summary>
        /// Путь к фото
        /// </summary>
        string Photo { set; get; }
        /// <summary>
        /// Адресс
        /// </summary>
        iAddress Address { set; get; }
        /// <summary>
        /// Телефоны
        /// </summary>
        ICollection<iPhone> Phones { set; get; }
        /// <summary>
        /// Возвращает строку Имя и Фамилию
        /// </summary>
        /// <returns>Возвращает строку Имя и Фамилию</returns>
        string GetShortName();
        /// <summary>
        /// Возвращает строку Имя и Фамилию и Отчество
        /// </summary>
        /// <returns>Возвращает строку Имя и Фамилию и Отчество</returns>
        string GetLongName();
    }
    /// <summary>
    /// Интерфейс область
    /// </summary>
    public interface iRegion
    {
        /// <summary>
        /// ИД
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Название
        /// </summary>
        string Name { set; get; }
    }
    /// <summary>
    /// Интерфейс города
    /// </summary>
    public interface iCity
    {
        /// <summary>
        /// ИД
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Название
        /// </summary>
        string Name { set; get; }
        /// <summary>
        /// Область
        /// </summary>
        iRegion Region { set; get; }
        /// <summary>
        /// Код города
        /// </summary>
        string Code { set; get; }
    }
    /// <summary>
    /// Интерфейс адресс
    /// </summary>
    public interface iAddress
    {
        /// <summary>
        /// ИД
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Город
        /// </summary>
        iCity City { set; get; }
        /// <summary>
        /// Название улицы
        /// </summary>
        string Street { set; get; }
        /// <summary>
        /// Номер дома
        /// </summary>
        string HouseNumber { set; get; }
        /// <summary>
        /// Номер квартиры
        /// </summary>
        string Flat { set; get; }
        /// <summary>
        /// Разрешается ли показывать информацию
        /// </summary>
        bool AlowShowInformation { set; get; }
        /// <summary>
        /// Возвращает строку с информацией про адресс
        /// </summary>
        /// <returns></returns>
        string GetAddressInformatin();
    }
    /// <summary>
    /// Интерфейс телефонный номер
    /// </summary>
    public interface iPhone
    {
        /// <summary>
        /// ИД
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Телефонный номер
        /// </summary>
        string Number { set; get; }
    }
    /// <summary>
    /// Интерфейс пользователь
    /// </summary>
    public interface iUser
    {
        /// <summary>
        /// ИД
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Человек
        /// </summary>
        iHuman Human { set; get; }
        /// <summary>
        /// Логин
        /// </summary>
        string Login { set; get; }
        /// <summary>
        /// Пароль
        /// </summary>
        string Password { set; get; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        DateTime? RegisterDate { set; get; }
        /// <summary>
        /// Админ или нет
        /// </summary>
        bool Admin { set; get; }
        /// <summary>
        /// Должность
        /// </summary>
        iPosition Position { set; get; }
    }
    /// <summary>
    /// Интерфейс Должность
    /// </summary>
    public interface iPosition
    {
        /// <summary>
        /// ИД
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Название
        /// </summary>
        string Name { set; get; }
        /// <summary>
        /// ДатаСоздания
        /// </summary>
        DateTime? CreationDate { set; get; }
    }
    /// <summary>
    /// Интерфейс скидка
    /// </summary>
    public interface iDiscount
    {
        /// <summary>
        /// ИД
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// На что скидка
        /// </summary>
        string Product { set; get; }
        /// <summary>
        /// Значение
        /// </summary>
        string Value { set; get; }
    }
    /// <summary>
    /// Интерфейс клиента
    /// </summary>
    public interface iClientHuman
    {
        /// <summary>
        /// ИД
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Человек
        /// </summary>
        iHuman Human { set; get; }
        /// <summary>
        /// Пользователь, который добавил клиента
        /// </summary>
        iUser User { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime? CreationDate { set; get; }
        /// <summary>
        /// Заметка
        /// </summary>
        string Notice { set; get; }
        /// <summary>
        /// Платильщик НДС
        /// </summary>
        bool VAT { set; get; }
        /// <summary>
        /// Скидки
        /// </summary>
        ICollection<iDiscount> Discounts { set; get; }
        /// <summary>
        /// Ресурс
        /// </summary>
        iResourse Resourse { set; get; }
        /// <summary>
        /// Email
        /// </summary>
        iEmail Email { set; get; }
        /// <summary>
        /// Оборот
        /// </summary>
        double Turnover { set; get; }
    }
    /// <summary>
    /// Интерфейс клиента-компании
    /// </summary>
    public interface iClientCompany
    {
        /// <summary>
        /// ИД
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Клиенты-Человеки
        /// </summary>
        ICollection<iClientHuman> ClientHumans { set; get; }
        /// <summary>
        /// Пользователь, который добавил клиента
        /// </summary>
        iUser User { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime? CreationDate { set; get; }
        /// <summary>
        /// Заметка
        /// </summary>
        string Notice { set; get; }
        /// <summary>
        /// Платильщик НДС
        /// </summary>
        bool VAT { set; get; }
        /// <summary>
        /// Скидки
        /// </summary>
        ICollection<iDiscount> Discounts { set; get; }
        /// <summary>
        /// Ресурс
        /// </summary>
        iResourse Resourse { set; get; }
        /// <summary>
        /// Email
        /// </summary>
        iEmail Email { set; get; }
        /// <summary>
        /// Чем занимается
        /// </summary>
        string Ocupation { set; get; }
        /// <summary>
        /// Оборот
        /// </summary>
        double Turnover { set; get; }
    }
    /// <summary>
    /// Интерфейс добавления в ресурсы
    /// </summary>
    public interface iAdditionToResourse
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Клиент
        /// </summary>
        iClientHuman Client { set; get; }
        /// <summary>
        /// Дата добавления
        /// </summary>
        DateTime? Dateofaddition { set; get; }

    }
    /// <summary>
    /// Интерфейс ресурса
    /// </summary>
    public interface iResourse
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Название
        /// </summary>
        string Name { set; get; }
        /// <summary>
        /// Пользователь, который создал
        /// </summary>
        iUser User { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime? Creationdate { set; get; }
    }
    /// <summary>
    /// Интерфейс Email
    /// </summary>
    public interface iEmail
    {
        /// <summary>
        /// Email
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Емеил
        /// </summary>
        string Name { set; get; }
    }
    /// <summary>
    /// Интерфейс счета
    /// </summary>
    public interface iBill
    {
        /// <summary>
        /// ИД
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Имя счета
        /// </summary>
        string Name { set; get; }
        /// <summary>
        /// Дата создания счета
        /// </summary>
        DateTime? Dateofbill { set; get; }
        /// <summary>
        /// Дата добавления счета
        /// </summary>
        DateTime? Dateofcreation { set; get; }
    }
    /// <summary>
    /// Интерфейс Процесс выполнения запроса
    /// </summary>
    public interface iProcess
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Имя
        /// </summary>
        string Name { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime? Dateofcreation { set; get; }
        /// <summary>
        /// Кто создал
        /// </summary>
        iUser User { set; get; }
    }
    /// <summary>
    /// Интерфейс История выполнения запроса
    /// </summary>
    public interface iHistory
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Текст
        /// </summary>
        string Text { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime DateofCreation { set; get; }
        /// <summary>
        /// Пользователь
        /// </summary>
        iUser User { set; get; }
    }
    /// <summary>
    /// Интерфейс Отправитель перевозщиков
    /// </summary>
    public interface iSender
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Телефоны
        /// </summary>
        ICollection<iPhone> phones { set; get; }
        /// <summary>
        /// Имя (название)
        /// </summary>
        string Name { set; get; }
        /// <summary>
        /// Кто создал
        /// </summary>
        iUser User { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime? Dateofcreation { set; get; }
    }
    /// <summary>
    /// Отделение перевозщика
    /// </summary>
    public interface iOffice
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Кто добавил
        /// </summary>
         iUser User { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime Dateofcreation { set; get; }
        /// <summary>
        /// Номер отделения
        /// </summary>
        string Number { set; get; }
        /// <summary>
        /// Адресс
        /// </summary>
        iAddress Address { set; get; }
        /// <summary>
        /// Телефоны
        /// </summary>
        ICollection<iPhone> Phones { set; get; }
        /// <summary>
        /// Перевозщик
        /// </summary>
        iDeliver Deliver { set; get; }
    }
    /// <summary>
    /// Интерфейс Перевозщик
    /// </summary>
    public interface iDeliver
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Кто добавил
        /// </summary>
        iUser User { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime Dateofcreation { set; get; }
        /// <summary>
        /// Название
        /// </summary>
        string Name { set; get; }
        /// <summary>
        /// Отделения
        /// </summary>
        ICollection<iOffice> Offices { set; get; }
    }
    /// <summary>
    /// Интерфейс Процесс выполнения отправки
    /// </summary>
    public interface iShippingProcess
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Имя
        /// </summary>
        string Name { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime? Dateofcreation { set; get; }
        /// <summary>
        /// Кто создал
        /// </summary>
        iUser User { set; get; }
    }
    /// <summary>
    /// Интерфейс отправки
    /// </summary>
    public interface iShipping
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Кто добавил
        /// </summary>
        iUser User { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime Dateofcreation { set; get; }
        /// <summary>
        /// Клиент человек
        /// </summary>
        iClientHuman ClientHuman { set; get; }
        /// <summary>
        /// Клиент Компания
        /// </summary>
        iClientCompany ClientCompany { set; get; }
        /// <summary>
        /// Город
        /// </summary>
        iCity City { set; get; }
        /// <summary>
        /// Перевозщик
        /// </summary>
        iDeliver Deliver { set; get; }
        /// <summary>
        /// Отправитель
        /// </summary>
        iSender Sender { set; get; }
        /// <summary>
        /// Телефон
        /// </summary>
        iPhone Phone { set; get; }
        /// <summary>
        /// Пометка
        /// </summary>
        string Notice { set; get; }
        /// <summary>
        /// Процесс отправки
        /// </summary>
        iShippingProcess ShippingProcess { set; get; }
        /// <summary>
        /// Закрыть отправку
        /// </summary>
        void Close();

    }
    /// <summary>
    /// Интерфейс запроса
    /// </summary>
    public interface iRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime? Dateofcreation { set; get; }
        /// <summary>
        /// Кто создал
        /// </summary>
        iUser User { set; get; }
        /// <summary>
        /// Клиент компания
        /// </summary>
        iClientCompany ClientCompany { set; get; }
        /// <summary>
        /// Клиент человек
        /// </summary>
        iClientHuman iClientHuman { set; get; }
        /// <summary>
        /// Отправки
        /// </summary>
        ICollection<iShipping> Shippings { set; get; }
        /// <summary>
        /// Процесс
        /// </summary>
        iProcess Process { set; get; }
        /// <summary>
        /// История
        /// </summary>
        ICollection<iHistory> Histories { set; get; }
        /// <summary>
        /// Счет
        /// </summary>
        ICollection<iBill> Bills { set; get; }
        /// <summary>
        /// Добавить историю
        /// </summary>
        /// <param name="date">Дата</param>
        /// <param name="user">Пользователь</param>
        /// <param name="text">Текст</param>
        void Addhistory(DateTime date, iUser user, string text);
        
    }
    /// <summary>
    /// Категория поставщика
    /// </summary>
    public interface iCategory
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime? Dateofcreation { set; get; }
        /// <summary>
        /// Кто создал
        /// </summary>
        iUser User { set; get; }
        /// <summary>
        /// Название
        /// </summary>
        string Name { set; get; }
    }
    /// <summary>
    /// Интерфейс менеджера поставщика
    /// </summary>
    public interface iManager
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime? Dateofcreation { set; get; }
        /// <summary>
        /// Кто создал
        /// </summary>
        iUser User { set; get; }
        /// <summary>
        /// Человек
        /// </summary>
        iHuman Human { set; get; }
        /// <summary>
        /// Телефоны
        /// </summary>
        ICollection<iPhone> Phones { set; get; }
        /// <summary>
        /// Должность
        /// </summary>
        iPosition Position { set; get; }
        /// <summary>
        /// Язык
        /// </summary>
        string Language { set; get; }
        /// <summary>
        /// Заметка
        /// </summary>
        string Notice { set; get; }
        /// <summary>
        /// Email
        /// </summary>
        iEmail Email { set; get; }
    }
    /// <summary>
    /// Интерфейс поставщика
    /// </summary>
    public interface iSupplier
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime? Dateofcreation { set; get; }
        /// <summary>
        /// Кто создал
        /// </summary>
        iUser User { set; get; }
        /// <summary>
        /// Название
        /// </summary>
        string Name { set; get; }
        /// <summary>
        /// Адресс
        /// </summary>
        iAddress Address { set; get; }
        /// <summary>
        /// Менеджеры
        /// </summary>
        ICollection<iManager> Managers { set; get; }
        /// <summary>
        /// Категории
        /// </summary>
        ICollection<iCategory> Categories { set; get; }
        /// <summary>
        /// Сайт
        /// </summary>
        string Site { set; get; }
        /// <summary>
        /// Пометка
        /// </summary>
        string Notice { set; get; }
        /// <summary>
        /// Email
        /// </summary>
        iEmail Email { set; get; }
        /// <summary>
        /// Перевозщики
        /// </summary>
        ICollection<iOffice> Office { set; get; }
        /// <summary>
        /// Файлы
        /// </summary>
        ICollection<iFile> Files { set; get; }
       
    }
    /// <summary>
    /// Файл
    /// </summary>
    public interface iFile
    {
        /// <summary>
        /// ID
        /// </summary>
        int ID { set; get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime? Dateofcreation { set; get; }
        /// <summary>
        /// Кто создал
        /// </summary>
        iUser User { set; get; }
        /// <summary>
        /// Путь к файлу
        /// </summary>
        string Path { set; get; }
        /// <summary>
        /// Расширение
        /// </summary>
        string Extension { set; get; }
    }
   
}
