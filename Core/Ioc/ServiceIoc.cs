using Castle.Windsor;
using Castle.Windsor.Installer;
namespace Core.Ioc
{
    public class ServiceIoc
    {
        protected ServiceIoc()
        {

        }
        private static IWindsorContainer _container;
        public static IWindsorContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new WindsorContainer();
                    _container.Install(FromAssembly.This());
                }
                return _container;
            }
        }
    }
}
