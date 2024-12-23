using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInventario.Shared.Entitis
{
    public class Producto
    {
        public int Cantidad;

        [Key]
        public int IdProducto { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal precio_unitario { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int stockactual { get; set; }

        public int? id_proveedor { get; set; }
    }
}