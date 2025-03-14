﻿using System.ComponentModel.DataAnnotations;

namespace GestorInventario.Shared.Entitis
{
    public class Rol
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        // Genericos

        //public ICollection<User> Users { get; set; }

        // public int UserCount => Users == null ? 0 : Users.Count();// lectura
    }
}