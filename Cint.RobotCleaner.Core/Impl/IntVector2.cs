using System;
using System.Diagnostics;

namespace Cint.RobotCleaner.Core.Impl
{
    /// <inheritdoc cref="ITranslatable{TCoordinate}"/>
    [DebuggerDisplay("v2({X};{Y})")]
    public struct IntVector2 : ITranslatable<IntVector2>
    {
        public IntVector2(int x, int y)
        {
            ValidateArgs(x, y);
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public bool Equals(IntVector2 other)
        {
            return X == other.X && Y == other.Y;
        }

        public IntVector2 Translate(IntVector2 other)
        {
            return new IntVector2(X + other.X, Y + other.Y);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        private static void ValidateArgs(int x, int y)
        {
            if (Math.Abs(x) > Constants.CoordinateBound)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            if (Math.Abs(y) > Constants.CoordinateBound)
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }
        }
    }
}
