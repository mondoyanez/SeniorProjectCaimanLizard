using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WatchParty.Models;
using WatchParty.DAL.Concrete;
using WatchParty.DAL.Abstract;
using WatchParty.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WatchParty.Controllers
{
    public class NotificationController : Controller
    {
        private readonly WatchPartyDbContext _context;
        private readonly INotificationRepository _notificationRepo;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWatcherRepository _watcherRepository;


        public NotificationController(WatchPartyDbContext context, UserManager<IdentityUser> userManager, INotificationRepository notificationRepo, IWatcherRepository watcherRepository)
        {
            _context = context;
            _notificationRepo = notificationRepo;
            _userManager = userManager;
            _watcherRepository = watcherRepository;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            NotificationVM vm = new();

            var currentUser = await _userManager.GetUserAsync(User);
            vm.watcher = _watcherRepository.FindByAspNetId(currentUser.Id);

            vm.notifications = _notificationRepo.FindAllByUserID(vm.watcher.Id);
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeleteNotification(int notificationId)
        {
            _notificationRepo.DeleteById(notificationId);
            _context.SaveChanges();

            return Ok();

        }

        [Authorize]
        [HttpPost]
        public IActionResult ReadItem(int notificationId)
        {
            Notification notification = _notificationRepo.FindById(notificationId);
            notification.IsRead = true;

            _context.SaveChanges();
            return Ok();
        }



        //// GET: Notification
        //public async Task<IActionResult> Index()
        //{
        //    var watchPartyDbContext = _context.Notifications.Include(n => n.NotifType).Include(n => n.Notifier);
        //    return View(await watchPartyDbContext.ToListAsync());
        //}

        //// GET: Notification/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Notifications == null)
        //    {
        //        return NotFound();
        //    }

        //    var notification = await _context.Notifications
        //        .Include(n => n.NotifType)
        //        .Include(n => n.Notifier)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (notification == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(notification);
        //}

        //// GET: Notification/Create
        //public IActionResult Create()
        //{
        //    ViewData["NotifTypeId"] = new SelectList(_context.NotificationTypes, "Id", "Id");
        //    ViewData["NotifierId"] = new SelectList(_context.Watchers, "Id", "Id");
        //    return View();
        //}

        //// POST: Notification/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,NotifierId,NotifTypeId,Content,IsRead,CreatedAt")] Notification notification)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(notification);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["NotifTypeId"] = new SelectList(_context.NotificationTypes, "Id", "Id", notification.NotifTypeId);
        //    ViewData["NotifierId"] = new SelectList(_context.Watchers, "Id", "Id", notification.NotifierId);
        //    return View(notification);
        //}

        //// GET: Notification/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Notifications == null)
        //    {
        //        return NotFound();
        //    }

        //    var notification = await _context.Notifications.FindAsync(id);
        //    if (notification == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["NotifTypeId"] = new SelectList(_context.NotificationTypes, "Id", "Id", notification.NotifTypeId);
        //    ViewData["NotifierId"] = new SelectList(_context.Watchers, "Id", "Id", notification.NotifierId);
        //    return View(notification);
        //}

        //// POST: Notification/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,NotifierId,NotifTypeId,Content,IsRead,CreatedAt")] Notification notification)
        //{
        //    if (id != notification.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(notification);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!NotificationExists(notification.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["NotifTypeId"] = new SelectList(_context.NotificationTypes, "Id", "Id", notification.NotifTypeId);
        //    ViewData["NotifierId"] = new SelectList(_context.Watchers, "Id", "Id", notification.NotifierId);
        //    return View(notification);
        //}

        //// GET: Notification/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Notifications == null)
        //    {
        //        return NotFound();
        //    }

        //    var notification = await _context.Notifications
        //        .Include(n => n.NotifType)
        //        .Include(n => n.Notifier)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (notification == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(notification);
        //}

        //// POST: Notification/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Notifications == null)
        //    {
        //        return Problem("Entity set 'WatchPartyDbContext.Notifications'  is null.");
        //    }
        //    var notification = await _context.Notifications.FindAsync(id);
        //    if (notification != null)
        //    {
        //        _context.Notifications.Remove(notification);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool NotificationExists(int id)
        {
          return (_context.Notifications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
