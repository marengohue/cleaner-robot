namespace Cint.RobotCleaner.Core
{
    public interface INavigator<in TCoordinate> where TCoordinate : ITranslatable<TCoordinate>
    {
        public int DistinctPointsVisited { get; }

        public void Move(TCoordinate destination);

    }
}
