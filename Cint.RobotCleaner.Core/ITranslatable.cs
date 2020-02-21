namespace Cint.RobotCleaner.Core
{
    public interface ITranslatable<TCoordinate>
    {
        TCoordinate Translate(TCoordinate other);
    }
}
