using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaImagina.Models
{
    public class Categoria
    {
        public long CategoriaId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }

        /* esta lista conforma la relación manyToOne 
        entre Producto y Categoria*/
        public List<Producto> Productos { get; set; }
    }
}
