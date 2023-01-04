using System;
using GerenciamentodeHotel.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentodeHotel.Entities
{
    internal class Quarto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Tamanho { get; set; }
        public int MyProperty { get; set; }
        public Status Situacao { get; set; }
        public List<Quarto> Quartos { get; set; }
    }
}
