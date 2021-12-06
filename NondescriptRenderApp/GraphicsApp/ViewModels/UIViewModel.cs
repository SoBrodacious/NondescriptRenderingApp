using GraphicsApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Shapes;

namespace GraphicsApp.ViewModels
{
    public class UIViewModel : BindableBase
    {
        private UIModel uiModel;
        public UIModel UIModel
        {
            get { return uiModel; }
            set
            {
                SetProperty(ref uiModel, value);
            }
        }

        public UIViewModel()
        {
            uiModel = new UIModel();
            SetShapeCommand = 
                new DelegateCommand<string>(SetShapeExecute, CanSetShapeExecute);
        }

        private void SetShapeExecute(string shapeName)
        {
            
        }

        private bool CanSetShapeExecute(string shapeName)
        {
            return true;
        }

        public DelegateCommand<string> SetShapeCommand { get; private set; }
    }
}
