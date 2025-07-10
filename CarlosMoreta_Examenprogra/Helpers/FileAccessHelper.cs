using System;
using System.IO;

namespace CarlosMoreta_Examenprogra.Helpers
{
    public static class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(path, filename);
        }
    }
}
