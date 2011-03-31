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
    }
}
