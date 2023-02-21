using System;
using System.Collections.Generic;

namespace WatchParty.Models;

public partial class LikePost
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual Watcher User { get; set; } = null!;
}
