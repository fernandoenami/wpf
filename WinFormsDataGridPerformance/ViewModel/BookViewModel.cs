using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
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
