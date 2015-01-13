using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CinemaDataContext cdb = new CinemaDataContext();
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var list = (from se in cdb.Sessions select se).ToList<Session>();
                cbSessions.ItemsSource = list; // задаем источник для ComboBox Сеансов
                cbSessions.DisplayMemberPath = "Name";
                cbSessions.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dpDate.SelectedDate = DateTime.Today;
        }

        /// <summary>
        /// Обрабатываем событие нажатия на кнопку места в зале
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void But_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SalesRep sr = new SalesRep(); // создаем новый объект записи для таблицы продаж
                int tHall = Convert.ToInt32(((Hall)cbHalls.SelectedItem).Id);
                int tChType = 0;
                sr.HallId = tHall;
                sr.RowNumber = (int)(sender as Button).Tag;
                sr.LocNumber = (int)(sender as Button).Content;
                sr.DateSale = dpDate.SelectedDate.Value;
                int tSes = Convert.ToInt32(((Session)cbSessions.SelectedItem).Id);
                sr.SessionId = tSes;

                if((sender as Button).Background == Brushes.Yellow)
                {
                    tChType = 1;  
                }
                else
                {
                    if((sender as Button).Background == Brushes.Red)
                    {
                        tChType = 2;  
                    }
                    else
                    {
                        if((sender as Button).Background == Brushes.Green)
                        {
                            tChType = 3;  
                        }
                        else
                        {
                            MessageBox.Show("Нет такого типа кресла");
                        }
                    }
                }

                var tick = (from t in cdb.Tickets where (t.ChairTypeId == tChType) select t).ToList<Ticket>();
                sr.Cash = ((Ticket)tick[0]).Price;
                cdb.SalesReps.Add(sr); // добавляем запись в таблицу базы
                cdb.SaveChanges(); // сохраняем изменения в базе
                (sender as Button).IsEnabled = false;
                MessageBox.Show("Билет продан! Дата: " + dpDate.SelectedDate.Value.ToShortDateString()
                    +", " + ((Session)cbSessions.SelectedItem).Name.ToString()
                    + ", Ряд № " + (sender as Button).Tag + ", Место № " + (sender as Button).Content.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Обработчик события выбора Сеанса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSessions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var list = (from h in cdb.Halls select h).ToList<Hall>();
                cbHalls.ItemsSource = list; // задаем источник для ComboBox Залов
                cbHalls.DisplayMemberPath = "Name";
                cbHalls.SelectedIndex = 0;

                int h1 = Convert.ToInt32(((Hall)cbHalls.SelectedItem).Id);
                ChangeHall(h1); // вызываем метод отображения мест в зале на форме Grid
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Обработчик события выбора зала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbHalls_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Session s = (Session)cbSessions.SelectedItem;
                Hall h = (Hall)cbHalls.SelectedItem;
                int h1 = Convert.ToInt32(h.Id);
                int s1 = Convert.ToInt32(s.Id);

                var f1 = (from sch in cdb.Schemas where (sch.SessionId == s1 && sch.HallId == h1) select sch).ToList<Schema>();
                int tm = Convert.ToInt32(f1[0].FilmId);

                var list = (from f in cdb.Films where (f.Id == tm) select f).ToList<Film>();
                cbFilms.ItemsSource = list; // задаем источник для ComboBox Фильмов
                cbFilms.DisplayMemberPath = "Name";
                cbFilms.SelectedIndex = 0;

                ChangeHall(h1); // вызываем метод отображения мест в зале на форме Grid
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// Метод отображения мест в зале на форме Grid
        /// </summary>
        /// <param name="h1">Принимает Id зала</param>
        private void ChangeHall(int h1)
        {
            List<string[]> li = InputHall.InputingHall(h1); // вызываем метод загрузки файла с конфигурацией зала
            int size1 = li.Count(); // задаем размер для определения кол-ва строк рванного массива
            
            grid.Children.Clear();
            grid.HorizontalAlignment = HorizontalAlignment.Left;
            grid.VerticalAlignment = VerticalAlignment.Top;

            Button[][] hallschem = new Button[size1][]; // инициализируем массив кнопок

            double y = 75; // задаем отступ от левого края
            double x = 0; // задаем отступ от верхнего края 
            int tsize = 25; // задаем высоту кнопки

            for (int i = 0; i < hallschem.Length; i++)
            {
                string[] item = li[i];
                int size2 = item.Length; // размер для определения кол-ва столбцов рванного массива в каждой строке
                hallschem[i] = new Button[size2];
                x = 0;
                TextBox tb = new TextBox();
                tb.HorizontalAlignment = HorizontalAlignment.Left;
                tb.VerticalAlignment = VerticalAlignment.Top;
                tb.Text = ("ряд " + (i + 1)); // название ряда
                tb.Height = tsize; // задаем высоту кнопки
                tb.Width = 55;  // задаем ширину кнопки
                tb.Margin = new Thickness(x, y, 0, 0);
                this.grid.Children.Add(tb);
                x = tb.Width + 5; // задаем смещение вправо для следующей кнопки

                int locNum = 1;
                for (int j = 0; j < size2; j++)
                {
                    hallschem[i][j] = new Button();
                    hallschem[i][j].HorizontalAlignment = HorizontalAlignment.Left;
                    hallschem[i][j].VerticalAlignment = VerticalAlignment.Top;
                    hallschem[i][j].Height = tsize;
                    hallschem[i][j].Width = 35;
                    hallschem[i][j].Margin = new Thickness(x, y, 0, 0);
                    x += hallschem[i][j].Width + 5;
                    this.grid.Children.Add(hallschem[i][j]);
                    hallschem[i][j].Click += But_Click;

                    char tc = Convert.ToChar(item[j]);
                    switch (tc)
                    {
                        case '0':
                            {
                                hallschem[i][j].Visibility = System.Windows.Visibility.Hidden;
                                break;
                            }
                        case '1':
                            {
                                Brush br = Brushes.Yellow;
                                locNum = SetButtonData(h1, hallschem, i, locNum, j, br);
                                break;
                            }
                        case '2':
                            {
                                Brush br = Brushes.Red;
                                locNum = SetButtonData(h1, hallschem, i, locNum, j, br);
                                break;
                            }
                        case '3':
                            {
                                Brush br = Brushes.Green;
                                locNum = SetButtonData(h1, hallschem, i, locNum, j, br); break;
                            }
                        default:
                            break;
                    }
                }
                y += tsize + 5; // задаем смещение для следующего ряда кнопок
            }

        }

        /// <summary>
        /// Метод для установки данных кнопки места в зале
        /// </summary>
        /// <param name="h1">Id зала</param>
        /// <param name="hallschem">Массив кнопок</param>
        /// <param name="i">Номер строки массива кнопок</param>
        /// <param name="locNum">Номер места</param>
        /// <param name="j">Номер столбца массива кнопок</param>
        /// <param name="br">Цвет кнопки</param>
        /// <returns>Номер следующего по порядку места в ряду</returns>
        private int SetButtonData(int h1, Button[][] hallschem, int i, int locNum, int j, Brush br)
        {
            hallschem[i][j].Content = locNum;
            hallschem[i][j].Tag = (i + 1);
            hallschem[i][j].Background = br;
            DateTime? tDat = dpDate.SelectedDate;
            if (tDat == null)
            {
                //MessageBox.Show("Выберите дату");
            }
            else
            {
                int tSes = Convert.ToInt32(((Session)cbSessions.SelectedItem).Id);
                var idt = (from s in cdb.SalesReps
                           where (s.HallId == h1 && s.RowNumber == (i + 1) && s.LocNumber == locNum && s.DateSale == tDat && s.SessionId == tSes)
                           select s).ToList<SalesRep>();
                if (idt.Count() > 0)
                {
                    hallschem[i][j].IsEnabled = false;
                }
                locNum++;
            }
            return locNum;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки вывода отчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btZvit_Click(object sender, RoutedEventArgs e)
        {
            Window1 wZvit = new Window1();
            wZvit.ShowDialog();
        }

        /// <summary>
        /// Обработчик изменения даты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            int h1 = Convert.ToInt32(((Hall)cbHalls.SelectedItem).Id);
            ChangeHall(h1); // вызываем метод отображения мест в зале на форме Grid
        }


    }
}