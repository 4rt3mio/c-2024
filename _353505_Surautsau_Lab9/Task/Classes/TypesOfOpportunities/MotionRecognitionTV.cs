using Task.Classes.AbstractClasses;
using Task.Classes.Interfaces;

namespace Task.Classes.TypesOfOpportunities
{
    internal class MotionRecognitionTV : TelevisionBase
    {
        public MotionRecognitionTV(IMotionRecognitionFunctionality functionality, IAdditionalFunctionality additionalFunctionality, string name, string screenType)
        : base(functionality, additionalFunctionality)
        {
            Name = name;
            ScreenType = screenType;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Motion Recognition TV: {Name}, Screen Type: {ScreenType}");
        }

        public override void Show()
        {
            Console.WriteLine("Showing content via motion recognition");
        }

        public override void SpecialFunction()
        {
            Console.WriteLine("Motion Recognition TV: Special functionality activated");
        }
    }
}
