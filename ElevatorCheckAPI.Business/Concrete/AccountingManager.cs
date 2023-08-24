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
    public class AccountingManager : IAccountingService
    {
        private readonly IUnitOfWork _uow;

        public AccountingManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Accounting> AddAsync(Accounting Entity)
        {
            await _uow.AccountingRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Accounting>> GetAllAsync(Expression<Func<Accounting, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.AccountingRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Accounting> GetAsync(Expression<Func<Accounting, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.AccountingRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Accounting Entity)
        {
            await _uow.AccountingRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Accounting Entity)
        {
            await _uow.AccountingRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
