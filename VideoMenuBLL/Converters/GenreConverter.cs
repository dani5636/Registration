using VideoMenuBLL.BusinessObjects;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Converters
{
    class GenreConverter
    {
        public GenreBO Convert(Genre g)
        {
            return new GenreBO
            {
                Id = g.Id,
                Name = g.Name
            };
        }
        public Genre Convert(GenreBO g)
        {
            return new Genre
            {
                Id = g.Id,
                Name = g.Name
            };
        }
    }
}
