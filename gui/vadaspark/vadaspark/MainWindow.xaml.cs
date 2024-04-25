using System;
using System.Collections.Generic;
using System.IO;
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

namespace vadaspark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int db = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void kilepes_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            if (nev.Text != "" && faj.Text != "" && datum.SelectedDate != null && hely.Text != "" && etel.Text != "" && utod.Text != "" && (him.IsChecked != true || no.IsChecked != true))
            {
                string check = "";
                if (him.IsChecked == true)
                {
                    check = "Hím";
                }
                else if (no.IsChecked == true)
                {
                    check = "Nőstény";
                }
                allatok.Items.Add($"{db}. {nev.Text}; {faj.Text}; {datum.SelectedDate}; {hely.Text}; {check}; {etel.Text}; {utod.Text}");
                szam.Content = allatok.Items.Count.ToString();
                db++;
            }
        }

        private void letoltes_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter nyilvantartas = new StreamWriter("nyilvantartas.txt", true);

            foreach (var item in allatok.Items)
            {
                nyilvantartas.WriteLine(item);
            }
            allatok.Items.Clear();
            szam.Content = allatok.Items.Count.ToString();
            nyilvantartas.Close();

        }

        private void torles_Click(object sender, RoutedEventArgs e)
        {
            allatok.Items.Remove(allatok.SelectedItem);
            szam.Content = allatok.Items.Count.ToString();
        }

        private void betoltes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader nyilvantartas = new StreamReader("nyilvantartas.txt");

                for (int i = 0; i < 15; i++)
                {
                    allatok.Items.Add($"{nyilvantartas.ReadLine()}");
                }
                szam.Content = allatok.Items.Count.ToString();

                nyilvantartas.Close();
            }
            catch (FileNotFoundException)
            {

                MessageBox.Show("Nem található fálj");
            }
        }
    }
}
