using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace WatchParty_BDD_Tests.PageObjects;

public class PostIndexPageObject : PageObject
{
    public PostIndexPageObject(IWebDriver webDriver) : base(webDriver)
    {
        _pageName = "Post";
    }

    public IWebElement PopularShowsCarousel => _webDriver.FindElement(By.Id("PopularShowsCarousel"));
    public IWebElement PopularMoviesCarousel => _webDriver.FindElement(By.Id("PopularMoviesCarousel"));

    public IWebElement PopularShowsCarouselHover => PopularShowsCarousel.FindElement(By.ClassName("active"));
    public IWebElement PopularMoviesCarouselHover => PopularMoviesCarousel.FindElement(By.ClassName("active"));

    public string PopularShowsCarouselHoverText => PopularShowsCarouselHover.FindElement(By.ClassName("carousel-hidden-text")).Text;
    public string PopularMoviesCarouselHoverText => PopularMoviesCarouselHover.FindElement(By.ClassName("carousel-hidden-text")).Text;

    public void HoverPopularShows()
    {
        new Actions(_webDriver).MoveToElement(PopularShowsCarouselHover).Perform();
    }

    public void HoverPopularMovies()
    {
        new Actions(_webDriver).MoveToElement(PopularMoviesCarouselHover).Perform();
    }
}

