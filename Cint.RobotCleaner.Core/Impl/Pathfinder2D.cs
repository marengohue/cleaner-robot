using System.Collections.Generic;

namespace Cint.RobotCleaner.Core.Impl
{
    public class PathFinder2D : IPathFinder<IntVector2>
    {
        public IEnumerable<IntVector2> BuildPath(IntVector2 from, IntVector2 to)
        {
            return new [] { from, to };
        }
    }
}
