using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.Entity.DTO.Maintenance
{
    public class MaintenanceDTOBase
    {
        public Guid Guid { get; set; }
        public string LastMaintenanceDate { get; set; }
        public string RemainingDate { get; set; }
        public Guid StructureGUID { get; set; }
        public string StructureName { get; set; }
    }
}
