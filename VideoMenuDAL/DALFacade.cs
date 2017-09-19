using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Repositories;
using VideoMenuDAL.UOW;

namespace VideoMenuDAL
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
