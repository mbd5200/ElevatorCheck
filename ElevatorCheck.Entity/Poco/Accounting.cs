using ElevatorCheckAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.Entity.Poco
{

    //Bina adı, Bakım borcu, Arıza borcu
    public class Accounting:AuditableEntity
    {

        public int StructureID { get; set; } //Bağlı olduğu ID

        public double? MaintenanceDebt { get; set; } // Bakım Borcu

        public double? FaultDebt { get; set; } // Arıza borcu

        public virtual Structure Structure { get; set; }
    }
}
