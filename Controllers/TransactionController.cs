using BankTransactions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTransactions.Controllers
{
    public class TransactionController : Controller
    {
        public TransactionDbContext _context { get; }
        public TransactionController(TransactionDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            var transaction = await _context.Transactions.ToListAsync();
            return View(transaction);
        }

        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transaction transactions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactions);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var transactionDB = await _context.Transactions.FirstOrDefaultAsync(t => t.TransactionId == id);
            if(transactionDB is null)
            {
                return NotFound();
            }
            return View(transactionDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Transaction transaction)
        {
            if (!ModelState.IsValid)
                return View(transaction);
            
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var transactionDB = await _context.Transactions.FirstOrDefaultAsync(t => t.TransactionId == id);
            if (transactionDB is null)
            {
                return NotFound();
            }
            _context.Transactions.Remove(transactionDB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var transactionDB = await _context.Transactions.FirstOrDefaultAsync(t => t.TransactionId == id);
            if (transactionDB is null)
            {
                return NotFound();
            }
            return View(transactionDB);
        }
    }
}
