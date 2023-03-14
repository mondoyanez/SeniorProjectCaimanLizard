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

    [Column("ShowID")]
    public int? ShowId { get; set; }

    [Column("MovieID")]
    public int? MovieId { get; set; }

    [ForeignKey("MovieId")]
    [InverseProperty("WatchLists")]
    public virtual Movie? Movie { get; set; }

    [ForeignKey("ShowId")]
    [InverseProperty("WatchLists")]
    public virtual Show? Show { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("WatchLists")]
    public virtual Watcher User { get; set; } = null!;
}
