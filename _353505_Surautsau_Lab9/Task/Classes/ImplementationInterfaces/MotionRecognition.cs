using Task.Classes.Interfaces;

namespace Task.Classes.ImplementationInterfaces
{
    internal class MotionRecognition : IMotionRecognitionFunctionality, IAdditionalFunctionality
    {
        public void Activate()
        {
            Console.WriteLine("Motion recognition activated");
        }

        public void ActivateMotionRecognition()
        {
            Console.WriteLine("Recognizing motion");
        }

        public void PerformFunction()
        {
            Console.WriteLine("Performing additional motion recognition functionality");
        }
    }
}
