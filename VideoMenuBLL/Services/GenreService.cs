using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuBLL.BusinessObjects;
using VideoMenuBLL.Converters;
using VideoMenuDAL;
using VideoMenuDAL.Entities;

namespace VideoMenuBLL.Services
{
    class GenreService : IGenreService
    {
        GenreConverter conv = new GenreConverter();
        DALFacade facade;
        public GenreService(DALFacade facade)
        {
            this.facade = facade;
        }

        public bool CreateGenre(GenreBO g)
        {
            bool success = false;
            using (var uow = facade.UnitOfWork)
            {
                if(uow.GenreRepository.GetAllGenres().FirstOrDefault(x => x.Name.ToLower().Equals(g.Name.ToLower())) == null)
                {
                    uow.GenreRepository.CreateGenre(conv.Convert(g));
                    success = true;
                    uow.Complete();
                }
                return success;
            }
        }

        public bool DeleteGenre(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var result = uow.GenreRepository.DeleteGenre(id);
                uow.Complete();
                return result;
            }
        }

        public List<GenreBO> GetAllGenre()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.GenreRepository.GetAllGenres().Select(g => conv.Convert(g)).ToList();
            }
        }

        public GenreBO GetGenreById(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.GenreRepository.GetGenreById(id));
            }
        }
        public GenreBO GetGenreByName(string str)
        {
            using (var uow = facade.UnitOfWork)
            {
               var genre = uow.GenreRepository.GetAllGenres().FirstOrDefault(x=> x.Name.ToLower().Equals(str.ToLower()));
               return conv.Convert(genre);
            }
            
        }

        public List<GenreBO> SearchGenres(string str)
        {
            var searchTerm = str.ToLower();
            bool intExist = false;
            if (int.TryParse(searchTerm, out int searchId))
            {
                intExist = true;
            }
            var searchedVideos = GetAllGenre().Where(x =>
                        x.Name.ToLower().Contains(searchTerm)
                        || (intExist && x.Id == searchId)).ToList();


            return searchedVideos;
        }

        public void UpdateGenre(GenreBO g)
        {
            using (var uow = facade.UnitOfWork)
            {
                var vidFromDB = uow.GenreRepository.GetGenreById(g.Id);
                if (vidFromDB == null)
                {
                    throw new InvalidOperationException("Genre Not Found");
                }
                vidFromDB.Name = g.Name;
                uow.Complete();
            }
        }
        

    }
}
