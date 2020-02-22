using System;
using System.Linq;
using Cint.RobotCleaner.Core.Impl;
using NUnit.Framework;

namespace Cint.RobotCleaner.Tests
{
    public class PathFinderTests
    {
        [Test]
        public void PathFinder_ShouldConnectAdjacentPoints()
        {
            var pathfinder = new StraightPathFinder2D();

            CollectionAssert.AreEqual(new[] { new IntVector2(0, 1), new IntVector2(0, 2) },
                pathfinder.BuildPath(new IntVector2(0, 1), new IntVector2(0, 2)));

            CollectionAssert.AreEqual(new[] { new IntVector2(0, 1), new IntVector2(0, 0) },
                pathfinder.BuildPath(new IntVector2(0, 1), new IntVector2(0, 0)));

            CollectionAssert.AreEqual(new[] { new IntVector2(0, 0), new IntVector2(-1, 0) },
                pathfinder.BuildPath(new IntVector2(0, 0), new IntVector2(-1, 0)));
        }

        [Test]
        public void PathFinder_ConnectsPointsOnOneLine()
        {
            TestVerticalPaths();
            TestHorizontalPaths();
        }

        private void TestHorizontalPaths()
        {
            var pathfinder = new StraightPathFinder2D();

            var horizontalPath = Enumerable
                .Range(-5, 11)
                .Select(it => new IntVector2(it, 3));
            var horizontalResult = pathfinder.BuildPath(new IntVector2(-5, 3), new IntVector2(5, 3));
            CollectionAssert.AreEqual(horizontalPath, horizontalResult);

            var horizontalInversePath = Enumerable
                .Range(-5, 11)
                .Select(it => new IntVector2(it, 3))
                .Reverse();
            var horizontalInverseResult = pathfinder.BuildPath(new IntVector2(5, 3), new IntVector2(-5, 3));
            CollectionAssert.AreEqual(horizontalInversePath, horizontalInverseResult);
        }

        public void TestVerticalPaths()
        {
            var pathfinder = new StraightPathFinder2D();

            var verticalPath = Enumerable
                .Range(5, 6)
                .Select(it => new IntVector2(3, it));
            var verticalResult = pathfinder.BuildPath(new IntVector2(3, 5), new IntVector2(3, 10));
            CollectionAssert.AreEqual(verticalPath, verticalResult);

            var verticalInversePath = Enumerable
                .Range(5, 6)
                .Select(it => new IntVector2(3, it))
                .Reverse();
            var verticalInverseResult = pathfinder.BuildPath(new IntVector2(3, 10), new IntVector2(3, 5));
            CollectionAssert.AreEqual(verticalInversePath, verticalInverseResult);
        }

        [Test]
        public void PathFinder_ThrowsWhenEncounteringNonStraightPath()
        {
            var pathfinder = new StraightPathFinder2D();
            Assert.Throws<NotImplementedException>(() => pathfinder.BuildPath(new IntVector2(0, 0), new IntVector2(1, 1)));
        }
    }
}
