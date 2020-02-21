using System;

namespace Cint.RobotCleaner.Core
{
    // Represents an int vector in x and y range of -100000 to 100000
    public struct IntVector2 : IEquatable<IntVector2>, ITranslatable<IntVector2>
    {
        public IntVector2(int x, int y)
        {
            ValidateArgs(x, y);
            X = x;
            Y = y;
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

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is IntVector2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}
