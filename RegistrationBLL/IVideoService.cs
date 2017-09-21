using System;
using System.Collections.Generic;
using System.Text;
using RegistrationBLL.BusinessObjects;

namespace RegistrationBLL
{
   public interface IVideoService
    {
        //C
        void CreateVideo(VideoBO v);
        void CreateMultipleVideos(List<VideoBO> videos);
        //R
        List<VideoBO> GetAllVideos();
        VideoBO GetVideoById(int id);
        List<VideoBO> SearchVideos(string str);
        //U
        void UpdateVideo(VideoBO v);
        //D
        bool DeleteVideo(int id);
    }
}
