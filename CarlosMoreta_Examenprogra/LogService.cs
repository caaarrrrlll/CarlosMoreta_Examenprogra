using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosMoreta_Examenprogra
{
    public class LogService
    {
        private readonly string _logFilePath;
        private readonly string _nombreProducto;  

        public LogService(string apellido, string nombreProducto)
        {
            string filename = $"Logs_{apellido}.txt";
            _logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), filename);
            _nombreProducto = nombreProducto; 
        }

        public void EscribirLog(string message)
        {
            string logEntry = $"Se incluyo el registro de [{_nombreProducto}] el {DateTime.Now:dd/MM/yyyy HH:mm} - {message}";
            File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
        }

        public List<string> GetLogs()
        {
            if (!File.Exists(_logFilePath))
            {
                return new List<string> { "No hay registros en el archivo de logs." };
            }
            return File.ReadAllLines(_logFilePath).ToList();
        }
    }
}
