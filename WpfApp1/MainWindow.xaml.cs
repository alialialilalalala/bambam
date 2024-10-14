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

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            string colorName = (sender as MenuItem)?.Tag?.ToString() ?? (sender as Button)?.Tag?.ToString();
            if (!string.IsNullOrEmpty(colorName))
            {
                this.Background = (System.Windows.Media.Brush)new System.Windows.Media.SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(colorName));
            }
        }

        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: alialialilalala", "О разработчике", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CloseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MenuItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                StatusText.Text = menuItem.ToolTip?.ToString() ?? menuItem.Header.ToString();
            }
        }

        private void MenuItem_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StatusText.Text = "Готово";
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (sender is Button button)
            {
                StatusText.Text = button.ToolTip?.ToString() ?? button.Content.ToString();
            }
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StatusText.Text = "Готово";
        }
    }
}