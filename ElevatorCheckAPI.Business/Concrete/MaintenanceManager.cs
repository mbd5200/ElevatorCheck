using ElevatorCheckAPI.Business.Abstract;
using ElevatorCheckAPI.DAL.Abstract.DataManagement;
using ElevatorCheckAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.Business.Concrete
{
    public class MaintenanceManager : IMaintenanceService
    {
        private readonly IUnitOfWork _uow;

        public MaintenanceManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Maintenance> AddAsync(Maintenance Entity)
        {
            await _uow.MaintenanceRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Maintenance>> GetAllAsync(Expression<Func<Maintenance, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.MaintenanceRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Maintenance> GetAsync(Expression<Func<Maintenance, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.MaintenanceRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Maintenance Entity)
        {
            await _uow.MaintenanceRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Maintenance Entity)
        {
            await _uow.MaintenanceRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
