using SerilogDemo.Data.DBContexts;
using SerilogDemo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogDemo.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IGuestRepository Guests { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Guests = new GuestRepository(context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
    //public class UnitOfWork : IUnitOfWork
    //{
    //    public IGuestRepository Guests { get; }

    //    public UnitOfWork(IGuestRepository guestRepository)
    //    {
    //        Guests = guestRepository;
    //    }

    //    public void Commit()
    //    {
    //        // Here we would commit changes to the database in a real-world scenario.
    //    }
    //}
}
