using Rastro.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rastro.Domain.Entities
{
    public class Parcelas : ContaBase
    {
        public int NumeroParcela { get; set; }
        public bool Pago { get; set; }
        public DateTime? DataPagamento { get; set; }
        public Guid ContaAPagarId { get; set; }
        public Guid ContaAReceberId { get; set; }

        public Parcelas(int numeroParcela,
                        StatusConta statusConta,
                        DateTime dataVencimento,
                        DateTime? dataPagamento = null,
                        Guid contaAPagarId = default,
                        Guid contaAReceberId = default,
                        bool pago = false)
        {
            Id = Guid.NewGuid();
            Status = statusConta;
            DataVencimento = dataVencimento;
            NumeroParcela = numeroParcela;
            Pago = pago;
            DataPagamento = dataPagamento;
            ContaAPagarId = contaAPagarId;
            ContaAReceberId = contaAReceberId;
        }
    }

}
