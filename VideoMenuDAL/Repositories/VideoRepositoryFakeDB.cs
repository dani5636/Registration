using System;
using System.Collections.Generic;
using System.Linq;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repositories
{
    class VideoRepositoryFakeDB : IVideoRepository
    {
        #region fakeDB

        #endregion
        private static int Id = 0;
        private static List<Video> Videos = new List<Video>();

        public void CreateVideo(Video v)
        {
            Videos.Add(new Video()
            {
                Id = ++Id,
                Genre = v.Genre,
                Name = v.Name
            });
        }

        public bool DeleteVideo(int id)
        {
            var vid = GetVideoById(id);
            if (vid != null)
            {
                Videos.Remove(vid);
                return true;
            }
            return false;
        }

        public List<Video> GetAllVideos()
        {
            return Videos;
        }

        public Video GetVideoById(int id)
        {
            return Videos.FirstOrDefault(x => x.Id == id);
        }
    }
}
