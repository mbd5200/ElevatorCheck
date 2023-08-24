using ElevatorCheckAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.Entity.Poco
{
    public class Structure:AuditableEntity
    {

        public Structure()
        {
            Maintenances = new HashSet<Maintenance>();
            Faults = new HashSet<Fault>();
            Managers = new HashSet<Manager>();
            Accountings = new HashSet<Accounting>();
        }

        public string StructureName { get; set; } // Bina adı

        public string Address { get; set; } // Bina adresi

        public string MaintenanceFee { get; set; } // Aylık bakım ücreti

        public string MaintenanceCompany { get; set; }  //Bakım firması adı

        public int UserID { get; set; }

        public virtual IEnumerable<Maintenance> Maintenances { get; set; }
        public virtual IEnumerable<Fault> Faults { get; set; }
        public virtual IEnumerable<Manager> Managers { get; set; }
        public virtual IEnumerable<Accounting> Accountings { get; set; }

        public virtual User User { get; set; }

    }
}
