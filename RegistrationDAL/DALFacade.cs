using System;
using System.Collections.Generic;
using System.Text;
using RegistrationDAL.Repositories;
using RegistrationDAL.UOW;

namespace RegistrationDAL
{
    public class DALFacade
    {
        public IUnitOfWork UnitOfWork
        {
            //get { return new VideoRepositoryFakeDB(); }
            get { return new UnitOfWorkMem(); }
        }
      

    }
}
