using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp
{
    class UIShape
    {
        private float _xpos;
        private float _ypos;

        public float XPos
        {
            get { return _xpos; }
            set
            {
                _xpos = value;
            }
        }

        public float YPos
        {
            get { return _ypos; }
            set
            {
                _ypos = value;
            }
        }
    }
}
