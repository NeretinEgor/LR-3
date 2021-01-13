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
using System.Globalization;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string language;
        public MainWindow()
        {
            InitializeComponent();
            language = "rus-RU";
            this.textBox.PreviewTextInput += new TextCompositionEventHandler(textBox_PreviewTextInput);
            this.textBox1.PreviewTextInput += new TextCompositionEventHandler(textBox1_PreviewTextInput);
        }
        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
        void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void minButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            language = (cb.SelectedItem as ComboBoxItem).Tag.ToString();
            if (language != null)
            {
                CultureInfo lang = new CultureInfo(language);
                if(lang!=null)
                {
                    App.Language = lang;
                }
            }
        }

        private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int x, y;
            double z;
            string S1 = textBox.Text;
            string S2 = textBox1.Text;
            if ((S1 == "") || (S2 == ""))
            { MessageBox.Show("Вы не ввели значения в оба поля!!!"); }
            else
            {
                x = Convert.ToInt32(S1);
                y = Convert.ToInt32(S2);
                z = Math.Pow(x, y);
                rez.Content = z.ToString();
            }
            
        }
    }

}
