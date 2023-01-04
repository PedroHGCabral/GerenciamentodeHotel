using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentodeHotel.Entities
{
    internal class Dependente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public Dependente(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
    }
}
