using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchParty.DAL.Abstract;
using WatchParty.Models;
using WatchParty.ViewModels;

namespace WatchParty.Controllers;

[Authorize]
public class CommentController : Controller
{
    private readonly IPostRepository _postRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IWatcherRepository _watcherRepository;

    public CommentController(IPostRepository postRepository, ICommentRepository commentRepository, IWatcherRepository watcherRepository)
    {
        _postRepository = postRepository;
        _commentRepository = commentRepository;
        _watcherRepository = watcherRepository;
    }

    [HttpGet]
    public IActionResult Index(int postId)
    {
        CommentVM vm = new()
        {
            Comments = _commentRepository.GetComments(0).Where(c => c.PostId == postId).ToList(),
            PostId = postId
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
    public IActionResult Index(string commentString, int postId)
    {
        Watcher? currentUser = _watcherRepository.FindByUsername(User.Identity.Name);
        Post post = _postRepository.FindById(postId);

        Comment comment = new()
        {
            CommentTitle = commentString,
            DatePosted = DateTime.Now,
            UserId = currentUser.Id,
            User = currentUser,
            PostId = postId,
            Post = post
        };

        _commentRepository.AddComment(comment);

        CommentVM vm = new()
        {
            Comments = _commentRepository.GetComments(0).Where(c => c.PostId == postId).ToList(),
            PostId = postId
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
}