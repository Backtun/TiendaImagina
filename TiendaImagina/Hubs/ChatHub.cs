using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TiendaImagina.Hubs
{
    public class ChatHub : Hub
    {
        //Es un método al que le pasamos dos valores de tipo String, el usuario y el mensaje 
        public async Task EnviarMensaje(string user, string message)
        {
            /*
             * Clients: hace referencia a los clientes que están contectados apuntando al Hub,
             * con él podemos decir a quién queremos enviar el mensaje.
             * All: indicamos quien queremos enviar el mensaje a todos los usuarios conectados.
             * SendAsync: enviamos de forma asíncrona, esta función requiere del nombre de un
             * método, este método es la función de javascript que usaremos para ejecutarlo,
             * además le añadimos los parámetros que le estamos pasando en esta función: user
             * y message.
             */
            await Clients.All.SendAsync("RecibirMensaje", user, message);
        }
    }
}
