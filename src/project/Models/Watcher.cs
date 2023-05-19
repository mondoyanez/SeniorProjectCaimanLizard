using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

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
    [EmailAddress]
    public string? Email { get; set; }

    [StringLength(16)]
    [Phone]
    public string? Phone { get; set; }

    [StringLength(256)]
    public string? Bio { get; set; }

    public bool WatchListPrivacy { get; set; }

    [InverseProperty("User")]
    [ValidateNever]
    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    [InverseProperty("Following")]
    [ValidateNever]
    public virtual ICollection<FollowingList> FollowingListFollowings { get; } = new List<FollowingList>();

    [InverseProperty("User")]
    [ValidateNever]
    public virtual ICollection<FollowingList> FollowingListUsers { get; } = new List<FollowingList>();

    [InverseProperty("User")]
    [ValidateNever]
    public virtual ICollection<LikePost> LikePosts { get; } = new List<LikePost>();

    [InverseProperty("Notifier")]
    [ValidateNever]
    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();

    [InverseProperty("User")]
    [ValidateNever]
    public virtual ICollection<Post> Posts { get; } = new List<Post>();

    [InverseProperty("User")]
    [ValidateNever]
    public virtual ICollection<Reshare> Reshares { get; } = new List<Reshare>();

    [InverseProperty("User")]
    [ValidateNever]
    public virtual ICollection<WatchList> WatchLists { get; } = new List<WatchList>();

    [InverseProperty("Watcher")]
    [ValidateNever]
    public virtual ICollection<WatchPartyGroupAssignment> WatchPartyGroupAssignments { get; } = new List<WatchPartyGroupAssignment>();

    [InverseProperty("Host")]
    [ValidateNever]
    public virtual ICollection<WatchPartyGroup> WatchPartyGroups { get; } = new List<WatchPartyGroup>();
}
