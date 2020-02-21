using System.Collections.Generic;

namespace Cint.RobotCleaner.Core
{
    /// <summary>
    /// A service to build paths from point A to point B in a space, defined by the <see cref="TCoordinate"/>
    /// </summary>
    /// <typeparam name="TCoordinate">Vector type which defines the space</typeparam>
    public interface IPathFinder<TCoordinate> where TCoordinate : ITranslatable<TCoordinate>
    {
        /// <summary>
        /// Build a path from <see cref="from"/> to <see cref="to"/>
        /// </summary>
        /// <param name="from">Start point of the path</param>
        /// <param name="to">End point of the path</param>
        /// <returns>An enumerable of points</returns>
        public IEnumerable<TCoordinate> BuildPath(TCoordinate from, TCoordinate to);
    }
}
