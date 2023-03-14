using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

[Table("WatchList")]
public partial class WatchList
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("TMDBID")]
    public int Tmdbid { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("WatchLists")]
    public virtual Watcher User { get; set; } = null!;
}
