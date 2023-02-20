using System;
using System.Collections.Generic;

namespace WatchParty.Models;

public partial class Post
{
    public int Id { get; set; }

    public string PostTitle { get; set; } = null!;

    public string PostDescription { get; set; } = null!;

    public DateTime DatePosted { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<LikePost> LikePosts { get; } = new List<LikePost>();

    public virtual ICollection<Reshare> Reshares { get; } = new List<Reshare>();

    public virtual Watcher User { get; set; } = null!;
}
