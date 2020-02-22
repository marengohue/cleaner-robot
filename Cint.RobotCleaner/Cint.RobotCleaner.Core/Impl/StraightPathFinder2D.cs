using System;
using System.Collections.Generic;
using System.Linq;

namespace Cint.RobotCleaner.Core.Impl
{
    public class StraightPathFinder2D : IPathFinder<IntVector2>
    {
        /// <summary>
        /// Builds a straight path from <see cref="from"/> to <see cref="to"/>
        /// Fails when trying to build curved or non-straight paths
        /// </summary>
        /// <param name="from">Start point</param>
        /// <param name="to">End point</param>
        /// <returns></returns>
        public IEnumerable<IntVector2> BuildPath(IntVector2 from, IntVector2 to)
        {
            var diff = new IntVector2(to.X - from.X, to.Y - from.Y);
            ValidateStraightPath(diff);
            if (diff.X != 0)
            {
                return BuildHorizontalPath(from, to, diff);
            }
            return BuildVerticalPath(from, to, diff);
        }

        private void ValidateStraightPath(IntVector2 diff)
        {
            if (diff.X != 0 && diff.Y != 0)
            {
                throw new NotImplementedException("Non-straight paths are not supported!");
            }
        }

        private static IEnumerable<IntVector2> BuildVerticalPath(IntVector2 from, IntVector2 to, IntVector2 diff)
        {
            var result = Enumerable
                .Range(Math.Min(from.Y, to.Y), Math.Abs(diff.Y) + 1)
                .Select(y => new IntVector2(to.X, y));

            return diff.Y < 0 ? result.Reverse() : result;
        }

        private static IEnumerable<IntVector2> BuildHorizontalPath(IntVector2 from, IntVector2 to, IntVector2 diff)
        {
            var result = Enumerable
                .Range(Math.Min(from.X, to.X), Math.Abs(diff.X) + 1)
                .Select(x => new IntVector2(x, to.Y));

            return diff.X < 0 ? result.Reverse() : result;
        }
    }
}
