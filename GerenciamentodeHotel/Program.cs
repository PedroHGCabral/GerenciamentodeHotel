using GerenciamentodeHotel.Entities;


Console.WriteLine("Bem Vindo Funcionário de cadastro:");
Console.WriteLine("Id: 10");
Console.WriteLine("Nome: Pedro Cabral");
Console.WriteLine("Cargo: Recepcionista");
Console.WriteLine("Cpf: 059.885.272-20");

Console.WriteLine("Adicionar um hospede:");
Console.Write("Nome: ");
string nome = Console.ReadLine();
Console.Write("Cpf: ");
string cpf = Console.ReadLine();
Console.Write("Tem dependentes? s ou n");
char dependente = char.Parse(Console.ReadLine());
Hospede hospede = new Hospede(nome, cpf, dependente);
if (dependente == 's')
{
    Console.WriteLine("Quantos dependentes vai adicionar?");
    int x = int.Parse(Console.ReadLine());
    for (int i = 0; i < x; i++)
    {
        Console.Write("Nome: ");
        nome = Console.ReadLine();
        Console.Write("Cpf: ");
        cpf = Console.ReadLine();
        hospede.Dependentes.Add(new Dependente(nome, cpf));
    }
}

Console.WriteLine($"Nome: {hospede.Nome}, Cpf: {hospede.Cpf}");
if (hospede.Dependentes.Count > 0)
{
    Console.WriteLine("Dependentes:");
    foreach (Dependente dp in hospede.Dependentes)
    {
        Console.WriteLine($"Nome: {dp.Nome}, Cpf: {dp.Cpf}");
    }
}