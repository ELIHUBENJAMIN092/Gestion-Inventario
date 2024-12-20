using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInventario.Shared.Entitis
{
    public class Categoria
    {
        [Key] // Indica que esta propiedad es la clave primaria
        public int ID_Categoria { get; set; }

        [Required] // Indica que esta propiedad es obligatoria
        [MaxLength(100)] // Establece el tamaño máximo de la columna Nombre
        public string Name { get; set; }

        [MaxLength(255)] // Establece el tamaño máximo de la columna Descripcion
        public string? Descripcion { get; set; }
    }
}