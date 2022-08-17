using System;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using ejercicio3_1.Models;

using Xamarin.Forms;
using System.Collections.Generic;
using ejercicio3_1.Views;
using ejercicio3_1.Behaviors;

namespace ejercicio3_1.ViewModels
{
    public class ListEmpleadoViewModel : BaseViewModel
    {

        private ObservableCollection<Empleado> _empleados;

        public ObservableCollection<Empleado> Empleados
        {
            get { return _empleados; }
            set { _empleados = value; OnPropertyChanged(); }
        }

        private Empleado _selectedEmpleado;

        public Empleado SelectedEmpleado
        {
            get { return _selectedEmpleado; }
            set { _selectedEmpleado = value; OnPropertyChanged(); }
        }



        public ICommand CrearEmpleadoCommand { private set; get; }



        public INavigation Navigation { get; set; }



        public ListEmpleadoViewModel(INavigation navigation)
        {
            Navigation = navigation;
            CrearEmpleadoCommand = new Command<Type>(async (pageType) => await CrearEmpleado(pageType));
        }

        public async void setearEmpleadosSQLite()
        {
            Empleados = new ObservableCollection<Empleado>();

            List<Empleado> ListEmpleados = new List<Empleado>();

            try
            {
                ListEmpleados = await App.DBase.obtenerListaEmpleado();

                if (ListEmpleados != null)
                {
                    ListEmpleados.Reverse();

                    for (int i = 0; i < ListEmpleados.Count; i++)
                    {
                        Empleados.Add(ListEmpleados[i]);
                    }
                }
            }
            catch (Exception error){}
        }

        async Task CrearEmpleado(Type pageType)
        {
            var page = (Page)Activator.CreateInstance(pageType);

            page.BindingContext = new EmpleadoViewModel()
            {
                btncrearIsVisible = true,
                btnactualizarIsVisible = false,
                btneliminarIsVisible = false,

                Navigation = Navigation
            };

            await Navigation.PushAsync(page);
        }

    }
}
