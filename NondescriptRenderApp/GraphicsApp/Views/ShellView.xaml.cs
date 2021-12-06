using GraphicsApp.Models;
using GraphicsApp.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraphicsApp.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        //Graphics
        private Polygon _currentPolygon;

        //UI


        public ShellView()
        {
            InitializeComponent();

            InitPolygon();
        }

        private void InitPolygon()
        {
            SolidColorBrush yellowBrush = new SolidColorBrush();
            yellowBrush.Color = Colors.Yellow;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;

            PointCollection points = new PointCollection();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 20);
            Point p3 = new Point(40, 20);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);

            PolygonModelBuilder builder = new GenericPolygonModelBuilder(points, blackBrush, yellowBrush);

            ShapeAndBox pModel = builder.CreatePolygonModel();

            _currentPolygon = pModel.Polygon;

            DoubleAnimation doubleAnimationX = new DoubleAnimation();
            //DoubleAnimation doubleAnimationY = new DoubleAnimation();
            doubleAnimationX.From = 0;
            doubleAnimationX.To = 500;
            doubleAnimationX.Duration = new Duration(TimeSpan.FromSeconds(10));

            _currentPolygon.BeginAnimation(Canvas.LeftProperty, doubleAnimationX);

            //RenderCanvas.Children.Add(_currentPolygon);
        }


        //Events
        private void AddRectangle_Click(object sender, RoutedEventArgs e)
        {
            ChangePolygonToStandardRect();
        }

        private void ChangePolygonToStandardRect()
        {
            
            PointCollection points = new PointCollection();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 20);
            Point p3 = new Point(40, 20);
            Point p4 = new Point(40, 0);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);

            _currentPolygon.Points = points;
        }

        private void CanvasWidth_Click(object sender, RoutedEventArgs e)
        {
            ResetPolygonToScreenCentre();
        }

        private void ResetPolygonToScreenCentre()
        {
            ShapeBoundingBox polygonBoundingBox = new ShapeBoundingBox(_currentPolygon.Points);

            TranslateTransform ttf = new TranslateTransform();
            //ttf.X = (RenderCanvas.ActualWidth / 2.0) - polygonBoundingBox.GetXCentre();
            //ttf.Y = RenderCanvas.ActualHeight / 2.0 - polygonBoundingBox.GetYCentre();

            _currentPolygon.RenderTransform = ttf;
        }

        private void SetShapeRectangle_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("e_SetShapeRectangle");
        }

        private void SetShapeTriangle_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("e_SetShapeTriangle");
        }

        private void SetShapeEllipse_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("e_SetShapeEllipse");
        }

        private void SetShapeHexagon_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("e_SetShapeHexagon");
        }

        private void LoadCustomPolygon_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("e_SetShapeCustomPolygon");
        }
    }
}
