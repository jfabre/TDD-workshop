using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robocode.RobotInterfaces;
using Robocode;

namespace JFabre
{
    public class MyNewRobot : IBasicRobot, IBasicEvents, IRunnable
    {
        private Robot _robot;
        public MyNewRobot()
        {
            _robot = new MyRobot();
        }
        public void Run()
        {
            _robot.Run();
        }

        public void OnBulletHit(Robocode.BulletHitEvent evnt)
        {
            _robot.OnBulletHit(evnt);
        }

        public void OnBulletHitBullet(Robocode.BulletHitBulletEvent evnt)
        {
            _robot.OnBulletHitBullet(evnt);
        }

        public void OnBulletMissed(Robocode.BulletMissedEvent evnt)
        {
            _robot.OnBulletMissed(evnt);
        }

        public void OnDeath(Robocode.DeathEvent evnt)
        {
            _robot.OnDeath(evnt);
        }

        public void OnHitByBullet(Robocode.HitByBulletEvent evnt)
        {
            _robot.OnHitByBullet(evnt);
        }

        public void OnHitRobot(Robocode.HitRobotEvent evnt)
        {
            _robot.OnHitRobot(evnt);
        }

        public void OnHitWall(Robocode.HitWallEvent evnt)
        {
            _robot.OnHitWall(evnt);
        }

        public void OnRobotDeath(Robocode.RobotDeathEvent evnt)
        {
            _robot.OnRobotDeath(evnt);
        }

        public void OnScannedRobot(Robocode.ScannedRobotEvent evnt)
        {
            _robot.OnScannedRobot(evnt);
        }

        public void OnStatus(Robocode.StatusEvent evnt)
        {
            _robot.OnStatus(evnt);
        }

        public void OnWin(Robocode.WinEvent evnt)
        {
            _robot.OnWin(evnt);
        }

        public void OnBattleEnded(Robocode.BattleEndedEvent evnt)
        {
            _robot.OnBattleEnded(evnt);
        }

        public void OnRoundEnded(Robocode.RoundEndedEvent evnt)
        {
            _robot.OnRoundEnded(evnt);
        }

        public IBasicEvents GetBasicEventListener()
        {
            return ((IBasicRobot)_robot).GetBasicEventListener();
        }

        public IRunnable GetRobotRunnable()
        {
            return ((IBasicRobot)_robot).GetRobotRunnable();
        }

        public void SetOut(System.IO.TextWriter output)
        {
            ((IBasicRobot)_robot).SetOut(output);
        }

        public void SetPeer(Robocode.RobotInterfaces.Peer.IBasicRobotPeer peer)
        {
            ((IBasicRobot)_robot).SetPeer(peer);
        }
    }
}
