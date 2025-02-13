using Task.Classes.AbstractClasses;
using Task.Classes.Interfaces;
using Task.Classes.TypesOfOpportunities;

namespace Task.Classes.Factories
{
    internal class SmartTVFactory : ITelevisionFactory
    {
        private readonly IInternetFunctionality _internetFunctionality;
        private readonly IAdditionalFunctionality _additionalFunctionality;

        public SmartTVFactory(IInternetFunctionality internetFunctionality)
        {
            _internetFunctionality = internetFunctionality;
        }

        public TelevisionBase CreateTelevision(string name)
        {
            return new SmartTV(_internetFunctionality, _additionalFunctionality, name, "OLED");
        }
    }
}
