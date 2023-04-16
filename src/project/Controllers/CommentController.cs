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
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;

    public CommentController(ICommentRepository commentRepository, IPostRepository postRepository)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
    }

    [HttpGet]
    public IActionResult Index(int postId)
    {
        Post post = _postRepository.FindById(postId);

        if (post == null)
        {
            throw new ArgumentException(nameof(post));
        }

        CommentVM vm = new()
        {
            Comments = _commentRepository.GetComments(0).Where(c => c.PostId == post.Id).ToList(),
            PostId = post.Id,
            UserId = post.User.Id
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
    public IActionResult Index(string commentString, int userId)
    {
        return View();
    }
}