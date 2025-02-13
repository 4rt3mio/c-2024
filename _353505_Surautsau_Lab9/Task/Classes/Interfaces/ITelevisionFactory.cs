using Task.Classes.AbstractClasses;
namespace Task.Classes.Interfaces
{
    internal interface ITelevisionFactory
    {
        TelevisionBase CreateTelevision(string name);
    }
}
