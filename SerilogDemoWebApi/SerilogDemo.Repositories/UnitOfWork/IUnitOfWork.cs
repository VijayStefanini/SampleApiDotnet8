using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using System;
    using System.Threading.Tasks;

namespace SerilogDemo.Repositories.UnitOfWork
{
    using SerilogDemo.Data.Entities;
    //public interface IUnitOfWork
    //{
    //    IGuestRepository Guests { get; }
    //    void Commit();
    //}


    public interface IUnitOfWork : IDisposable
    {
        IGuestRepository Guests { get; }
        Task<int> CompleteAsync();
    }
}
