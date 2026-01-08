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
    public class RegistrosEstacionamentoController : Controller
    {
        private readonly ApplicationDBContext _context;

        public RegistrosEstacionamentoController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: RegistrosEstacionamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegistrosEstacionamento.ToListAsync());
        }

        // GET: RegistrosEstacionamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroEstacionamento = await _context.RegistrosEstacionamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroEstacionamento == null)
            {
                return NotFound();
            }

            return View(registroEstacionamento);
        }

        // GET: RegistrosEstacionamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistrosEstacionamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa")] RegistroEstacionamento registroEstacionamento)
        {
            registroEstacionamento.HoraEntrada = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                _context.Add(registroEstacionamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroEstacionamento);
        }

        // GET: RegistrosEstacionamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroEstacionamento = await _context.RegistrosEstacionamento.FindAsync(id);
            if (registroEstacionamento == null)
            {
                return NotFound();
            }
            return View(registroEstacionamento);
        }

        // POST: RegistrosEstacionamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] RegistroEstacionamento registroEstacionamento)
        {
            var localizaCarro = await _context.RegistrosEstacionamento.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            
            if(localizaCarro == null) return NotFound();
            
            registroEstacionamento.Placa = localizaCarro.Placa;
            registroEstacionamento.HoraEntrada = localizaCarro.HoraEntrada;
            registroEstacionamento.HoraSaida = DateTime.Now;
            
            if(ModelState.IsValid){
                
                _context.Update(registroEstacionamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroEstacionamento);
        }

        // GET: RegistrosEstacionamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroEstacionamento = await _context.RegistrosEstacionamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registroEstacionamento == null)
            {
                return NotFound();
            }

            return View(registroEstacionamento);
        }

        // POST: RegistrosEstacionamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroEstacionamento = await _context.RegistrosEstacionamento.FindAsync(id);
            if (registroEstacionamento != null)
            {
                _context.RegistrosEstacionamento.Remove(registroEstacionamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroEstacionamentoExists(int id)
        {
            return _context.RegistrosEstacionamento.Any(e => e.Id == id);
        }
    }
}
