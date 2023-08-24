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
    public class UserMap:BaseMap<User>
    {

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(q => q.NameSurname).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Username).HasMaxLength(100).IsRequired();
            builder.Property(q => q.Password).HasMaxLength(100).IsRequired();

            builder.HasMany(q => q.Structures).WithOne(q => q.User).HasForeignKey(q => q.UserID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);


        }
    }
}
