﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjAtividadeBanco.models
{
    internal class ContaPoupanca
    {
        public string Titular { get; set; }
        public string NumeroConta { get; set; }
        public double Saldo { get; set; }
        public DateTime DataDeAniversario = DateTime.Now;

        public string exibirDadosConta()
        {
            return $"#############################\n " +
            $"O nome do titular é: {this.Titular}, " +
            $"o número de sua conta é: {this.NumeroConta}, " +
            $"seu saldo atual é de: {this.Saldo}, " +
            $"e sua data de entrada é: {this.DataDeAniversario}. " +
            $"\n#############################";
        }

        public void Sacar(double valor)
        {
            if (valor > Saldo)
            {
                throw new InvalidOperationException("#############################\n Saque não permitido. Valor maior que o saldo. \n#############################");
            }
            this.Saldo -= valor;
        }

        public void Depositar(double valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("#############################\n Valor do depósito deve ser maior que zero.\n#############################");
            }
            this.Saldo += valor;
        }
        public string exibirDadosPosOperacao()
        {
            return $"#############################\n " +
            $"seu saldo atual é de: {this.Saldo}, " +
            $"\n#############################";
        }

        public void Transferir(double valor, ContaPoupanca contaDestino)
        {
            if (valor > Saldo)
            {
                throw new InvalidOperationException("Transferência não permitida. Valor maior que o saldo.");
            }

            this.Sacar(valor); 
            contaDestino.Depositar(valor);
        }
        public void Transferir(double valor, ContaEspecial contaDestino)
        {
            if (valor > Saldo)
            {
                throw new InvalidOperationException("Transferência não permitida. Valor maior que o saldo.");
            }

            this.Sacar(valor);
            contaDestino.Depositar(valor);
        }

    }
}
