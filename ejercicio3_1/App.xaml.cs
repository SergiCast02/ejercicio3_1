using ejercicio3_1.Controllers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ejercicio3_1
{
    public partial class App : Application
    {
        static DataBase db;

        public static DataBase DBase
        {
            get
            {
                if (db == null)
                {
                    String FolderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Empleado.db3");
                    db = new DataBase(FolderPath);
                }

                return db;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new Views.ListEmpleadoView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
