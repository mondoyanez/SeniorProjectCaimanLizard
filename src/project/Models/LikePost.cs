using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

[Table("LikePost")]
public partial class LikePost
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PostID")]
    public int PostId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [ForeignKey("PostId")]
    [InverseProperty("LikePosts")]
    public virtual Post Post { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("LikePosts")]
    public virtual Watcher User { get; set; } = null!;
}
