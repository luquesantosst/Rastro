using System;

namespace Rastro.Domain.DTOs.ContasAPagar
{
    public class CreateContasAPagarDTO
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public Guid UsuarioId { get; set; }
        public string NomeCredor { get; set; }
        public string? Observacoes { get; set; }
        public bool Parcelado { get; set; }
        public int? NumeroParcelas { get; set; }
        public bool LembreteAtivo { get; set; }
        public DateTime? DataLembrete { get; set; }
    }
}
