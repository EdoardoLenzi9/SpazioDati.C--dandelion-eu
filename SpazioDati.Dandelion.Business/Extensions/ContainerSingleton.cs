using SimpleInjector;

namespace SpazioDati.Dandelion.Business.Extensions
{
    public static class ContainerSingleton
    {
        private static Container _container;

        public static Container GetInstance(this Container container)
        {
            if (_container == null)
            {
                _container = new Container();
                _container.Options.AllowOverridingRegistrations = true;
            }

            return _container; //TODO try use this as ref
        }
    }
}