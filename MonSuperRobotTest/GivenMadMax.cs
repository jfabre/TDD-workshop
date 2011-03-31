using System.Linq;
using NUnit.Framework;
using JFabre;
using Robocode;
using Moq;
using JFabre.Base;

namespace MonSuperRobotTest
{
    //Resharper Disable InconsistentNaming
    [TestFixture]
    public class GivenMadMax
    {
        private MadMax _sut;
        private Mock<ITestableRobot> _mock;
        [SetUp]
        public void Init()
        {
            _mock = new Mock<ITestableRobot>();
            _sut = new MadMax(_mock.Object);
        }

        [Test]
        public void When_my_robot_scans_another_robot_Then_it_should_fire_a_bullet()
        { 
           var evt = new ScannedRobotEvent("name", 1, 0, 20, 30, 10);
           
            _sut.OnScannedRobot(evt);

           _mock.Verify(x => x.FireBullet(It.IsAny<double>()), Times.Once());
        }

        [Test]
        public void My_robot_should_try_to_keep_track_of_enemy_by_changing_the_direction_to_the_enemy_direction_when_scanned()
        {
            var evt = new ScannedRobotEvent("name", 1, 0, 20, 30, 10);

            _sut.OnScannedRobot(evt);

            
        }
    }
}
