using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace AppLibros
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        //protected override void OnCreate(Bundle savedInstanceState)
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        protected override void OnResume()
        {
            base.OnResume();

            Task cargar = new Task(new Action(CargarPantalla));
            cargar.Start();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

        async void CargarPantalla()
        {
            await Task.Delay(3000);
            Intent pantallaPrincipal = new Intent(this, typeof(MainActivity));
            StartActivity(pantallaPrincipal);
        }
    }
}