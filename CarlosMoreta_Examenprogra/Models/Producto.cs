using SQLite;
using SQLite.Net.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarlosMoreta_Examenprogra.Models
{
    [Table("Productos")]
    public class Producto
    {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            [MaxLength(100)]
            public string Nombre { get; set; }

            [MaxLength(50)]
            public string Categoria { get; set; }

            public int Cantidad { get; set; }

            public decimal PrecioEstimado { get; set; }
    }
}
