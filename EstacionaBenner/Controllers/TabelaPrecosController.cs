using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstacionaBenner.Data;
using EstacionaBenner.Models;

namespace EstacionaBenner.Controllers
{
    public class TabelaPrecosController : Controller
    {
        private readonly ApplicationDBContext _context;

        public TabelaPrecosController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: TabelaPrecos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabelaPreco.ToListAsync());
        }

        // GET: TabelaPrecos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaPreco = await _context.TabelaPreco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabelaPreco == null)
            {
                return NotFound();
            }

            return View(tabelaPreco);
        }

        // GET: TabelaPrecos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TabelaPrecos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InicioVigencia,FimVigencia,ValorHoraInicial,ValorHoraAdicional,Ativo")] TabelaPreco tabelaPreco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabelaPreco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabelaPreco);
        }

        // GET: TabelaPrecos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaPreco = await _context.TabelaPreco.FindAsync(id);
            if (tabelaPreco == null)
            {
                return NotFound();
            }
            return View(tabelaPreco);
        }

        // POST: TabelaPrecos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InicioVigencia,FimVigencia,ValorHoraInicial,ValorHoraAdicional,Ativo")] TabelaPreco tabelaPreco)
        {
            if (id != tabelaPreco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabelaPreco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabelaPrecoExists(tabelaPreco.Id))
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
            return View(tabelaPreco);
        }

        // GET: TabelaPrecos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaPreco = await _context.TabelaPreco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabelaPreco == null)
            {
                return NotFound();
            }

            return View(tabelaPreco);
        }

        // POST: TabelaPrecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabelaPreco = await _context.TabelaPreco.FindAsync(id);
            if (tabelaPreco != null)
            {
                _context.TabelaPreco.Remove(tabelaPreco);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabelaPrecoExists(int id)
        {
            return _context.TabelaPreco.Any(e => e.Id == id);
        }
    }
}
