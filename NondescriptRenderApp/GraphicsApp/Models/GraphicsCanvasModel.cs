using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace GraphicsApp.Models
{
    public class GraphicsCanvasModel : BindableBase
    {
        private Shape _shape;

        public Shape Shape
        {
            get { return _shape; }
            set
            {
                SetProperty(ref _shape, value);
            }
        }

        private ShapeBoundingBox boundingBox;
    }
}
