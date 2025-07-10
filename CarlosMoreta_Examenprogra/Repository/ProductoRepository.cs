using CarlosMoreta_Examenprogra.Models;
using SQLite;
using System.Collections.Generic;

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
