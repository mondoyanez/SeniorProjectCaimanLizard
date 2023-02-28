using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

[Table("Reshare")]
public partial class Reshare
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PostID")]
    public int PostId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [ForeignKey("PostId")]
    [InverseProperty("Reshares")]
    public virtual Post Post { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Reshares")]
    public virtual Watcher User { get; set; } = null!;
}
