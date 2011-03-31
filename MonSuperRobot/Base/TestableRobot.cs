using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Robocode;
using Robocode.RobotInterfaces;
using Robocode.RobotInterfaces.Peer;

namespace JFabre.Base
{
    public abstract class TestableRobot : ITestableRobot
    {
        private Robot _myRobot;
        private ITestableRobot _testableRobot;
        private bool _onTest;

        private class DefaultRobot : Robot { }

        public TestableRobot()
        {
            _myRobot =  new DefaultRobot();
        }
        public TestableRobot(ITestableRobot robot)
        {
            _onTest = true;
            _testableRobot = robot;
        }

        public virtual void Init()
        { 
            
        }
            
        public abstract void DoRobotThings();
        public void Run()
        {
            Init();
            while (true)
            {
                DoRobotThings();
            }
        }

        /// <summary>
        ///   Immediately moves your robot ahead (forward) by distance measured in
        ///   pixels.
        ///   <p />
        ///   This call executes immediately, and does not return until it is complete,
        ///   i.e. when the remaining distance to move is 0.
        ///   <p />
        ///   If the robot collides with a wall, the move is complete, meaning that the
        ///   robot will not move any further. If the robot collides with another
        ///   robot, the move is complete if you are heading toward the other robot.
        ///   <p />
        ///   Note that both positive and negative values can be given as input,
        ///   where negative values means that the robot is set to move backward
        ///   instead of forward.
        ///   <p />
        ///   <example>
        ///     <code>
        ///     // Move the robot 100 pixels forward
        ///     Ahead(100);
        ///
        ///     // Afterwards, move the robot 50 pixels backward
        ///     Ahead(-50);
        ///     </code>
        ///   </example>
        /// </summary>
        /// <param name="distance">
        ///   The distance to move ahead measured in pixels.
        ///   If this value is negative, the robot will move back instead of ahead.
        /// </param>
        /// <seealso cref="Back(double)" />
        /// <seealso cref="OnHitWall(HitWallEvent)" />
        /// <seealso cref="OnHitRobot(HitRobotEvent)" />
        public virtual void Ahead(double distance)
        {
            if (_onTest)
            {
                _testableRobot.Ahead(distance);
            }
            else
            {
                _myRobot.Ahead(distance);
            }
            
        }


        /// <summary>
        ///   Immediately resumes the movement you stopped by <see cref="Stop()" />, if any.
        ///   <p />
        ///   This call executes immediately, and does not return until it is complete.
        ///   <seealso cref="Stop()" />
        ///   <seealso cref="Stop(bool)" />
        /// </summary>
        public virtual void Resume()
        {
            if (_onTest)
            {
                _testableRobot.Resume();
            }
            else
            {
                _myRobot.Resume();
            }
        }

        /// <summary>
        ///   Immediately moves your robot backward by distance measured in pixels.
        ///   <p />
        ///   This call executes immediately, and does not return until it is complete,
        ///   i.e. when the remaining distance to move is 0.
        ///   <p />
        ///   If the robot collides with a wall, the move is complete, meaning that the
        ///   robot will not move any further. If the robot collides with another
        ///   robot, the move is complete if you are heading toward the other robot.
        ///   <p />
        ///   Note that both positive and negative values can be given as input,
        ///   where negative values means that the robot is set to move forward instead
        ///   of backward.
        ///   <p />
        ///   <example>
        ///     <code>
        ///     // Move the robot 100 pixels backward
        ///     Back(100);
        ///
        ///     // Afterwards, move the robot 50 pixels forward
        ///     Back(-50);
        ///     </code>
        ///   </example>
        ///   <seealso cref="Ahead(double)" />
        ///   <seealso cref="OnHitWall(HitWallEvent)" />
        ///   <seealso cref="OnHitRobot(HitRobotEvent)" />
        /// </summary>
        /// <param name="distance">
        ///   The distance to move back measured in pixels.
        ///   If this value is negative, the robot will move ahead instead of back.
        /// </param>
        public virtual void DoNothing()
        {
            if (_onTest)
            {
                _testableRobot.DoNothing();
            }
            else
            {
                _myRobot.DoNothing();
            }
        }

        /// <summary>
        ///   Immediately moves your robot backward by distance measured in pixels.
        ///   <p />
        ///   This call executes immediately, and does not return until it is complete,
        ///   i.e. when the remaining distance to move is 0.
        ///   <p />
        ///   If the robot collides with a wall, the move is complete, meaning that the
        ///   robot will not move any further. If the robot collides with another
        ///   robot, the move is complete if you are heading toward the other robot.
        ///   <p />
        ///   Note that both positive and negative values can be given as input,
        ///   where negative values means that the robot is set to move forward instead
        ///   of backward.
        ///   <p />
        ///   <example>
        ///     <code>
        ///     // Move the robot 100 pixels backward
        ///     Back(100);
        ///
        ///     // Afterwards, move the robot 50 pixels forward
        ///     Back(-50);
        ///     </code>
        ///   </example>
        ///   <seealso cref="Ahead(double)" />
        ///   <seealso cref="OnHitWall(HitWallEvent)" />
        ///   <seealso cref="OnHitRobot(HitRobotEvent)" />
        /// </summary>
        /// <param name="distance">
        ///   The distance to move back measured in pixels.
        ///   If this value is negative, the robot will move ahead instead of back.
        /// </param>
        public virtual void Back(double distance)
        {
            if (_onTest)
            {
                _testableRobot.Back(distance);
            }
            else
            {
                _myRobot.Back(distance);
            }
        }

        /// 
        ///<summary>
        ///  Immediately turns the robot's body to the right by degrees.
        ///  This call executes immediately, and does not return until it is complete,
        ///  i.e. when the angle remaining in the robot's turn is 0.
        ///  <p />
        ///  Note that both positive and negative values can be given as input,
        ///  where negative values means that the robot's body is set to turn left
        ///  instead of right.
        ///  <p />
        ///  <example>
        ///    <code>
        ///    // Turn the robot 180 degrees to the right
        ///    TurnRight(180);
        ///
        ///    // Afterwards, turn the robot 90 degrees to the left
        ///    TurnRight(-90);
        ///    </code>
        ///  </example>
        ///
        ///  <seealso cref="TurnLeft(double)" />
        ///  <seealso cref="TurnGunLeft(double)" />
        ///  <seealso cref="TurnGunRight(double)" />
        ///  <seealso cref="TurnRadarLeft(double)" />
        ///  <seealso cref="TurnRadarRight(double)" />
        ///</summary>
        ///<param name="degrees">
        ///  The amount of degrees to turn the robot's body to the right.
        ///  If degrees &gt; 0 the robot will turn right.
        ///  If degrees &lt; 0 the robot will turn left.
        ///  If degrees = 0 the robot will not turn, but execute.
        ///</param>
        public virtual void TurnRight(double degree)
        {
            if (_onTest)
            {
                _testableRobot.TurnRight(degree);
            }
            else
            {
                _myRobot.TurnRight(degree);
            }
        }

        /// <summary>
        ///   Immediately turns the robot's body to the left by degrees.
        ///   <p />
        ///   This call executes immediately, and does not return until it is complete,
        ///   i.e. when the angle remaining in the robot's turn is 0.
        ///   <p />
        ///   Note that both positive and negative values can be given as input,
        ///   where negative values means that the robot's body is set to turn right
        ///   instead of left.
        ///   <p />
        ///   <example>
        ///     <code>
        ///       // Turn the robot 180 degrees to the left
        ///       TurnLeft(180);
        ///
        ///       // Afterwards, turn the robot 90 degrees to the right
        ///       TurnLeft(-90);
        ///     </code>
        ///   </example>
        ///   <seealso cref="TurnRight(double)" />
        ///   <seealso cref="TurnGunLeft(double)" />
        ///   <seealso cref="TurnGunRight(double)" />
        ///   <seealso cref="TurnRadarLeft(double)" />
        ///   <seealso cref="TurnRadarRight(double)" />
        /// </summary>
        /// <param name="degrees">
        ///   The amount of degrees to turn the robot's body to the left.
        ///   If degrees &gt; 0 the robot will turn left.
        ///   If degrees &lt; 0 the robot will turn right.
        ///   If degrees = 0 the robot will not turn, but execute.
        /// </param>
        public virtual void TurnLeft(double degree)
        {
            if (_onTest)
            {
                _testableRobot.TurnLeft(degree);
            }
            else
            {
                _myRobot.TurnLeft(degree);
            }
        }
        public virtual void Fire(double power)
        {
            if (_onTest)
            {
                _testableRobot.Fire(power);
            }
            else
            {
                _myRobot.Fire(power);
            }
        }
        public virtual void FireBullet(double power)
        {
            if (_onTest)
            {
                _testableRobot.FireBullet(power);
            }
            else
            {
                _myRobot.FireBullet(power);
            }
        }
        
        public virtual void Scan()
        {
            if (_onTest)
            {
                _testableRobot.Scan();
            }
            else
            {
                _myRobot.Scan();
            }
        }
        public virtual void SetAllColors(Color color)
        {
            if (_onTest)
            {
                _testableRobot.SetAllColors(color);
            }
            else
            {
                _myRobot.SetAllColors(color);
            }
        }

        public IRunnable GetRobotRunnable()
        {
            return this;
        }

        public IBasicEvents GetBasicEventListener()
        {
            return this;
        }

        public void SetPeer(IBasicRobotPeer peer)
        {
            ((IBasicRobot) _myRobot).SetPeer(peer);
        }

        public void SetOut(TextWriter output)
        {
            ((IBasicRobot)_myRobot).SetOut(output);
        }

        public virtual void OnStatus(StatusEvent evnt)
        {
            
        }

        public virtual void OnBulletHit(BulletHitEvent evnt)
        {
            
        }

        public virtual void OnBulletHitBullet(BulletHitBulletEvent evnt)
        {
            
        }

        public virtual void OnBulletMissed(BulletMissedEvent evnt)
        {
            
        }

        public virtual void OnDeath(DeathEvent evnt)
        {
            _myRobot.OnDeath(evnt);
        }

        public virtual void OnHitByBullet(HitByBulletEvent evnt)
        {
            
        }

        public virtual void OnHitRobot(HitRobotEvent evnt)
        {
            
        }

        public virtual void OnHitWall(HitWallEvent evnt)
        {
            
        }

        public virtual void OnScannedRobot(ScannedRobotEvent evnt)
        {
            
        }

        public virtual void OnRobotDeath(RobotDeathEvent evnt)
        {
            _myRobot.OnRobotDeath(evnt);
        }

        public virtual void OnWin(WinEvent evnt)
        {
            _myRobot.OnWin(evnt);
        }

        /// <summary>
        ///   Sets the color of the robot's body, gun, and radar in the same time.
        ///   <p />
        ///   You may only call this method one time per battle. A <em>null</em>
        ///   indicates the default (blue) color.
        ///   <p />
        ///   <example>
        ///     <code>
        ///     // Don't forget to using System.Drawing at the top...
        ///     using System.Drawing;
        ///     ...
        ///
        ///     public void Init()
        ///     {
        ///         SetColors(null, Color.Red, Color.fromArgb(150, 0, 150));
        ///         ...
        ///     }
        ///     </code>
        ///   </example>
        ///   <seealso cref="SetColors(Color, Color, Color, Color, Color)" />
        ///   <seealso cref="SetAllColors(Color)" />
        ///   <seealso cref="BodyColor" />
        ///   <seealso cref="GunColor" />
        ///   <seealso cref="RadarColor" />
        ///   <seealso cref="BulletColor" />
        ///   <seealso cref="ScanColor" />
        ///   <seealso cref="Color" />
        /// </summary>
        /// <param name="bodyColor">The new body color</param>
        /// <param name="gunColor">The new gun color</param>
        /// <param name="radarColor">The new radar color</param>
        public virtual void SetColors(Color bodyColor, Color gunColor, Color radarColor)
        {
            if (_onTest)
            {
                _testableRobot.SetColors(bodyColor, gunColor, radarColor);
            }
            else
            {
                _myRobot.SetColors(bodyColor, gunColor, radarColor);
            }
        }

        /// 
        ///<summary>
        ///  Immediately turns the robot's radar to the right by degrees.
        ///  This call executes immediately, and does not return until it is complete,
        ///  i.e. when the angle remaining in the radar's turn is 0.
        ///  <p />
        ///  Note that both positive and negative values can be given as input,
        ///  where negative values means that the robot's radar is set to turn left
        ///  instead of right.
        ///  <p />
        ///  <example>
        ///    <code>
        ///    // Turn the robot's radar 180 degrees to the right
        ///    TurnRadarRight(180);
        ///
        ///    // Afterwards, turn the robot's radar 90 degrees to the left
        ///    TurnRadarRight(-90);
        ///    </code>
        ///  </example>
        ///
        ///  <seealso cref="TurnRadarLeft(double)" />
        ///  <seealso cref="TurnLeft(double)" />
        ///  <seealso cref="TurnRight(double)" />
        ///  <seealso cref="TurnGunLeft(double)" />
        ///  <seealso cref="TurnGunRight(double)" />
        ///  <seealso cref="IsAdjustRadarForRobotTurn" />
        ///  <seealso cref="IsAdjustRadarForGunTurn" />
        ///</summary>
        ///<param name="degrees">
        ///  The amount of degrees to turn the robot's radar to the right.
        ///  If degrees &gt; 0 the robot's radar will turn right.
        ///  If degrees &lt; 0 the robot's radar will turn left.
        ///  If degrees = 0 the robot's radar will not turn, but execute.
        ///</param>
        ///
        public virtual void TurnRadarRight(double degrees)
        {
            if (_onTest)
            {
                _testableRobot.TurnRadarRight(degrees);
            }
            else
            {
                _myRobot.TurnRadarRight(degrees);
            }
        }

        /// <summary>
        ///   Immediately turns the robot's radar to the left by degrees.
        ///   <p />
        ///   This call executes immediately, and does not return until it is complete,
        ///   i.e. when the angle remaining in the radar's turn is 0.
        ///   <p />
        ///   Note that both positive and negative values can be given as input,
        ///   where negative values means that the robot's radar is set to turn right
        ///   instead of left.
        ///   <p />
        ///   <example>
        ///     <code>
        ///     // Turn the robot's radar 180 degrees to the left
        ///     TurnRadarLeft(180);
        ///
        ///     // Afterwards, turn the robot's radar 90 degrees to the right
        ///     TurnRadarLeft(-90);
        ///     </code>
        ///   </example>
        ///   <seealso cref="TurnRadarRight(double)" />
        ///   <seealso cref="TurnLeft(double)" />
        ///   <seealso cref="TurnRight(double)" />
        ///   <seealso cref="TurnGunLeft(double)" />
        ///   <seealso cref="TurnGunRight(double)" />
        ///   <seealso cref="IsAdjustRadarForRobotTurn" />
        ///   <seealso cref="IsAdjustRadarForGunTurn" />
        /// </summary>
        /// <param name="degrees">
        ///   The amount of degrees to turn the robot's radar to the left.
        ///   If degrees &gt; 0 the robot's radar will turn left.
        ///   If degrees &lt; 0 the robot's radar will turn right.
        ///   If degrees = 0 the robot's radar will not turn, but execute.
        /// </param>
        public virtual void TurnRadarLeft(double degrees)
        {
            if (_onTest)
            {
                _testableRobot.TurnRadarLeft(degrees);
            }
            else
            {
                _myRobot.TurnRadarLeft(degrees);
            }
        }

        public virtual void TurnGunRight(double degrees)
        {
            if (_onTest)
            {
                _testableRobot.TurnGunRight(degrees);
            }
            else
            {
                _myRobot.TurnGunRight(degrees);
            }
        }

        public virtual void TurnGunLeft(double degrees)
        {
            if (_onTest)
            {
                _testableRobot.TurnGunLeft(degrees);
            }
            else
            {
                _myRobot.TurnGunLeft(degrees);
            }
        }

        public virtual void Stop()
        {
            if (_onTest)
            {
                _testableRobot.Stop();
            }
            else
            {
                _myRobot.Stop();
            }
        }

        public virtual double BattleFieldHeight
        {
            get 
            {
                return _onTest ? _testableRobot.BattleFieldHeight : _myRobot.BattleFieldHeight;
            }
        }

        public virtual double BattleFieldWidth
        {
            get
            {
                return _onTest ? _testableRobot.BattleFieldWidth : _myRobot.BattleFieldWidth;
            }
        }

        public virtual Color BodyColor
        {
            get
            {
                return _onTest ? _testableRobot.BodyColor : _myRobot.BodyColor;
            }
            set
            {
                if (_onTest)
                {
                    _testableRobot.BodyColor = value;
                }
                else
                {
                    _myRobot.BodyColor = value;
                }
            }
        }

        public virtual Color BulletColor
        {
            get
            {
                return _onTest ? _testableRobot.BulletColor : _myRobot.BulletColor;
            }
            set
            {
                if (_onTest)
                {
                    _testableRobot.BulletColor = value;
                }
                else
                {
                    _myRobot.BulletColor = value;
                }
            }
        }

        public virtual Color GunColor
        {
            get
            {
                return _onTest ? _testableRobot.GunColor : _myRobot.GunColor;
            }
            set
            {
                if (_onTest)
                {
                    _testableRobot.GunColor = value;
                }
                else
                {
                    _myRobot.GunColor = value;
                }
            }

        }

        public virtual double Energy
        {
            get
            {
                return _onTest ? _testableRobot.Energy : _myRobot.Energy;
            }
        }
        public virtual double GunCoolingRate
        {
            get
            {
                return _onTest ? _testableRobot.GunCoolingRate : _myRobot.GunCoolingRate;
            }
        }

        public virtual double GunHeading
        {
            get
            {
                return _onTest ? _testableRobot.GunHeading : _myRobot.GunHeading;
            }
        }

        public virtual double GunHeat
        {
            get
            {
                return _onTest ? _testableRobot.GunHeat : _myRobot.GunHeat;
            }
        }

        public virtual double Heading
        {
            get
            {
                return _onTest ? _testableRobot.Heading : _myRobot.Heading;
            }
        }

        public string Name
        {
            get
            {
                return _onTest ? _testableRobot.Name : _myRobot.Name;
            }
        }
        public int NumRounds
        {
            get
            {
                return _onTest ? _testableRobot.NumRounds : _myRobot.NumRounds;
            }
        }
        public int Others { get { return _onTest ? _testableRobot.Others : _myRobot.Others; } }

        public Color RadarColor
        {
            get
            {
                return _onTest ? _testableRobot.RadarColor : _myRobot.RadarColor;
            }
            set
            {
                if (_onTest)
                {
                    _testableRobot.RadarColor = value;
                }
                else
                {
                    _myRobot.RadarColor = value;
                }
            }
        }

        public double Height { get { return _onTest ? _testableRobot.Height : _myRobot.Height; } }

        public bool IsAdjustGunForRobotTurn
        {
            get
            {
                return _onTest ? _testableRobot.IsAdjustGunForRobotTurn : _myRobot.IsAdjustGunForRobotTurn;
            }
            set 
            {
                if (_onTest)
                {
                    _testableRobot.IsAdjustGunForRobotTurn = value;
                }
                else
                {
                    _myRobot.IsAdjustGunForRobotTurn = value;
                }
            }
        }

        public bool IsAdjustRadarForGunTurn
        {
            get
            {
                return _onTest ? _testableRobot.IsAdjustRadarForGunTurn : _myRobot.IsAdjustRadarForGunTurn;
            }
            set
            {
                if (_onTest)
                {
                    _testableRobot.IsAdjustRadarForGunTurn = value;
                }
                else
                {
                    _myRobot.IsAdjustRadarForGunTurn = value;
                }
            }
        }

        public bool IsAdjustRadarForRobotTurn
        {
            get
            {
                return _onTest ? _testableRobot.IsAdjustRadarForRobotTurn : _myRobot.IsAdjustRadarForRobotTurn;
            }
            set
            {
                if (_onTest)
                {
                    _testableRobot.IsAdjustRadarForRobotTurn = value;
                }
                else
                {
                    _myRobot.IsAdjustRadarForRobotTurn = value;
                }
            }
        }
        public int RoundNum { get { return _onTest ? _testableRobot.RoundNum : _myRobot.RoundNum; } }
        public Color ScanColor 
        { 
            get { return _onTest ? _testableRobot.ScanColor : _myRobot.ScanColor; }
            set 
            {
                if (_onTest)
                {
                    _testableRobot.ScanColor = value;
                }
                else
                {
                    _myRobot.ScanColor = value;
                }
            }
        }
        public double Velocity { get { return _onTest ? _testableRobot.Velocity : _myRobot.Velocity; } }
        public double Width { get { return _onTest ? _testableRobot.Width : _myRobot.Width; } }
        public double X { get { return _onTest ? _testableRobot.X : _myRobot.X; } }
        public double Y { get { return _onTest ? _testableRobot.Y : _myRobot.Y; } }
    }
}
