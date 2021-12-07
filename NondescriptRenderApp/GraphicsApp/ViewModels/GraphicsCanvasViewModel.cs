using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Prism.Mvvm;
using Prism.Commands;
using GraphicsApp.Models;
using Prism.Events;
using System.Diagnostics;

namespace GraphicsApp.ViewModels
{
    public class GraphicsCanvasViewModel : BindableBase
    {
        private GraphicsCanvasModel graphicsCanvasModel;

        IEventAggregator _ea;

        public GraphicsCanvasViewModel(IEventAggregator ea)
        {
            _ea = ea;
            ea.GetEvent<UIShapeUpdateEvent>().Subscribe(MessageRecieved);
            graphicsCanvasModel = new GraphicsCanvasModel();
        }

        public GraphicsCanvasModel GraphicsCanvasModel
        {
            get { return graphicsCanvasModel; }
            set
            {
                SetProperty(ref graphicsCanvasModel, value);
            }
        }

        private void MessageRecieved(Shape parameter)
        {
            Debug.WriteLine("GCVM MessageRecieved");
            
        }



        //private void CodeDump()
        //{
        //    _currentPolygon = new Polygon();

        //    SolidColorBrush yellowBrush = new SolidColorBrush();
        //    yellowBrush.Color = Colors.Yellow;
        //    SolidColorBrush blackBrush = new SolidColorBrush();
        //    blackBrush.Color = Colors.Black;

        //    _currentPolygon.Stroke = blackBrush;
        //    _currentPolygon.Fill = yellowBrush;
        //    _currentPolygon.StrokeThickness = 4;

        //    PointCollection points = new PointCollection();
        //    Point p1 = new Point(0, 0);
        //    Point p2 = new Point(0, 20);
        //    Point p3 = new Point(40, 20);
        //    points.Add(p1);
        //    points.Add(p2);
        //    points.Add(p3);

        //    _currentPolygon.Points = points;

        //    TranslateTransform ttf = new TranslateTransform();
        //    ttf.X = 500;
        //    ttf.Y = 500;

        //    //_polygon.RenderTransform = ttf;

        //    DoubleAnimation doubleAnimationX = new DoubleAnimation();
        //    //DoubleAnimation doubleAnimationY = new DoubleAnimation();
        //    doubleAnimationX.From = 0;
        //    doubleAnimationX.To = 500;
        //    doubleAnimationX.Duration = new Duration(TimeSpan.FromSeconds(10));

        //    _currentPolygon.BeginAnimation(Canvas.LeftProperty, doubleAnimationX);

        //    RenderCanvas.Children.Add(_currentPolygon);
        //}
    }
}
