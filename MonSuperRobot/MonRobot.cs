using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robocode;

namespace JFabre
{
    public class MonRobot : Robot
    {

        // The main method of your robot containing robot logics
        public override void Run()
        {
            // -- Initialization of the robot --

            // Here we turn the robot to point upwards, and move the gun 90 degrees
            TurnLeft(Heading - 90);
            TurnGunRight(90);

            // Infinite loop making sure this robot runs till the end of the battle round
            while (true)
            {
                // -- Commands that are repeated forever --

                // Move our robot 5000 pixels ahead
                Ahead(20);

                TurnRight(10);
                // Turn the robot 90 degrees

                //OnChoosingDirection(new ChooseDirectionEvent(this.NavigationSystem));

                // Our robot will move along the borders of the battle field
                // by repeating the above two statements.
            }
        }

        // Robot event handler, when the robot sees another robot
        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            // We fire the gun with bullet power = 1
            Fire(1);
        }

        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            this.NavigationSystem.NextPosition = this.NavigationSystem.CurrentPosition - 180;
        }
        public NavigationSystem NavigationSystem
        {
            get;
            private set;
        }


    }
   
}
