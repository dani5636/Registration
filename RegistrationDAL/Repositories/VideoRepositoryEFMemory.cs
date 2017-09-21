using System.Collections.Generic;
using System.Linq;
using RegistrationDAL.Context;
using RegistrationDAL.Entities;

namespace RegistrationDAL.Repositories
{
    class VideoRepositoryEFMemory : IVideoRepository
    {
        InMemoryContext context;

        public VideoRepositoryEFMemory(InMemoryContext context)
        {
            this.context = context;
        }
        public void CreateVideo(Video v)
        {
            context.Videos.Add(v);
        }

        public bool DeleteVideo(int id)
        {
            var vid = GetVideoById(id);
            if (vid != null)
            {
                context.Videos.Remove(vid);
                return true;
            }
            return false;
        }

        public List<Video> GetAllVideos()
        {
            return context.Videos.ToList();
        }

        public Video GetVideoById(int id)
        {
            return context.Videos.FirstOrDefault(x => x.Id == id);
        }
    }
}
