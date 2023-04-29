using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

[Table("Comment")]
public partial class Comment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(2048), Required(AllowEmptyStrings = false, ErrorMessage = "Title is a required field")]
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
    public virtual Post Post { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Comments")]
    public virtual Watcher User { get; set; } = null!;
}
