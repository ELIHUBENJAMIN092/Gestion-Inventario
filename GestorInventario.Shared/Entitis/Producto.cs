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
        [Key]
        public int IdProducto { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }  // Nombre del producto

        public string? descripcion { get; set; }  // Descripción opcional

        [Required]
        [Column(TypeName = "decimal(18, 2)")] // Configura la precisión con anotación compatible
        public decimal precio_unitario { get; set; }  // Precio unitario

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int stockactual { get; set; }  // Stock actual, con valor por defecto 0

        public int? id_proveedor { get; set; }  // Relación con Proveedor, puede ser nulo si no se asigna
    }
}