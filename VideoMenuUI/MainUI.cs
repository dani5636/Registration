using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;
using static System.Console;
namespace VideoMenuUI
{
    class MainUI
    {
        static BLLFacade bllFacade = new BLLFacade();

        static void Main(string[] args)
        {
            //Fills the database with mockdata
            
            FillDatabaseWithGenres();
            FillDatabaseWithVideos();
            //This should be removed at the end of project
            #region Menu Items
            string[] menuItems =
            {
                "Genres",
                "Videos",
                "Exit"
            };
            #endregion

            #region Menu Switch
            var selection = ExtraUI.ShowMenu(menuItems);
            while (selection != 3)
            {
                switch (selection)
                {
                    case 1:
                        GenreUI.GenreMenu();
                        break;
                    case 2:
                        VideoUI.VideoMenu();
                        break;

                }
                selection = ExtraUI.ShowMenu(menuItems);


            }
            #endregion
            WriteLine("Press enter to close the program");
            ReadLine();

        }
        private static void FillDatabaseWithVideos()
        {
            #region Filling Video List

            bllFacade.VideoService.CreateVideo(new VideoBO
            {
                Genre = "Horror",
                Name = "The Ring"
            });


            bllFacade.VideoService.CreateVideo(new VideoBO
            {
                Genre = "Comedy",
                Name = "Dr. Doolittle"
            });
            bllFacade.VideoService.CreateVideo(new VideoBO
            {
                Genre = "Action",
                Name = "Spider Man: Homecoming"
            });

            #endregion}
        }
        private static void FillDatabaseWithGenres()
        {
            bllFacade.GenreService.CreateGenre(new GenreBO
            {
                Name = "Horror"
            });
            bllFacade.GenreService.CreateGenre(new GenreBO
            {
                Name = "Action"
            });
            bllFacade.GenreService.CreateGenre(new GenreBO
            {
                Name = "Drama"
            });
            bllFacade.GenreService.CreateGenre(new GenreBO
            {
                Name = "Sci-Fi"
            });
            bllFacade.GenreService.CreateGenre(new GenreBO
            {
                Name = "Comedy"
            });
        }
    }
}
