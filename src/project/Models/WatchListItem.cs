using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

public partial class WatchListItem
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("WatchListID")]
    public int WatchListId { get; set; }

    [Column("ShowID")]
    public int? ShowId { get; set; }

    [Column("MovieID")]
    public int? MovieId { get; set; }

    [ForeignKey("MovieId")]
    [InverseProperty("WatchListItems")]
    public virtual Movie? Movie { get; set; }

    [ForeignKey("ShowId")]
    [InverseProperty("WatchListItems")]
    public virtual Show? Show { get; set; }

    [ForeignKey("WatchListId")]
    [InverseProperty("WatchListItems")]
    public virtual WatchList WatchList { get; set; } = null!;
}
