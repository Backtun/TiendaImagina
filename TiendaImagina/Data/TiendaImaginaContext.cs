using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiendaImagina.Models;

namespace TiendaImagina.Models
{
    public class TiendaImaginaContext : DbContext
    {
        public TiendaImaginaContext (DbContextOptions<TiendaImaginaContext> options)
            : base(options)
        {
        }

        public DbSet<TiendaImagina.Models.Producto> Producto { get; set; }

        public DbSet<TiendaImagina.Models.Categoria> Categoria { get; set; }

        public DbSet<TiendaImagina.Models.Comentario> Comentario { get; set; }
    }
}
