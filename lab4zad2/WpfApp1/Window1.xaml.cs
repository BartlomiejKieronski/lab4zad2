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
using System.Windows.Shapes;
using WpfApp1;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private MainWindow.Studenci studenci;

        public Window1()
        {
        }

        public Window1(List<Ocena> lista)
        {
            InitializeComponent();
            dgGrades.Columns.Add(new DataGridTextColumn() { Header = "Oceny", Binding = new Binding("ocena") });
            dgGrades.AutoGenerateColumns = false;
            dgGrades.ItemsSource = lista;
        }

        public Window1(MainWindow.Studenci studenci)
        {
            this.studenci = studenci;
        }

        public MainWindow.Studenci student { get; internal set; }

        private void dgGrades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class Ocena
    {
    }
}
