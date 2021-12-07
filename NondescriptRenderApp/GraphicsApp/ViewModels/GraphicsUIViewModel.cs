using GraphicsApp.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicsApp.ViewModels
{
    public class GraphicsUIViewModel : BindableBase
    {
        private GraphicsUIModel uiModel;
        public GraphicsUIModel UIModel
        {
            get { return uiModel; }
            set
            {
                SetProperty(ref uiModel, value);
            }
        }

        IEventAggregator _ea;

        public GraphicsUIViewModel(IEventAggregator ea)
        {
            _ea = ea;
            uiModel = new GraphicsUIModel();
            SetShapeCommand = 
                new DelegateCommand<string>(SetShapeExecute);
        }


        private Shape GenerateShapeFromUIParameters()
        {
            Shape shape;

            SolidColorBrush yellowBrush = new SolidColorBrush();
            yellowBrush.Color = Colors.Yellow;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;

            switch (UIModel.SelectedShape)
            {
                default:
                    shape = new Rectangle();
                    shape.Width = 50;
                    shape.Height = 50;
                    shape.Fill = yellowBrush;
                    shape.Stroke = blackBrush;
                    shape.StrokeThickness = 3;
                    break;
            }

            return shape;
        }

        public DelegateCommand<string> SetShapeCommand { get; private set; }

        private void SetShapeExecute(string shapeName)
        {
            Debug.WriteLine(String.Format("SetShapeCommand: {0}", shapeName));
            UIModel.SelectedShape = shapeName;
            Shape payload = GenerateShapeFromUIParameters();
            _ea.GetEvent<UIShapeUpdateEvent>().Publish(payload);
        }

        private void UIUpdateAnimationMessage()
        {

        }

        private void UIBeginRenderMessage()
        {

        }
    }
}
