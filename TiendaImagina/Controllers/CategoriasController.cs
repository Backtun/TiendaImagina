using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaImagina.Models;

namespace TiendaImagina.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly TiendaImaginaContext _context;

        public CategoriasController(TiendaImaginaContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categoria.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*Este atributo indica que sólo recibirá peticiones de método POST*/
        [HttpPost]
        /*
        *Este atributo genera un unica cookie en tu navegador 
        *y luego en el mismo formulario, si la cookie no coincide 
        *cuando se hace submit te envía un error. 
        *Se utiliza para evitar falsificaciones de solicitudes entre sitios
        */
        [ValidateAntiForgeryToken]
        /*
        *El método recibe la información de la petición y anexiona la información
        *a un objeto del tipo Categoria.
        */
        public async Task<IActionResult> Create([Bind("CategoriaId,Nombre,Fecha")] Categoria categoria)
        {
            /*
            *Revisa el estado del objeto que recibe el controlador
            *Si es correcto guardará los datos en la base de datos
            *Si no es correcto lanzará un mensaje de error en el campo correspondiente
            */
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: Categorias/Edit/id
        public async Task<IActionResult> Edit(long? id)
        {
            //si id es null devuelve un not found.
            if (id == null)
            {
                return NotFound();
            }
            //Crea una varible con la categoría seleccionada cogiendo la id que le pasa el método.
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/id
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CategoriaId,Nombre,Fecha")] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //Comprueba la posible salida de errores SQL y realiza el cambio en la entidad categoría.
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.CategoriaId))
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
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        //Este método es el mismo que el de editar pero aplicado a la vista delete
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoria = await _context.Categoria
                .FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //Crea una variable de categoria buscando por la id.
            var categoria = await _context.Categoria.FindAsync(id);
            //Prepara una sentencia para remover de la entidad la categoria correspondiente a la id.
            _context.Categoria.Remove(categoria);
            //Lanza los cambios a la base de datos.
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(long id)
        {
            return _context.Categoria.Any(e => e.CategoriaId == id);
        }
    }
}
