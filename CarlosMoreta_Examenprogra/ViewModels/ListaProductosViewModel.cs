using CarlosMoreta_Examenprogra.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarlosMoreta_Examenprogra.ViewModels
{
    public class ListaProductosViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Producto> Productos { get; set; } = new();

        public ICommand CargarCommand { get; }

        public ListaProductosViewModel()
        {
            CargarCommand = new Command(CargarProductos);
            CargarProductos();
        }

        private void CargarProductos()
        {
            Productos.Clear();
            var lista = App.ProductoRepo.ObtenerProductos();

            foreach (var prod in lista)
                Productos.Add(prod);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
