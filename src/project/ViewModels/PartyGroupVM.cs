using WatchParty.Models;

namespace WatchParty.ViewModels;
public class PartyGroupVM
{
    public WatchPartyGroup? Group { get; set; }
    public List<Watcher>? Watchers { get; set; }
}

