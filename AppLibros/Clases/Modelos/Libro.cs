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

namespace AppLibros.Clases.Modelos
{
    public class Libro
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "IDLibro")]
        public int IDLibro { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "Titulo")]
        public string Titulo { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "Autor")]
        public string Autor { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "Descripcion")]
        public string Descripcion { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "Imagen")]
        public string Imagen { get; set; }
    }
}