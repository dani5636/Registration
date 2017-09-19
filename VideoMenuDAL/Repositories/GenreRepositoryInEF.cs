using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuDAL.Context;
using VideoMenuDAL.Entities;

namespace VideoMenuDAL.Repositories
{
    class GenreRepositoryInEF : IGenreRepository
    {
        InMemoryContext context;

        public GenreRepositoryInEF(InMemoryContext context) 
            {
                this.context = context;
            }
        
        public void CreateGenre(Genre g)
        {
            context.Genres.Add(g);
        }

        public bool DeleteGenre(int id)
        {
            var gen = GetGenreById(id);
            if (gen != null)
            {
                context.Genres.Remove(gen);
                return true;
            }
            return false;

        }

        public List<Genre> GetAllGenres()
        {
            return context.Genres.ToList();
        }

        public Genre GetGenreById(int id)
        {
            return context.Genres.FirstOrDefault(x => x.Id == id);
        }

    }
}

