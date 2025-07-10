using CarlosMoreta_Examenprogra.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosMoreta_Examenprogra.ViewModels
{
    public class LogsViewModel : INotifyPropertyChanged
    {
        private const string LogFileName = "Logs_Masin.txt";

        public ObservableCollection<string> Logs { get; } = new();

        public LogsViewModel()
        {
            CargarLogs();
        }

        public void CargarLogs()
        {
            Logs.Clear();

            string path = FileAccessHelper.GetLocalFilePath(LogFileName);

            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    Logs.Add(line);
                }
            }
            else
            {
                Logs.Add("No hay registros en el archivo de logs.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
