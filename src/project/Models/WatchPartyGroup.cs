using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

[Table("WatchPartyGroup")]
public partial class WatchPartyGroup
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(512), Required(AllowEmptyStrings = false, ErrorMessage = "Title is a required field")]
    public string GroupTitle { get; set; } = null!;

    [StringLength(1024)]
    public string? GroupDescription { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("HostID")]
    public int HostId { get; set; }

    [ForeignKey("HostId")]
    [InverseProperty("WatchPartyGroups")]
    public virtual Watcher Host { get; set; } = null!;

    [InverseProperty("Group")]
    public virtual ICollection<WatchPartyGroupAssignment> WatchPartyGroupAssignments { get; } = new List<WatchPartyGroupAssignment>();
}
