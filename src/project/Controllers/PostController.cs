using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WatchParty.DAL.Abstract;
using WatchParty.Models;
using WatchParty.Services.Abstract;
using WatchParty.ViewModels;

namespace WatchParty.Controllers;

[Authorize]
public class PostController : Controller
{
    private readonly IPostRepository _postRepository;
    private readonly IWatcherRepository _watcherRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITMDBService _tmdbService;

    public PostController(IPostRepository postRepository, IWatcherRepository watcherRepository ,UserManager<IdentityUser> userManager, ITMDBService tmdbService)
    {
        _postRepository = postRepository;
        _watcherRepository = watcherRepository;
        _userManager = userManager;
        _tmdbService = tmdbService;
    }

    // GET: Post
    public IActionResult Index()
    {
	    FeedVM vm = new()
	    {
		    Posts = _postRepository.GetAllPostsDescending(),
		    PopularMovies = _tmdbService.GetPopularMovies(),
            PopularShows = _tmdbService.GetPopularShows(),
		    ImageConfig = _tmdbService.SetImageConfig()

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
        post.DatePosted = DateTime.Now;
        post.UserId = _watcherRepository.FindByAspNetId(_userManager.GetUserId(User)!)!.Id;
        post.User = _watcherRepository.FindByAspNetId(_userManager.GetUserId(User)!)!;

        ModelState.Clear();
        TryValidateModel(post);

        if (!ModelState.IsValid) 
            return View(post);
        
        try
        {
            _postRepository.AddPost(post);
        }
        catch (DbUpdateConcurrencyException e)
        {
            ViewBag.Message = "A concurrency error occurred while trying to create the item.  Please try again.";
            return View(post);
        }

        return RedirectToAction("Index");
    }
    /*
    // GET: Post/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _postRepository.Posts == null)
        {
            return NotFound();
        }

        var post = await _postRepository.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        ViewData["UserId"] = new SelectList(_postRepository.Watchers, "Id", "Id", post.UserId);
        return View(post);
    }

    // POST: Post/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,PostTitle,PostDescription,DatePosted,UserId")] Post post)
    {
        if (id != post.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _postRepository.Update(post);
                await _postRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(post.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["UserId"] = new SelectList(_postRepository.Watchers, "Id", "Id", post.UserId);
        return View(post);
    }

    // GET: Post/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _postRepository.Posts == null)
        {
            return NotFound();
        }

        var post = await _postRepository.Posts
            .Include(p => p.User)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }

    // POST: Post/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_postRepository.Posts == null)
        {
            return Problem("Entity set 'WatchPartyDbContext.Posts'  is null.");
        }
        var post = await _postRepository.Posts.FindAsync(id);
        if (post != null)
        {
            _postRepository.Posts.Remove(post);
        }
            
        await _postRepository.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PostExists(int id)
    {
        return (_postRepository.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
    }*/
}
