using CarlosMoreta_Examenprogra.Models;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarlosMoreta_Examenprogra.Helpers;

namespace CarlosMoreta_Examenprogra.ViewModels
{
    public class AgregarProductoViewModel : INotifyPropertyChanged
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioEstimado { get; set; }

        private string mensaje;
        public string Mensaje
        {
            get => mensaje;
            set
            {
                mensaje = value;
                OnPropertyChanged(nameof(Mensaje));
            }
        }

        public ICommand GuardarCommand { get; }

        public AgregarProductoViewModel()
        {
            GuardarCommand = new Command(GuardarProducto);
        }

        private void GuardarProducto()
        {
            if (Cantidad < 1 && Categoria?.ToLower() != "ropa")
            {
                Mensaje = "La cantidad mínima es 1 (excepto para Ropa).";
                return;
            }

            var producto = new Producto
            {
                Nombre = Nombre,
                Categoria = Categoria,
                Cantidad = Cantidad,
                PrecioEstimado = PrecioEstimado
            };

            App.ProductoRepo.AgregarProducto(producto);

            string logFile = FileAccessHelper.GetLocalFilePath("Logs_Moreta.txt");
            string logEntry = $"Se incluyó el registro [{producto.Nombre}] el {System.DateTime.Now:dd/MM/yyyy HH:mm}";
            File.AppendAllText(logFile, logEntry + System.Environment.NewLine);

            Mensaje = $"Producto '{producto.Nombre}' agregado correctamente.";
            Nombre = Categoria = string.Empty;
            Cantidad = 0;
            PrecioEstimado = 0;
            OnPropertyChanged(nameof(Nombre));
            OnPropertyChanged(nameof(Categoria));
            OnPropertyChanged(nameof(Cantidad));
            OnPropertyChanged(nameof(PrecioEstimado));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

