using System;

namespace RegistrationDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }
        int Complete();
    }
}
