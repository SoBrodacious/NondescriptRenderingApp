using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace GraphicsApp.ShapeUtility
{
    /*
     * interface for ellipse build specific methods
     */
    interface IEllipseBuilder : IShapeBuilder
    {
        public void SetWidth(double width);
        public void SetHeight(double height);
        public Ellipse Build(XElement polyXML);
    }
}
