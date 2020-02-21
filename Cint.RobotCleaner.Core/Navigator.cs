using System;
using System.Numerics;

namespace Cint.RobotCleaner.Core
{
    public class Navigator<TCoordinate> where TCoordinate : ITranslatable<TCoordinate>
    {
        public TCoordinate CurrentPosition { get; private set; }

        public Navigator(TCoordinate startingPosition)
        {
            CurrentPosition = startingPosition;
        }

        public void Move(TCoordinate direction)
        {
            CurrentPosition = CurrentPosition.Translate(direction);
        }
    }
}
