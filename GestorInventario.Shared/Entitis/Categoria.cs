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
        [Key]
        public int ID_Categoria { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string? Descripcion { get; set; }
    }
}