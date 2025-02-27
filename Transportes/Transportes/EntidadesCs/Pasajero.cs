using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public sealed class Pasajero : Persona
   {
      private List<Pasaje> pasajes; // asoc multiple pasaje (1 pasajero muchos pasajes)

      public Pasajero(string dni, string nombre) : base(dni, nombre)
      {
         pasajes = new List<Pasaje>();
      }

      // internal: acceso limitado al ensamblado actual
      // nivel paquete porque la otra clase lo hace de manera publica. una expone y la otra no.
      internal void AddPasaje(Pasaje pasaje) 
      {
         if (pasaje == null)
            throw new ArgumentException(" el pasaje no puede ser nulo.");
         pasajes.Add(pasaje);
      }

      public List<Pasaje> GetAllPasajes()
      {
         return pasajes;
      }
   }
}
