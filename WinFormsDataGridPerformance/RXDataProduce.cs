using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using WpfApplication2.Model;

namespace WinFormsDataGridPerformance
{
    public class RXDataProduce
    {
        public static Subject<BookRow> stream = new Subject<BookRow>();

        public static void StartProduceData()
        {
            var interval = Observable.Interval(TimeSpan.FromMilliseconds(1));
            interval.Subscribe(i => stream.OnNext(new BookRow
            {
                posicao = (int)i,
                qtdCompra = new Random().Next(999),
                qtdVenda = new Random().Next(999),
                pxCompra = new Random().Next(99),
                pxVenda = new Random().Next(99)
            }));
        }
    }
}
