using System;

namespace snakeCode
{
    public class Usuario
    {
         public string Nombre { get; set; }
        public string Apodo { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public int Edad
        {
            get
            {
                return (DateTime.Now.Year - FechaDeNacimiento.Year);
            }
        }
    }
}