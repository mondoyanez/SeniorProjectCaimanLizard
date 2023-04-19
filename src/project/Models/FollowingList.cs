using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

[Table("FollowingList")]
public partial class FollowingList
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("FollowingID")]
    public int FollowingId { get; set; }

    [ForeignKey("FollowingId")]
    [InverseProperty("FollowingListFollowings")]
    public virtual Watcher Following { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("FollowingListUsers")]
    public virtual Watcher User { get; set; } = null!;
}
