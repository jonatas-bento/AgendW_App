using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendW.Models
{
    public class Atendimento
    {
            public int Id { get; set; }
            public string TipoAtendimento { get; set; }
            public string NomeCliente { get; set; }
            public string EmailCliente { get; set; }
            public string TelCliente { get; set; }
            public string PlacaCarro { get; set; }
            public string MarcaCarro { get; set; }
            public string ModeloCarro { get; set; }
            public DateTime DataDesejadaAtendimento { get; set; }
            public bool Pneus { get; set; }
            public bool Freios { get; set; }
            public bool Suspensao { get; set; }
            public bool Escapamento { get; set; }
            public bool TrocaOleo { get; set; }
            public bool RevisaoPadrao { get; set; }
            public bool AlinhamentoEBalanceamento { get; set; }
            public bool MecanicaLeve { get; set; }
            public string Status { get; set; }
            public string? MotivoCancelamento { get; set; }
            public string UnidadeAtendimento { get; set; }

            public string DescricaoProblema { get; set; }
        
    }
}
