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

        public LogService(string Apellido)
        {
            string filename = $"Logs_{Apellido}.txt";
            _logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), filename); 
        }

        public void Log(string message)
        {
            string logEntry = $"{DateTime.Now:dd/MM/yyyy HH:mm} - {message}";
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
