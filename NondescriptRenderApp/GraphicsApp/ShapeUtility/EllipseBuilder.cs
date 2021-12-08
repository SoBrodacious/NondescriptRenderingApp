using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace GraphicsApp.ShapeUtility
{
    class EllipseBuilder : IEllipseBuilder
    {
        private Ellipse _ellipse = new Ellipse();

        public Ellipse Ellipse
        {
            get { return _ellipse; }
            set { _ellipse = value; }
        }

        public EllipseBuilder()
        {

        }

        public void CreateSetFillBrush(int r, int g, int b)
        {
            SolidColorBrush fillBrush = new SolidColorBrush();
            fillBrush.Color = Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
            Ellipse.Fill = fillBrush;
        }

        public void CreateSetStrokeBrush(int r, int g, int b)
        {
            SolidColorBrush strokeBrush = new SolidColorBrush();
            strokeBrush.Color = Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
            Ellipse.Stroke = strokeBrush;
        }

        public void Reset()
        {
            Ellipse = new Ellipse();
        }

        public void SetHeight(double height)
        {
            Ellipse.Height = height;
        }

        public void SetStrokeWidth(int width)
        {
            Ellipse.StrokeThickness = width;
        }

        public void SetWidth(double width)
        {
            Ellipse.Width = width;
        }

        public Ellipse Build(XElement polyXML)
        {
            throw new NotImplementedException();
        }
    }
}
