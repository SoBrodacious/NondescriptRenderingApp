using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicsApp.ShapeUtility
{
    /*
     * Interface for build methods common to all shapes within scope
     */
    interface IShapeBuilder
    {
        public void Reset();
        public void SetStrokeWidth(int width);
        public void CreateSetStrokeBrush(int r, int g, int b);
        public void CreateSetFillBrush(int r, int g, int b);
    }
}
