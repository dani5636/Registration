using System.Collections.Generic;
using VideoMenuBLL.BusinessObjects;

namespace VideoMenuBLL
{
    public interface IGenreService
    {
        //C
        bool CreateGenre(GenreBO g);
        //R
        List<GenreBO> GetAllGenre();
        GenreBO GetGenreById(int id);
        List<GenreBO> SearchGenres(string str);
        //U
        void UpdateGenre(GenreBO g);
        //D
        bool DeleteGenre(int id);
        GenreBO GetGenreByName(string str);
    }
}
