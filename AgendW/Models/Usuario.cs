using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendW.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? NomeFoto { get; set; }
        public string Email { get; set; }
        public string? Telefone { get; set; }
        public int AtribuicaoId { get; set; }
    }
}
