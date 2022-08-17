using ejercicio3_1.ViewModels;
using ejercicio3_1.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ejercicio3_1.Behaviors
{
    public class EventToCommand : Behavior<ListView>
    {
        public INavigation Navigation { get; set; }

        protected override void OnAttachedTo(ListView listview)
        {
            listview.ItemSelected += OnListViewItemSelected;
            base.OnAttachedTo(listview);
        }

        protected override void OnDetachingFrom(ListView listview)
        {
            listview.ItemSelected -= OnListViewItemSelected;
            base.OnDetachingFrom(listview);
        }

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation = App.Current.MainPage.Navigation;

            var SelectedEmpleado = (Models.Empleado)e.SelectedItem;

            var page = new EmpleadoView();

            page.BindingContext = new EmpleadoViewModel()
            {
                Id = SelectedEmpleado.Id,
                Nombre = SelectedEmpleado.Nombre,
                Apellidos = SelectedEmpleado.Apellidos,
                Edad = SelectedEmpleado.Edad,
                Direccion = SelectedEmpleado.Direccion,
                Puesto = SelectedEmpleado.Puesto,
                Foto = SelectedEmpleado.Foto,

                btncrearIsVisible = false,
                btnactualizarIsVisible = true,
                btneliminarIsVisible = true,

                Navigation = Navigation
            };

            await Navigation.PushAsync(page);
        }

    }
}
