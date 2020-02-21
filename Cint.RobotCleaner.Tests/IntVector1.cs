using System.Diagnostics;
using Cint.RobotCleaner.Core;

namespace Cint.RobotCleaner.Tests
{
    /// <summary>
    /// A test implementation of the translatable vector
    /// Maps the navigator space into R1 (a straight 1D line)
    /// Contains sample and generated implementations of the methods
    /// </summary>
    [DebuggerDisplay("v1({" + nameof(Offset) + "})")]
    struct IntVector1 : ITranslatable<IntVector1>
    {
        public int Offset { get; }

        public IntVector1(int value)
        {
            Offset = value;
        }

        public static IntVector1 FromInt(int offset)
        {
            return new IntVector1(offset);
        }

        public IntVector1 Translate(IntVector1 other)
        {
            return new IntVector1(Offset + other.Offset);
        }

        public bool Equals(IntVector1 other)
        {
            return Offset == other.Offset;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is IntVector1 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Offset;
        }
    }
}
