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

        //Prism eventaggregator
        IEventAggregator _ea;

        //Property for custom shape string, ui textbox
        private string _customShape;
        public string CustomShape
        {
            get { return _customShape; }
            set { SetProperty(ref _customShape, value); }
        }

        //Property for selected shape string
        private string _selectedShape = "NoShapeSelected";
        public string SelectedShape
        {
            get { return _selectedShape; }
            set { _selectedShape = value; }
        }

        //command for selecting a shape in ui, bound as command to shape selector ui button elements, taking a string as the payload
        private DelegateCommand<string> _commandSetShape = null;
        public DelegateCommand<string> CommandSetShape =>
            _commandSetShape ?? (_commandSetShape = new DelegateCommand<string>(SetShapeExecute));


        public ShapeSelectorViewModel(IEventAggregator ea)
        {
            _ea = ea;
        }

        //method for command execute, recieves string from command declaration in the shape selector view, and publishes it to eventaggregator for use in graphics canvas vm
        private void SetShapeExecute(string obj)
        {
            Debug.WriteLine(String.Format("ShapeSelectorVM Set Shape: {0}", obj));
            _ea.GetEvent<UISetShapeUpdate>().Publish(obj);
        }

    }

}
