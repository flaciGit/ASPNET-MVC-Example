using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using forma1Example.Data;
using forma1Example.Models;
using Microsoft.AspNetCore.Authorization;

namespace forma1Example.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public ActionResult Index()
        {
            var usersWithRoles = (from user in _context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      PasswordHash = user.PasswordHash

                                  }).ToList().Select(p => new Account()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,

                                      PasswordHash = p.PasswordHash
        });
            
            return View(usersWithRoles);
        }

        // GET: ViewModels/Details/5
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var viewModel = (from user in _context.Users
                             where user.Id.Equals(id)
                             select new Account()
                             {
                                 UserId = user.Id,
                                 Username = user.UserName,
                                 Email = user.Email
                             });
            
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel.FirstOrDefault());
        }

        // GET: ViewModels/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = (from user in _context.Users
                             where user.Id.Equals(id)
                             select new Account()
                             {
                                 UserId = user.Id,
                                 Username = user.UserName,
                                 Email = user.Email
                             });

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel.FirstOrDefault());
        }

        // POST: ViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            
            var viewModel = await _context.Users.FindAsync(id);
            _context.Users.Remove(viewModel);
            
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(string id)
        {
            return _context.ViewModel.Any(e => e.UserId == id);
        }
    }
}
