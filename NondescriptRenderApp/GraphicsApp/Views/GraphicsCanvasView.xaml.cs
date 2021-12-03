using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicsApp.Views
{
    /// <summary>
    /// Interaction logic for GraphicsCanvasView.xaml
    /// </summary>
    public partial class GraphicsCanvasView : UserControl
    {
        Polygon _polygon;

        public GraphicsCanvasView()
        {
            InitializeComponent();

            _polygon = new Polygon();

            SolidColorBrush yellowBrush = new SolidColorBrush();
            yellowBrush.Color = Colors.Yellow;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;

            _polygon.Stroke = blackBrush;
            _polygon.Fill = yellowBrush;
            _polygon.StrokeThickness = 4;

            PointCollection points = new PointCollection();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 100);
            Point p3 = new Point(200, 100);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);

            _polygon.Points = points;

            TranslateTransform ttf = new TranslateTransform();
            ttf.X = 500;
            ttf.Y = 500;

            _polygon.RenderTransform = ttf;

            renderCanvas.Children.Add(_polygon);
        }
    }
}
