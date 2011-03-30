using System.Linq;

namespace JFabre
{
    public class MyTestableRobot : TestableRobot
    {
        public override void DoRobotThings()
        {
            Ahead(20);

            TurnRight(10);
        }
        
    }
}
