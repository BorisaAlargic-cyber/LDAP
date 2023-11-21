using System;
namespace IIS.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
