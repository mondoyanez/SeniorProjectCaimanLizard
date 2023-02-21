using Microsoft.AspNetCore.Identity;

namespace WatchParty.Areas.Identity.Data;

public class WatchPartyUser : IdentityUser
{
    [PersonalData]
    public string Username { get; set; }
    [PersonalData]
    public string? FirstName { get; set; }
    [PersonalData]
    public string? LastName { get; set; }
}