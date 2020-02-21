using System;
using System.IO;
using Cint.RobotCleaner.Core;
using Cint.RobotCleaner.Core.Impl;

namespace Cint.RobotCleaner.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using var stdio = Console.OpenStandardInput();
            var parser = new InputParser(stdio);
            var navigator = SetupNavigator(parser);
            foreach (var move in parser.Moves)
            {
                navigator.Move(move);
            }
            Console.WriteLine($"=> Cleaned: {navigator.DistinctPointsVisited}");
        }

        private static INavigator<IntVector2> SetupNavigator(InputParser parser)
        {
            return new Navigator<IntVector2>(parser.StartingPoint, new StraightPathFinder2D());
        }
    }
}
