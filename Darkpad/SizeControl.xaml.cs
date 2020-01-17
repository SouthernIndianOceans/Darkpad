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
    /// Interaction logic for SizeControl.xaml
    /// </summary>
    public partial class SizeControl : UserControl
    {
        public SizeControl()
        {
            InitializeComponent();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            textBlock.FontSize = slider.Value;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Global.Editor.FontSize = textBlock.FontSize;
            ((Panel)Parent).Children.Remove(this);
        }
    }
}
