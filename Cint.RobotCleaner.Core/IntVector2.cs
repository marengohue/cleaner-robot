﻿using System;
using System.Collections.Generic;

namespace Cint.RobotCleaner.Core
{
    /// <inheritdoc cref="ITranslatable{TCoordinate}"/>
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

        public IEnumerable<IntVector2> GetIntermediatePoints(IntVector2 other)
        {
            var deltaPoint = new IntVector2(Math.Abs(other.X - X), Math.Abs(other.Y - Y));
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