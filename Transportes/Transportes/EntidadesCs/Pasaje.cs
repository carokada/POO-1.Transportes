using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Pasaje
   {
      private DateTime fecha;
      private decimal monto; //IVA: 21% del MONTO

      private Pasajero pasajero; // asoc simple pasajero (1 pasaje 1 pasajero)
      private Ciudad origen; // asoc simple ciudad (1 pasaje 1 origen)
      private Ciudad destino; // asoc simple ciudad (1 pasaje 1 destino)

      public Pasaje(DateTime fecha, Pasajero pasajero, Ciudad origen, Ciudad destino)
      {
         Fecha = fecha;
         Origen = origen;
         Destino = destino;
         Pasajero = pasajero;
      }

      public DateTime Fecha
      {
         get => fecha;
         set => fecha = value.Date > DateTime.Today ? value : throw new ArgumentException(" la fecha debe ser mayor a la del sistema.");
      }

      public Pasajero Pasajero
      {
         get => pasajero;
         set
         {
            pasajero = value ?? throw new ArgumentException(" el pasajero no puede ser nulo.");
            pasajero.AddPasaje(this); // asoc multiple pasajero
            // set completo con el addPasaje. le corresponde la responsabilidad del atributo pasajero. se pone la referencia en la propiedad de la asociacion. si el pasaje se borra deberia haber un metodo que elimine el pasaje de la lista del pasajero.
            // agregar a getMovimientos Persona ??
         }
      }

      public Ciudad Origen
      {
         get => origen;
         set => origen = value ?? throw new ArgumentException(" la ciudad de origen no puede ser nula.");
      }

      public Ciudad Destino
      {
         get => destino;
         set => destino = value ?? throw new ArgumentException(" la ciudad de destino no puede ser nula.");
      }

      public decimal Monto
      {
         get => monto;
         set => monto = value > 0 ? value : throw new ArgumentException(" el monto debe ser mayor a cero.");
      }

      public decimal CalcularIva()
      {
         return Monto * .21M;
      }

      public override string ToString()
      {
         return $"{Pasajero}: desde {Origen} hasta {Destino} ({Fecha.ToString("dd/MM/yy")})";
      }
   }
}
