using ElevatorCheckAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.Entity.Poco
{

    //Bina yöneticisi Bilgileri.. Adı, Telefonu, Bina adresi, Bakım ücreti
    public class Manager:AuditableEntity
    {
        public int StructureID { get; set; }

        public string ManagerName { get; set; } // Bina yöneticisi adı, soyadı

        public string ManagerPhone { get; set; } // Telefonu


        public virtual Structure Structure { get; set; }
    }
}
