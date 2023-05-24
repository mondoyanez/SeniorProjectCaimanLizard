using Microsoft.EntityFrameworkCore;
using System;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.DAL.Concrete
{
    public class LikePostRepository : Repository<LikePost>, ILikePostRepository
    {
        public LikePostRepository(WatchPartyDbContext ctx) : base(ctx)
        {
        }

        public void AddPostLike(LikePost likePost)
        {
            if (likePost == null)
            {
                throw new ArgumentNullException(nameof(likePost));
            }

            try
            {
                AddOrUpdate(likePost);
            }
            catch (Exception e)
            {
                throw new Exception("Invalid information was given while trying to update database");
            }
        }

        public void RemovePostLike(LikePost likePost)
        {
            try
            {
                Delete(likePost);
            }
            catch (Exception e)
            {
                throw new Exception("Invalid information was given while trying to update database");
            }
        }
    }
}
