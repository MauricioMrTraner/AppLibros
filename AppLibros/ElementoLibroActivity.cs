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

using AppLibros.Clases.Servicios;
using AppLibros.Clases.Modelos;

using Square.Picasso;

namespace AppLibros
{
    [Activity(Label = "Libro")]
    public class ElementoLibroActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Eliminar la notificacion
            NotificationManager notiMan = NotificationManager.FromContext(this);
            notiMan.Cancel(Intent.Extras.GetInt("Key_IDLibro"));

            // Create your application here
            SetContentView(Resource.Layout.ElementoLibro);

            TextView lblIDLibro = FindViewById<TextView>(Resource.Id.lblIDLibro);
            TextView lblTitulo = FindViewById<TextView>(Resource.Id.lblTitulo);
            TextView lblAutor = FindViewById<TextView>(Resource.Id.lblAutor);
            TextView lblDescripcion = FindViewById<TextView>(Resource.Id.lblDescripcion);
            ImageView imgLibro = FindViewById<ImageView>(Resource.Id.imgLibro);

            LibroServicio servicio = new LibroServicio();
            int _IDLibro = Intent.Extras.GetInt("Key_IDLibro");
            Libro libro = await servicio.ConsultarLibro(_IDLibro);

            lblIDLibro.Text = "IDLibro: " + Convert.ToString(libro.IDLibro);
            lblTitulo.Text = "Título: " + libro.Titulo;
            lblAutor.Text = "Autor: " + libro.Autor;
            lblDescripcion.Text = "Descripción: " + libro.Descripcion;

            Picasso.With(this)
                .Load(LibroServicio.servicioImagenesURL + libro.Imagen)
                .Placeholder(Resource.Drawable.Icon)
                .Into(imgLibro);
        }
    }
}