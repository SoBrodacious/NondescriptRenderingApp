using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace GraphicsApp.ViewModels
{
   public class MainViewModel
    {
        public PersonViewModel Person { get; private set; }
        public BackgroundViewModel Background { get; private set; }

        public MainViewModel()
        {
            Person = new PersonViewModel();
            Background = new BackgroundViewModel();
        }

        public void SetBackground(Brush brushColor)
        {
            Background.Color = brushColor;
        }
    }
}
