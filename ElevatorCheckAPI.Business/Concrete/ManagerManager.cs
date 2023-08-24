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
    public class ManagerManager : IManagerService
    {
        private readonly IUnitOfWork _uow;

        public ManagerManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Manager> AddAsync(Manager Entity)
        {
            await _uow.ManagerRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Manager>> GetAllAsync(Expression<Func<Manager, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.ManagerRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Manager> GetAsync(Expression<Func<Manager, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.ManagerRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Manager Entity)
        {
            await _uow.ManagerRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Manager Entity)
        {
            await _uow.ManagerRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
