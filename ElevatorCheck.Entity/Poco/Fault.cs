using ElevatorCheckAPI.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.Entity.Poco
{

    //Bina adı, Arıza tarihi, Arıza giderilme tarihi, Arıza tamamlandı düğmesi
    public class Fault:AuditableEntity
    {
        public int StructureID { get; set; }

        public string FaultDate { get; set; }

        public string RepairDate { get; set; }

        public virtual Structure Structure { get; set; }
    }
}
