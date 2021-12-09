using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace GraphicsApp.ShapeUtility
{
    /*
     * interface for polygon build specific methods
     */
    interface IPolygonBuilder : IShapeBuilder
    {
        public void SetPoints(PointCollection points);
        public Polygon Build(XElement polyXML);
    }
}
