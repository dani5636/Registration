
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;
using static System.Console;

namespace VideoMenuUI
{
    class GenreUI
    {

        static BLLFacade bllFacade = new BLLFacade();

        public static void GenreMenu()
        {
            #region Menu Items
            string[] menuItems =
            {
                "Create a genre",
                "List all genres",
                "Change a genre",
                "Remove a genre",
                "Search in genres",
                "Back"
            };
            #endregion

            #region Menu Switch
            var selection = ExtraUI.ShowMenu(menuItems);
            while (selection != 6)
            {
                switch (selection)
                {
                    case 1:
                        CreateGenre();
                        break;
                    case 2:
                        ListAllGenres();
                        break;
                    case 3:
                        UpdateGenre();
                        break;
                    case 4:
                        RemoveGenre();
                        break;
                    case 5:
                        SearchGenres();
                        break;
                }
                WriteLine("Press Enter to go back to the menu");
                ReadLine();
                selection = ExtraUI.ShowMenu(menuItems);


            }
            #endregion
            WriteLine("Press Enter to return to the main menu");
            ReadLine();

        }

        private static void RemoveGenre()
        {
            int id;
            WriteLine("Input the id of the genre you would like to delete:(ID)");
            if (int.TryParse(ReadLine(), out id))
            {
                var result = bllFacade.GenreService.DeleteGenre(id) == true ? "Genre was succesfully deleted" : "Genre was not found";
                WriteLine(result);
            }
            else
            {
                WriteLine("Please input an id");
            }
        }

        private static void SearchGenres()
        {
            WriteLine("Search for Genres");
            var searchedGenres = bllFacade.GenreService.SearchGenres(ReadLine());

            WriteLine("Search Result");
            foreach (var genre in searchedGenres)
            {
                WriteLine($"ID: {genre.Id}|Genre: {genre.Name}");
            }

        }



        private static void UpdateGenre()
        {
            WriteLine("Which genre would you like to update? (ID)");
            var genre = FindGenreById();

            if (genre != null)
            {
                WriteLine("You are updating the following genre:");
                WriteLine($"ID: {genre.Id} |Name: {genre.Name}");
                
                WriteLine("Name of genre: ");
                var name = ReadLine();

                WriteLine("You have inputted the following info:");
                WriteLine($"ID: {genre.Id} |Name: {name}");
                if (ExtraUI.ConfirmInfo())
                {
                    genre.Name = name;
                    bllFacade.GenreService.UpdateGenre(genre);
                    WriteLine("Genre has been updated");
                }
                else
                {
                    WriteLine("The genre was not updated");
                }
            }
        }

       

        private static GenreBO FindGenreById()
        {
            WriteLine("Enter Q to go back to the menu");
            GenreBO genre = null;
            while (genre == null)
            {
                int idSearch;
                string input = ReadLine();

                if (int.TryParse(input, out idSearch))
                {
                    return bllFacade.GenreService.GetGenreById(idSearch);
                }
                else if (input.ToLower().Equals("q"))
                {
                    break;
                }
                else
                {
                    Write("You have to input the id");
                }


            }
            return null;
        }

        private static void CreateGenre()
        {
            WriteLine("Name of genre: ");
            var name = ReadLine();

            WriteLine("You have inputted the following info:");
            WriteLine($"Name: {name}");

            if (ExtraUI.ConfirmInfo())
            {
                if (bllFacade.GenreService.CreateGenre(new GenreBO() { Name = name }))
                {
                    WriteLine("Genre is now in information");
                }
                else
                {
                    WriteLine("This genre already exist");
                }
            }
            else
            {
                WriteLine("The Genre was not added");
            }
        }

        private static void ListAllGenres()
        {
            foreach (var genre in bllFacade.GenreService.GetAllGenre())
            {
                WriteLine($"ID: {genre.Id} |Name: {genre.Name}");
            }
        }
        
    }
}
