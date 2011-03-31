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

        /// <summary>
        /// Setup the first moves of the robot before it starts doing things
        /// </summary>
        public virtual void Init()
        { 
            
        }
            
        /// <summary>
        /// This method is called infinitely, it is where you will do your things
        /// </summary>
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


        /// <summary>
        ///   Immediately fires a bullet. The bullet will travel in the direction the
        ///   gun is pointing.
        ///   <p />
        ///   The specified bullet power is an amount of energy that will be taken from
        ///   the robot's energy. Hence, the more power you want to spend on the
        ///   bullet, the more energy is taken from your robot.
        ///   <p />
        ///   The bullet will do (4 * power) damage if it hits another robot. If power
        ///   is greater than 1, it will do an additional 2 * (power - 1) damage.
        ///   You will get (3 * power) back if you hit the other robot. You can call
        ///   <see cref="Rules.GetBulletDamage(double)" />
        ///   for getting the damage that a
        ///   bullet with a specific bullet power will do.
        ///   <p />
        ///   The specified bullet power should be between <see cref="Rules.MIN_BULLET_POWER" />
        ///   and <see cref="Rules.MAX_BULLET_POWER" />.
        ///   <p />
        ///   Note that the gun cannot Fire if the gun is overheated, meaning that
        ///   <see cref="GunHeat" />
        ///   returns a value &gt; 0.
        ///   <p />
        ///   A event is generated when the bullet hits a robot (<see cref="BulletHitEvent" />),
        ///   wall (<see cref="BulletMissedEvent" />), or another bullet
        ///   (<see cref="BulletHitBulletEvent" />).
        ///   <p />
        ///   <example>
        ///     <code>
        ///     // Fire a bullet with maximum power if the gun is ready
        ///     if (GetGunHeat() == 0)
        ///     {
        ///         Fire(Rules.MAX_BULLET_POWER);
        ///     }
        ///     </code>
        ///   </example>
        ///   <seealso cref="FireBullet(double)" />
        ///   <seealso cref="GunHeat" />
        ///   <seealso cref="GunCoolingRate" />
        ///   <seealso cref="OnBulletHit(BulletHitEvent)" />
        ///   <seealso cref="OnBulletHitBullet(BulletHitBulletEvent)" />
        ///   <seealso cref="OnBulletMissed(BulletMissedEvent)" />
        /// </summary>
        /// <param name="power">
        ///   The amount of energy given to the bullet, and subtracted from the robot's energy.
        /// </param>
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

        /// 
        ///<summary>
        ///  Immediately fires a bullet. The bullet will travel in the direction the
        ///  gun is pointing.
        ///  <p />
        ///  The specified bullet power is an amount of energy that will be taken from
        ///  the robot's energy. Hence, the more power you want to spend on the
        ///  bullet, the more energy is taken from your robot.
        ///  <p />
        ///  The bullet will do (4 * power) damage if it hits another robot. If power
        ///  is greater than 1, it will do an additional 2 * (power - 1) damage.
        ///  You will get (3 * power) back if you hit the other robot. You can call
        ///  <see cref="Rules.GetBulletDamage(double)" />
        ///  for getting the damage that a
        ///  bullet with a specific bullet power will do.
        ///  <p />
        ///  The specified bullet power should be between <see cref="Rules.MIN_BULLET_POWER" />
        ///  and <see cref="Rules.MAX_BULLET_POWER" />.
        ///  <p />
        ///  Note that the gun cannot Fire if the gun is overheated, meaning that
        ///  <see cref="GunHeat" /> returns a value &gt; 0.
        ///  <p />
        ///  A event is generated when the bullet hits a robot (<see cref="BulletHitEvent" />),
        ///  wall (<see cref="BulletMissedEvent" />), or another bullet
        ///  (<see cref="BulletHitBulletEvent" />).
        ///  <p />
        ///  <example>
        ///    <code>
        ///    // Fire a bullet with maximum power if the gun is ready
        ///    if (GetGunHeat() == 0)
        ///    {
        ///        Bullet bullet = FireBullet(Rules.MAX_BULLET_POWER);
        ///
        ///        // Get the velocity of the bullet
        ///        if (bullet != null)
        ///        {
        ///            double bulletVelocity = bullet.Velocity;
        ///        }
        ///    }
        ///    </code>
        ///  </example>
        ///  Returns a
        ///  <see cref="Bullet" />
        ///  That contains information about the bullet if it  was actually fired,
        ///  which can be used for tracking the bullet after it has been fired.
        ///  If the bullet was not fired, null is returned.
        ///  <seealso cref="Fire(double)" />
        ///  <seealso cref="Bullet" />
        ///  <seealso cref="GunHeat" />
        ///  <seealso cref="GunCoolingRate" />
        ///  <seealso cref="OnBulletHit(BulletHitEvent)" />
        ///  <seealso cref="OnBulletHitBullet(BulletHitBulletEvent)" />
        ///  <seealso cref="OnBulletMissed(BulletMissedEvent)" />
        ///</summary>
        ///<param name="power">
        ///  power the amount of energy given to the bullet, and subtracted from the robot's energy.
        ///</param>
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

        /// 
        ///<summary>
        ///  Scans for other robots. This method is called automatically by the game,
        ///  as long as the robot is moving, turning its body, turning its gun, or
        ///  turning its radar.
        ///  <p />
        ///  Scan will cause <see cref="OnScannedRobot(ScannedRobotEvent)" />
        ///  to be called if you see a robot.
        ///  <p />
        ///  There are 2 reasons to call <see cref="Scan()" /> manually:
        ///  <ol>
        ///    <li>
        ///      You want to scan after you stop moving.
        ///    </li>
        ///    <li>
        ///      You want to interrupt the <see cref="OnScannedRobot(ScannedRobotEvent)" />
        ///      event. This is more likely. If you are in
        ///      <see cref="OnScannedRobot(ScannedRobotEvent)" /> and call
        ///      <see cref="Scan()" />, and you still see a robot, then the system will interrupt your
        ///      <see cref="OnScannedRobot(ScannedRobotEvent)" />  event immediately and start it
        ///      from the top.
        ///    </li>
        ///  </ol>
        ///  <p />
        ///  This call executes immediately.
        ///  <seealso cref="OnScannedRobot(ScannedRobotEvent)" />
        ///  <seealso cref="ScannedRobotEvent" />
        ///</summary>
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

        /// <summary>
        ///   Sets all the robot's color to the same color in the same time, i.e. the
        ///   color of the body, gun, radar, bullet, and scan arc.
        ///   <p />
        ///   You may only call this method one time per battle. A <em>null</em>
        ///   indicates the default (blue) color for the body, gun, radar, and scan
        ///   arc, but white for the bullet color.
        ///   <p />
        ///   <example>
        ///     <code>
        ///     // Don't forget to using System.Drawing at the top...
        ///     using System.Drawing;
        ///     ...
        ///
        ///     public void Run()
        ///     {
        ///         SetAllColors(Color.Red);
        ///         ...
        ///     }
        ///     </code>
        ///   </example>
        ///   <seealso cref="SetColors(Color, Color, Color)" />
        ///   <seealso cref="SetColors(Color, Color, Color, Color, Color)" />
        ///   <seealso cref="BodyColor" />
        ///   <seealso cref="GunColor" />
        ///   <seealso cref="RadarColor" />
        ///   <seealso cref="BulletColor" />
        ///   <seealso cref="ScanColor" />
        ///   <seealso cref="Color" />
        /// </summary>
        /// <param name="color">The new color for all the colors of the robot</param>
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

        IRunnable IRunnable.GetRobotRunnable()
        {
            return this;
        }

        IBasicEvents IBasicRobot.GetBasicEventListener()
        {
            return this;
        }

        void IBasicRobot.SetPeer(IBasicRobotPeer peer)
        {
            ((IBasicRobot) _myRobot).SetPeer(peer);
        }

        void IBasicRobot.SetOut(TextWriter output)
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

        /// 
        ///<summary>
        ///  Immediately turns the robot's gun to the right by degrees.
        ///  This call executes immediately, and does not return until it is complete,
        ///  i.e. when the angle remaining in the gun's turn is 0.
        ///  <p />
        ///  Note that both positive and negative values can be given as input,
        ///  where negative values means that the robot's gun is set to turn left
        ///  instead of right.
        ///  <p />
        ///  <example>
        ///    <code>
        ///    // Turn the robot's gun 180 degrees to the right
        ///    TurnGunRight(180);
        ///
        ///    // Afterwards, turn the robot's gun 90 degrees to the left
        ///    TurnGunRight(-90);
        ///    </code>
        ///  </example>
        ///
        ///  <seealso cref="TurnGunLeft(double)" />
        ///  <seealso cref="TurnLeft(double)" />
        ///  <seealso cref="TurnRight(double)" />
        ///  <seealso cref="TurnRadarLeft(double)" />
        ///  <seealso cref="TurnRadarRight(double)" />
        ///  <seealso cref="IsAdjustGunForRobotTurn" />
        ///</summary>
        ///<param name="degrees">
        ///  The amount of degrees to turn the robot's gun to the right.
        ///  If degrees &gt; 0 the robot's gun will turn right.
        ///  If degrees &lt; 0 the robot's gun will turn left.
        ///  If degrees = 0 the robot's gun will not turn, but execute.
        ///</param>
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

        /// 
        ///<summary>
        ///  Immediately turns the robot's gun to the left by degrees.
        ///  <p />
        ///  This call executes immediately, and does not return until it is complete,
        ///  i.e. when the angle remaining in the gun's turn is 0.
        ///  <p />
        ///  Note that both positive and negative values can be given as input,
        ///  where negative values means that the robot's gun is set to turn right
        ///  instead of left.
        ///  <p />
        ///  <example>
        ///    <code>
        ///    // Turn the robot's gun 180 degrees to the left
        ///    TurnGunLeft(180);
        ///
        ///    // Afterwards, turn the robot's gun 90 degrees to the right
        ///    TurnGunLeft(-90);
        ///    </code>
        ///  </example>
        ///
        ///  <seealso cref="TurnGunRight(double)" />
        ///  <seealso cref="TurnLeft(double)" />
        ///  <seealso cref="TurnRight(double)" />
        ///  <seealso cref="TurnRadarLeft(double)" />
        ///  <seealso cref="TurnRadarRight(double)" />
        ///  <seealso cref="IsAdjustGunForRobotTurn" />
        ///</summary>
        ///<param name="degrees">
        ///  The amount of degrees to turn the robot's gun to the left.
        ///  If degrees &gt; 0 the robot's gun will turn left.
        ///  If degrees &lt; 0 the robot's gun will turn right.
        ///  If degrees = 0 the robot's gun will not turn, but execute.
        ///</param>
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

        /// 
        ///<summary>
        ///  Immediately stops all movement, and saves it for a call to <see cref="Resume()" />.
        ///  If there is already movement saved from a previous stop, this will have no effect.
        ///  <p />
        ///  This method is equivalent to <see cref="Stop(bool)">Stop(false)</see>.
        ///  <seealso cref="Resume()" />
        ///  <seealso cref="Stop(bool)" />
        ///</summary>
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

        /// <summary>
        ///   Returns the rate at which the gun will cool down, i.e. the amount of heat
        ///   the gun heat will drop per turn.
        ///   <p />
        ///   The gun cooling rate is default 0.1 / turn, but can be changed by the
        ///   battle setup. So don't count on the cooling rate being 0.1!
        ///   <seealso cref="GunHeat" />
        ///   <seealso cref="Fire(double)" />
        ///   <seealso cref="FireBullet(double)" />
        /// </summary>
        public virtual double GunCoolingRate
        {
            get
            {
                return _onTest ? _testableRobot.GunCoolingRate : _myRobot.GunCoolingRate;
            }
        }

        /// <summary>
        ///   Returns the direction that the robot's gun is facing, in degrees.
        ///   The value returned will be between 0 and 360 (is excluded).
        ///   <p />
        ///   Note that the heading in Robocode is like a compass, where 0 means North,
        ///   90 means East, 180 means South, and 270 means West.
        ///   <seealso cref="Heading" />
        ///   <seealso cref="RadarHeading" />
        /// </summary>
        public virtual double GunHeading
        {
            get
            {
                return _onTest ? _testableRobot.GunHeading : _myRobot.GunHeading;
            }
        }

        /// <summary>
        ///   Returns the current heat of the gun. The gun cannot Fire unless this is
        ///   0. (Calls to Fire will succeed, but will not actually Fire unless
        ///   GetGunHeat() == 0).
        ///   <p />
        ///   The amount of gun heat generated when the gun is fired is 1 + (firePower / 5).
        ///   Each turn the gun heat drops by the amount returned   by <see cref="GunCoolingRate" />,
        ///   which is a battle setup.
        ///   <p />
        ///   Note that all guns are "hot" at the start of each round, where the gun heat is 3.
        ///   <seealso cref="GunCoolingRate" />
        ///   <seealso cref="Fire(double)" />
        ///   <seealso cref="FireBullet(double)" />
        /// </summary>
        public virtual double GunHeat
        {
            get
            {
                return _onTest ? _testableRobot.GunHeat : _myRobot.GunHeat;
            }
        }

        /// <summary>
        ///   Returns the direction that the robot's body is facing, in degrees.
        ///   The value returned will be between 0 and 360 (is excluded).
        ///   <p />
        ///   Note that the heading in Robocode is like a compass, where 0 means North,
        ///   90 means East, 180 means South, and 270 means West.
        ///   <seealso cref="GunHeading" />
        ///   <seealso cref="RadarHeading" />
        /// </summary>
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

        /// <summary>
        ///   Returns the number of rounds in the current battle.
        ///   <seealso cref="RoundNum" />
        /// </summary>
        public int NumRounds
        {
            get
            {
                return _onTest ? _testableRobot.NumRounds : _myRobot.NumRounds;
            }
        }


        /// <summary>
        ///   Returns how many opponents that are left in the current round.
        /// </summary>
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


        /// <summary>
        ///   Sets the gun to turn independent from the robot's turn.
        ///   <p />
        ///   Ok, so this needs some explanation: The gun is mounted on the robot's
        ///   body. So, normally, if the robot turns 90 degrees to the right, then the
        ///   gun will turn with it as it is mounted on top of the robot's body. To
        ///   compensate for this, you can call
        ///   <see cref="IsAdjustGunForRobotTurn" />.
        ///   When this is set, the gun will turn independent from the robot's turn,
        ///   i.e. the gun will compensate for the robot's body turn.
        ///   <p />
        ///   Note: This method is additive until you reach the maximum the gun can
        ///   turn. The "adjust" is added to the amount you set for turning the robot,
        ///   then capped by the physics of the game. If you turn infinite, then the
        ///   adjust is ignored (and hence overridden).
        ///   <p />
        /// <example>
        ///   Assuming both the robot and gun start Out facing up (0 degrees):
        ///   <code>
        ///   // Set gun to turn with the robot's turn
        ///   setAdjustGunForRobotTurn(false); // This is the default
        ///   TurnRight(90);
        ///   // At this point, both the robot and gun are facing right (90 degrees)
        ///   TurnLeft(90);
        ///   // Both are back to 0 degrees
        ///   </code>
        ///   -- or --
        ///   <code>
        ///   // Set gun to turn independent from the robot's turn
        ///   setAdjustGunForRobotTurn(true);
        ///   TurnRight(90);
        ///   // At this point, the robot is facing right (90 degrees), but the gun is still facing up.
        ///   TurnLeft(90);
        ///   // Both are back to 0 degrees.
        ///   </code>
        /// </example>
        ///   <p />
        ///   Note: The gun compensating this way does count as "turning the gun".
        ///   <seealso cref="IsAdjustRadarForGunTurn" />
        /// </summary>
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

        /// <summary>
        ///   Sets the radar to turn independent from the gun's turn.
        ///   <p />
        ///   Ok, so this needs some explanation: The radar is mounted on the robot's
        ///   gun. So, normally, if the gun turns 90 degrees to the right, then the
        ///   radar will turn with it as it is mounted on top of the gun. To compensate
        ///   for this, you can call <see cref="IsAdjustRadarForGunTurn" /> = (true).
        ///   When this is set, the radar will turn independent from the robot's turn,
        ///   i.e. the radar will compensate for the gun's turn.
        ///   <p />
        ///   Note: This method is additive until you reach the maximum the radar can
        ///   turn. The "adjust" is added to the amount you set for turning the gun,
        ///   then capped by the physics of the game. If you turn infinite, then the
        ///   adjust is ignored (and hence overridden).
        ///   <p />
        /// <example>
        ///   Assuming both the gun and radar start Out facing up (0 degrees):
        ///   <code>
        ///   // Set radar to turn with the gun's turn
        ///   SetAdjustRadarForGunTurn(false); // This is the default
        ///   TurnGunRight(90);
        ///   // At this point, both the radar and gun are facing right (90 degrees);
        ///   </code>
        ///   -- or --
        ///   <code>
        ///   // Set radar to turn independent from the gun's turn
        ///   SetAdjustRadarForGunTurn(true);
        ///   TurnGunRight(90);
        ///   // At this point, the gun is facing right (90 degrees), but the radar is still facing up.
        ///   </code>
        /// </example>
        ///   Note: Calling <see cref="IsAdjustRadarForGunTurn" /> will automatically call
        ///   <see cref="IsAdjustRadarForRobotTurn" /> with the same value, unless you have
        ///   already called it earlier. This behavior is primarily for backward compatibility
        ///   with older Robocode robots.
        ///   <seealso cref="IsAdjustRadarForRobotTurn" />
        ///   <seealso cref="IsAdjustGunForRobotTurn" />
        /// </summary>
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

        /// <summary>
        ///   Sets the radar to turn independent from the robot's turn.
        ///   <p />
        ///   Ok, so this needs some explanation: The radar is mounted on the gun, and
        ///   the gun is mounted on the robot's body. So, normally, if the robot turns
        ///   90 degrees to the right, the gun turns, as does the radar. Hence, if the
        ///   robot turns 90 degrees to the right, then the gun and radar will turn
        ///   with it as the radar is mounted on top of the gun. To compensate for
        ///   this, you can call <see cref="IsAdjustRadarForRobotTurn" /> = true.
        ///   When this is set, the radar will turn independent from the robot's turn,
        ///   i.e. the radar will compensate for the robot's turn.
        ///   <p />
        ///   Note: This method is additive until you reach the maximum the radar can
        ///   turn. The "adjust" is added to the amount you set for turning the robot,
        ///   then capped by the physics of the game. If you turn infinite, then the
        ///   adjust is ignored (and hence overridden).
        ///   <p />
        /// <example>
        ///   Assuming the robot, gun, and radar all start Out facing up (0
        ///   degrees):
        ///   <code>
        ///   // Set radar to turn with the robots's turn
        ///   setAdjustRadarForRobotTurn(false); // This is the default
        ///   TurnRight(90);
        ///   // At this point, the body, gun, and radar are all facing right (90 degrees);
        ///   </code>
        ///   -- or --
        ///   <code>
        ///   // Set radar to turn independent from the robot's turn
        ///   setAdjustRadarForRobotTurn(true);
        ///   TurnRight(90);
        ///   // At this point, the robot and gun are facing right (90 degrees), but the radar is still facing up.
        ///   </code>
        /// </example>
        ///   <seealso cref="IsAdjustGunForRobotTurn" />
        ///   <seealso cref="IsAdjustRadarForGunTurn" />
        /// </summary>
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

        /// <summary>
        ///   Returns the current round number (0 to <see cref="NumRounds" /> - 1) of the battle.
        ///   <seealso cref="NumRounds" />
        /// </summary>
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

        /// <summary>
        ///   Returns the velocity of the robot measured in pixels/turn.
        ///   <p />
        ///   The maximum velocity of a robot is defined by <see cref="Rules.MAX_VELOCITY" />
        ///   (8 pixels / turn).
        ///   <seealso cref="Rules.MAX_VELOCITY" />
        /// </summary>
        public double Velocity { get { return _onTest ? _testableRobot.Velocity : _myRobot.Velocity; } }
        
        public double Width { get { return _onTest ? _testableRobot.Width : _myRobot.Width; } }
        
        public double X { get { return _onTest ? _testableRobot.X : _myRobot.X; } }
        
        public double Y { get { return _onTest ? _testableRobot.Y : _myRobot.Y; } }
    }
}
