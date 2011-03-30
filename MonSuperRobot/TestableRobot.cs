using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Robocode;
using Robocode.RobotInterfaces;
using Robocode.RobotInterfaces.Peer;

namespace JFabre
{
    public abstract class TestableRobot : ITestableRobot
    {
        private Robot _myRobot;
        public TestableRobot()
        {
            _myRobot = new DefaultRobot();
        }

        public abstract void DoRobotThings();
        public void Run()
        {
            while (true)
            {
                DoRobotThings();
            }
        }

        public virtual void Ahead(double distance)
        {
            _myRobot.Ahead(distance);
        }
        public virtual void Back(double distance)
        {
            _myRobot.Back(distance);
        }
        public virtual void Fire(double power)
        {
            _myRobot.Fire(power);
        }
        public virtual void FireBullet(double power)
        {
            _myRobot.FireBullet(power);
        }
        public virtual void Resume(double power)
        {
            _myRobot.Resume();
        }
        public virtual void Scan()
        {
            _myRobot.Scan();
        }
        public virtual void SetAllColors(Color color)
        {
            _myRobot.SetAllColors(color);
        }

        public IRunnable GetRobotRunnable()
        {
            return this;
        }

        public IBasicEvents GetBasicEventListener()
        {
            return ((IBasicRobot) _myRobot).GetBasicEventListener();
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
            _myRobot.OnStatus(evnt);
        }

        public virtual void OnBulletHit(BulletHitEvent evnt)
        {
            _myRobot.OnBulletHit(evnt);
        }

        public void OnBulletHitBullet(BulletHitBulletEvent evnt)
        {
            _myRobot.OnBulletHitBullet(evnt);
        }

        public void OnBulletMissed(BulletMissedEvent evnt)
        {
            _myRobot.OnBulletMissed(evnt);
        }

        public void OnDeath(DeathEvent evnt)
        {
            _myRobot.OnDeath(evnt);
        }

        public void OnHitByBullet(HitByBulletEvent evnt)
        {
            _myRobot.OnHitByBullet(evnt);
        }

        public void OnHitRobot(HitRobotEvent evnt)
        {
            _myRobot.OnHitRobot(evnt);
        }

        public void OnHitWall(HitWallEvent evnt)
        {
            _myRobot.OnHitWall(evnt);
        }

        public void OnScannedRobot(ScannedRobotEvent evnt)
        {
            _myRobot.OnScannedRobot(evnt);
        }

        public void OnRobotDeath(RobotDeathEvent evnt)
        {
            _myRobot.OnRobotDeath(evnt);
        }

        public void OnWin(WinEvent evnt)
        {
            _myRobot.OnWin(evnt);
        }
    }
}
