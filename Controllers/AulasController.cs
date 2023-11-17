using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAcademiaFinal.Models;

namespace WebAcademiaFinal.Controllers
{
    public class AulasController : Controller
    {
        private readonly Contexto _context;

        public AulasController(Contexto context)
        {
            _context = context;
        }

        // GET: Aulas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Aulas.Include(a => a.aluno).Include(a => a.professor);
            return View(await contexto.ToListAsync());
        }

        // GET: Aulas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aulas == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas
                .Include(a => a.aluno)
                .Include(a => a.professor)
                .FirstOrDefaultAsync(m => m.id == id);
            if (aula == null)
            {
                return NotFound();
            }
           
            return View(aula);
        }

        // GET: Aulas/Create
        public IActionResult Create()
        {
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "nome");
            ViewData["professorID"] = new SelectList(_context.Professores, "id", "nome");
            return View();
        }

        // POST: Aulas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,alunoID,professorID,data")] Aula aula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "nome", aula.alunoID);
            ViewData["professorID"] = new SelectList(_context.Professores, "id", "nome", aula.professorID);
            return View(aula);
        }

        // GET: Aulas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aulas == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas.FindAsync(id);
            if (aula == null)
            {
                return NotFound();
            }
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "nome", aula.alunoID);
            ViewData["professorID"] = new SelectList(_context.Professores, "id", "nome", aula.professorID);
            return View(aula);
        }

        // POST: Aulas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,alunoID,professorID,data")] Aula aula)
        {
            if (id != aula.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AulaExists(aula.id))
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
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "nome", aula.alunoID);
            ViewData["professorID"] = new SelectList(_context.Professores, "id", "nome", aula.professorID);
            return View(aula);
        }

        // GET: Aulas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aulas == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas
                .Include(a => a.aluno)
                .Include(a => a.professor)
                .FirstOrDefaultAsync(m => m.id == id);
            if (aula == null)
            {
                return NotFound();
            }
            ViewData["alunoID"] = new SelectList(_context.Alunos, "id", "nome", aula.alunoID);
            ViewData["professorID"] = new SelectList(_context.Professores, "id", "nome", aula.professorID);
            return View(aula);
        }

        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aulas == null)
            {
                return Problem("Entity set 'Contexto.Aulas'  is null.");
            }
            var aula = await _context.Aulas.FindAsync(id);
            if (aula != null)
            {
                _context.Aulas.Remove(aula);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AulaExists(int id)
        {
          return _context.Aulas.Any(e => e.id == id);
        }
    }
}
