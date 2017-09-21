using System;
using System.Collections.Generic;
using System.Text;
using RegistrationBLL.Services;
using RegistrationDAL;

namespace RegistrationBLL
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
