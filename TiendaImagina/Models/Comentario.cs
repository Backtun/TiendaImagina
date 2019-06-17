using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaImagina.Models
{
    public class Comentario
    {
        public long ComentarioId { get; set; }
        public string Texto { get; set; }
        public string NombreUsuario { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Fecha { get; set; }

        [DisplayName("Producto")]
        public long ProductoId { get; set; }
        // creamos una variable para guardar la id del producto.

        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        public Comentario()
        {
            this.Fecha = DateTime.Now;
        }
    }
}
