using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WatchParty.DAL.Abstract;
using WatchParty.Models;
using WatchParty.Services.Abstract;
using WatchParty.ViewModels;

namespace WatchParty.Controllers;

[Authorize]
public class PostController : Controller
{
    private readonly IPostRepository _postRepository;
    private readonly ILikePostRepository _likePostRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IWatcherRepository _watcherRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITMDBService _tmdbService;

    public PostController(IPostRepository postRepository, ILikePostRepository likePostRepository,ICommentRepository commentRepository, IWatcherRepository watcherRepository ,UserManager<IdentityUser> userManager, ITMDBService tmdbService)
    {
        _postRepository = postRepository;
        _likePostRepository = likePostRepository;
        _commentRepository = commentRepository;
        _watcherRepository = watcherRepository;
        _userManager = userManager;
        _tmdbService = tmdbService;
    }

    // GET: Post
    [HttpGet]
    public IActionResult Index()
    {
	    FeedVM vm = new()
	    {
		    Posts = _postRepository.GetAllPostsDescending(),
            LikePosts = _likePostRepository.GetAll(),
            Comments = _commentRepository.GetVisibleComments(),
		    PopularMovies = _tmdbService.GetPopularMovies(),
            PopularShows = _tmdbService.GetPopularShows(),
		    ImageConfig = _tmdbService.SetImageConfig(),
            CurrentWatcher = _watcherRepository.FindByAspNetId(_userManager.GetUserId(User)!)!
        };
	    if (ModelState.IsValid)
	    {
		    ViewBag.IsValid = true;
	    }
	    else
	    {
            ViewBag.IsValid = false;
            var errors = ModelState.Values.SelectMany(v => v.Errors);
	    }
        return View(vm);
    }

    [HttpPost]
    public IActionResult Index(int postId)
    {
        Post? post = _postRepository.FindPostById(postId);

        if (post == null)
        {
            throw new NullReferenceException($"{post} is null");
        }

        _postRepository.HidePost(post);

        FeedVM vm = new()
        {
            Posts = _postRepository.GetAllPostsDescending(),
            Comments = _commentRepository.GetVisibleComments(),
            PopularMovies = _tmdbService.GetPopularMovies(),
            PopularShows = _tmdbService.GetPopularShows(),
            ImageConfig = _tmdbService.SetImageConfig(),
            CurrentWatcher = _watcherRepository.FindByAspNetId(_userManager.GetUserId(User)!)!
        };

        if (ModelState.IsValid)
        {
            ViewBag.IsValid = true;
        }
        else
        {
            ViewBag.IsValid = false;
            var errors = ModelState.Values.SelectMany(v => v.Errors);
        }

        return View("Index", vm);
    }

    // GET: Post/Create
    public IActionResult Create()
    {
        return View();
    }
    
    // POST: Post/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("PostTitle, PostDescription")] Post post)
    {
        ModelState.Clear();

        post.DatePosted = DateTime.Now;
        post.UserId = _watcherRepository.FindByAspNetId(_userManager.GetUserId(User)!)!.Id;
        post.IsVisible = true;

        TryValidateModel(post);

        if (ModelState.IsValid)
        {
            _postRepository.AddPost(post);
            return RedirectToAction("Index");
        }
        
        return View();
    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Post? post = _postRepository.FindPostById((int) id);
        if (post == null)
        {
            return NotFound();
        }
        return View(post);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Post updatedPost)
    {
        if (id != updatedPost.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            updatedPost.DatePosted = DateTime.Now;
            updatedPost.UserId = _watcherRepository.FindByAspNetId(_userManager.GetUserId(User)!)!.Id;
            updatedPost.IsVisible = true;
            _postRepository.AddOrUpdate(updatedPost);
            return RedirectToAction("Index");
        }

        return View(updatedPost);
    }
}
