using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WatchParty.Models.Concrete;

namespace WatchPartyTest
{
    public class TMDBServicePerson_Tests
    {
        private TMDBPerson _actor;

        [SetUp]
        public void Setup()
        {
            _actor = new TMDBPerson
            {
                Id = 5374,
                Name = "Jim Parsons",
                ImagePath = "/sa05slVgacuXe94UFnQs4rfqZL4.jpg",
                Popularity = 19.411,
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

        [Test]
        public void NumberOfTitles_WithTwoTotal_ReturnsTwo()
        {
            // Arrange
            int expected = 2;

            // Act
            int actual = _actor.KnownFor.Count();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void NumberOfTitles_WithNone_ReturnsZero()
        {
            // Arrange
            int expected = 0;
            _actor.KnownFor = new List<TMDBTitle>();

            // Act
            int actual = _actor.KnownFor.Count();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ActorPopularity_ReturnsCorrectValue()
        {
            // Arrange
            double expected = 19.411;

            // Act
            double actual = _actor.Popularity;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ActorPopularity_ReturnsIncorrectValue()
        {
            // Arrange
            double expected = 25.3;

            // Act
            double actual = _actor.Popularity;

            // Assert
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test]
        public void ActorImagePath_ReturnsCorrectImagePath()
        {
            // Arrange
            string expected = "/sa05slVgacuXe94UFnQs4rfqZL4.jpg";

            // Act
            string actual = _actor.ImagePath;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ActorImagePath_ReturnsIncorrectImagePath()
        {
            // Arrange
            string expected = "/dafsslVgacuXe94UFnQs4rfqZL4.jpg";

            // Act
            string actual = _actor.ImagePath;

            // Assert
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test]
        public void ActorName_ReturnsCorrectName()
        {
            // Arrange
            string expected = "Jim Parsons";

            // Act
            string actual = _actor.Name;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ActorName_ReturnsIncorrectName()
        {
            // Arrange
            string expected = "Tom Holland";

            // Act
            string actual = _actor.Name;

            // Assert
            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test]
        public void ActorId_ReturnsCorrectId()
        {
            // Arrange
            int expected = 5374;

            // Act
            int actual = _actor.Id;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ActorId_ReturnsIncorrectId()
        {
            // Arrange
            int expected = 5474;

            // Act
            int actual = _actor.Id;

            // Assert
            Assert.That(actual, Is.Not.EqualTo(expected));
        }
    }
}
