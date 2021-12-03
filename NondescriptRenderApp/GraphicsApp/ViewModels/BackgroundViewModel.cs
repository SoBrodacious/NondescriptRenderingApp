using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace GraphicsApp.ViewModels
{
    public class BackgroundViewModel : ObservableObject
    {
        private Brush _color;

        public Brush Color
        {
            get
            {
                if(_color == null)
                    return Brushes.Red;

                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }

    }
}
