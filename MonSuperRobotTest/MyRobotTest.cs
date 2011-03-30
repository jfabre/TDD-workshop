using System.Linq;
using NUnit.Framework;
using JFabre;
using Robocode;

namespace MonSuperRobotTest
{
    //Resharper Disable InconsistentNaming
    [TestFixture]
    public class GivenMyRobot
    {
        private MyRobot _robot;
        
        [SetUp]
        public void Init()
        {
            _robot = new MyRobot(true);
        }

        [Test]
        public void When_my_robot_is_hit_Then_it_should_change_its_direction_so_that_it_avoids_the_next_bullet()
        { 
            var myEvent = new HitByBulletEvent(0, new Bullet(180, 10, 20, 2, "", "", true, 1));
            _robot.OnHitByBullet(myEvent);

            Assert.That(_robot.NavigationSystem.NextPosition, Is.EqualTo(_robot.NavigationSystem.CurrentPosition - 180));
        }

        [Test]
        public void When_my_robot_choose_a_direction_it_should_change_the_current_Position()
        { 
            var myEvent = new ChooseDirectionEvent(_robot.NavigationSystem);
            _robot.OnChoosingDirection(myEvent);

            Assert.That(_robot.NavigationSystem.CurrentPosition, Is.EqualTo(_robot.NavigationSystem.NextPosition));
        }

        [Test]
        public void When_my_robot_choose_a_direction_and_the_current_position_is_east_Then_the_next_position_should_be_south()
        {
            _robot.NavigationSystem.CurrentPosition = 90;

            var myEvent = new ChooseDirectionEvent(_robot.NavigationSystem);
            _robot.OnChoosingDirection(myEvent);

            Assert.That(_robot.NavigationSystem.CurrentPosition, Is.EqualTo(_robot.NavigationSystem.NextPosition));
        }

    }
}
