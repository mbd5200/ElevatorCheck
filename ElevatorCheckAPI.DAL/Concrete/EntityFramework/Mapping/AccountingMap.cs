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
    public class AccountingMap:BaseMap<Accounting>
    {
        public override void Configure(EntityTypeBuilder<Accounting> builder)
        {
            builder.ToTable("Accounting");
            builder.HasOne(q => q.Structure).WithMany(q => q.Accountings).HasForeignKey(q => q.StructureID).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
