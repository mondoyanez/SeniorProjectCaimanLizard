using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WatchParty.Models;

[Table("Movie")]
public partial class Movie
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("TMDBID")]
    public int Tmdbid { get; set; }

    [StringLength(128)]
    public string Title { get; set; } = null!;

    [StringLength(2048)]
    public string? Overview { get; set; }

    [StringLength(32)]
    public string? ReleaseDate { get; set; }

    [InverseProperty("Movie")]
    public virtual ICollection<WatchListItem> WatchListItems { get; } = new List<WatchListItem>();
}
