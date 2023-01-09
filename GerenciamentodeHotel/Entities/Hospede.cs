using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentodeHotel.Entities
{
    internal class Hospede
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public List<Dependente> Dependentes { get; set; }

        public Hospede()
        {
        }

        public Hospede(string nome, string cpf, string dependente)
        {
            Nome = nome;
            Cpf = cpf;
            if (dependente == "s")
            {
                Dependentes = new List<Dependente>();
            }
        }

        public void AddDependente(Dependente dependente)
        {
            Dependentes.Add(dependente);
        }
        public void DelDependente(Dependente dependente)
        {
            Dependentes.Remove(dependente);
        }
        public override string ToString()
        {
            return $"Nome: {Nome}, Cpf: {Cpf}";
        }
    }
}
