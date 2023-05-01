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
    public int Id { get; set; }

    [StringLength(450)]
    public string AspNetIdentityId { get; set; } = null!;

    [StringLength(256)]
    public string Username { get; set; } = null!;

    [StringLength(64)]
    public string? FirstName { get; set; }

    [StringLength(64)]
    public string? LastName { get; set; }

    [StringLength(256)]
    public string? Email { get; set; }

    [StringLength(256)]
    public string? Bio { get; set; }

    public bool WatchListPrivacy { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    [InverseProperty("Following")]
    public virtual ICollection<FollowingList> FollowingListFollowings { get; } = new List<FollowingList>();

    [InverseProperty("User")]
    public virtual ICollection<FollowingList> FollowingListUsers { get; } = new List<FollowingList>();

    [InverseProperty("User")]
    public virtual ICollection<LikePost> LikePosts { get; } = new List<LikePost>();

    [InverseProperty("Notifier")]
    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();

    [InverseProperty("User")]
    public virtual ICollection<Post> Posts { get; } = new List<Post>();

    [InverseProperty("User")]
    public virtual ICollection<Reshare> Reshares { get; } = new List<Reshare>();

    [InverseProperty("User")]
    public virtual ICollection<WatchList> WatchLists { get; } = new List<WatchList>();

    [InverseProperty("Watcher")]
    public virtual ICollection<WatchPartyGroupAssignment> WatchPartyGroupAssignments { get; } = new List<WatchPartyGroupAssignment>();

    [InverseProperty("Host")]
    public virtual ICollection<WatchPartyGroup> WatchPartyGroups { get; } = new List<WatchPartyGroup>();
}
