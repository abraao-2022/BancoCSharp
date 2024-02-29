using BancoCSharp.Enums;

namespace BancoCSharp.models
{
    public abstract class ContaBancaria
    {
        #region Atributos
        public Titular Titular { get; set; }
        public double Saldo { get; private set; }
        public DateTime DataAbertura { get; private set; }
        protected List<Movimentacao> Movimentacoes { get; set; }
        protected readonly double VALOR_MINIMO = 10.0;

        #endregion

        #region Construtores
        public ContaBancaria(Titular titular, double saldoAbertura)
        {
            Titular = titular;
            Saldo = saldoAbertura;
            DataAbertura = DateTime.Now;

            Movimentacoes = new List<Movimentacao>()
            {
                new Movimentacao(TipoMovimentacao.ABERTURA_CONTA, saldoAbertura)
            };

        }
        public ContaBancaria(Titular titular)
        {
            Titular = titular;
            Saldo = 0;
            DataAbertura = DateTime.Now;

            Movimentacoes = new List<Movimentacao>()
            {
                new Movimentacao(TipoMovimentacao.ABERTURA_CONTA, Saldo)
            };
        }

        #endregion

        #region Metodos

        public void Depositar(double valor)
        {
            if (valor < VALOR_MINIMO)
            {
                throw new Exception("O valor minimo para deposito é R$ " + VALOR_MINIMO);
            }

            Saldo += valor;
            Movimentacoes.Add(new Movimentacao(TipoMovimentacao.DEPOSITO, valor));
        }

        public double Sacar(double valor)
        {
            if (valor < VALOR_MINIMO)
            {
                throw new Exception("O valor minimo para saque é R$ " + VALOR_MINIMO);
            }

            if (valor > Saldo)
            {
                throw new Exception("valor de saque maior do que o saldo da conta, Saldo atual R$ " + Saldo);
            }

            Saldo -= valor;
            Movimentacoes.Add(new Movimentacao(TipoMovimentacao.SAQUE, valor));

            return valor;
        }

        public void Transferir(ContaBancaria contaDestino, double valor)
        {
            if (valor < VALOR_MINIMO)
            {
                throw new Exception("valor minimo para transferência é de R$ " + VALOR_MINIMO);
            }

            if (valor > Saldo)
            {
                throw new Exception("O seu saldo é insuficiente para efetuar a transferência, Saldo atual: R$ " + Saldo);
            }

            contaDestino.Depositar(valor);
            Saldo -= valor;
            Movimentacoes.Add(new Movimentacao(TipoMovimentacao.TRANSFERENCIA, valor));
        }

        public virtual void ImprimirExtrato()
        {
            System.Console.WriteLine("Imprimir extrato!");
        }

        #endregion

    }
}