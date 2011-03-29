using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JFabre
{
    public class TurnEvent : EventArgs
    {
        public TurnEvent(double newHeading)
        {
            NewHeading = newHeading;
        }
        public double NewHeading { get; private set; }
    }
}
