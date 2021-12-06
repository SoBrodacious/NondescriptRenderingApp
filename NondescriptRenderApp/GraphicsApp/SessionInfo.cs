using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphicsApp
{
    public sealed class SessionInfo
    {
        public IEventAggregator eventHandler;

        private SessionInfo()
        {

        }

        private static SessionInfo _instance = null;

        public static SessionInfo Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new SessionInfo();
                        _instance.eventHandler = new EventAggregator();
                    }
                }
                return _instance;
            }
        }
    }
}
