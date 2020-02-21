using System.Linq;
using Cint.RobotCleaner.Core;
using Cint.RobotCleaner.Core.Impl;
using NUnit.Framework;

namespace Cint.RobotCleaner.Tests
{
    public class VectorTests
    {
        [Test]
        public void IntVector2_ShouldAddUpProperly()
        {
            Assert.AreEqual(new IntVector2(10, 10), new IntVector2(5, 2).Translate(new IntVector2(5, 8)));
        }
    }
}
