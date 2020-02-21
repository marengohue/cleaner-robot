using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Cint.RobotCleaner.Core;

namespace Cint.RobotCleaner.Tests
{
    /// <summary>
    /// A test implementation of the translatable vector
    /// Maps the navigator space into R1 (a straight 1D line)
    /// Contains sample and generated implementations of the methods
    /// </summary>
    [DebuggerDisplay("v1({" + nameof(offset) + "})")]
    struct IntVector1 : ITranslatable<IntVector1>
    {
        private readonly int offset;
        public IntVector1(int value)
        {
            offset = value;
        }

        public static IntVector1 FromInt(int offset)
        {
            return new IntVector1(offset);
        }

        public IntVector1 Translate(IntVector1 other)
        {
            return new IntVector1(offset + other.offset);
        }

        public IEnumerable<IntVector1> GetIntermediatePoints(IntVector1 other)
        {
            var range = Enumerable
                .Range(Math.Min(offset, other.offset), Math.Abs(other.offset - offset) + 1)
                .Select(FromInt);
            return offset > other.offset
                ? range.Reverse()
                : range;
        }

        public bool Equals(IntVector1 other)
        {
            return offset == other.offset;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is IntVector1 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return offset;
        }
    }
}
