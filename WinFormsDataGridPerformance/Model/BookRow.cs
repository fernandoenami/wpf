using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2.Model
{
    public class BookRow
    {
        public int posicao { get; set; }
        public int qtdCompra { get; set; }
        public int pxCompra { get; set; }
        public int pxVenda { get; set; }
        public int qtdVenda { get; set; }

        public override string ToString()
        {
            return posicao + " " + qtdCompra + " " + pxCompra + " " + pxVenda + " " + qtdVenda;
        }
    }
}
