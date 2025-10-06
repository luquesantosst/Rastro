using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rastro.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public virtual ICollection<ContasAPagar> ContasAPagar { get; set; }
        public virtual ICollection<ContasAReceber> ContasAReceber { get; set; }

        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
        {
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
        }
    }
}
