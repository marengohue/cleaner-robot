using System;
using System.Collections.Generic;
using System.Linq;
using Cint.RobotCleaner.Core;

namespace Cint.RobotCleaner.Tests
{
    class OneDPathfinder : IPathFinder<IntVector1>
    {
        public IEnumerable<IntVector1> BuildPath(IntVector1 from, IntVector1 to)
        {
            var range = Enumerable
                .Range(Math.Min(from.Offset, to.Offset), Math.Abs(to.Offset - from.Offset) + 1)
                .Select(IntVector1.FromInt);
            return from.Offset > to.Offset
                ? range.Reverse()
                : range;
        }
    }
}
