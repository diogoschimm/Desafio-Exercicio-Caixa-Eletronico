# Desafio-Exercicio-Caixa-Eletronico

Desafio do Saque de Notas para Caixa Eletrônico

### 1) Fazer um programa que dado um valor inteiro m ( 3 < m < 32767) calcule o menor número de notas de Real em que este número pode ser decomposto. Lembre-se que as notas existentes são 2, 5, 10, 20, 50 e 100. A Sáida do programa deve ser o valor da entrada seguido de uma lista de notas correspondentes, ex:

- Valor R$ 1.451,00
- R$ 100,00 -- 14 -- R$ 1.400,00
- R$  50,00 --  0 -- R$     0,00
- R$  20,00 --  2 -- R$    40,00
- R$  10,00 --  0 -- R$     0,00
- R$   5,00 --  1 -- R$     5,00
- R$   2,00 --  3 -- R$     6,00

- Total: R$ 1.451,00
- Qtd Notas: 20

## Resultado da Execução

![image](https://user-images.githubusercontent.com/30643035/69021595-bda5ff00-098e-11ea-8e4a-5c9274ee156a.png)

![image](https://user-images.githubusercontent.com/30643035/69021644-e62df900-098e-11ea-9a0d-78af3c580f66.png)

## Código Núcleo

```c#
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
```
