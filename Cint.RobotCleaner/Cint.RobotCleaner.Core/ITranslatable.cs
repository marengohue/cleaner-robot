using System;

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
    }
}
