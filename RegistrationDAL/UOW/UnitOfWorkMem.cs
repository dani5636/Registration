using System;
using System.Collections.Generic;
using System.Text;
using RegistrationDAL.Context;
namespace RegistrationDAL.UOW
{
    class UnitOfWorkMem : IUnitOfWork
    {
        private InMemoryContext context;
        public IVideoRepository VideoRepository { get; internal set; }
        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            VideoRepository = new VideoRepositoryEFMemory(context);
        }

        public int Complete()
        {
            //The number of objects writting to the database
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
