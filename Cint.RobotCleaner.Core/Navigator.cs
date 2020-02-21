using System.Collections.Generic;

namespace Cint.RobotCleaner.Core
{
    /// <summary>
    /// Navigator class that is able to remember the visited coordinates.
    /// Can operate on any custom implementation of the <see cref="TCoordinate"/>
    /// </summary>
    /// <typeparam name="TCoordinate"></typeparam>
    public class Navigator<TCoordinate> where TCoordinate : ITranslatable<TCoordinate>
    {
        public TCoordinate CurrentPosition { get; private set; }

        public int DistinctPointsVisited => visitedPoints.Count;

        private readonly HashSet<TCoordinate> visitedPoints;

        public Navigator(TCoordinate startingPosition)
        {
            CurrentPosition = startingPosition;
            visitedPoints = new HashSet<TCoordinate>();
            RememberPoint(CurrentPosition);
        }

        public void Move(TCoordinate direction)
        {
            var resultingPosition = CurrentPosition.Translate(direction);
            RememberPathPoints(CurrentPosition, resultingPosition);
            CurrentPosition = resultingPosition;
        }

        private void RememberPathPoints(TCoordinate currentPosition, TCoordinate resultingPosition)
        {
            foreach (var point in currentPosition.GetIntermediatePoints(resultingPosition))
            {
                RememberPoint(point);
            }
        }

        private void RememberPoint(TCoordinate point)
        {
            visitedPoints.Add(point);
        }
    }
}