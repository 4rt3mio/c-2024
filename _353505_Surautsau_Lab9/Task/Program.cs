using Task.Classes.AbstractClasses;
using Task.Classes.Factories;
using Task.Classes.ImplementationInterfaces;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание фабрик
            var motionRecognitionFactory = new MotionRecognitionTVFactory(new MotionRecognition());
            var smartTVFactory = new SmartTVFactory(new InternetBrowser());
            var voiceAssistantFactory = new VoiceAssistantTVFactory(new VoiceAssistant());

            // Создание коллекции телевизоров
            var tvCollection = new List<TelevisionBase>
            {
                motionRecognitionFactory.CreateTelevision("MotionTV1"),
                smartTVFactory.CreateTelevision("SmartTV1"),
                voiceAssistantFactory.CreateTelevision("VoiceTV1")
            };

            // Демонстрация работы телевизоров
            foreach (var tv in tvCollection)
            {
                tv.GetInfo();
                tv.Show();
                tv.SpecialFunction();
                Console.WriteLine("---------------------");
            }
        }
    }
}
