using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TiendaImagina.Models
{
    public class BDInicial
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TiendaImaginaContext(
                serviceProvider.GetRequiredService<DbContextOptions<TiendaImaginaContext>>()))
            {
                // Busca si existen Productos.
                if (context.Producto.Any())
                {
                    //En caso de que hayan productos en la base de datos no hará la inicialización.
                    return;
                }

                //Añadimos productos    
                context.Producto.AddRange(
                     new Producto
                     {
                         Nombre = "Unity",
                         Precio = 1000,
                         Fecha = DateTime.Now,
                         CategoriaId = 2
                     },

                     new Producto
                     {
                         Nombre = ".NET",
                         Precio = 500,
                         Fecha = DateTime.Now,
                         CategoriaId = 2
                     }
                );

                context.Categoria.AddRange(
                new Categoria
                {
                    Nombre = "Python",
                    Fecha = DateTime.Now
                }

                );


                context.SaveChanges();
            }
        }
    }
}
