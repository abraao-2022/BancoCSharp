namespace BancoCSharp.models
{
    public class ContaInvestimento : ContaBancaria
    {
        public double ValorInvestido { get; private set; }
        public ContaInvestimento(Titular titular) : base(titular)
        {
        }

        public ContaInvestimento(Titular titular, double saldoAbertura) : base(titular, saldoAbertura)
        {
        }

        public override void ImprimirExtrato()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("*** Extrato Conta Investimento ***");
            Console.WriteLine("**********************************");
            Console.WriteLine();

            System.Console.WriteLine("Gerado em: " + DateTime.Now);
            System.Console.WriteLine();

            foreach (var movimentacao in Movimentacoes)
            {
                System.Console.WriteLine(movimentacao.ToString());
            }

            System.Console.WriteLine("Saldo atual: R$ " + Saldo);
            System.Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine("********* Fim do extrato *********");
            Console.WriteLine("**********************************");
            Console.WriteLine();
        }
    }
}