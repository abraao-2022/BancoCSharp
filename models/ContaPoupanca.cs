namespace BancoCSharp.models
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca(Titular titular) : base(titular)
        {
        }

        public ContaPoupanca(Titular titular, double saldoAbertura) : base(titular, saldoAbertura)
        {
        }

        public override void ImprimirExtrato()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("***** Extrato Conta Poupança *****");
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