using GraphicsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsApp.Utility
{
    class GenericPolygonModelBuilder : PolygonModelBuilder
    {
        private PointCollection _points;
        public PointCollection Points 
        {
            get { return _points; }
            set 
            {
                _points = value;
            } 
        }

        private Brush _strokeBrush;
        public Brush StrokeBrush
        {
            get { return _strokeBrush; }
            set
            {
                _strokeBrush = value;
            }
        }

        private Brush _fillBrush;
        public Brush FillBrush
        {
            get { return _fillBrush; }
            set
            {
                _fillBrush = value;
            }
        }


        public GenericPolygonModelBuilder(PointCollection points, Brush strokeBrush, Brush fillBrush)
        {
            Points = points;
            StrokeBrush = strokeBrush;
            FillBrush = fillBrush;
        }

        public ShapeAndBox CreatePolygonModel()
        {
            Polygon polygon = new Polygon();
            polygon.Points = Points;
            polygon.Stroke = StrokeBrush;
            polygon.Fill = FillBrush;

            ShapeBoundingBox boundingBox = new ShapeBoundingBox(polygon.Points);
            return new ShapeAndBox(polygon, boundingBox);
        }
    }
}
