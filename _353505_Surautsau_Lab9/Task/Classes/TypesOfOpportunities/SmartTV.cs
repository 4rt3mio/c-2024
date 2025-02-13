using Task.Classes.AbstractClasses;
using Task.Classes.Interfaces;

namespace Task.Classes.TypesOfOpportunities
{
    internal class SmartTV : TelevisionBase
    {
        public SmartTV(IInternetFunctionality functionality, IAdditionalFunctionality additionalFunctionality, string name, string screenType)
        : base(functionality, additionalFunctionality)
        {
            Name = name;
            ScreenType = screenType;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Another Smart TV: {Name}, Screen Type: {ScreenType}");
        }

        public override void Show()
        {
            Console.WriteLine("Showing content via Internet browser");
        }

        public override void SpecialFunction()
        {
            Console.WriteLine("Another Smart TV: Special functionality activated");
        }
    }
}
