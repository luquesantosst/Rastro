using System;
using Rastro.Domain.Entities.Enums;

namespace Rastro.Domain.Entities
{
    public abstract class ContaBase
    {
        public ContaBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Observacoes { get; set; }
        public StatusConta Status { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
