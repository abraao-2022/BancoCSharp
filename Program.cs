using BancoCSharp.models;

Console.WriteLine("**********************************");
Console.WriteLine("********** Banco CSharp *********");
Console.WriteLine("**********************************");
Console.WriteLine();

var titutlar01 = new Titular(
    "José da Silva",
    "12345678901",
    "21999997788",
    new Endereco
    {
        Cep = "28900630",
        Rua = "Rua XYZ",
        Numero = 53,
    }
);
var titutlar02 = new Titular(
    "Maria da Silva",
    "12345678901",
    "21999997799",
    new Endereco
    {
        Cep = "28900630",
        Rua = "Rua XYZ",
        Numero = 53,
    }
);

var conta01 = new ContaCorrente(titutlar01, 100.0);
var conta02 = new ContaInvestimento(titutlar02);
var conta03 = new ContaPoupanca(titutlar02);

conta01.Depositar(50);

conta02.Depositar(500);
conta02.Sacar(100);
conta02.Transferir(conta03, 100);

conta03.Sacar(25);

conta01.ImprimirExtrato();
conta02.ImprimirExtrato();
conta03.ImprimirExtrato();

System.Console.WriteLine();
