using System;

namespace VideoMenuDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }
        IGenreRepository GenreRepository { get; }
        int Complete();
    }
}
