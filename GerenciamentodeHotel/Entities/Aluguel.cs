using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentodeHotel.Entities
{
    internal class Aluguel
    {
        public Hospede Hospedes { get; set; }
        public List<Quarto> Quartos { get; set; }

        public Aluguel()
        {
            Quartos = new List<Quarto>();
        }

        public Aluguel(Hospede hospedes, List<Quarto> quartos)
        {
            Hospedes = hospedes;
            Quartos = quartos;
        }

        public double Total()
        {
            double x = 0.0;
            foreach (Quarto q in Quartos)
            {
                x += q.Preco;
            }
            return x;
        }

        public string ShowHospede()
        {
            return Hospedes.ToString();
        }
    }
}