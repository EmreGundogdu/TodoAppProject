using DataAccess.Concrete;
using DataAccess.Contexts;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoContext _context;

        public UnitOfWork(TodoContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class, new()
        {
            return new GenericRepository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
