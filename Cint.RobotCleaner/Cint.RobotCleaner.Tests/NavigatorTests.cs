using System;
using Cint.RobotCleaner.Core;
using Cint.RobotCleaner.Core.Impl;
using Moq;
using NUnit.Framework;

namespace Cint.RobotCleaner.Tests
{
    public class NavigatorTests
    {
        private IPathFinder<IntVector1> oneDPathFinder;

        private Mock<IPathFinder<IntVector2>> twoDPathFinder;

        [SetUp]
        public void Setup()
        {
            oneDPathFinder = new OneDPathfinder();
            twoDPathFinder = new Mock<IPathFinder<IntVector2>>();
            twoDPathFinder
                .Setup(pf => pf.BuildPath(It.IsAny<IntVector2>(), It.IsAny<IntVector2>()))
                .Returns(new IntVector2[] {});
        }

        [Test]
        public void Navigator_ShouldValidateInputValues()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.DoesNotThrow(() => new Navigator<IntVector2>(new IntVector2(0, 0), twoDPathFinder.Object));
            AssertOutOfBounds(1000001, 0);
            AssertOutOfBounds(0, 1000001);
            AssertOutOfBounds(0, -1000001);
            AssertOutOfBounds(-1000001, 0);
            AssertOutOfBounds(1000001, 1000001);
        }

        [Test]
        public void Navigator_CanMove()
        {
            var navigator = new Navigator<IntVector2>(new IntVector2(0, 0), twoDPathFinder.Object);
            navigator.Move(new IntVector2(1,0));
            Assert.AreEqual(new IntVector2(1, 0), navigator.CurrentPosition);
            navigator.Move(new IntVector2(1, 0));
            Assert.AreEqual(new IntVector2(2, 0), navigator.CurrentPosition);
            navigator.Move(new IntVector2(0, 1));
            Assert.AreEqual(new IntVector2(2, 1), navigator.CurrentPosition);
        }

        [Test]
        public void Navigator_CanRememberTouchedPoints()
        {
            var plusOne = IntVector1.FromInt(1);
            var navigator = new Navigator<IntVector1>(IntVector1.FromInt(0), oneDPathFinder);
            navigator.Move(plusOne);
            navigator.Move(plusOne);
            Assert.AreEqual(3, navigator.DistinctPointsVisited);
            navigator.Move(plusOne);
            Assert.AreEqual(4, navigator.DistinctPointsVisited);
        }

        [Test]
        public void Navigator_DoesNotRememberAlreadyTouchedPoints()
        {
            var navigator = new Navigator<IntVector1>(IntVector1.FromInt(0), oneDPathFinder);
            navigator.Move(IntVector1.FromInt(1));
            Assert.AreEqual(2, navigator.DistinctPointsVisited);
            navigator.Move(IntVector1.FromInt(-1));
            Assert.AreEqual(2, navigator.DistinctPointsVisited);
        }

        [Test]
        public void Navigator_RemembersIntermediatePointsOfTravel()
        {
            var navigator = new Navigator<IntVector1>(IntVector1.FromInt(0), oneDPathFinder);
            navigator.Move(IntVector1.FromInt(3));
            Assert.AreEqual(4, navigator.DistinctPointsVisited);

            var navigator2 = new Navigator<IntVector1>(IntVector1.FromInt(0), oneDPathFinder);
            navigator2.Move(IntVector1.FromInt(-3));
            Assert.AreEqual(4, navigator.DistinctPointsVisited);
        }

        private void AssertOutOfBounds(int x, int y)
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentOutOfRangeException>(() => new Navigator<IntVector2>(new IntVector2(x, y), twoDPathFinder.Object));
        }
    }
}