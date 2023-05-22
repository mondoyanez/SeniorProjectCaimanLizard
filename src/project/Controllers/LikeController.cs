using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchParty.DAL.Abstract;
using WatchParty.Models;

namespace WatchParty.Controllers
{
    [Route("like")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly IWatcherRepository _watcherRepository;
        private readonly IPostRepository _postRepository;
        private readonly ILikePostRepository _likePostRepository;

        public LikeController(IWatcherRepository watcherRepository, IPostRepository postRepository, ILikePostRepository likePostRepository)
        {
            _watcherRepository = watcherRepository;
            _postRepository = postRepository;
            _likePostRepository = likePostRepository;
        }

        [HttpPost("AddLikePost")]
        public IActionResult AddLikePost(int userId, int postId)
        {
            Watcher watcher = _watcherRepository.FindById(userId);
            Post post = _postRepository.FindById(postId);

            if (watcher == null)
                throw new ArgumentNullException(nameof(watcher));

            if (post == null)
                throw new ArgumentNullException(nameof(post));

            LikePost newLikePost = new()
            {
                PostId = post.Id,
                UserId = watcher.Id
            };

            _likePostRepository.AddPostLike(newLikePost);

            return Ok(StatusCodes.Status201Created);
        }

        [HttpPost("RemoveLikePost")]
        public IActionResult RemoveLikePost(int userId, int postId)
        {
            Watcher watcher = _watcherRepository.FindById(userId);
            Post post = _postRepository.FindById(postId);

            if (watcher == null)
                throw new ArgumentNullException(nameof(watcher));

            if (post == null)
                throw new ArgumentNullException(nameof(post));

            LikePost likePost = _likePostRepository.GetAll().FirstOrDefault(lp => lp.UserId == userId && lp.PostId == postId) ?? new LikePost();

            if (likePost == null)
                throw new ArgumentNullException(nameof(likePost));

            _likePostRepository.RemovePostLike(likePost);
            return Ok(StatusCodes.Status200OK);
        }   
    }
}
