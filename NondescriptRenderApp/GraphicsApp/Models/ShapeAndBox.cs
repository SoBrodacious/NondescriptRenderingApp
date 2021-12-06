using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace GraphicsApp.Models
{
    class ShapeAndBox
    {
        private Shape _shape;

        public Shape Shape
        {
            get { return _shape; }
            set { _shape = value; }
        }

        private ShapeBoundingBox _boundingBox;

        public ShapeBoundingBox BoundingBox
        {
            get { return _boundingBox; }
            set { _boundingBox = value; }
        }

        public ShapeAndBox(Shape shape, ShapeBoundingBox boundingBox)
        {
            Shape = shape;
            BoundingBox = boundingBox;
        }

    }
}
