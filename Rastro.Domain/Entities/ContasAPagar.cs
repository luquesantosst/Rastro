using Rastro.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rastro.Domain.Entities
{
    public class ContasAPagar : ContaBase
    {
        public string NomeCredor { get; private set; }
        public bool LembreteAtivo { get; private set;}
        public DateTime? DataLembrete { get; private set;}
        public bool Parcelado { get; private set; }
        public int? NumeroParcelas { get; private set;}
        public int? ParcelaAtual { get; private set;}
        public List<Parcelas> Parcelas { get; private set; }
        public decimal? ValorParcela { get; private set;}
        public decimal? ValorTotal { get; private set;}

        public ContasAPagar()
        {

        }

        public ContasAPagar(
           string nomeCredor,
           decimal valor,
           DateTime dataVencimento,
           Guid usuarioId,
           string observacoes = null,
           bool parcelado = false,
           int? numeroParcelas = null,
           bool lembreteAtivo = false,
           DateTime? dataLembrete = null,
           List<Parcelas> parcelas = null)
        {
            Id = Guid.NewGuid();
            NomeCredor = nomeCredor;
            Valor = valor;
            DataVencimento = dataVencimento;
            UsuarioId = usuarioId;
            Observacoes = observacoes;
            Status = StatusConta.Pendente;

            ConfigurarParcelamento(parcelado, numeroParcelas);
            ConfigurarLembrete(lembreteAtivo, dataLembrete);
        }
        

        private void ConfigurarParcelamento(bool parcelado, int? numeroParcelas)
        {
            if (parcelado)
            {
                if (!numeroParcelas.HasValue || numeroParcelas <= 1)
                    throw new ArgumentException("Número de parcelas deve ser maior que 1 para contas parceladas.");

                Parcelado = true;
                NumeroParcelas = numeroParcelas;
                ValorParcela = Math.Round(Valor / NumeroParcelas.Value, 2);
                ValorTotal = ValorParcela * NumeroParcelas.Value;
                ParcelaAtual = 1;
            }
            else
            {
                Parcelado = false;
                NumeroParcelas = null;
                ValorParcela = null;
                ValorTotal = Valor;
                ParcelaAtual = null;
            }
        }

        private void ConfigurarLembrete(bool lembreteAtivo, DateTime? dataLembrete)
        {
            LembreteAtivo = lembreteAtivo;

            if (lembreteAtivo)
            {
                DataLembrete = dataLembrete ?? DataVencimento.AddDays(-2);

            if (dataLembrete >= DataVencimento)
                throw new ApplicationException("A data do lembre não pode ser maior que a data do vencimento da conta.");
            }
            else
            {
                DataLembrete = null;
            }
        }

        public void AtualizarParcelamento(bool parcelado, int? numeroParcelas)
        {
            if (Status != StatusConta.Pendente)
                throw new ApplicationException("Não é possível alterar o parcelamento de uma conta que não está pendente.");

            ConfigurarParcelamento(parcelado, numeroParcelas);
        }

        public void AtualizarLembrete(bool lembreteAtivo, DateTime? dataLembrete)
        {
            ConfigurarLembrete(lembreteAtivo, dataLembrete);
        }

        public void AtualizarStatus(StatusConta novoStatus)
        {
            Status = novoStatus;
        }
    }
}
