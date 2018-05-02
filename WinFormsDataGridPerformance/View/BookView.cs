using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WpfApplication2.ViewModel;

namespace WinFormsDataGridPerformance
{
    public partial class BookView : Form
    {
        private BookViewModel viewModel;
        public BookView()
        {
            InitializeComponent();
            viewModel = new BookViewModel();
        }

        private void BookView_Load(object sender, EventArgs e)
        {
            var source = new BindingSource(viewModel.Book, null);
            grid.DataSource = source;
        }
    }
}
