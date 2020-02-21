using System.IO;
using System.Linq;
using System.Text;
using Cint.RobotCleaner.Client;
using Cint.RobotCleaner.Core.Impl;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace Cint.RobotCleaner.Tests
{
    public class InputParserTests
    {

        private string sampleInput = "5\n10 20\nE 2\nN 1\nW 5\nS 4\nW 3";

        private Stream GetSampleStream(string sampleData)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(sampleData));
        }

        private InputParser sampleParser;

        private Stream sampleDataStream;

        [SetUp]
        public void Setup()
        {
            sampleDataStream = GetSampleStream(sampleInput);
            sampleParser = new InputParser(sampleDataStream);
        }

        [TearDown]
        public void TearDown()
        {
            sampleDataStream.Dispose();
        }

        [Test]
        public void InputParser_ShouldReadCommandCount()
        {
            Assert.AreEqual(5, sampleParser.CommandCount);
        }

        [Test]
        public void InputParser_ShouldNotFailWhenReadingCommandCountManyTimes()
        {
            Assert.DoesNotThrow(() => {
                var noFail = sampleParser.CommandCount;
                var alsoNoFailAsWell = sampleParser.CommandCount;
            });
        }

        [Test]
        public void InputParser_ShouldReturnStartingPoint()
        {
            Assert.AreEqual(new IntVector2(10, 20), sampleParser.StartingPoint);
        }

        [Test]
        public void InputParser_DoesNotFailOnRandomAccesses()
        {
            Assert.DoesNotThrow(() =>
            {
                var noFail = sampleParser.StartingPoint;
                var alsoNoFail = sampleParser.CommandCount;
                var noFailAsWell = sampleParser.StartingPoint;
            });
        }

        [Test]
        public void InputParser_YieldsOutFullMoves()
        {
            var result = sampleParser.Moves.ToArray();
            CollectionAssert.AreEqual(new[]
            {
                new IntVector2(2, 0),
                new IntVector2(0, 1),
                new IntVector2(-5, 0),
                new IntVector2(0, -4),
                new IntVector2(-3, 0)
            }, result);
        }

        [Test]
        public void InputParser_MovesCanBeReadManyTimes()
        {
            Assert.DoesNotThrow(() =>
            {
                var result = sampleParser.Moves.ToArray();
                var doesNotFail = sampleParser.Moves.ToArray();
                var stillDoesNotFail = sampleParser.Moves.ToArray();
            });
        }
    }
}
