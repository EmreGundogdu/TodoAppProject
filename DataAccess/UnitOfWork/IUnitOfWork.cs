using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : class, new();
        Task SaveChanges();
    }
}
