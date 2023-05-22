using Microsoft.AspNetCore.Authorization;
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

    private CommentVM SetUpCommentVm(int postId)
    {
        Post? post = _postRepository.FindPostById(postId);

        CommentVM vm = new()
        {
            Comments = _commentRepository.GetVisibleComments().Where(c => c.PostId == postId).ToList(),
            PostId = postId
        };

        if (post == null)
            throw new NullReferenceException($"{post} is null");

        ViewBag.IsPostOwner = User?.Identity?.Name == post?.User.Username;
        ViewBag.IsPostVisible = post.IsVisible;

        return vm;
    }

    [HttpGet]
    public IActionResult Index(int postId)
    {
        CommentVM vm = SetUpCommentVm(postId);
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
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

        if (currentUser == null)
        {
            throw new ArgumentException(nameof(currentUser));
        }

        ModelState.Clear();

        newComment.DatePosted = DateTime.Now;
        newComment.IsVisible = true;
        newComment.UserId = currentUser.Id;

        TryValidateModel(newComment);

        if (ModelState.IsValid)
        {
            _commentRepository.AddComment(newComment);
            return RedirectToAction("Index", new { postId = newComment.PostId });
        }

        CommentVM vm = SetUpCommentVm(newComment.PostId);
        return View("Index", vm);
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