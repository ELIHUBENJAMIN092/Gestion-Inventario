using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInventario.Shared.Entitis
{
    public class Entrada_Inventario
    {
        [Key]
        public int ID_Entrada { get; set; }

        public DateTime Fecha_Entrada { get; set; } = DateTime.Now;

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int ID_Producto { get; set; }

        [Required]
        public int ID_Proveedor { get; set; }

        // Las relaciones con Producto y Proveedor se representarían con las siguientes propiedades
        public Producto productos { get; set; }

        public Proveedor proveedores { get; set; }
    }
}