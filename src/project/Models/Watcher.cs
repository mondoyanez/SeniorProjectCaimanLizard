using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

[Table("Watcher")]
public partial class Watcher
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(64)]
    public string FirstName { get; set; } = null!;

    [StringLength(64)]
    public string LastName { get; set; } = null!;

    [StringLength(64)]
    public string? Email { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<LikePost> LikePosts { get; } = new List<LikePost>();

    [InverseProperty("User")]
    public virtual ICollection<Post> Posts { get; } = new List<Post>();

    [InverseProperty("User")]
    public virtual ICollection<Reshare> Reshares { get; } = new List<Reshare>();
}
