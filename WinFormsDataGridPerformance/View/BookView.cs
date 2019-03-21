using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reactive.Linq;
using System.Windows.Data;
using System.Windows.Threading;
using WpfApplication2.Model;

using WpfApplication2.ViewModel;

namespace WinFormsDataGridPerformance
{
    public partial class BookView : Form
    {
        public BookView()
        {
            InitializeComponent();
        }

        private BindingList<BookRow> _book = new BindingList<BookRow>();


        public BindingList<BookRow> Book
        {
            get { return _book; }
            set { _book = value; }
        }

        private void BookView_Load(object sender, EventArgs e)
        {
            RXDataProduce.StartProduceData();

            var source = new BindingSource(this.Book, null);
            grid.DataSource = source;

            RXDataProduce.stream
                .SubscribeOn(System.Reactive.Concurrency.TaskPoolScheduler.Default)
                //.Sample(TimeSpan.FromMilliseconds(500))
                .Buffer(TimeSpan.FromMilliseconds(5000), 500)
                .ObserveOn(this.grid)
                .Subscribe(b =>
                {
                    this.Book.Clear();
                    foreach (var item in b)
                    {
                        this.Book.Add(item);
                    }
                    
                });

                                    //BindingOperations.EnableCollectionSynchronization(Book, _lock);
                //                    Observable.Interval(TimeSpan.FromMilliseconds(300))
                //.SubscribeOn(System.Reactive.Concurrency.TaskPoolScheduler.Default)
                //.ObserveOn(this.grid)
                //.Subscribe(_ =>
                //{
                //    this.Book.Clear();
                //    for (int i = 0; i < 10; i++)
                //    {
                //        this.Book.Add(new BookRow()
                //        {
                //            posicao = i,
                //            qtdCompra = new Random().Next(999),
                //            qtdVenda = new Random().Next(999),
                //            pxCompra = new Random().Next(99),
                //            pxVenda = new Random().Next(99)

                //        });
                //    }

                    //                         Dispatcher.CurrentDispatcher.BeginInvoke(
                    //                           DispatcherPriority.Loaded,
                    //                           new Action(() =>
                    //                           {
                    //                               countRender++;
                    //                               Render = countRender;
                    //                           }));
                //});
        }
    }
}
