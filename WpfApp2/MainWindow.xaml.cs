using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Point? lastPoint;
        private Color brushColor = Colors.Black;
        private double brushSize = 5;
        private bool isDrawing = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ColorPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)ColorPicker.SelectedItem;
            switch (selectedItem.Content.ToString())
            {
                case "Красный":
                    brushColor = Colors.Red;
                    break;
                case "Зеленый":
                    brushColor = Colors.Green;
                    break;
                case "Синий":
                    brushColor = Colors.Blue;
                    break;
                case "Черный":
                    brushColor = Colors.Black;
                    break;
            }
        }

        private void BrushSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            brushSize = BrushSizeSlider.Value;
        }

        private void DrawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                lastPoint = e.GetPosition(DrawingCanvas);
                isDrawing = true;
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && lastPoint.HasValue)
            {
                Point currentPoint = e.GetPosition(DrawingCanvas);
                DrawLine(lastPoint.Value, currentPoint);
                lastPoint = currentPoint;
            }
        }

        private void DrawingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
        }

        private void DrawLine(Point startPoint, Point endPoint)
        {
            Line line = new Line();
            line.Stroke = new SolidColorBrush(brushColor);
            line.StrokeThickness = brushSize;
            line.X1 = startPoint.X;
            line.Y1 = startPoint.Y;
            line.X2 = endPoint.X;
            line.Y2 = endPoint.Y;

            DrawingCanvas.Children.Add(line);
        }
    }
}
