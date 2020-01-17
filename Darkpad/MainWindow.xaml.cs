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
        public Color BB { get; set; }
        public Color FF { get; set; }
        public bool Maxi;
        public MainWindow()
        {
            Global.Editor = new TextBox();
          //  Global.Editor.HorizontalAlignment = HorizontalAlignment.Stretch;
          //  Global.Editor.VerticalAlignment = VerticalAlignment.Stretch;
          //  Global.Editor.Margin = new Thickness(0, 0, 27, 0);
            Global.Editor.TextWrapping = TextWrapping.Wrap;
            Global.Editor.AcceptsReturn = true;
            Global.Editor.BorderThickness = new Thickness(0);
            Global.Editor.FontSize = 25;
            Global.Editor.Style = TryFindResource("TextBoxStyle1") as Style;
            BB = Color.FromRgb(30, 30, 30);
            FF = Color.FromRgb(146, 202, 244);
            SolidColorBrush sa = new SolidColorBrush();
            sa.Color = BB;
            SolidColorBrush sb = new SolidColorBrush();
            sb.Color = FF;
            Global.Editor.Background = sa;
            Global.Editor.Foreground = sb;
            DataContext = this;
            InitializeComponent();
            Inner.Child = Global.Editor;
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                Global.Editor.Text = File.ReadAllText(args[1]);
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
            if (Maxi)
            {
                Width = 800;
                Height = 600;
                Left = (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - 800) / 2;
                Top = (System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - 600) / 2;
                Maxi = false;
            }
            else
            {
                Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
                Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
                Left = 0;
                Top = 0;
                Maxi = true;
            }
        }
        private void Exiter(object s, RoutedEventArgs e) 
        {
            App.Current.Shutdown();
        }
        private void Sizable(object s, RoutedEventArgs e)
        {
            SizeControl sc = new SizeControl();
            sc.VerticalAlignment = VerticalAlignment.Center;
            sc.HorizontalAlignment = HorizontalAlignment.Center;
            Mam.Children.Add(sc);
        }
        private void Fonter(object s, RoutedEventArgs e)
        {
            FontBox fb = new FontBox();
            fb.HorizontalAlignment = HorizontalAlignment.Center;
            fb.VerticalAlignment = VerticalAlignment.Center;
            Mam.Children.Add(fb);
        }
        private void Fullscreen(object s, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
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
                        File.WriteAllText(Colmo.Content.ToString(), Global.Editor.Text);
                        LineH.Content = "Format : " + Path.GetExtension(sv.FileName);
                    }
                }
                else 
                {
                    File.WriteAllText(Colmo.Content.ToString(), Global.Editor.Text);
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
                    Global.Editor.Text = File.ReadAllText(Op.FileName);
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

        private void Bar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Global.Editor.Margin = new Thickness(0, -(Global.Editor.RenderSize.Height / Bar.Maximum)* Bar.Value, 0, 0);
        }
    }
    public static class Global
    {       
        public static TextBox Editor;   
    }
}
