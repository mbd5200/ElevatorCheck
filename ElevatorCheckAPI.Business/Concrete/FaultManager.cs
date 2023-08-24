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
    public class FaultManager : IFaultService
    {
        private readonly IUnitOfWork _uow;

        public FaultManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Fault> AddAsync(Fault Entity)
        {
            await _uow.FaultRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Fault>> GetAllAsync(Expression<Func<Fault, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.FaultRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Fault> GetAsync(Expression<Func<Fault, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.FaultRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Fault Entity)
        {
            await _uow.FaultRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Fault Entity)
        {
            await _uow.FaultRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
