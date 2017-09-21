using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL.Services;
using VideoMenuDAL;

namespace VideoMenuBLL
{
    public class BLLFacade
    {
       
        public IVideoService VideoService
        {
            get
            { return new VideoService(new DALFacade());}
        }
        
    }
}
