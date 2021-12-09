using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsApp.ShapeUtility
{
    /*
     * Utility for a shape bounding box, as polygon does not seem to implement something like this by default
     */
    class ShapeBoundingBox
    {
        
        private double _xMin;

        public double XMin
        {
            get { return _xMin; }
            set { _xMin = value; }
        }

        private double _xMax;

        public double XMax
        {
            get { return _xMax; }
            set { _xMax = value; }
        }

        private double _yMin;

        public double YMin
        {
            get { return _yMin; }
            set { _yMin = value; }
        }

        private double _yMax;

        public double YMax
        {
            get { return _yMax; }
            set { _yMax = value; }
        }

        //
        public ShapeBoundingBox(Ellipse ellipse)
        {
            GenerateBounds(ellipse);
        }

        public ShapeBoundingBox(Polygon polygon)
        {
            GenerateBounds(polygon);
        }

        //for each point, check if min max has been exceeded from point x,y, update min max
        private void GenerateBounds(Polygon polygon)
        {
            PointCollection points = polygon.Points;

            if(points != null && points.Count > 0)
            {
                XMin = points[0].X;
                XMax = points[0].X;
                YMin = points[0].Y;
                YMax = points[0].Y;

                foreach(Point p in points)
                {
                    if (p.X < XMin) XMin = p.X;
                    if (p.X > XMax) XMax = p.X;
                    if (p.Y < YMin) YMin = p.Y;
                    if (p.Y > YMax) YMax = p.Y;
                }
            }
            else
            {
                throw new Exception("InvalidPointCollection");
            }
        }

        //find width height, /2.0 to get reach on either side, min = -ve, max = +ve
        private void GenerateBounds(Ellipse ellipse)
        {
            double x = ellipse.Width / 2.0;
            double y = ellipse.Height / 2.0;
            XMin = -x;
            XMax = x;
            YMin = -y;
            YMax = y;
        }

        //Return the centre of this bounding box for rendering to centre needs
        public Point GetBBCentre()
        {
            return new Point(GetXCentre(), GetYCentre());
        }

        public double GetXCentre() 
        { 
            return (XMax - XMin) / 2.0;
        }

        public double GetYCentre()
        {
            return (YMax - YMin) / 2.0;
        }
    }
}
