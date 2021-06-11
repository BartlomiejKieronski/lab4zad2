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
using System.Text.RegularExpressions;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy ocenyWindow.xaml
    /// </summary>
    public partial class ocenyWindow : Window
    {
        public int ocena { get; set; }
        public ocenyWindow()
        {
            InitializeComponent();
        }

        private void btnOAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(tbOcena.Text, @"^[1-6]{0,1}$"))
            {
                ocena = int.Parse(tbOcena.Text);

            }
            else
            {
                MessageBox.Show("Podaj ocene w zakresie 1-6");
            }
            this.DialogResult = true;
        }
    }
}
