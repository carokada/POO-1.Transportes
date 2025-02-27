using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public abstract class Persona
   {
      // private static List<> movimientos;

      private string dni;
      private string nombre;

      public Persona(string dni, string nombre)
      {
         Dni = dni;
         Nombre = nombre;
      }

      public string Dni
      {
         get => dni;
         set => dni = (value.Length > 0 && value.Length <= 8) ? value : throw new ArgumentException(" el dni no cumple con los requerimientos del campo.");
      }

      public string Nombre
      {
         get => nombre;
         set => nombre = (value.Length > 0 && value.Length <= 30) ? value : throw new ArgumentException(" el nombre no cumple con los requerimientos del campo");
      }

      // public static ?? GetMovimientos() ?? de que ?? 

      public override string ToString()
      {
         return $"[{Dni}] {Nombre}";
      }
   }
}
