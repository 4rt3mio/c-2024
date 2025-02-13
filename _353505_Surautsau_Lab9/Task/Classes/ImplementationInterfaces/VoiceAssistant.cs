using Task.Classes.Interfaces;

namespace Task.Classes.ImplementationInterfaces
{
    internal class VoiceAssistant : IVoiceAssistantFunctionality, IAdditionalFunctionality
    {
        public void Activate()
        {
            Console.WriteLine("Voice assistant activated");
        }

        public void ActivateVoiceAssistant()
        {
            Console.WriteLine("Assisting via voice commands");
        }

        public void PerformFunction()
        {
            Console.WriteLine("Performing additional voice assistant functionality");
        }
    }
}
