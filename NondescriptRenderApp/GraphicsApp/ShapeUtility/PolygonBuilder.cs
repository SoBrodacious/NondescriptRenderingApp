using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace GraphicsApp.ShapeUtility
{
    class PolygonBuilder : IPolygonBuilder
    {
        private Polygon _poly = new Polygon();

        public Polygon Poly
        {
            get { return _poly; }
            set { _poly = value; }
        }

        public PolygonBuilder()
        {

        }

        public void CreateSetFillBrush(int r, int g, int b)
        {
            Debug.WriteLine(String.Format("New fillbrush r:{0} g:{1} b:{2}", r, g, b));
            SolidColorBrush fillBrush = new SolidColorBrush();
            fillBrush.Color = Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
            Poly.Fill = fillBrush;
        }

        public void CreateSetStrokeBrush(int r, int g, int b)
        {
            Debug.WriteLine(String.Format("New strokebrush r:{0} g:{1} b:{2}", r, g, b));
            SolidColorBrush strokeBrush = new SolidColorBrush();
            strokeBrush.Color = Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
            Poly.Stroke = strokeBrush;
        }

        public void Reset()
        {
            Poly = new Polygon();
        }

        public void SetPoints(PointCollection points)
        {
            Poly.Points = points;
        }

        public void SetStrokeWidth(int width)
        {
            Poly.StrokeThickness = width;
        }

        public Polygon Build(XElement wholeXML)
        {
            Reset();

            XNamespace ns = "http://tempuri.org/Polygon.xsd";
            Debug.WriteLine("TryBuildPoly");

            //Debug.WriteLine(wholeXML.Element(ns + "polygonName"));
            //Name
            string name = wholeXML.Element(ns + "polygonName").Value;

            //Points
            XElement pointsXML = wholeXML.Element(ns + "points");
            PointCollection points = new PointCollection();
            foreach(XElement el in pointsXML.Elements(ns + "point"))
            {
                string xStr = el.Element(ns + "x").Value;
                double x = Convert.ToDouble(xStr);
                string yStr = el.Element(ns + "y").Value;
                double y = Convert.ToDouble(yStr);
                Point p = new Point(x, y);
                points.Add(p);
            }
            SetPoints(points);

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

            return Poly;
        }
    }
}
