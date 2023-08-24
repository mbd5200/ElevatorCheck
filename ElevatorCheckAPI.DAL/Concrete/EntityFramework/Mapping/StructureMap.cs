using ElevatorCheckAPI.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using ElevatorCheckAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.DAL.Concrete.EntityFramework.Mapping
{
    public class StructureMap:BaseMap<Structure>
    {
        public override void Configure(EntityTypeBuilder<Structure> builder)
        {
            builder.ToTable("Structure");
        }
    }
}
