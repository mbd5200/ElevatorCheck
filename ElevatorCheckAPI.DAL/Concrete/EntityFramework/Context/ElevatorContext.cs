using ElevatorCheckAPI.DAL.Concrete.EntityFramework.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.DAL.Concrete.EntityFramework.Context
{
    public class ElevatorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "data source=.\\SQLEXPRESS; initial catalog=ElevatorCheckDB; integrated security=True; TrustServerCertificate=true");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountingMap());
            modelBuilder.ApplyConfiguration(new FaultMap());
            modelBuilder.ApplyConfiguration(new MaintenanceMap());
            modelBuilder.ApplyConfiguration(new ManagerMap());
            modelBuilder.ApplyConfiguration(new StructureMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
