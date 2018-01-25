using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Z1
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Dodaj bitmape";
            op.Filter = "Pliki graficzne|*.bmp;*.jpg;*.jpeg;*.png;*.tiff|" +
              "BMP|*.bmp" +
              "JPEG|*.jpg;*.jpeg|" +
              "PNG|*.png" +
              "TIFF|*.tiff";
            if (op.ShowDialog() == true)
            {
                ThreadPool.QueueUserWorkItem(addImg, new object[] { op.FileName });
            }
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Dodaj bitmape";
            op.Filter = "Pliki graficzne|*.bmp;*.jpg;*.jpeg;*.png;*.tiff|" +
              "BMP|*.bmp" +
              "JPEG|*.jpg;*.jpeg|" +
              "PNG|*.png" +
              "TIFF|*.tiff";
            if (op.ShowDialog() == true)
            {
                string fileName = op.FileName;
                this.Dispatcher.Invoke(() =>
                {
                    img.Source = new BitmapImage(new Uri(fileName));
                });
            }
        }

        private void addImg(Object stateInfo)
        {
            string fileName = (string)((object[])stateInfo)[0];
            this.Dispatcher.Invoke(() =>
            {
                img.Source = new BitmapImage(new Uri(fileName));
            });

        }
    }
}
