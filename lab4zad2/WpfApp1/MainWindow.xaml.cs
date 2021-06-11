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
using System.Text.RegularExpressions;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Ocena> ListaOcen { get; set; }
        public List<Studenci> ListaStudentow { set; get; }
        public MainWindow()

        {            
            ListaStudentow = new List<Studenci>()
            {
                new Studenci() { Imie = "Jan",Nazwisko="Kowalski",NrIndeksu=1234,Wydzial="KIS" ,
                ListaOcen = new List<Ocena>()
                {
                    new Ocena(){Oceny=1},
                    new Ocena(){Oceny =2}
                }
                },

                new Studenci() { Imie = "Anna",Nazwisko="Nowak",NrIndeksu=4321,Wydzial="KIS",
                ListaOcen = new List<Ocena>()
                {
                    new Ocena(){Oceny=1},
                    new Ocena(){Oceny =2}
                } },
                new Studenci() { Imie = "Michał",Nazwisko="Jacek",NrIndeksu=3421,Wydzial="KIS" }
            };
            InitializeComponent();
            
            DgStudenci.Columns.Add(new DataGridTextColumn() { Header = "Imie", Binding = new Binding("Imie") });
            DgStudenci.Columns.Add(new DataGridTextColumn() { Header = "Nazwisko", Binding = new Binding("Nazwisko") });
            DgStudenci.Columns.Add(new DataGridTextColumn() { Header = "NrIndeksu", Binding = new Binding("NrIndeksu") });
            DgStudenci.Columns.Add(new DataGridTextColumn() { Header = "Wydzial", Binding = new Binding("Wydzial") });

            DgStudenci.AutoGenerateColumns = false;
            DgStudenci.ItemsSource = ListaStudentow;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new StudentWindow();
            if (dialog.ShowDialog() == true)
            {

                ListaStudentow.Add(dialog.student);
                DgStudenci.Items.Refresh();
            }
        }
        private void btnSub_Click(object sender, RoutedEventArgs e)
        {
            if (DgStudenci.SelectedItem is Studenci)
            {
                ListaStudentow.Remove((Studenci)DgStudenci.SelectedItem);
                DgStudenci.Items.Refresh();
            }
        }
        private void DgStudenci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnEddit_Click(object sender, RoutedEventArgs e)
        {
            var index = DgStudenci.SelectedIndex;
            if(index != -1)
            {
                var dialog = new Window1(ListaStudentow[index]);

                if (dialog.ShowDialog() == true)
                {
                    if (DgStudenci.SelectedItem is Studenci)
                    {
                        ListaStudentow.Remove((Studenci)DgStudenci.SelectedItem);
                        DgStudenci.Items.Refresh();
                    }
                    ListaStudentow.Add(dialog.student);
                    DgStudenci.Items.Refresh();

                }
            }
            else
            {
                MessageBox.Show("Wybierz studenta");
            }
        }

        private void btnAddsG_Click(object sender, RoutedEventArgs e)
        {
            var index = DgStudenci.SelectedIndex;
            if (index != -1)
            {
                var dialog = new ocenyWindow();
                if (dialog.ShowDialog() == true)
                {
                    var oceny = ListaStudentow[index].ListaOcen;
                    var ocena = dialog.ocena;
                    if (ocena >= 1)
                    {
                        oceny.Add(new Ocena() { Oceny = ocena });
                    }
                
                }
                

            }
            else
            {
                MessageBox.Show("Wybierz studenta");
            }
        }
        private void btnSGS_Click(object sender, RoutedEventArgs e)
        {
            var index = DgStudenci.SelectedIndex;
            if (index != -1)
            {
                var dialog = new Window1();
                if (dialog.ShowDialog() == true)
                {
                    var oceny = ListaStudentow[index].ListaOcen;
                    dialog.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Wybierz Studenta");
                }
            }
        }
    }
}