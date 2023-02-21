using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WatchParty.Models.Concrete;

namespace WatchPartyTest
{
    public class TMDBServiceModelPerson_Tests
    {
        private List<TMDBPerson> _actors;
        private TMDBPerson _actor;

        [SetUp]
        public void Setup()
        {
            _actors = new List<TMDBPerson>()
            {
                new TMDBPerson
                {
                    Id = 1136406, Name = "Tom Holland", ImagePath = "/bBRlrpJm9XkNSg0YT5LCaxqoFMX.jpg", Popularity = 56.703,
                    KnownFor = new List<TMDBTitle>()
                    {
                        new TMDBTitle 
                        { 
                            Id = 315635, ImagePath = "/c24sv2weTHPsmDa7jEMN0m2P3RT.jpg", MediaType = "movie", 
                            PlotSummary = "Following the events of Captain America: Civil War, Peter Parker, with the help of his mentor Tony Stark, tries to balance his life as an ordinary high school student in Queens, New York City, with fighting crime as his superhero alter ego Spider-Man as a new threat, the Vulture, emerges.",
                            Popularity = 138.045, ReleaseDate = "2017-07-05", Title = "Spider-Man: Homecoming"
                        },
                        new TMDBTitle
                        {
                            Id = 634649, ImagePath = "/uJYYizSuA9Y3DCs0qS4qWvHfZg4.jpg", MediaType = "movie",
                            PlotSummary = "Peter Parker is unmasked and no longer able to separate his normal life from the high-stakes of being a super-hero. When he asks for help from Doctor Strange the stakes become even more dangerous, forcing him to discover what it truly means to be Spider-Man.",
                            Popularity = 496.333, ReleaseDate = "2021-12-15", Title = "Spider-Man: No Way Home"
                        }
                    }
                },
                new TMDBPerson
                {
                    Id = 31, Name = "Tom Hanks", ImagePath = "/xndWFsBlClOJFRdhSt4NBwiPq2o.jpg", Popularity = 97.069,
                    KnownFor = new List<TMDBTitle>()
                    {
                        new TMDBTitle
                        {
                            Id = 13, ImagePath = "/arw2vcBveWOVZr6pxd9XTd1TdQa.jpg", MediaType = "movie",
                            PlotSummary = "A man with a low IQ has accomplished great things in his life and been present during significant historic events—in each case, far exceeding what anyone imagined he could do. But despite all he has achieved, his one true love eludes him.",
                            Popularity = 66.947, ReleaseDate = "1994-06-23", Title = "Forrest Gump"
                        }
                    }
                }
            };

            _actor = new TMDBPerson
            {
                Id = 5374, Name = "Jim Parsons", ImagePath = "/sa05slVgacuXe94UFnQs4rfqZL4.jpg", Popularity = 19.411,
                KnownFor = new List<TMDBTitle>()
                {
                    new TMDBTitle
                    {
                        Id = 1418, ImagePath = "/ooBGRQBdbGzBxAVfExiO8r7kloA.jpg", MediaType = "tv",
                        PlotSummary = "The sitcom is centered on five characters living in Pasadena, California: roommates Leonard Hofstadter and Sheldon Cooper; Penny, a waitress and aspiring actress who lives across the hall; and Leonard and Sheldon's equally geeky and socially awkward friends and co-workers, mechanical engineer Howard Wolowitz and astrophysicist Raj Koothrappali. The geekiness and intellect of the four guys is contrasted for comic effect with Penny's social skills and common sense.",
                        Popularity = 200.109, ReleaseDate = "2007-09-24", Title = "The Big Bang Theory"
                    },
                    new TMDBTitle
                    {
                        Id = 228161, ImagePath = "/ln7DqfqyKosTw1xoa92Q7FRT3Jh.jpg", MediaType = "movie",
                        PlotSummary = "When Earth is taken over by the overly-confident Boov, an alien race in search of a new place to call home, all humans are promptly relocated, while all Boov get busy reorganizing the planet. But when one resourceful girl, Tip, manages to avoid capture, she finds herself the accidental accomplice of a banished Boov named Oh. The two fugitives realize there’s a lot more at stake than intergalactic relations as they embark on the road trip of a lifetime.",
                        Popularity = 43.029, ReleaseDate = "2015-03-18", Title = "Home"
                    }
                }
            };
        }
    }
}
