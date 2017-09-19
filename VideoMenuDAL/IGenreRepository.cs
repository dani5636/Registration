using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL
{
   public interface IGenreRepository
    {
        //C
        void CreateGenre(Genre g);
        //R
        List<Genre> GetAllGenres();
        Genre GetGenreById(int id);
        //U
        //No update for the repository. Task of UoW
        //D
        bool DeleteGenre(int id);
    }
}
