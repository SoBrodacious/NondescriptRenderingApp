using GraphicsApp.ViewModels;
using Prism.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicsApp.Views
{
    /// <summary>
    /// Interaction logic for GraphicsCanvasView.xaml
    /// </summary>
    public partial class GraphicsCanvas : UserControl
    {
        IEventAggregator ea;
        public GraphicsCanvas()
        {
            
            InitializeComponent();
            ea.GetEvent<UIShapeUpdateEvent>().Subscribe(MessageRecieved);
        }

        private void MessageRecieved(Shape parameter)
        {
            Debug.WriteLine("GC Code Behind MessageRecieved");
        }
    }
}
