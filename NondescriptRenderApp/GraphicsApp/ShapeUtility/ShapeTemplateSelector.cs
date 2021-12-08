using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace GraphicsApp.ShapeUtility
{
    class ShapeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PolygonTemplate { get; set; }
        public DataTemplate EllipseTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return null;

            if (item.GetType() == typeof(Polygon)) return PolygonTemplate;
            else if (item.GetType() == typeof(Ellipse)) return EllipseTemplate;
            else return null;
        }
    }
}
