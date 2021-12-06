using GraphicsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsApp.Utility
{
    interface PolygonModelBuilder
    {

        Brush StrokeBrush { get; set; }
        Brush FillBrush { get; set; }

        public ShapeAndBox CreatePolygonModel();
    }
}
