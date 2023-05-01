using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

[Table("NotificationType")]
public partial class NotificationType
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("NType")]
    [StringLength(256)]
    public string Ntype { get; set; } = null!;

    [InverseProperty("NotifType")]
    public virtual ICollection<Notification> Notifications { get; } = new List<Notification>();
}
