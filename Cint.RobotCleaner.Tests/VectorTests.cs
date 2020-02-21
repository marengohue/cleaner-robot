using System.Linq;
using Cint.RobotCleaner.Core;
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

        [Test]
        public void IntVector2_AdjacentPointsHaveTwoIntermediatePts()
        {
            var vector = new IntVector2(0, 1);
            var vector2 = new IntVector2(0, 2);
            Assert.AreEqual(2, vector.GetIntermediatePoints(vector2).Count());
            Assert.AreEqual(2, vector2.GetIntermediatePoints(vector).Count());

            Assert.AreEqual(2, new IntVector2(-1, -1).GetIntermediatePoints(new IntVector2(-2, -1)).Count());
        }
    }
}
