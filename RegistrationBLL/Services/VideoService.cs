using System;
using System.Collections.Generic;
using System.Linq;
using RegistrationBLL.BusinessObjects;
using RegistrationBLL.Converters;
using RegistrationDAL;

namespace RegistrationBLL.Services
{
    class VideoService : IVideoService
    {
        VideoConverter conv = new VideoConverter();
        DALFacade Facade;
        public VideoService(DALFacade facade)
        {
            this.Facade = facade;
        }

        public void CreateMultipleVideos(List<VideoBO> videos)
        {
            using (var uow = Facade.UnitOfWork)
            {
                foreach (var v in videos)
                {
                    uow.VideoRepository.CreateVideo(conv.Convert(v));
                }
                uow.Complete();
            }
        }

        public void CreateVideo(VideoBO v)
        {
            using (var uow = Facade.UnitOfWork) {
                
                uow.VideoRepository.CreateVideo(conv.Convert(v));
                uow.Complete();
            }

        }

        public bool DeleteVideo(int id)
        {
            using (var uow = Facade.UnitOfWork)
            {
               var result =  uow.VideoRepository.DeleteVideo(id);
                uow.Complete();
                return result;
            }
        }

        public List<VideoBO> GetAllVideos()
        {
            using (var uow = Facade.UnitOfWork)
            {
                //Video -> VideoBO
                return uow.VideoRepository.GetAllVideos().Select(v => conv.Convert(v)).ToList();
                
            }
        }

        public VideoBO GetVideoById(int id)
        {
            using (var uow = Facade.UnitOfWork)
            {
                return conv.Convert(uow.VideoRepository.GetVideoById(id));

            }
        }

        public List<VideoBO> SearchVideos(string str)
        {


            var searchTerm = str.ToLower();
            bool intExist = false;
            if (int.TryParse(searchTerm, out int searchId))
            {
                intExist = true;
            }
            var searchedVideos = GetAllVideos().Where(x =>
                        x.Name.ToLower().Contains(searchTerm)
                        || x.Genre.ToLower().Contains(searchTerm)
                        || (intExist && x.Id == searchId)).ToList();


            return searchedVideos;
        }

        public void UpdateVideo(VideoBO v)
        {
            using (var uow = Facade.UnitOfWork)
            {
                var vidFromDB = uow.VideoRepository.GetVideoById(v.Id);
                if (vidFromDB == null)
                {
                    throw new InvalidOperationException("Video Not Found");
                }
                vidFromDB.Name = v.Name;
                vidFromDB.Genre = v.Genre;
                uow.Complete();
            }
          
        }
        
    }
}
