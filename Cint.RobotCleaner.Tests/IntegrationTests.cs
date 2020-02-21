using Cint.RobotCleaner.Core;
using Cint.RobotCleaner.Core.Impl;
using NUnit.Framework;

namespace Cint.RobotCleaner.Tests
{
    public class IntegrationTests
    {
        /// <summary>
        /// This test creates a grid and tries to run spirals around and check if the calculation is correct.
        /// The running is performed counter-clockwise
        /// </summary>
        [Test]
        [Ignore("Long running, stress")]
        public void Integration_SpiralTest()
        {
            var pf = new StraightPathFinder2D();
            var origin = new IntVector2(0, 0);
            var nav = new Navigator<IntVector2>(origin, pf);

            for (int move = 0; move < 4000; move += 2)
            {
                nav.Move(new IntVector2(move + 1, 0));
                nav.Move(new IntVector2(0, move + 1));
                nav.Move(new IntVector2(-(move + 2), 0));
                nav.Move(new IntVector2(0, -(move + 2)));
            }

            Assert.AreEqual(4001*4001-4000, nav.DistinctPointsVisited);
        }

    }
}
