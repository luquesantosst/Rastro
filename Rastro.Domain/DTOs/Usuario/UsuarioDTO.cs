using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rastro.Domain.DTOs.Usuario
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string Password { get; set; }

        public UsuarioDTO()
        {
            Id = Guid.NewGuid();
        }

    }
}