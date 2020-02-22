using System;
using System.Collections.Generic;

namespace Cint.RobotCleaner.Core.Impl
{
    /// <summary>
    /// Navigator class that is able to remember the visited coordinates.
    /// Can operate on any custom implementation of the <see cref="TCoordinate"/>
    /// </summary>
    /// <typeparam name="TCoordinate"></typeparam>
    public class Navigator<TCoordinate> : INavigator<TCoordinate>
        where TCoordinate : ITranslatable<TCoordinate>
    {
        public TCoordinate CurrentPosition { get; private set; }

        public int DistinctPointsVisited => visitedPoints.Count;

        protected readonly IPathFinder<TCoordinate> PathFinder;

        private readonly HashSet<TCoordinate> visitedPoints;

        public Navigator(TCoordinate startingPosition, IPathFinder<TCoordinate> pathFinder)
        {
            CurrentPosition = startingPosition;
            visitedPoints = new HashSet<TCoordinate>();
            PathFinder = pathFinder;
            RememberPoint(CurrentPosition);
        }

        /// <summary>
        /// Move a navigator in the given direction
        /// </summary>
        /// <param name="direction"></param>
        public void Move(TCoordinate direction)
        {
            var resultingPosition = CurrentPosition.Translate(direction);
            RememberPathPoints(CurrentPosition, resultingPosition);
            CurrentPosition = resultingPosition;
        }

        private void RememberPathPoints(TCoordinate currentPosition, TCoordinate resultingPosition)
        {
            foreach (var point in PathFinder.BuildPath(currentPosition, resultingPosition))
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