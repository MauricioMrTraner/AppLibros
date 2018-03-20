using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;

using AppLibros.Clases.Adaptadores;
using AppLibros.Clases.Servicios;
using AppLibros.Clases.Modelos;
using Android.Media;
using Android.Graphics;
using System.Threading.Tasks;

namespace AppLibros
{
    [Activity(Label = "Libros")]
    public class MainActivity : Activity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
            ListView lvLibros = FindViewById<ListView>(Resource.Id.lvLibros);

            LibroServicio servicio = new LibroServicio();
            List<Libro> libros = await servicio.ConsultarLibros();

            lvLibros.Adapter = new ListaLibrosAdaptador(this, libros);
            lvLibros.ItemClick += LvLibros_ItemClick;
            lvLibros.ItemLongClick += LvLibros_ItemLongClick;
        }

        private async void LvLibros_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            Libro libro = await (new LibroServicio()).ConsultarLibro((int)e.Id);

            Intent pantallaLibro = new Intent(this, typeof(ElementoLibroActivity));
            pantallaLibro.PutExtra("Key_IDLibro", libro.IDLibro);

            PendingIntent pendiente = PendingIntent.GetActivity(this, libro.IDLibro, pantallaLibro, PendingIntentFlags.OneShot);

            Toast.MakeText(this, "Titulo: " + libro.Titulo, ToastLength.Short).Show();

            Notification.Builder notiBui = new Notification.Builder(this);
            notiBui.SetContentTitle(libro.IDLibro + ".- Notificación de AppLibros");
            //notiBui.SetContentText("Ejemplo de notificación con Xamarin Android :)");
            Notification.BigTextStyle notiBig = new Notification.BigTextStyle();
            notiBig.BigText("Ejemplo de notificación con Xamarin Android :)");
            notiBui.SetStyle(notiBig);
            notiBui.SetSmallIcon(Resource.Drawable.Icon);
            notiBui.SetLargeIcon(BitmapFactory.DecodeResource(Resources, Resource.Drawable.Icon));
            notiBui.SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate);
            notiBui.SetContentIntent(pendiente);

            Notification noti = notiBui.Build();

            NotificationManager notiMan = NotificationManager.FromContext(this);
            notiMan.Notify(libro.IDLibro, noti);
        }

        private async void LvLibros_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Libro libro = await (new LibroServicio()).ConsultarLibro((int)e.Id);

            Intent pantallaLibro = new Intent(this, typeof(ElementoLibroActivity));
            pantallaLibro.PutExtra("Key_IDLibro", libro.IDLibro);
            StartActivity(pantallaLibro);
        }
    }
}

