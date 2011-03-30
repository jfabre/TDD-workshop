using System.Drawing;
using System.Linq;
using Robocode.RobotInterfaces;

namespace JFabre
{
    public interface ITestableRobot : IBasicRobot, IBasicEvents, IRunnable
    {
        void Ahead(double distance);
        void Back(double distance);

        
        void Fire(double power);

        void FireBullet(double power);

        void Resume(double power);

        void SetAllColors(Color color);

    }
}
