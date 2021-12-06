using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Animation;

namespace GraphicsApp.Utility
{
    public abstract class AnimationFactory
    {
        public abstract Animatable GenerateAnimation();
    }
}
