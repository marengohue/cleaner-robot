using System;
using System.Collections.Generic;
using System.IO;
using Cint.RobotCleaner.Core.Impl;

namespace Cint.RobotCleaner.Client
{
    public class InputParser
    {
        private TextReader reader;

        public InputParser(Stream input)
        {
            reader = new StreamReader(input);
        }

        private int? commandCount;

        /// <summary>
        /// The amount of commands to execute
        /// </summary>
        public int CommandCount
        {
            get
            {
                EnsureCommandCount();
                // ReSharper disable once PossibleInvalidOperationException
                return commandCount.Value;
            }
        }

        private IntVector2? startingPoint;

        /// <summary>
        /// Starting point of the cleaner navigation
        /// </summary>
        public IntVector2 StartingPoint
        {
            get
            {
                EnsureCommandCount();
                EnsureStartingPoint();
                // ReSharper disable once PossibleInvalidOperationException
                return startingPoint.Value;
            }
        }

        private int movesRead;

        /// <summary>
        /// Moves to execute.
        /// <remarks>This collection is yielded only once due to the nature of the reader.
        /// In order to read it again, please re-create the parser.</remarks>
        /// </summary>
        public IEnumerable<IntVector2> Moves
        {
            get
            {
                EnsureCommandCount();
                EnsureStartingPoint();
                while (movesRead < CommandCount)
                {
                    yield return GetNextMove();
                    movesRead++;
                }
            }
        }

        private IntVector2 GetNextMove()
        {
            var parts = reader.ReadLine().Split(' ');
            var (x, y) = GetVectorFromDirection(parts[0]);
            if (int.TryParse(parts[1], out int distance))
            {
                return new IntVector2(x * distance, y * distance);
            }
            
            throw new FormatException("The move is malformed!");
        }

        private (int, int) GetVectorFromDirection(string part)
        {
            switch (part.ToLowerInvariant())
            {
                case "n": return (0, 1);
                case "e": return (1, 0);
                case "s": return (0, -1);
                case "w": return (-1, 0);
                default: throw new FormatException("Unable to determine the direction.");
            }
        }

        private void EnsureStartingPoint()
        {
            if (startingPoint.HasValue)
            {
                return;
            }

            var parts = reader.ReadLine().Split(' ');
            if (int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
            {
                startingPoint = new IntVector2(x, y);
            }
            else
            {
                throw new FormatException("The starting point is malformed!");
            }
        }

        private void EnsureCommandCount()
        {
            if (commandCount.HasValue)
            {
                return;
            }

            if (int.TryParse(reader.ReadLine(), out int resultNumber))
            {
                commandCount = resultNumber;
            }
            else
            {
                throw new FormatException("The command count is malformed!");
            }
        }
    }
}
