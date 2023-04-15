using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchParty.DAL.Abstract;
using WatchParty.ViewModels;

namespace WatchParty.Controllers;

[Authorize]
public class CommentController : Controller
{
    private readonly ICommentRepository _commentRepository;

    public CommentController(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public IActionResult Index(int id)
    {
        CommentVM vm = new()
        {
            Comments = _commentRepository.GetComments(0).Where(c => c.PostId == id).ToList()
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