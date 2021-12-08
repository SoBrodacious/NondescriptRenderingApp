using GraphicsApp.Events;
using GraphicsApp.ShapeDefinitions;
using GraphicsApp.ShapeUtility;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsApp.ViewModels
{
    class GraphicsCanvasViewModel : BindableBase
    {
        private PolygonBuilder polygonBuilder = new PolygonBuilder();
        private EllipseBuilder ellipseBuilder = new EllipseBuilder();
        private XMLLoader loader = new XMLLoader();

        private Shape _renderShape;

        public Shape RenderShape
        {
            get { return _renderShape; }
            set
            {
                SetProperty(ref _renderShape, value);
            }
        }

        //Test polygon bound through content control
        private Polygon _renderPolygon;
        public Polygon RenderPolygon
        {
            get { return _renderPolygon; }
            set
            {
                _renderPolygon = value;
            }
        }

        private Ellipse _renderEllipse;

        public Ellipse RenderEllipse
        {
            get { return _renderEllipse; }
            set { _renderEllipse = value; }
        }



        public GraphicsCanvasViewModel(IEventAggregator ea)
        {
            ea.GetEvent<UISetShapeUpdate>().Subscribe(ListenUISetShape);

            _renderPolygon = new Polygon();

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

            _renderPolygon.Points = points;
            _renderPolygon.Stroke = blackBrush;
            _renderPolygon.Fill = yellowBrush;
            _renderPolygon.StrokeThickness = 4;

            RenderShape = RenderPolygon;
        }

        private void ListenUISetShape(string obj)
        {
            loader.LoadShapeFromXML(obj);

            switch (obj)
            {
                case "Rectangle":
                    RenderShape = polygonBuilder.Build(loader.XmlShape);
                    break;
                case "Triangle":
                    RenderShape = polygonBuilder.Build(loader.XmlShape);
                    break;
                case "Ellipse":
                    RenderShape = ellipseBuilder.Build(loader.XmlShape);
                    break;
                case "Hexagon":
                    RenderShape = polygonBuilder.Build(loader.XmlShape);
                    break;
                default:
                    Debug.WriteLine("Whoops, no definition for " + obj + " in GraphicsCanvasVM");
                    break;
            }
        }

    }
}
