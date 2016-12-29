using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZLKB.UsersFolder
{
    public class User
    {
        public int Id { set; get; }    
        public string Login { set; get;}
        public string Password { set; get; }
        public DateTime? RegistationDate { set; get; }
        public bool Admin { set; get; }
        public Position UserPosition { set; get; }
    }
    public class Position
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
}
