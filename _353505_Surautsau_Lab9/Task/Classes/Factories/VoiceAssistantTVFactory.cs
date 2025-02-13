using Task.Classes.AbstractClasses;
using Task.Classes.Interfaces;
using Task.Classes.TypesOfOpportunities;

namespace Task.Classes.Factories
{
    internal class VoiceAssistantTVFactory : ITelevisionFactory
    {
        private readonly IVoiceAssistantFunctionality _voiceAssistantFunctionality;
        private readonly IAdditionalFunctionality _additionalFunctionality;

        public VoiceAssistantTVFactory(IVoiceAssistantFunctionality voiceAssistantFunctionality)
        {
            _voiceAssistantFunctionality = voiceAssistantFunctionality;
        }

        public TelevisionBase CreateTelevision(string name)
        {
            return new VoiceAssistantTV(_voiceAssistantFunctionality, _additionalFunctionality, name, "LED");
        }
    }
}
