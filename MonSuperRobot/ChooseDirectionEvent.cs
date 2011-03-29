using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robocode;

namespace JFabre
{
    public class ChooseDirectionEvent
    {
        public ChooseDirectionEvent(NavigationSystem system)
        {
            NavigationSystem = system;
        }
        public NavigationSystem NavigationSystem { get; private set; }
    }
}
