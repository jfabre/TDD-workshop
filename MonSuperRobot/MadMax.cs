using System.Linq;
using JFabre.Base;

namespace JFabre
{
    public class MadMax : TestableRobot
    {
        public MadMax()
        { 
        
        }
        
        public MadMax(ITestableRobot robot) 
            : base(robot)
        { 
            
        }

        public override void DoRobotThings()
        {
            TurnRight(20);
        }

        public override void OnScannedRobot(Robocode.ScannedRobotEvent evnt)
        {
            FireBullet(1);
        }
    }
}
