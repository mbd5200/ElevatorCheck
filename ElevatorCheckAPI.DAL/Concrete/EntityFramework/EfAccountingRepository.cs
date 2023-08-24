using ElevatorCheckAPI.DAL.Abstract;
using ElevatorCheckAPI.DAL.Concrete.EntityFramework.DataManagement;
using ElevatorCheckAPI.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorCheckAPI.DAL.Concrete.EntityFramework
{
    public class EfAccountingRepository : EfRepository<Accounting>, IAccountingRepository
    {
        public EfAccountingRepository(DbContext context) : base(context)
        {
        }
    }
}
