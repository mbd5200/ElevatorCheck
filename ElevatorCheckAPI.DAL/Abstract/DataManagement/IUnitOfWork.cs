using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.DAL.Abstract.DataManagement
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IMaintenanceRepository MaintenanceRepository { get; }

        IAccountingRepository AccountingRepository { get; }

        IFaultRepository FaultRepository { get; }

        IManagerRepository ManagerRepository { get; }

        IStructureRepository StructureRepository { get; }

        Task<int> SaveChangeAsync();





    }
}
