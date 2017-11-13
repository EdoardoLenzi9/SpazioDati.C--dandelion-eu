using System;
using System.Collections.Generic;
using System.Text;

namespace SpazioDati.Dandelion.Business.Extensions
{
    public static class ContainerSingleton
    {
        private static SimpleInjector.Container _container;

        public static SimpleInjector.Container GetInstance(this SimpleInjector.Container container)
        {
            if (_container == null)
            {
                _container = new SimpleInjector.Container();
                //_container.Options.AllowOverridingRegistrations = true;
            }

            return _container; //TODO try use this as ref
        }
    }
}