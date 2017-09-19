using System.Collections.Generic;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;
using static System.Console;
namespace VideoMenuUI
{
    class VideoUI
    {
        static BLLFacade bllFacade = new BLLFacade();
        
        public static void VideoMenu()
        {
           

            #region Menu Items
            string[] menuItems =
            {
                "Add a video",
                "Add multiple videos",
                "List all videos",
                "Update a video",
                "Delete a video",
                "Search in all videos",
                "Back"
            };
            #endregion

            #region Menu Switch
            var selection = ExtraUI.ShowMenu(menuItems);
            while (selection != 7)
            {
                switch (selection)
                {
                    case 1:
                        CreateVideo();
                        break;
                    case 2:
                        CreateMultipleVideos();
                        break;
                    case 3:
                        ListAllVideos();
                        break;
                    case 4:
                        UpdateVideo();
                        break;
                    case 5:
                        DeleteVideo();
                        break;
                    case 6:
                        SearchVideos();
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

       

        private static void CreateVideo()
        {
            WriteLine("Genre: ");
            var genre = GenreExistCheck();


            WriteLine("Name: ");
            var name = ReadLine();

            WriteLine("You have inputted the following info:");
            WriteLine($"Genre: {genre.Name} |Name: {name}");

            if (ExtraUI.ConfirmInfo())
            {
                bllFacade.VideoService.CreateVideo(new VideoBO()
                {
                    Genre = genre.Name,
                    Name = name
                });
                WriteLine("Video is now in information");
            }
            else
            {
                WriteLine("The video was not added");
            }
        }
        private static void CreateMultipleVideos()
        {
            WriteLine("How many videos do you wish to add?");
            int times;
            while (!int.TryParse(ReadLine(), out times))
            {
                WriteLine("Please input a number");
            }
            WriteLine("What is the genre for all of these videos?:");
            WriteLine("Genre: ");
            var genre = GenreExistCheck();
            List<VideoBO> videos = new List<VideoBO>();
            WriteLine("C to cancel and A to Accept enter all inputted info");
            bool save = true;
            for (int i = 0; i < times; i++)
            {
                
                WriteLine("Name: ");
                var name = ReadLine();
                if (name.ToLower().Equals("c"))
                {
                    save = false;
                    break;
                }
                else if(name.ToLower().Equals("a"))
                WriteLine("You have inputted the following info:");
                WriteLine($"Genre: {genre.Name} |Name: {name}");
                if (ExtraUI.ConfirmInfo())
                {
                    videos.Add(new VideoBO { Genre = genre.Name, Name = name });
                }
                else
                {
                    WriteLine("The video was not added");
                    i--;
                }
            }
            if (save)
            {
                bllFacade.VideoService.CreateMultipleVideos(videos);
            }
        }
        private static void ListAllVideos()
        {
            foreach (var video in bllFacade.VideoService.GetAllVideos())
            {
                WriteLine($"ID: {video.Id} |Genre: {video.Genre} |Name: {video.Name}");
            }
        }
        private static void UpdateVideo()
        {
            WriteLine("Which Video would you like to update? (ID)");
            var video = FindVideoById();

            if (video != null)
            {
                WriteLine("You are updating the following video:");
                WriteLine($"Genre: {video.Genre} |Name: {video.Name}");
                WriteLine("Genre: ");
                var genre = GenreExistCheck();

                WriteLine("Name: ");
                var name = ReadLine();

                WriteLine("You have inputted the following info:");
                WriteLine($"Genre: {genre.Name} |Name: {name}");
                if (ExtraUI.ConfirmInfo())
                {
                    video.Genre = genre.Name;
                    video.Name = name;
                    bllFacade.VideoService.UpdateVideo(video);
                    WriteLine("Video has been updated");
                }
                else
                {
                    WriteLine("The video was not updated");
                }
            }
        }


        private static void DeleteVideo()
        {
            int id;
            WriteLine("Input the id of the video you would like to delete:(ID)");
            if (int.TryParse(ReadLine(), out id)) {
                var result = bllFacade.VideoService.DeleteVideo(id)== true ? "Video was succesfully deleted" : "Video was not found";
                WriteLine(result);
            }
            else {
                WriteLine("Please input an id");
            }
        }

        private static void SearchVideos()
        {
            WriteLine("Search for videos");
            var searchedVideos = bllFacade.VideoService.SearchVideos(ReadLine());
            
            WriteLine("Search Result");
            foreach (var video in searchedVideos)
            {
                WriteLine($"ID: {video.Id}|Genre: {video.Genre}|Name: {video.Name}");
            }

        }
        
        private static VideoBO FindVideoById()
        {
            WriteLine("Enter Q to go back to the menu");
            VideoBO video = null;
            while (video == null)
            {
                int idSearch;
                string input = ReadLine();

                if (int.TryParse(input, out idSearch))
                {
                    return bllFacade.VideoService.GetVideoById(idSearch);
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
        private static GenreBO GenreExistCheck() {
            bool foundGenre = false;
            string str = ReadLine();
            GenreBO genre = null;
            while (!foundGenre)
            {
                genre = bllFacade.GenreService.GetGenreByName(str);
                if (genre != null)
                {
                    return genre;
                }
                else
                {
                    WriteLine("The genre inputted was not found");
                    WriteLine($"Do you wish to create a genre named {str}");

                    if (ExtraUI.ConfirmInfo())
                    {
                        genre = new GenreBO { Name = str };
                        bllFacade.GenreService.CreateGenre(genre);
                        return genre;
                    }
                    else
                    {
                    }
                }
                str = ReadLine();
            }
            return null;
        }

       
    }
}