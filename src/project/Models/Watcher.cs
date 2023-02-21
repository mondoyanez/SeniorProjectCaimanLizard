using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WatchParty.Models;

public partial class Watcher
{
    public int Id { get; set; }

    public string AspNetIdentityId { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int? FollowingCount { get; set; }

    public int? FollowerCount { get; set; }

    [StringLength(256)]
    public string? Bio { get; set; }

    public virtual ICollection<LikePost> LikePosts { get; } = new List<LikePost>();

    public virtual ICollection<Post> Posts { get; } = new List<Post>();

    public virtual ICollection<Reshare> Reshares { get; } = new List<Reshare>();
}
