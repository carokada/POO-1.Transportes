using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Factura
   {
      private DateTime fecha;

      private Cliente cliente; // asoc simple cliente (1 factura 1 cliente)
      private List<Pasaje> pasajes; // asoc multiple pasaje (1 factura muchos pasajes)

      public Factura(DateTime fecha, Cliente cliente)
      {
         pasajes = new List<Pasaje>();

         Fecha = fecha;
         Cliente = cliente;

         Agencia.AddFactura(this); // para agregar a la lista facturas de la clase de utilidad
      }

      public DateTime Fecha
      {
         get => fecha;
         set => fecha = value <= DateTime.Now ? value : throw new ArgumentException(" la fecha no puede ser mayor a la del sistema.");
      }

      public Cliente Cliente
      {
         get => cliente;
         set
         {
            cliente = value ?? throw new ArgumentException(" el cliente no puede ser nulo.");
            Cliente.AddFactura(this); // asoc multiple cliente (contraparte internal)
         }
      }

      public decimal CalcularMontoTotal()
      {
         decimal total = 0;
         foreach (var pasaje in pasajes)
         {
            total += pasaje.Monto + pasaje.CalcularIva();
         }
         return total;
      }

      public void AddPasaje(Pasaje pasaje)
      {
         if (pasaje == null)
            throw new ArgumentException(" el pasaje no puede ser nulo.");
         if (pasajes.Contains(pasaje))
            throw new ArgumentException(" el pasaje ya ha sido agregado al registro.");
         pasajes.Add(pasaje);
         // agregar a getMovimientos Persona (IMovimiento)
      }

      public List<Pasaje> GetPasajes()
      {
         return pasajes;
      }

      public void RemovePasaje(Pasaje pasaje)
      {
         if (pasaje == null)
            throw new ArgumentException(" el pasaje no puede ser nulo.");
         if (!pasajes.Contains(pasaje))
            throw new ArgumentException(" el pasaje no ha sido agregado al registro.");
         pasajes.Remove(pasaje);
      }

      public override string ToString()
      {
         return $"[{Fecha.ToString("dd/MM/yy")}] {Cliente} - monto total: ${CalcularMontoTotal()})";
      }
   }
}
