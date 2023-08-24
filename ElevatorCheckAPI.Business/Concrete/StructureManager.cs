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
    public class StructureManager : IStructureService
    {
        private readonly IUnitOfWork _uow;

        public StructureManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Structure> AddAsync(Structure Entity)
        {
            await _uow.StructureRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Structure>> GetAllAsync(Expression<Func<Structure, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.StructureRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Structure> GetAsync(Expression<Func<Structure, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.StructureRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Structure Entity)
        {
            await _uow.StructureRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Structure Entity)
        {
            await _uow.StructureRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
