using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace GraphicsApp.ShapeUtility
{
    /*
     * concrete implementation of ellipse builder
     */
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

        public Ellipse Build(XElement wholeXML)
        {
            Reset();

            XNamespace ns = "http://tempuri.org/Ellipse.xsd";
            Debug.WriteLine("TryBuildEllipse");

            //Debug.WriteLine(wholeXML.Element(ns + "polygonName"));
            //Name
            string name = wholeXML.Element(ns + "ellipseName").Value;

            //Dimensions
            XElement dimensionsXML = wholeXML.Element(ns + "dimensions");
            string widthStr = dimensionsXML.Element(ns + "width").Value;
            double width = Convert.ToDouble(widthStr);
            SetWidth(width);
            string heightStr = dimensionsXML.Element(ns + "height").Value;
            double height = Convert.ToDouble(heightStr);
            SetHeight(height);

            //StrokeWeight
            string strokeWeightStr = wholeXML.Element(ns + "strokeWeight").Value;
            int strokeWeight = Convert.ToInt32(strokeWeightStr);
            SetStrokeWidth(strokeWeight);

            //StrokeBrush
            XElement strokeBrushXML = wholeXML.Element(ns + "strokeColor");
            string srStr = strokeBrushXML.Element(ns + "r").Value;
            Debug.WriteLine(srStr);
            string sgStr = strokeBrushXML.Element(ns + "g").Value;
            Debug.WriteLine(sgStr);
            string sbStr = strokeBrushXML.Element(ns + "b").Value;
            Debug.WriteLine(sbStr);
            int sr = Convert.ToInt32(srStr);
            int sg = Convert.ToInt32(sgStr);
            int sb = Convert.ToInt32(sbStr);
            CreateSetStrokeBrush(sr, sg, sb);

            //FillBrush
            XElement fillBrushXML = wholeXML.Element(ns + "fillColor");
            string frStr = fillBrushXML.Element(ns + "r").Value;
            Debug.WriteLine(frStr);
            string fgStr = fillBrushXML.Element(ns + "g").Value;
            Debug.WriteLine(fgStr);
            string fbStr = fillBrushXML.Element(ns + "b").Value;
            Debug.WriteLine(fbStr);
            int fr = Convert.ToInt32(frStr);
            int fg = Convert.ToInt32(fgStr);
            int fb = Convert.ToInt32(fbStr);
            CreateSetFillBrush(fr, fg, fb);

            return Ellipse;
        }
    }
}
