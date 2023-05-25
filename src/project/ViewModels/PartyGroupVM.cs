﻿using WatchParty.Models;

namespace WatchParty.ViewModels;
public class PartyGroupVM
{
    public WatchPartyGroup? Group { get; set; }
    public List<Watcher>? Watchers { get; set; }
    public bool UserInGroup { get; set; }
    public bool HasOccurred { get; set; }
    public string? ActionMethod { get; set; }
}

