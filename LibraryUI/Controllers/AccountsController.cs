using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryApp;

namespace LibraryUI.Controllers
{
    public class AccountsController : Controller
    {
        private readonly LibraryContext _context;

        public AccountsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.accounts.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberAcc = await _context.accounts
                .FirstOrDefaultAsync(m => m.AccountNumber == id);
            if (memberAcc == null)
            {
                return NotFound();
            }

            return View(memberAcc);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountNumber,AccountType,EmailAddress,PhoneNumber,UserName,MemberName,PinNumber,BooksBalance,CreatedDate")] MemberAcc memberAcc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberAcc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memberAcc);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberAcc = await _context.accounts.FindAsync(id);
            if (memberAcc == null)
            {
                return NotFound();
            }
            return View(memberAcc);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountNumber,AccountType,EmailAddress,PhoneNumber,UserName,MemberName,PinNumber,BooksBalance,CreatedDate")] MemberAcc memberAcc)
        {
            if (id != memberAcc.AccountNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberAcc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberAccExists(memberAcc.AccountNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(memberAcc);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberAcc = await _context.accounts
                .FirstOrDefaultAsync(m => m.AccountNumber == id);
            if (memberAcc == null)
            {
                return NotFound();
            }

            return View(memberAcc);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberAcc = await _context.accounts.FindAsync(id);
            _context.accounts.Remove(memberAcc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberAccExists(int id)
        {
            return _context.accounts.Any(e => e.AccountNumber == id);
        }
    }
}
