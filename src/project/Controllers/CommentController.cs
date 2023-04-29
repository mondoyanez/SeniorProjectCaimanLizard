using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
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
        Post? post = _postRepository.FindPostById(postId);

        CommentVM vm = new()
        {
            Comments = _commentRepository.GetVisibleComments().Where(c => c.PostId == postId).ToList(),
            PostId = postId
        };

        if (post == null)
        {
            throw new NullReferenceException($"{post} is null");
        }

        ViewBag.IsPostOwner = User?.Identity?.Name == post?.User.Username;
        ViewBag.IsPostVisible = post.IsVisible;

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
    public IActionResult Index([Bind("Id, CommentTitle, PostId")] Comment newComment, string ActionMethod)
    {
        switch (ActionMethod)
        {
            case "CreateComment":
                return CreateComment(newComment);
            case "HideComment":
                return HideComment(newComment);
            default:
                return View();
        }
    }

    private IActionResult CreateComment(Comment newComment)
    {
        Watcher? currentUser = _watcherRepository.FindByUsername(User.Identity.Name);
        Post post = _postRepository.FindById(newComment.PostId);

        if (currentUser == null)
        {
            throw new ArgumentException(nameof(currentUser));
        }

        newComment.DatePosted = DateTime.Now;
        newComment.IsVisible = true;
        newComment.Post = post;
        newComment.UserId = currentUser.Id;
        newComment.User = currentUser;

        _commentRepository.AddComment(newComment);

        return RedirectToAction("Index", new { postId = newComment.PostId });
    }

    private IActionResult HideComment(Comment newComment)
    {
        Comment? comment = _commentRepository.FindCommentById(newComment.Id);

        if (comment == null)
            throw new ArgumentException(nameof(comment));

        _commentRepository.HideComment(comment);

        ViewBag.IsPostOwner = User?.Identity?.Name == comment?.Post?.User.Username;
        ViewBag.IsPostVisible = comment?.Post?.IsVisible;

        return RedirectToAction("Index", new { postId = comment?.PostId });
    }
}