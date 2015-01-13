using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CinemaProject
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        CinemaDataContext cdb = new CinemaDataContext();
        /// <summary>
        /// Constructor
        /// </summary>
        public Window1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var tsale = (from s in cdb.SalesReps select new { s.Hall, s.Session, s.Id, s.DateSale, s.RowNumber, s.LocNumber, s.Cash }).ToList();
            dgZvit.ItemsSource = tsale; // задаем источник для вывода записей таблицы в Grid

            float sum = 0;
            foreach (var item in tsale)
            {
                sum += item.Cash;
            }
            this.tbw1.Text += sum.ToString() + " грн.";
        }
    }
}
