using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using AppLibros.Clases.Modelos;

using System.Net.Http;
using System.Threading.Tasks;

namespace AppLibros.Clases.Servicios
{
    public class LibroServicio
    {
        private HttpClient httpClient;
        private string servicioURL = "http://192.168.1.1:8081/api";

        public static string servicioImagenesURL = "http://192.168.1.1/webapp-libros/imagenes/";

        public LibroServicio()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Libro>> ConsultarLibros()
        {
            List<Libro> libros;

            string json = await httpClient.GetStringAsync(servicioURL + "/libros");

            libros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Libro>>(json);

            foreach(Libro l in libros)
            {
                System.Console.WriteLine(l.Titulo);
            }

            return libros;
        }

        public async Task<Libro> ConsultarLibro(int id)
        {
            List<Libro> libros;

            string json = await httpClient.GetStringAsync(servicioURL + "/libro/" + id);

            libros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Libro>>(json);

            foreach (Libro l in libros)
            {
                System.Console.WriteLine(l.Titulo);
            }

            return libros[0];
        }

        public async Task InsertarLibro(Libro libro)
        {
            string ContentType = "application/x-www-form-urlencoded";

            System.Console.WriteLine("Titulo=" + libro.Titulo);
            System.Console.WriteLine("Autor=" + libro.Autor);
            System.Console.WriteLine("Descripcion=" + libro.Descripcion);
            System.Console.WriteLine("Imagen=" + libro.Imagen);

            string parametros = String.Format("Titulo={0}&Autor={1}&Descripcion={2}&Imagen={3}", libro.Titulo, libro.Autor, libro.Descripcion, libro.Imagen);

            System.Console.WriteLine("datos=" + parametros);

            HttpResponseMessage res = await httpClient.PostAsync(servicioURL + "/libro/agregar/", new StringContent(parametros, Encoding.UTF8, ContentType));

            if(res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                System.Console.WriteLine("Funciona - Status Code: OK");
            }
            else
            {
                System.Console.WriteLine("Error - Status Code: " + res.StatusCode.ToString());
            }
        }
    }
}