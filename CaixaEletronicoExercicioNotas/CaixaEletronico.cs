using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaixaEletronicoExercicioNotas
{
    public class CaixaEletronico
    {
        private readonly List<int> NotasDisponiveis = new List<int>() { 2, 5, 10, 20, 50, 100 };

        public List<Item> SepararNotas(int valor)
        {
            this.Validar(valor);

            return this.Separar(valor);
        }

        private void Validar(int valor)
        {
            if (this.NotasDisponiveis == null || this.NotasDisponiveis.Count() == 0)
                throw new Exception("Nenhuma nota disponível para realizar o Saque");

            if (this.NotasDisponiveis.FirstOrDefault(x => x == 1) == 1)
                throw new Exception("Na lista de Notas disponíveis não pode ser adicionado a nota R$ 1,00");

            if (valor <= 3)
                throw new Exception("Valor não pode ser menor ou igual a R$ 3,00 Reais");

            if (valor >= 32767)
                throw new Exception("Valor não pode ser maior ou igual a R$ 32.767,00 Reais");
        }

        private List<Item> Separar(int valor)
        {
            var notas = new List<Item>
            {
                new Item(0, valor)
            };

            foreach (var nota in this.NotasDisponiveis.OrderByDescending(x => x))
            {
                valor = this.Add(notas, valor, nota);
            }

            if (valor > 0)
                throw new Exception("Valor Inválido, Notas Disponíveis " + this.StrNotasDisponiveis());

            return notas;
        }

        private int Add(List<Item> notas, int valor, int nota)
        {
            int valorAdd = 0;

            if (valor >= nota)
            {
                int divRem = valor / nota;
                valor %= nota;
                if (valor == 1 || valor == 3)
                {
                    valor += nota;
                    if (divRem > 1)
                    {
                        valorAdd = divRem - 1;
                    }
                }
                else
                {
                    valorAdd = divRem;
                }
            }

            notas.Add(new Item(nota, valorAdd));
            return valor;
        }

        public void Exibir(List<Item> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item.ToString() + " ");
            }

            Console.WriteLine("");
            Console.WriteLine("Total = " + String.Format("{0:c}", lista.Where(x => x.Nota != 0).Sum(p => p.ValorTotal)));
            Console.WriteLine("Qtd Notas = " + lista.Where(x => x.Nota != 0).Sum(p => p.Valor));
            Console.WriteLine("");
        }

        private string StrNotasDisponiveis()
        {
            string textoNotas = "";
            foreach (var item in this.NotasDisponiveis)
            {
                textoNotas += string.Format("{0:c}", item) + ", ";
            }
            return textoNotas;
        }
    }
}
