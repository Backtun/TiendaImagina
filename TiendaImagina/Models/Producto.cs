using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TiendaImagina.Models
{
    public class Producto
    {
        public long ProductoId { get; set; }

        [StringLength(40, MinimumLength = 4)]
        [Required]
        public string Nombre { get; set; }

        [Range(1, 1000)]
        [BindRequired]
        public decimal Precio { get; set; }

        [Range(typeof(DateTime), "1/1/2016", "1/1/2020")]
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
