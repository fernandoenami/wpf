using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Threading;
using WpfApplication2.Model;

namespace WpfApplication2.ViewModel
{
    public class BookViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BookRow> _book = new ObservableCollection<BookRow>();

        public ObservableCollection<BookRow> Book
        {
          get { return _book; }
          set { _book = value; }
        }

        private int _render;
        public int Render
        {
            get { return _render; }
            set { _render = value; OnPropertyChanged("Render"); }
        }

        public object _lock = new object();
        static int countRender = 0;


        public BookViewModel()
        {
            //BindingOperations.EnableCollectionSynchronization(Book, _lock);
            Observable.Interval(TimeSpan.FromMilliseconds(300))
                .SubscribeOn(NewThreadScheduler.Default)
                .ObserveOn(DispatcherScheduler.Current)
                .Subscribe(_ =>
                    {
                        this.Book.Clear();
                        for (int i = 0; i < 10; i++)
                        {
                            this.Book.Add(new BookRow()
                            {
                                posicao = i,
                                qtdCompra = new Random().Next(999),
                                qtdVenda = new Random().Next(999),
                                pxCompra = new Random().Next(99),
                                pxVenda = new Random().Next(99)

                            });
                        }

                        //Dispatcher.CurrentDispatcher.BeginInvoke(
                        //  DispatcherPriority.Loaded,
                        //  new Action(() =>
                        //  {
                        //      countRender++;
                        //      Render = countRender;
                        //  }));
                    });
                   

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
