using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rastro.Domain.Entities
{
    public class ContasAReceber : ContaBase
    {
        public string NomeDevedor { get; set; }
        public DateTime DataPrevistaRecebimento { get; set; }
    }
}
