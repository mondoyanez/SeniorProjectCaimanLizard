using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WatchParty.Models;

[Table("Comment")]
public partial class Comment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(2048), Required(AllowEmptyStrings = false, ErrorMessage = "Comment field cannot be left empty")]
    public string CommentTitle { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DatePosted { get; set; }

    public bool IsVisible { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("PostID")]
    public int PostId { get; set; }

    [ForeignKey("PostId")]
    [InverseProperty("Comments")]
    [ValidateNever]
    public virtual Post Post { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Comments")]
    [ValidateNever]
    public virtual Watcher User { get; set; } = null!;
}
