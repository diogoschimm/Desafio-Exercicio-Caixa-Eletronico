using System;
using System.Collections.Generic;

namespace CaixaEletronicoExercicioNotas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    if (MenuSistema() == "x")
                        break;
                }
                catch (Exception ex)
                {
                    TratarExcecao(ex);
                }
            }
        }

        private static string MenuSistema()
        {
            string valor = TelaSolicitarValor();

            if (int.TryParse(valor, out int valorInt))
            {
                var caixaEletronico = new CaixaEletronico();
                caixaEletronico.Exibir(caixaEletronico.SepararNotas(valorInt));
            }

            return valor;
        }

        private static string TelaSolicitarValor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("##### Caixa Eletrônico #####");
            Console.WriteLine("");
            Console.Write("Informe o valor que deseja sacar, x para sair, l para limpar: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string valor = Console.ReadLine();
            Console.WriteLine("");

            if (valor == "l")
                Console.Clear();

            return valor;
        }

        private static void TratarExcecao(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.WriteLine("");
        }

    }
}
