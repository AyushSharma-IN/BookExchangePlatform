using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookExchangePlatform.Models;
using Microsoft.AspNetCore.Identity;
using BookExchangePlatform.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BookExchangePlatform.Controllers
{
    [Authorize]
    public class ExchangeRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ExchangeRequestsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ExchangeRequests
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var data = await _context.ExchangeRequests.Select(e => new ExchangeRequestViewModel
            {
                ExchangeRequestId = e.ExchangeRequestId,
                BookId = e.BookId,
                Title = e.Book.Title,
                OwnerId = e.OwnerId,
                OwnerName = e.Owner.FullName,
                RequesterId = e.RequesterId,
                RequesterName = e.Requester.FullName,
                Status = e.Status,
                Duration = e.Duration,
                DeliveryMethod = e.DeliveryMethod,
                Terms = e.Terms,
                RequestDate = e.RequestDate
            }).Where(e => (e.OwnerId == user.Id) || (e.RequesterId == user.Id))
            .ToListAsync();
            return View(data);
        }

        public async Task<IActionResult> Accept(int id = 0)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRequest = await _context.ExchangeRequests.FindAsync(id);
            if (exchangeRequest == null)
            {
                return NotFound();
            }
            exchangeRequest.Status = "Accepted";
            _context.Update(exchangeRequest);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Reject(int id = 0)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRequest = await _context.ExchangeRequests.FindAsync(id);
            if (exchangeRequest == null)
            {
                return NotFound();
            }
            exchangeRequest.Status = "Rejected";
            _context.Update(exchangeRequest);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ERequest(Dictionary<string, string> value)
        {
            if (value.Count == 4)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                var exchangeRequest = new ExchangeRequestViewModel
                {
                    BookId = int.Parse(value.GetValueOrDefault("BookId")),
                    Title = value.GetValueOrDefault("Title"),
                    OwnerId = value.GetValueOrDefault("OwnerId"),
                    OwnerName = value.GetValueOrDefault("OwnerName"),
                    RequesterId = user.Id,
                    RequesterName = user.FullName,
                };
                return View(exchangeRequest);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ERequest(int? id, ExchangeRequestViewModel model)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                var exchange = new ExchangeRequest
                {
                    ExchangeRequestId = model.ExchangeRequestId,
                    BookId = model.BookId,
                    OwnerId = model.OwnerId,
                    RequesterId = model.RequesterId,
                    Status = model.Status,
                    Terms = model.Terms,
                    DeliveryMethod = model.DeliveryMethod,
                    Duration = model.Duration,
                    RequestDate = DateTime.Now

                };
                _context.Add(exchange);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), "Books", null);
            }

            var book = await _context.Books.FirstOrDefaultAsync(m => m.BookId == model.BookId);
            if (book != null && user != null)
            {
                var exchangeRequest = new ExchangeRequestViewModel
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    OwnerId = book.OwnerId,
                    OwnerName = book.Owner.FullName,
                    RequesterId = user.Id,
                    RequesterName = user.FullName,
                };
                return View(exchangeRequest);
            }
            return NotFound();
        }

        // GET: ExchangeRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exchangeRequest = await _context.ExchangeRequests
                .Include(e => e.Book)
                .Include(e => e.Owner)
                .Include(e => e.Requester)
                .FirstOrDefaultAsync(m => m.ExchangeRequestId == id);
            if (exchangeRequest == null)
            {
                return NotFound();
            }

            return View(exchangeRequest);
        }

        // POST: ExchangeRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exchangeRequest = await _context.ExchangeRequests.FindAsync(id);
            if (exchangeRequest != null)
            {
                _context.ExchangeRequests.Remove(exchangeRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExchangeRequestExists(int id)
        {
            return _context.ExchangeRequests.Any(e => e.ExchangeRequestId == id);
        }



    }
}
