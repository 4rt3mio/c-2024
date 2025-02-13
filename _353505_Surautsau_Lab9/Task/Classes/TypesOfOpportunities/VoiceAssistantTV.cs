using Task.Classes.AbstractClasses;
using Task.Classes.Interfaces;

namespace Task.Classes.TypesOfOpportunities
{
    internal class VoiceAssistantTV : TelevisionBase
    {
        public VoiceAssistantTV(IVoiceAssistantFunctionality functionality, IAdditionalFunctionality additionalFunctionality, string name, string screenType)
        : base(functionality, additionalFunctionality)
        {
            Name = name;
            ScreenType = screenType;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Voice Assistant TV: {Name}, Screen Type: {ScreenType}");
        }

        public override void Show()
        {
            Console.WriteLine("Showing content via voice commands");
        }

        public override void SpecialFunction()
        {
            Console.WriteLine("Voice Assistant TV: Special functionality activated");
        }
    }
}
