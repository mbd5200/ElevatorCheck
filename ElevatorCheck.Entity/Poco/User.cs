using ElevatorCheckAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.Entity.Poco
{
    //Bakımcı bilgileri
    public class User:AuditableEntity
    {

        public User()
        {
            Structures = new HashSet<Structure>();
        }

        public string NameSurname { get; set; }

        public string Username { get; set;}

        public string Password { get; set;}

        public string Phone { get; set;}

        public string Company { get; set; }

        public virtual IEnumerable<Structure> Structures { get; set; }

    }
}
