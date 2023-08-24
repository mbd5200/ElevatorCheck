using ElevatorCheckAPI.DAL.Abstract.DataManagement;
using ElevatorCheckAPI.DAL.Abstract;
using ElevatorCheckAPI.DAL.Concrete.EntityFramework.Context;
using ElevatorCheckAPI.Entity.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.DAL.Concrete.EntityFramework.DataManagement
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ElevatorContext _elevatorContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EfUnitOfWork(ElevatorContext elevatorContext, IHttpContextAccessor httpContextAccessor)
        {
            _elevatorContext = elevatorContext;
            _httpContextAccessor = httpContextAccessor;
            UserRepository = new EfUserRepository(_elevatorContext);
            MaintenanceRepository = new EfMaintenanceRepository(_elevatorContext);
            FaultRepository = new EfFaultRepository(_elevatorContext);
            ManagerRepository = new EfManagerRepository(_elevatorContext);
            AccountingRepository= new EfAccountingRepository(_elevatorContext);
            StructureRepository = new EfStructureRepository(_elevatorContext);
            
        }

        public IUserRepository UserRepository { get; }
        public IAccountingRepository AccountingRepository { get; }
        public IFaultRepository FaultRepository { get; }
        public IMaintenanceRepository MaintenanceRepository { get; }
        public IStructureRepository StructureRepository { get; }
        public IManagerRepository ManagerRepository { get; }

        public async Task<int> SaveChangeAsync()
        {
            foreach (EntityEntry<AuditableEntity> item in _elevatorContext.ChangeTracker.Entries<AuditableEntity>())
            {
                if (item.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    item.Entity.AddedTime = DateTime.Now;
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.AddedUser = 1;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.Guid = Guid.NewGuid();
                    item.Entity.AddedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    item.Entity.UpdatedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                    if (item.Entity.IsActive == null)
                    {
                        item.Entity.IsActive = true;
                    }
                    item.Entity.IsDeleted = false;
                }

                else if (item.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
                {
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.UpdatedIPV4Adress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                }
            }
            return await _elevatorContext.SaveChangesAsync();
        }
    }
}
