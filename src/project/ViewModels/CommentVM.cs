using WatchParty.Models;
using WatchParty.Utilities;

namespace WatchParty.ViewModels;
public class CommentVM
{
    public IEnumerable<Comment> Comments { get; set; }
    public Comment newComment { get; set; }
    public int? PostId { get; set; }
    public DateFromConversion Convert { get; set; } = new();
    public string ActionMethod { get; set; }
}