namespace WatchParty.Models.DTO;
public class WatcherDTO
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? FollowingCount { get; set; }
    public int? FollowerCount { get; set; }
}

