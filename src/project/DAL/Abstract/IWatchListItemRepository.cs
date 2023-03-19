using Microsoft.AspNetCore.Identity;
using WatchParty.Models;

namespace WatchParty.DAL.Abstract
{
    public interface IWatchListItemRepository : IRepository<WatchListItem>
    {
        IEnumerable<WatchListItem> GetAllWatchListItemsByID(int watchListId);

    }
}