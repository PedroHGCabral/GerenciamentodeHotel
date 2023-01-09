using GerenciamentodeHotel.Entities;
using System.Diagnostics;
using System.Security.Cryptography;

Aluguel aluguel = new Aluguel();
Hospede hospede = null;
//Variavel para fazer a contagem de pessoas a ocupar os quartos
int hospedes = 1;

//Obtenção de dados do hospede principal
Console.WriteLine("Bem Vindo! Cadastre seus dados para aluguel de quarto: \n");
Console.Write("Nome: ");
string nome = Console.ReadLine();
Console.Write("Cpf: ");
string cpf = Console.ReadLine();
Console.Write("Tem dependentes para adicionar? (s ou n): ");
string dependente = Console.ReadLine().ToLower();
Console.Clear();

//Obtenção de dados de dependentes do hospede principal
if (dependente != "s" && dependente != "n") // verificação de segurança pra evitar erro de entrada do usuário. Em caso de erro repete a solicitação
{
    do
    {
        Console.WriteLine("\nComando Inválido! Digite com (s) para sim ou (n) para não\n\n");
        Console.Write("Tem dependentes para adicionar? (s ou n): ");
        dependente = Console.ReadLine().ToLower();
        hospede = new Hospede(nome, cpf, dependente);
        Console.Clear();
    }
    while (dependente != "s" && dependente != "n");
}
if (dependente == "s") //verificação se vai adicionar dependente ou não
{
    int x = 0;
    do //looping para evitar erros de digitação do usuário. Com certeza tem um jeito mais eficiente e mais limpo de fazer isso, descobrir como.
    {
        hospede = new Hospede(nome, cpf, dependente);
        try
        {

            Console.WriteLine("Quantos dependentes vai adicionar?");
            x = int.Parse(Console.ReadLine());
            if (x == 999) // para encerrar adição de dependentes
            {
                break;
            }
            else if (x > 0) // para add dependente se entrada for maior que 0
            {
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
            else // caso dependente for 0 ou menor lançar erro e repetir processo
            {
                Console.WriteLine("Por favor insira um número válido ou digite '999' para cancelar");
                x = 0;
                Console.Clear();
            }
        }
        catch //caso entrada não seja um int lançar erro e repetir processo
        {

            Console.WriteLine("Por favor insira um número válido ou digite '999' para cancelar");
            x = 0;
            Console.Clear();
        }
    }
    while (x <= 0);
}
aluguel.Hospedes = hospede;
Console.Clear();

// Mostrar Hospede e dependentes com contagem de pessoas
#region
Console.WriteLine($"Nome: {hospede.Nome}, Cpf: {hospede.Cpf}");
if (dependente == "s")
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
int id = 0;
do
{
    Console.WriteLine("Selecione o(s) quarto(s) pelo número correspondente:");
    foreach (Quarto qt in quartos.Quartos)
    {
        Console.WriteLine(qt.ToString());
        Console.WriteLine();
    }
    try
    {
        Console.Write("Digite o Id do quarto selecionado: ");
        id = int.Parse(Console.ReadLine());
        Quarto refe = quartos.Quartos.Find(x => x.Id == id);
        //teste de ocupação do quarto
        if (refe.Situacao == "Ocupado")
        {
            Console.Clear();
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
            }
            else
            {
                conf = 's';
            }

            Console.Clear();
        }
    }
    catch
    {
        Console.WriteLine("Informação incorreta! Tente novamente!");
        conf = 'a';
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
Random random = new Random();
Console.WriteLine("Valor Total: R$" + aluguel.Total().ToString("F2"));
Console.WriteLine("Código para Check-In: " + random.Next());
