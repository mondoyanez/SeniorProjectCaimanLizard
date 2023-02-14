using Microsoft.AspNetCore.Identity;

namespace WatchParty.Areas.Identity.Data;

public class SimpleUser : IdentityUser
{
    [PersonalData]
    public string FirstName { get; set; }
    [PersonalData]
    public string LastName { get; set; }
    [PersonalData]
    public DateTime DOB { get; set; }

}