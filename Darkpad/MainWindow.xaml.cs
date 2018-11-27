using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace Darkpad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BB = Color.FromRgb(30, 30, 30);
            FF = Color.FromRgb(146, 202, 244);
            DataContext = this;
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                Editor.Text = File.ReadAllText(args[1]);
                Colmo.Content = args[1];
                LineH.Content = "Format : " + Path.GetExtension(args[1]);
            }
        }
        private void Minimize(object s, RoutedEventArgs e) 
        {
            WindowState = WindowState.Minimized;
        }
        private void Maximize(object s, RoutedEventArgs e) 
        {

        }
        private void Exiter(object s, RoutedEventArgs e) 
        {
            App.Current.Shutdown();
        }
        private void Fullscreen(object s, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal )
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }
        private void SaveDoc(object s, RoutedEventArgs e)
        {
            try
            {
                if (Colmo.Content.ToString() == "null") 
                {
                    SaveFileDialog sv = new SaveFileDialog();
                    sv.Filter = "Any File (*.*)|*.*";
                    bool? rslt = sv.ShowDialog();
                    if (rslt == true)
                    {
                        Colmo.Content = sv.FileName;
                        File.WriteAllText(Colmo.Content.ToString(), Editor.Text);
                        LineH.Content = "Format : " + Path.GetExtension(sv.FileName);
                    }
                }
                else 
                {
                    File.WriteAllText(Colmo.Content.ToString(), Editor.Text);
                }            
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        private void OpenDoc(object s, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog Op = new OpenFileDialog();
                Op.Filter = "Any File (*.*)|*.*";
                bool? rslt = Op.ShowDialog();
                if (rslt == true)
                {
                    Editor.Text = File.ReadAllText(Op.FileName);
                    Colmo.Content = Op.FileName;
                    LineH.Content = "Format : " + Path.GetExtension(Op.FileName);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Bcolr_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.VerticalAlignment = VerticalAlignment.Center;
            cd.HorizontalAlignment = HorizontalAlignment.Center;
            Mam.Children.Add(cd);
        }

        private void Tclor_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.front = true;
            cd.VerticalAlignment = VerticalAlignment.Center;
            cd.HorizontalAlignment = HorizontalAlignment.Center;
            Mam.Children.Add(cd);
        }
        public static Color BB { get; set; }
        public static Color FF { get; set; }
    }
}
