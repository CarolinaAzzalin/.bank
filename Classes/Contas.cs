using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybank
{
    class Conta
    {    // Atributos de uma conta (Tipo de conta , Crédito, Saldo, Nome)
        // Atributos como privado para não ter a possibilidade de alteração em nenhum ponto do código (Emcapsulmaento).Caso queira alterar o valor, será criado um método.
        private TipoConta TipoConta { get; set; } // Criar um enum TipoConta para Pfisica e Pjurídica
        private double Credito {get;set;}
        private double Saldo { get; set;}
        private string Nome { get; set;} 



        //Método de construtor (método que é chamado no momento que é criado meu objeto)
        public Conta (TipoConta tipoconta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoconta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public Conta(TipoConta tipoconta)
        {
            TipoConta = tipoconta;
        }

        // Métodos que serão realizados na conta (Sacar, depositar, transferir, consultar saldo)

        public bool Sacar (double valorSaque)  // bool true = se conseguir completar a operação / false se não conseguir.
        {
            //Validação de saldo suficiente
            if(this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insufuciente");
                return false;
            }

            this.Saldo = this.Saldo - valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} e {1}", this.Nome, this.Saldo);  // Utilizando um vetor de dados onde o {0} corresponde a This.nome e {1} a this.Saldo.
           
            return true;
        }

        public void Depositar(double valorDeposito) // Método depositar
        {
            this.Saldo = this.Saldo + valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} e {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()   // Criado para sobscrever o ToString da classe mãe, para ser possível a leitura no console.
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito + " | ";
            return retorno;
        }

    }
}
