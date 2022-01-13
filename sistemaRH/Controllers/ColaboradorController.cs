using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaRH.Data;
using sistemaRH.Models;

namespace sistemaRH.Controllers
{
    [Authorize]
    public class ColaboradorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColaboradorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Colaborador
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Colaborador.Include(c => c.Cargo).Include(c => c.Setor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Colaborador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Cargo)
                .Include(c => c.Setor)
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // GET: Colaborador/Create
        public IActionResult Create()
        {
            ViewData["IdCargo"] = new SelectList(_context.Cargo, "IdCargo", "Descricao");
            ViewData["IdSetor"] = new SelectList(_context.Setor, "IdSetor", "Descricao");
            return View();
        }

        // POST: Colaborador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matricula,Nome,Endereco,Telefone,Admissao,Salario,Gestor,IdSetor,IdCargo")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaborador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCargo"] = new SelectList(_context.Cargo, "IdCargo", "Descricao", colaborador.IdCargo);
            ViewData["IdSetor"] = new SelectList(_context.Setor, "IdSetor", "Descricao", colaborador.IdSetor);
            return View(colaborador);
        }

        // GET: Colaborador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            ViewData["IdCargo"] = new SelectList(_context.Cargo, "IdCargo", "Descricao", colaborador.IdCargo);
            ViewData["IdSetor"] = new SelectList(_context.Setor, "IdSetor", "Descricao", colaborador.IdSetor);
            return View(colaborador);
        }

        // POST: Colaborador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matricula,Nome,Endereco,Telefone,Admissao,Salario,Gestor,IdSetor,IdCargo")] Colaborador colaborador)
        {
            if (id != colaborador.Matricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorExists(colaborador.Matricula))
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
            ViewData["IdCargo"] = new SelectList(_context.Cargo, "IdCargo", "Descricao", colaborador.IdCargo);
            ViewData["IdSetor"] = new SelectList(_context.Setor, "IdSetor", "Descricao", colaborador.IdSetor);
            return View(colaborador);
        }

        // GET: Colaborador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaborador = await _context.Colaborador
                .Include(c => c.Cargo)
                .Include(c => c.Setor)
                .FirstOrDefaultAsync(m => m.Matricula == id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return View(colaborador);
        }

        // POST: Colaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colaborador = await _context.Colaborador.FindAsync(id);
            _context.Colaborador.Remove(colaborador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorExists(int id)
        {
            return _context.Colaborador.Any(e => e.Matricula == id);
        }
    }
}
