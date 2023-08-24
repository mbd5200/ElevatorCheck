using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.Entity.DTO.Structure
{
    public class StructureDTOBase
    {
        public Guid Guid { get; set; }
        public string StructureName { get; set; }
        public string Address { get; set; }
        public Guid UserGUID { get; set; }
        public string MaintenanceFee { get; set; }
        public string MaintenanceCompany { get; set; }

    }
}
