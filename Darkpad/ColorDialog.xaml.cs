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

namespace Darkpad
{
    /// <summary>
    /// Interaction logic for ColorDialog.xaml
    /// </summary>
    public partial class ColorDialog : UserControl
    {
        public bool front = false;
        public ColorDialog()
        {
            InitializeComponent();
        }
        void Docolor()
        {
            try
            {
                SolidColorBrush s = new SolidColorBrush(Color.FromArgb(255, Convert.ToByte(R.Text), Convert.ToByte(G.Text), Convert.ToByte(B.Text)));
                Bdr.Background = s;
            }
            catch (Exception)
            {

            }
        }
        private void R_TextChanged(object sender, TextChangedEventArgs e)
        {
            Docolor();
        }
        private void G_TextChanged(object sender, TextChangedEventArgs e)
        {
            Docolor();
        }

        private void B_TextChanged(object sender, TextChangedEventArgs e)
        {
            Docolor();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (front)
            {
                MainWindow.FF = Color.FromRgb(Convert.ToByte(R.Text), Convert.ToByte(G.Text), Convert.ToByte(B.Text));
            }
            else
            {
                MainWindow.BB = Color.FromRgb(Convert.ToByte(R.Text), Convert.ToByte(G.Text), Convert.ToByte(B.Text));
            }
            ((Panel)Parent).Children.Remove(this);
        }

        private void C_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            C.Value = (int)C.Value;
        }

        private void K_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            K.Value = (int)K.Value;
        }

        private void A_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            A.Value = (int)A.Value;
        }
    }
}
