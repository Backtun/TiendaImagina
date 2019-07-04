using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaImagina.Models
{
    public class Producto
    {
        public long ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }

        [DisplayName("Categoria")]
        public long CategoriaId { get; set; }
        // creamos una variable para guardar la id de la categoría.

        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }


        /* esta lista conforma la relación manyToOne 
        entre Producto y Comentario*/
        public List<Comentario> Comentarios { get; set; }

    }
}
