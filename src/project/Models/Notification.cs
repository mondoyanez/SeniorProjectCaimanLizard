using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

[Table("Notification")]
public partial class Notification
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("NotifierID")]
    public int NotifierId { get; set; }

    [Column("NotifTypeID")]
    public int NotifTypeId { get; set; }

    [StringLength(256)]
    public string Content { get; set; } = null!;

    public bool IsRead { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("NotifTypeId")]
    [InverseProperty("Notifications")]
    public virtual NotificationType NotifType { get; set; } = null!;

    [ForeignKey("NotifierId")]
    [InverseProperty("Notifications")]
    public virtual Watcher Notifier { get; set; } = null!;
}
