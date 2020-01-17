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
    /// Interaction logic for FontBox.xaml
    /// </summary>
    public partial class FontBox : UserControl
    {
        public FontBox()
        {
            InitializeComponent();           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            Global.Editor.FontFamily = Title.FontFamily;
            ((Panel)Parent).Children.Remove(this);
        }
    }
}
