using GraphicsApp.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;

namespace GraphicsApp.ViewModels
{
    class AnimationSelectorViewModel : BindableBase
    {
        IEventAggregator _ea;

        private DelegateCommand<string> _commandSelectAnimation = null;
        public DelegateCommand<string> CommandSelectAnimation =>
            _commandSelectAnimation ?? (_commandSelectAnimation = new DelegateCommand<string>(SelectAnimationExecute));

        private DelegateCommand<string> _commandSetDuration = null;
        public DelegateCommand<string> CommandSetDuration =>
            _commandSetDuration ?? (_commandSetDuration = new DelegateCommand<string>(SetDurationExecute));

        private string _timeSeconds = "4";

        public string TimeSeconds
        {
            get { return _timeSeconds; }
            set 
            { 
                SetProperty(ref _timeSeconds, value); 
            }
        }


        public AnimationSelectorViewModel(IEventAggregator ea)
        {
            _ea = ea;
        }

        private void SelectAnimationExecute(string animationSelection)
        {
            Debug.WriteLine(String.Format("AnimationSelectorVM Set Animation: {0}", animationSelection));
            SetDurationExecute(TimeSeconds);
            _ea.GetEvent<UISetAnimationUpdate>().Publish(animationSelection);
        }


        private void SetDurationExecute(string durationText)
        {
            Debug.WriteLine("Duration text changed");
            try
            {
                double value = Convert.ToDouble(durationText);
                Debug.WriteLine(String.Format("Text value changed to: {0}", value));
                _ea.GetEvent<UISetDurationUpdate>().Publish(durationText);
            }
            catch
            {
                Debug.WriteLine("Conversion failed");
            }
        }
    }
}
