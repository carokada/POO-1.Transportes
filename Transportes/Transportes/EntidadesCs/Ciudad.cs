using System;

namespace EntidadesCs
{
   public class Ciudad
   {
      private string nombre;

      public Ciudad(string nombre)
      {
         Nombre = nombre;
      }

      public string Nombre
      {
         get => nombre;
         set => nombre = (value.Length > 0 && value.Length < 30) ? value : throw new ArgumentException(" el nombre no cumple con los requerimientos del campo");
      }

      public override string ToString()
      {
         return $"{Nombre}";
      }
   }
}
