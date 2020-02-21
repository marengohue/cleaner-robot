using Cint.RobotCleaner.Core.Impl;
using NUnit.Framework;

namespace Cint.RobotCleaner.Tests
{
    public class PathFinderTests
    {
        [Test]
        public void PathFinder_ShouldConnectAdjacentPoints()
        {
            var pathfinder = new PathFinder2D();
            CollectionAssert.AreEqual(new[] { new IntVector2(0, 1), new IntVector2(0, 2) },
                pathfinder.BuildPath(new IntVector2(0, 1), new IntVector2(0, 2)));
        }
    }
}
