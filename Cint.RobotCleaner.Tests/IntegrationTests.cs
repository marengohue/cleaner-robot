using System.IO;
using System.IO.Pipes;
using System.Text;
using Cint.RobotCleaner.Client;
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

        /// <summary>
        /// This is a full test described in the task doc
        /// </summary>
        [Test]
        public void Integration_DocSampleTest()
        {
            var sampleInput = "2\n10 22\nE 2\nN 1";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(sampleInput));
            var parser = new InputParser(stream);
            var nav = new Navigator<IntVector2>(parser.StartingPoint, new StraightPathFinder2D());

            foreach (var move in parser.Moves)
            {
                nav.Move(move);
            }

            Assert.AreEqual(4, nav.DistinctPointsVisited);
        }
    }
}
