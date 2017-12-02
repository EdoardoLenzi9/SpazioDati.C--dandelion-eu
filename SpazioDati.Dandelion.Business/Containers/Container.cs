namespace SpazioDati.Dandelion.Business.Containers
{
    /// <summary> 
    ///     Represent Simple Injector Lifestyle
    /// </summary>
    public enum Lifestyle
    {
        Singleton,
        Transient,
        Scoped
    };

    /// <summary> 
    ///     Class that "wraps" Simple Injector Container in order to make it singleton
    /// </summary>
    public class Container
    {
        private static Container _instance;
        private static SimpleInjector.Container _container;
        private Container()
        {
            _container = new SimpleInjector.Container();
        }

        /// <summary> 
        ///     Method that returns the instance of the container
        /// </summary>
        /// <returns>Returns the singleton instance of the container </returns>
        public static Container GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Container();
            }
            return _instance;
        }

        /// <summary> 
        ///     Method that calls <c>Container.Register&lt;TService, TImplementation&gt;(Lifestyle lifestyle)</c>
        /// </summary>
        public void Register<TService, TImplementation>(Lifestyle lifeStyle)
            where TService : class
            where TImplementation : class, TService
        {
            switch (lifeStyle)
            {
                case Lifestyle.Singleton:
                    _container.Register<TService, TImplementation>(SimpleInjector.Lifestyle.Singleton);
                    break;
                case Lifestyle.Transient:
                    _container.Register<TService, TImplementation>(SimpleInjector.Lifestyle.Transient);
                    break;
                case Lifestyle.Scoped:
                    _container.Register<TService, TImplementation>(SimpleInjector.Lifestyle.Scoped);
                    break;
            }
        }

        /// <summary>
        ///     Method that calls <c>Container.Register&lt;TConcrete&gt;(Lifestyle lifestyle)</c>
        /// </summary>
        public void Register<TImplementation>(Lifestyle lifeStyle)
            where TImplementation : class
        {
            switch (lifeStyle)
            {
                case Lifestyle.Singleton:
                    _container.Register<TImplementation>(SimpleInjector.Lifestyle.Singleton);
                    break;
                case Lifestyle.Transient:
                    _container.Register<TImplementation>(SimpleInjector.Lifestyle.Transient);
                    break;
                case Lifestyle.Scoped:
                    _container.Register<TImplementation>(SimpleInjector.Lifestyle.Scoped);
                    break;
            }
        }

        /// <summary>
        ///     Method that calls <c>Container.GetInstance&lt;TService&gt;()</c>
        /// </summary>
        /// <returns>Returns an instance of <c>T</c> that respect the Lifestyle declared</returns>
        public T Resolve<T>()
            where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}