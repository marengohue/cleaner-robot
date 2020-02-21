namespace Cint.RobotCleaner.Core
{
    /// <summary>
    /// A generic navigator that is able to count up the amount of distinct visited places
    /// </summary>
    /// <typeparam name="TCoordinate"></typeparam>
    public interface INavigator<in TCoordinate> where TCoordinate : ITranslatable<TCoordinate>
    {
        /// <summary>
        /// The amount of distinct visited places
        /// </summary>
        public int DistinctPointsVisited { get; }

        /// <summary>
        /// Translate current position of the navigator by the <see cref="directionVector"/>
        /// </summary>
        /// <param name="directionVector"></param>
        public void Move(TCoordinate directionVector);

    }
}
