using GraphicsApp.Events;
using GraphicsApp.ShapeDefinitions;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GraphicsApp.ViewModels
{
    public class ShapeSelectorViewModel : BindableBase
    {

        IEventAggregator _ea;
        
        private string _selectedShape = "NoShapeSelected";

        private DelegateCommand<string> _commandSetShape = null;
        public DelegateCommand<string> CommandSetShape =>
            _commandSetShape ?? (_commandSetShape = new DelegateCommand<string>(SetShapeExecute));

        public string SelectedShape
        {
            get { return _selectedShape; }
            set { _selectedShape = value; }
        }

        public ShapeSelectorViewModel(IEventAggregator ea)
        {
            _ea = ea;
        }

        private void SetShapeExecute(string obj)
        {
            Debug.WriteLine(String.Format("ShapeSelectorVM Set Shape: {0}", obj));
            _ea.GetEvent<UISetShapeUpdate>().Publish(obj);
        }

    }

}
