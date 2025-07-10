using CarlosMoreta_Examenprogra.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosMoreta_Examenprogra.Repository
{
    public class ProductoRepository
    {
        private readonly SQLiteConnection _connection;

        public ProductoRepository(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Producto>();
        }

        public int AgregarProducto(Producto producto)
        {
            return _connection.Insert(producto);
        }

        public List<Producto> ObtenerProductos()
        {
            return _connection.Table<Producto>().ToList();
        }
    }
}
