# Cleaner robot navigation system
## Summary
The system provides the implementation for a basic robot navigation system which is able to count up the amount of unique spots that were visited by the robot.
Navigator is agnostic to the coordinate system used by the robot and can be easily adopted for 3D or even 4D spaces (time travelling robots, anyone?).

## Key abstractions
In order to define a space for the robot to operate in, a developer has to implement two interfaces:
``` ITranslatable ``` - which encapsulates information about the coordinates and coordinate system that the robot is using and ``` IPathFinder<TCoordinate> ``` which is used by the navigation system to build paths between the two points in the given coordinate system.

Built-in implementations for these interfaces include 2D discrete coordinates (a grid with nodes each having a coordinate described by two integer values, e.g. (10, 10)) - ``` IntVector2 ```. Default pathfinder implementation is only able to find paths for straight directions, e.g. ("10 tiles to the north") - ``` StraightPathFinder2D ```.

## Remarks
### Test solution remarks
The test solution also implements the pathfinder/coordinate pair for a 1D robot, because the sample implementation is very simple and is much easier to build than to provide mocks for every test case.

### A note about performance
The distinct tile count calculation is performed in constant time ```O(1)```.    
The move operation is performed in time proportional to the length of the move ``` O(N) ``` which means in total, the performance of the entire test client is quadratic - proportional to ``` O(N*M) ```, where ``` N ``` is maximum length of the move, ``` M ``` is the maximum amount of moves. However, this is barely notable during a real use as robot is not going to move a sizeable distance in an instant.