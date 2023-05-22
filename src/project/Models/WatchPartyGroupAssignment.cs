using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

[Table("WatchPartyGroupAssignment")]
public partial class WatchPartyGroupAssignment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("GroupID")]
    public int GroupId { get; set; }

    [Column("WatcherID")]
    public int WatcherId { get; set; }

    [ForeignKey("GroupId")]
    [InverseProperty("WatchPartyGroupAssignments")]
    public virtual WatchPartyGroup Group { get; set; } = null!;

    [ForeignKey("WatcherId")]
    [InverseProperty("WatchPartyGroupAssignments")]
    public virtual Watcher Watcher { get; set; } = null!;
}
