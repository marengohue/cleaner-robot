using System;
using System.Collections.Generic;

namespace Cint.RobotCleaner.Core
{
    /// <summary>
    /// A coordinate in some N-dimensional space.
    /// </summary>
    /// <typeparam name="TCoordinate">Self-reference to the type that implements the interface</typeparam>
    public interface ITranslatable<TCoordinate> : IEquatable<TCoordinate>
    {
        /// <summary>
        /// Translate the coordinate by a given <b>other</b> value
        /// </summary>
        /// <param name="other">Value to translate by</param>
        /// <returns>A new translated coordinate</returns>
        TCoordinate Translate(TCoordinate other);

        /// <summary>
        /// Returns all the intermediate points when following from <b>this</b> coordinate to the
        /// <b>other</b>.
        /// </summary>
        /// <param name="other">Target point of the intermediate calculation</param>
        /// <returns>An enumerable of intermediate points</returns>
        IEnumerable<TCoordinate> GetIntermediatePoints(TCoordinate other);
    }
}
