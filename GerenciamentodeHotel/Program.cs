using GerenciamentodeHotel.Entities;
using System.Runtime.CompilerServices;

Aluguel aluguel = new Aluguel();
//Variavel para fazer a contagem de pessoas a ocupar os quartos
int hospedes = 1;

//Obtenção de dados do hospede principal
Console.WriteLine("Bem Vindo! Cadastre seus dados para aluguel de quarto: \n");
Console.Write("Nome: ");
string nome = Console.ReadLine();
Console.Write("Cpf: ");
string cpf = Console.ReadLine();
Console.Write("Tem dependentes para adicionar? (s ou n): ");
char dependente = char.Parse(Console.ReadLine());
Hospede hospede = new Hospede(nome, cpf, dependente);

Console.Clear();

//Obtenção de dados de dependentes do hospede principal
if (dependente == 's')
{
    Console.WriteLine("Quantos dependentes vai adicionar?");
    int x = int.Parse(Console.ReadLine());
    for (int i = 0; i < x; i++)
    {
        Console.WriteLine($"Dependente {i + 1}");
        Console.Write("Nome: ");
        nome = Console.ReadLine();
        Console.Write("Cpf: ");
        cpf = Console.ReadLine();
        hospede.Dependentes.Add(new Dependente(nome, cpf));
        Console.Clear();
    }
    hospedes += x;
}
aluguel.Hospedes = hospede;
Console.Clear();

#region
Console.WriteLine($"Nome: {hospede.Nome}, Cpf: {hospede.Cpf}");
if (dependente == 's')
{
    Console.WriteLine("Dependentes:");
    foreach (Dependente dp in hospede.Dependentes)
    {
        Console.WriteLine($"Nome: {dp.Nome}, Cpf: {dp.Cpf}");
    }
}
Console.WriteLine($"Total de {hospedes} Pessoas");
#endregion

Console.WriteLine("Aperte qualquer tecla para continuar...");
Console.ReadKey();
Console.Clear();

//Carregando quartos pré-definidos via hardcode
Quarto quartos = new Quarto();
quartos.Inicializar();

//Parte de amostra e seleção de quartos
char conf = 'a';
do
{
    Console.WriteLine("Selecione o(s) quarto(s) pelo número correspondente:");
    foreach (Quarto qt in quartos.Quartos)
    {
        Console.WriteLine(qt.ToString());
        Console.WriteLine();
    }
    Console.Write("Digite o Id do quarto selecionado: ");
    int id = int.Parse(Console.ReadLine());
    Quarto refe = quartos.Quartos.Find(x => x.Id == id);

    //teste de ocupação do quarto
    if (refe.Situacao == "Ocupado")
    {
        Console.WriteLine("Esse quarto está ocupado, Escolha outro quarto");
    }
    else
    {
        Console.Clear();
        Console.WriteLine(quartos.Quartos.Find(x => x.Id == id).ToString() + "\n");
        Console.Write("Confirma o quarto escolhido? s ou n: ");
        conf = char.Parse(Console.ReadLine());
        int tamanho = 0;
        if (conf == 's')
        {
            int pos = quartos.Quartos.FindIndex(x => x.Id == id);
            refe = quartos.Quartos.Find(x => x.Id == id);
            refe.Situacao = "Ocupado";
            quartos.Quartos.RemoveAt(pos);
            quartos.Quartos.Insert(pos, refe);
            tamanho = refe.Tamanho;
            aluguel.Quartos.Add(refe);
        }
        Console.Clear();
        if (tamanho < hospedes)
        {
            Console.WriteLine($"Número de pessoas maior que o tamanho do quarto (tamanho {tamanho} pessoas e há {hospedes} pessoas).\n" +
                $"Deseja Selecionar outro quarto? s ou n");
        }
        else
        {
            Console.WriteLine("Deseja Adicionar mais um quarto? s ou n");
        }
        conf = char.Parse(Console.ReadLine());
        Console.Clear();
    }
}
while (conf != 'n');
Console.Clear();
Console.WriteLine("Impressão de hospede(s) e quarto(s) alugado(s)");
Console.WriteLine(aluguel.ShowHospede());
Console.WriteLine("Dependentes:");
foreach (Dependente dp in hospede.Dependentes)
{
    Console.WriteLine($"Nome: {dp.Nome}, Cpf: {dp.Cpf}");
}
foreach (Quarto al in aluguel.Quartos)
{
    al.MostrarAluguel();
}
Console.WriteLine(aluguel.Total().ToString("F2"));