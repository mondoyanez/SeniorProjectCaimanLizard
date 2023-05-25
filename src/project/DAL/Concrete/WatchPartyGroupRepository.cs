﻿using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;
public class WatchPartyGroupRepository : Repository<WatchPartyGroup>, IWatchPartyGroupRepository
{
    public WatchPartyGroupRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public void CreateWatchPartyGroup(WatchPartyGroup group)
    {
        if (group == null) 
            throw new ArgumentNullException(nameof(group));

        if (group.StartDate.CompareTo(DateTime.Now) < 0)
            throw new ArgumentException($"Date must be after {DateTime.Now}");

        try
        {
            AddOrUpdate(group);
        }
        catch
        {
            throw new Exception("Invalid information was given while trying to update database");
        }
    }

    public WatchPartyGroup? GetById(int id)
    {
        return GetAll().FirstOrDefault(g => g.Id == id);
    }

    public void UpdateGroup(WatchPartyGroup group)
    {
        if (group == null)
            throw new ArgumentNullException(nameof(group));

        if (group.StartDate.CompareTo(DateTime.Now) < 0)
            throw new ArgumentException($"Date must be after {DateTime.Now}");

        try
        {
            AddOrUpdate(group);
        }
        catch
        {
            throw new Exception("Invalid information was given while trying to update database");
        }
    }
}

