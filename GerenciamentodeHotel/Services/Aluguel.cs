using GerenciamentodeHotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentodeHotel.Services
{
    internal class Aluguel
    {
        public Hospede Hospede { get; set; }
        public Quarto Quarto { get; set; }
        public Funcionario Funcionario { get; set; }
        public List<Aluguel> Alugueis { get; set; }
    }
}
