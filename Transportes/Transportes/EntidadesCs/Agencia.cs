using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public static class Agencia
   {
      private static List<Factura> facturas = new List<Factura>(); // asoc multiple facturas

      internal static void AddFactura(Factura factura) // internal por abstraccion por asoc
      {
         if (factura == null)
            throw new ArgumentException(" la factura no puede ser nula.");
         if (facturas.Contains(factura))
            throw new ArgumentException(" la factura ya ha sido agregada al registro");
         facturas.Add(factura);
      }

      public static List<Factura> GetAllFacturas()
      {
         return facturas;
      }

      public static List<Factura> GetAllFacturasByFecha(DateTime fecha)
      {
         List<Factura> facturasPorFecha = new List<Factura>();

         foreach (var factura in facturas)
         {
            if (factura.Fecha.Date == fecha.Date) // Comparar solo la fecha, sin importar la hora
               facturasPorFecha.Add(factura);
         }
         return facturasPorFecha;
      }

      public static List<Pasajero> GetPasajerosByDestinoAndFecha(Ciudad destino, DateTime fecha)
      {
         List<Pasajero> pasajerosPorDestinoYFecha = new List<Pasajero>();

         foreach (var factura in facturas)
         {
            foreach (var pasaje in factura.GetPasajes())
            {
               if (pasaje.Fecha.Date == fecha.Date && pasaje.Destino == destino)
                  pasajerosPorDestinoYFecha.Add(pasaje.Pasajero);
            }
         }
         return pasajerosPorDestinoYFecha;
      }

      // queda pendiente: deberia agregar una interfaz que unifique factura y pasajes como movimientos
      // la lista deberia ser de pasajes y facturas (tipo IMovimiento)
      public static List<Persona> GetMovimientosByPersona(Persona persona)
      {
         List<Persona> movimientosPorPersona = new List<Persona>();

         foreach (var factura in facturas)
         {
            if (factura.Cliente.Dni == persona.Dni)
               movimientosPorPersona.Add(factura.Cliente); //ver: deberia agregarse la factura a la lista
            
            foreach (var pasaje in factura.GetPasajes())
            {
               if (pasaje.Pasajero.Dni == persona.Dni)
                  movimientosPorPersona.Add(pasaje.Pasajero); //ver: deberia agregarse el pasaje a la lista
            }
         }
         return movimientosPorPersona;
      }

   }
}
