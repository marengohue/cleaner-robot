using System;
using System.Numerics;
using Cint.RobotCleaner.Core;
using NUnit.Framework;

namespace Cint.RobotCleaner.Tests
{
    public class NavigatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Navigator_ShouldValidateInputValues()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.DoesNotThrow(() => new Navigator<IntVector2>(new IntVector2(0, 0)));
            AssertOutOfBounds(1000001, 0);
            AssertOutOfBounds(0, 1000001);
            AssertOutOfBounds(0, -1000001);
            AssertOutOfBounds(-1000001, 0);
            AssertOutOfBounds(1000001, 1000001);
        }

        [Test]
        public void Navigator_CanMove()
        {
            var navigator = new Navigator<IntVector2>(new IntVector2(0, 0));
            navigator.Move(new IntVector2(1,0));
            Assert.AreEqual(new IntVector2(1, 0), navigator.CurrentPosition);
            navigator.Move(new IntVector2(1, 0));
            Assert.AreEqual(new IntVector2(2, 0), navigator.CurrentPosition);
            navigator.Move(new IntVector2(0, 1));
            Assert.AreEqual(new IntVector2(2, 1), navigator.CurrentPosition);
        }

        private static void AssertOutOfBounds(int x, int y)
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentOutOfRangeException>(() => new Navigator<IntVector2>(new IntVector2(x, y)));
        }
    }
}