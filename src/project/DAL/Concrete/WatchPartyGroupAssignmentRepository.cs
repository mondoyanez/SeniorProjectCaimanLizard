﻿using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete;
public class WatchPartyGroupAssignmentRepository : Repository<WatchPartyGroupAssignment>, IWatchPartyGroupAssignmentRepository
{
    public WatchPartyGroupAssignmentRepository(WatchPartyDbContext ctx) : base(ctx)
    {
    }

    public WatchPartyGroupAssignment? FindGroupAssignment(int groupId, int userId)
    {
        return GetAll().FirstOrDefault(g => g.GroupId == groupId && g.WatcherId == userId);
    }

    public void AddToGroup(WatchPartyGroupAssignment assignment)
    {
        if (assignment == null)
            throw new ArgumentNullException(nameof(assignment));

        WatchPartyGroupAssignment? alreadyExists = GetAll().FirstOrDefault(a => a.WatcherId == assignment.WatcherId && a.GroupId == assignment.GroupId);

        if (alreadyExists != null)
            throw new Exception("User is already in group");

        try
        {
            AddOrUpdate(assignment);
        }
        catch
        {
            throw new Exception("Invalid information was given while trying to update database");
        }
    }

    public void RemoveFromGroup(WatchPartyGroupAssignment assignment)
    {
        throw new NotImplementedException();
    }

    public List<int> GetGroupIds(int userId)
    {
        return GetAll().Where(w => w.WatcherId == userId)
            .Select(w => w.GroupId)
            .ToList();
    }
}