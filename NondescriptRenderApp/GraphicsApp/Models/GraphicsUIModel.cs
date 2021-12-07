using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace GraphicsApp.Models
{
    public class GraphicsUIModel : BindableBase
    {
        private string _selectedShape;

        public string SelectedShape
        {
            get { return _selectedShape; }
            set { _selectedShape = value; }
        }

        private string _selectedAnimation;

        public string SelectedAnimation
        {
            get { return _selectedAnimation; }
            set { _selectedAnimation = value; }
        }

        private double _sliderValue;

        public double SliderValue
        {
            get { return _sliderValue; }
            set { _sliderValue = value; }
        }

    }
}
