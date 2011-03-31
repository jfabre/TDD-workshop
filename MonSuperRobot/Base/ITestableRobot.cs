using System.Drawing;
using System.Linq;
using Robocode.RobotInterfaces;

namespace JFabre.Base
{
    public interface ITestableRobot : IBasicRobot, IBasicEvents, IRunnable
    {
        void Init();
        void DoRobotThings();

        void Ahead(double distance);
        void Back(double distance);
       
        void DoNothing();
        void Resume();
        void Stop();
        void Scan();

        void TurnRight(double degrees);
        void TurnLeft(double degrees);
        void TurnGunLeft(double degrees);
        void TurnGunRight(double degrees);
        void TurnRadarLeft(double degrees);
        void TurnRadarRight(double degrees);

        void Fire(double power);
        void FireBullet(double power);

        void SetAllColors(Color color);
        void SetColors(Color bodyColor, Color gunColor, Color radarColor);

        double BattleFieldHeight { get; }
        double BattleFieldWidth { get; }
        
        Color BodyColor { get; set; }
        Color BulletColor { get; set; }
        Color GunColor { get; set; }
        
        double Energy { get; }
        double GunCoolingRate { get; }
        double GunHeading { get; }
        double GunHeat { get; }
        double Heading { get; }

        double Height { get; }

        bool IsAdjustGunForRobotTurn { get; set; }
        bool IsAdjustRadarForGunTurn { get; set; }
        bool IsAdjustRadarForRobotTurn { get; set; }

        string Name { get; }
        int NumRounds { get; }
        int Others { get; }
        Color RadarColor { get; set;  }

        int RoundNum { get; }
        Color ScanColor { get; set; }
        double Velocity { get; }
        double Width { get; }
        double X { get; }
        double Y { get; }
    }
}
