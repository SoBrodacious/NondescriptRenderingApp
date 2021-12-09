using GraphicsApp.Events;
using GraphicsApp.Models;
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
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace GraphicsApp.ViewModels
{
    class GraphicsCanvasViewModel : BindableBase
    {
        //utility
        private PolygonBuilder polygonBuilder = new PolygonBuilder();
        private EllipseBuilder ellipseBuilder = new EllipseBuilder();
        private XMLLoader loader = new XMLLoader();

        //properties for canvas width and height, incorrectly bound to view atm, not planning to have canvas width be dynamic
        private double _width = 800;
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private double _height = 600;
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private double animationDuration = 4.0;

        //property for the shape to be rendered, bound to graphics view by content control
        private Shape _renderShape;
        public Shape RenderShape
        {
            get { return _renderShape; }
            set
            {
                SetProperty(ref _renderShape, value);
            }
        }

        //properties for shape as poly and ellipse to expose associated methods since casting was being wonky
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
            ea.GetEvent<UISetAnimationUpdate>().Subscribe(ListenUISetAnimation);
            ea.GetEvent<UISetDurationUpdate>().Subscribe(ListenUISetDuration);
        }

        private void ListenUISetDuration(string timeSeconds)
        {
            animationDuration = Convert.ToDouble(timeSeconds);
        }

        private void ListenUISetAnimation(string animationType)
        {
            switch (animationType)
            {

                case "LeftRight":
                    MockAnimateLeftRight();
                    break;
                    
                case "TopBottom":
                    MockAnimateTopBottom();
                    break;
                case "Box":
                    MockAnimateBox();
                    break;
                case "Circle":
                    MockAnimateCircle();
                    break;
                default:
                    Debug.WriteLine(String.Format("GCVM Set Animation Error for Animation of Type: {0}", animationType));
                    break;
            }

        }

        //event listener from shape selector, takes currently selected shape as string, builds rendershape to be selected shape as loaded from xml, then resets that shape to centre
        private void ListenUISetShape(string shapeType)
        {
            loader.LoadShapeFromXML(shapeType);

            switch (shapeType)
            {
                case "Rectangle":
                    RenderShape = polygonBuilder.Build(loader.XmlShape);
                    ResetShapeToCenter();
                    break;
                case "Triangle":
                    RenderShape = polygonBuilder.Build(loader.XmlShape);
                    ResetShapeToCenter();
                    break;
                case "Circle":
                    RenderShape = ellipseBuilder.Build(loader.XmlShape);
                    ResetShapeToCenter();
                    break;
                case "Hexagon":
                    RenderShape = polygonBuilder.Build(loader.XmlShape);
                    ResetShapeToCenter();
                    break;
                default:
                    //Debug.WriteLine("Whoops, no definition for " + obj + " in GraphicsCanvasVM, too bad!");
                    break;
            }
        }

        private void ResetShapeToCenter()
        {

            if(RenderShape != null)
            {
                if (RenderShape is Polygon)
                {
                    ShapeBoundingBox bb = new ShapeBoundingBox((Polygon)RenderShape);
                    Point centre = bb.GetBBCentre();

                    RenderShape.Parent.SetValue(Canvas.LeftProperty, (Width / 2.0) - centre.X);
                    RenderShape.Parent.SetValue(Canvas.TopProperty, (Height / 2.0) - centre.Y);
                }
                else
                {
                    ShapeBoundingBox bb = new ShapeBoundingBox((Ellipse)RenderShape);
                    Point centre = bb.GetBBCentre();

                    RenderShape.Parent.SetValue(Canvas.LeftProperty, (Width / 2.0) - centre.X);
                    RenderShape.Parent.SetValue(Canvas.TopProperty, (Height / 2.0) - centre.Y);
                }
            }
        }


        //To be moved to separate animation classes, either builders or factory depending on complexity
        private void MockAnimateLeftRight()
        {
            Point start = new Point(0, Height / 2.0);
            Point end = new Point(Width - 30, Height / 2.0);
            ApplyPointToPointAnimation(start, end, animationDuration);
        }

        private void MockAnimateTopBottom()
        {
            Point start = new Point(Width / 2.0, 0);
            Point end = new Point(Width / 2.0, Height - 30);
            ApplyPointToPointAnimation(start, end, animationDuration);
        }

        private void MockAnimateBox()
        {
            Point p1 = new Point(40, 40);
            Point p2 = new Point(Width - 70, 40);
            Point p3 = new Point(Width - 70, Height - 70);
            Point p4 = new Point(40, Height - 70);
            Point p5 = new Point(30, 30);
            PointCollection points = new PointCollection();
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            points.Add(p1);
            ApplyManyPointAnimation(points, animationDuration);
        }

        //not implemented yet
        private void MockAnimateCircle()
        {

        }


        //generalized point to point animation structure
        private void ApplyPointToPointAnimation(Point p1, Point p2, double timeSeconds)
        {
            ContentControl cc = (ContentControl)RenderShape.Parent;

            DoubleAnimation animateX = new DoubleAnimation();
            animateX.From = p1.X;
            animateX.To = p2.X;
            animateX.Duration = new Duration(TimeSpan.FromSeconds(timeSeconds));

            Storyboard.SetTargetName(animateX, cc.Name);
            Storyboard.SetTargetProperty(animateX, new PropertyPath(Canvas.LeftProperty));

            DoubleAnimation animateY = new DoubleAnimation();
            animateY.From = p1.Y;
            animateY.To = p2.Y;
            animateY.Duration = new Duration(TimeSpan.FromSeconds(timeSeconds));

            Storyboard.SetTargetName(animateY, cc.Name);
            Storyboard.SetTargetProperty(animateY, new PropertyPath(Canvas.TopProperty));

            ParallelTimeline parallelTimeline = new ParallelTimeline();
            //parallelTimeline.Duration = new Duration(TimeSpan.FromSeconds(4));
            parallelTimeline.Children.Add(animateX);
            parallelTimeline.Children.Add(animateY);
            //cc.BeginAnimation(Canvas.LeftProperty, animateX);

            Storyboard sb = new Storyboard();
            sb.Children.Add(parallelTimeline);

            cc.BeginStoryboard(sb);
        }

        //generalized series of points animation structure
        private void ApplyManyPointAnimation(PointCollection points, double timeSeconds)
        {
            ContentControl cc = (ContentControl)RenderShape.Parent;

            Storyboard sb = new Storyboard();

            for (int i = 0; i < points.Count - 1; i++)
            {
                //Storyboard sub = new Storyboard();

                DoubleAnimation animateX = new DoubleAnimation();
                animateX.From = points[i].X;
                animateX.To = points[i+1].X;
                animateX.Duration = new Duration(TimeSpan.FromSeconds((timeSeconds / (points.Count - 1))));

                Storyboard.SetTargetName(animateX, cc.Name);
                Storyboard.SetTargetProperty(animateX, new PropertyPath(Canvas.LeftProperty));

                DoubleAnimation animateY = new DoubleAnimation();
                animateY.From = points[i].Y;
                animateY.To = points[i+1].Y;
                animateY.Duration = new Duration(TimeSpan.FromSeconds((timeSeconds / (points.Count - 1))));

                Storyboard.SetTargetName(animateY, cc.Name);
                Storyboard.SetTargetProperty(animateY, new PropertyPath(Canvas.TopProperty));

                ParallelTimeline parallelTimeline = new ParallelTimeline();
                //parallelTimeline.Duration = new Duration(TimeSpan.FromSeconds(timeSeconds));
                parallelTimeline.Children.Add(animateX);
                parallelTimeline.Children.Add(animateY);
                parallelTimeline.BeginTime = TimeSpan.FromSeconds((timeSeconds / (points.Count-1)) * i);

                //sub.Children.Add(parallelTimeline);

                //sb.Children.Add(sub);

                sb.Children.Add(parallelTimeline);
            }

            cc.BeginStoryboard(sb);
        }

        private void ApplyCircularRotation(double radius, double timeSeconds)
        {

        }
    }
}
