using Microsoft.AspNetCore.Identity;
using WatchParty.Models;

namespace WatchParty.DAL.Abstract
{
    public interface IWatchListRepository : IRepository<WatchList>
    {
        WatchList? FindByUserID(int userID, int listType);

        IEnumerable<WatchList> FindAllByUserID(int userID, int listType);

    }
}