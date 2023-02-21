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
                }
            };
        }
    }
}
