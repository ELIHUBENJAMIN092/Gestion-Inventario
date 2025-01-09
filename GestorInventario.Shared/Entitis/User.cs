using System.ComponentModel.DataAnnotations;

namespace GestorInventario.Shared.Entitis
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        private string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        public Rol? Rol { get; set; }

        [Required]
        public int RolId { get; set; }
    }
}