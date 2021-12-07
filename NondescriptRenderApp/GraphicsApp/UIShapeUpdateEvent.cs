using GraphicsApp.Models;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace GraphicsApp
{
    public class UIShapeUpdateEvent : PubSubEvent<Shape>
    {

    }
}
