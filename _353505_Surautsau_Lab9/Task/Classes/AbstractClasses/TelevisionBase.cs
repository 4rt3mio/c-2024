using Task.Classes.Interfaces;

namespace Task.Classes.AbstractClasses
{
    internal abstract class TelevisionBase
    {
        protected string Name;
        protected string ScreenType;
        protected ITelevisionFunctionality functionality;
        protected IAdditionalFunctionality additionalFunctionality;

        public TelevisionBase(ITelevisionFunctionality functionality, IAdditionalFunctionality additionalFunctionality)
        {
            this.functionality = functionality;
            this.additionalFunctionality = additionalFunctionality;
        }

        public abstract void GetInfo();
        public abstract void Show();

        public abstract void SpecialFunction();
    }
}
