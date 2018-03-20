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
using AppLibros.Clases.Servicios;

using Square.Picasso;

namespace AppLibros.Clases.Adaptadores
{
    class ListaLibrosAdaptador : BaseAdapter<Libro>
    {
        private Activity Contexto;
        private List<Libro> ListaLibros;

        public ListaLibrosAdaptador(Activity contexto, List<Libro> listaLibros)
        {
            this.Contexto = contexto;
            this.ListaLibros = listaLibros;
        }

        public override Libro this[int position]
        {
            get
            {
                return this.ListaLibros[position];
            }
        }

        public override int Count
        {
            get
            {
                return this.ListaLibros.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return this.ListaLibros[position].IDLibro;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Libro libro = this.ListaLibros[position];

            if(convertView == null)
            {
                convertView = this.Contexto.LayoutInflater.Inflate(Resource.Layout.FilaListaLibros, null);
            }

            TextView libroTitulo = convertView.FindViewById<TextView>(Resource.Id.libroTitulo);
            ImageView libroImagen = convertView.FindViewById<ImageView>(Resource.Id.libroImagen);

            libroTitulo.Text = libro.Titulo;

            Picasso.With(Contexto)
                .Load(LibroServicio.servicioImagenesURL + libro.Imagen)
                .Placeholder(Resource.Drawable.Icon)
                .Into(libroImagen);

            return convertView;
        }
    }
}