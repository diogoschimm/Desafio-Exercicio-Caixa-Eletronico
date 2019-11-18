using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronicoExercicioNotas
{
    public class Item
    {
        public int Nota { get; set; }
        public int Valor { get; set; }
        public int ValorTotal { get { return this.Nota * this.Valor; } }

        public Item(int nota, int valor)
        {
            this.Nota = nota;
            this.Valor = valor;
        }
        public Item() { }
        public override string ToString()
        {
            if (this.Nota == 0)
                return "Vlr Saque = " + this.Valor;
            else
                return String.Format("{0:c}", this.Nota) + " = " + this.Valor + String.Format(" ==> {0:c}", this.ValorTotal);
        }
    }
}
