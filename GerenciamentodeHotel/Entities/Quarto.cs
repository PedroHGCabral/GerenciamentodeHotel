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
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Tamanho { get; set; }
        public string Situacao { get; set; }
        public List<Quarto> Quartos { get; set; }

        public Quarto()
        {
            Quartos = new List<Quarto>();
        }

        public Quarto(int id, string nome, double preco, int tamanho)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Tamanho = tamanho;
            Situacao = "Vago";
        }

        public Quarto(int id, string nome, double preco, int tamanho, string situacao)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Tamanho = tamanho;
            Situacao = situacao;
        }

        public void Inicializar()
        {
            Quartos.Add(new Quarto(1, "Suite Master", 1000.00, 10, "Vago"));
            Quartos.Add(new Quarto(2, "King", 879.99, 6, "Vago"));
            Quartos.Add(new Quarto(3, "Queen", 750.00, 6, "Ocupado"));
            Quartos.Add(new Quarto(4, "Suite de Luxo", 670.00, 6, "Ocupado"));
            Quartos.Add(new Quarto(5, "Suite de Luxo 2", 670.00, 6, "Vago"));
            Quartos.Add(new Quarto(6, "Suite de Luxo 3", 670.00, 6, "Ocupado"));
            Quartos.Add(new Quarto(7, "Básico", 150.00, 4, "Vago"));
            Quartos.Add(new Quarto(8, "Básico 2", 150.00, 4, "Vago"));
            Quartos.Add(new Quarto(9, "Básico 3", 150.00, 4, "Vago"));
            Quartos.Add(new Quarto(10, "Básico 4", 150.00, 4, "Ocupado"));
            Quartos.Add(new Quarto(11, "Familiar", 250.00, 8, "Vago"));
            Quartos.Add(new Quarto(12, "Familiar 2", 250.00, 8, "Ocupado"));
            Quartos.Add(new Quarto(13, "Familiar 3", 250.00, 8, "Vago"));
            Quartos.Add(new Quarto(14, "Familiar 4", 250.00, 8, "Ocupado"));
        }

        public override string ToString()
        {
            return "Id: " + Id
                + "\nQuarto: " + Nome
                + "\nValor: " + Preco.ToString("F2")
                + "\nTamanho: " + Tamanho
                + " Pessoas" + "\nSituação: " + Situacao + "";
        }

        public string MostrarAluguel()
        {
            return "\nQuarto: " + Nome
                + "\nValor: R$" + Preco.ToString("F2")
                + "\nTamanho: " + Tamanho;
        }
    }
}