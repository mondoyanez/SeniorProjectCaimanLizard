using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

[Table("Post")]
public partial class Post
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(2048), Required(AllowEmptyStrings = false, ErrorMessage = "Title is a required field")]
    public string PostTitle { get; set; } = null!;

    [StringLength(2048)]
    public string? PostDescription { get; set; }

    [Column(TypeName = "datetime")] 
    public DateTime DatePosted { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [InverseProperty("Post")]
    public virtual ICollection<LikePost> LikePosts { get; } = new List<LikePost>();

    [InverseProperty("Post")]
    public virtual ICollection<Reshare> Reshares { get; } = new List<Reshare>();

    [ForeignKey("UserId")]
    [InverseProperty("Posts")]
    public virtual Watcher User { get; set; } = null!;
}
