using System;
using System.IO;
using Newtonsoft.Json;

namespace snakeCode
{
  class Perfil
    {
        const string _archivoJson = @"MisDatos.json";
        const string _archivoText = @"MisDatos.txt";
        


        public static Usuario[] LeerDatosJson()
        {
            Usuario[] result = null;
            string path = System.IO.Path.GetFullPath(_archivoJson);
            if (File.Exists(path))
            {
                StreamReader archivo = new StreamReader(path);
                string jsonString = archivo.ReadToEnd();
                result = JsonConvert.DeserializeObject<Usuario[]>(jsonString);
            }

            return result;
        }

        public static Usuario[] LeerDatosTexto()
        {
            Usuario[] result = null;
            string path = System.IO.Path.GetFullPath(_archivoText);
            if (File.Exists(path))
            {
                string[] lineas = File.ReadAllLines(path);
                result = new Usuario[lineas.Length];
                for (int i = 0; i < lineas.Length; i++)
                {
                    string ln = lineas[i];
                    string[] datos = ln.Split(',');

                    Usuario usr = new Usuario();
                    usr.Nombre = datos[0];
                    usr.Apodo = datos[1];
                    string fecha = datos[2];
                    usr.FechaDeNacimiento = DateTime.Parse(fecha);

                    result[i] = usr;
                }
            }

            return result;
        }




        public static void ImprimirDatos(Usuario[] usuarios)
        {

            for (int i = 0; i < usuarios.Length; i++)
            {
                Usuario usr = usuarios[i];
                Console.WriteLine($"***********************************************");
                Console.WriteLine($"{i + 1}) Usuario: {usr.Apodo}");
                Console.WriteLine($"    Nombre: {usr.Nombre}");
                Console.WriteLine($"    Fecha de Nacimiento: {usr.FechaDeNacimiento}");
                Console.WriteLine($"    Edad: {usr.Edad}");
                Console.WriteLine($"***********************************************");
                Console.WriteLine(" ");
            }

        }

        public static void ImprimirTituloSeccion(string titulo)
        {
            Console.WriteLine($"***********************************************");
            Console.WriteLine($"                {titulo}");
            Console.WriteLine($"***********************************************");

        }

        public static void GuardarUsuario(Usuario usr){
            //Guardar en el archivo de texto
            GuardarLineaTexto($"{usr.Nombre},{usr.Apodo},{usr.FechaDeNacimiento.ToShortDateString()}");

            //Guaradr en el archivo json


        }

        public static void GuardarLineaTexto(string linea)
        {
            string path = System.IO.Path.GetFullPath(_archivoText);
            if (File.Exists(path))
            {
                StreamWriter WriteReportFile = File.AppendText(path);
                WriteReportFile.WriteLine($"{linea}");
                WriteReportFile.Close();
            }
        }

        public static void GuardarJson(Usuario[] usr){
            //crear el metodo para guardar
        }







    }
    
}