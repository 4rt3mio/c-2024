using Task.Classes.AbstractClasses;
using Task.Classes.Interfaces;
using Task.Classes.TypesOfOpportunities;

namespace Task.Classes.Factories
{
    internal class MotionRecognitionTVFactory : ITelevisionFactory
    {
        private readonly IMotionRecognitionFunctionality _motionRecognitionFunctionality;
        private readonly IAdditionalFunctionality _additionalFunctionality;

        public MotionRecognitionTVFactory(IMotionRecognitionFunctionality motionRecognitionFunctionality)
        {
            _motionRecognitionFunctionality = motionRecognitionFunctionality;
        }

        public TelevisionBase CreateTelevision(string name)
        {
            return new MotionRecognitionTV(_motionRecognitionFunctionality, _additionalFunctionality, name, "Plasma");
        }
    }
}
