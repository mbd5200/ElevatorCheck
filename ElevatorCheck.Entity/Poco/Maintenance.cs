using ElevatorCheckAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.Entity.Poco
{

    //Bina adı, Son bakım tarihi, Sonraki bakım tarihi, Detay 
    public class Maintenance:AuditableEntity
    {
        public int StructureID { get; set; }

        public string LastMaintenanceDate { get; set; } //Son bakım yapılan tarih

        public string RemainingDate { get; set; } // Sonraki bakım tarihi 

        public virtual Structure Structure { get; set; }
    }
}
