using Task.Classes.Interfaces;

namespace Task.Classes.ImplementationInterfaces
{
    internal class InternetBrowser : IInternetFunctionality, IAdditionalFunctionality
    {
        public void Activate()
        {
            Console.WriteLine("Internet browser activated");
        }

        public void ActivateBrowser()
        {
            Console.WriteLine("Browsing the internet");
        }

        public void PerformFunction()
        {
            Console.WriteLine("Performing additional internet functionality");
        }
    }

}
