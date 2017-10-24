using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Core.Interfaces;
using Core.Services;
using Domain;

namespace Core.Installer
{
   public class ServiceIntaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
               Component.For<Context>()
                   .LifeStyle.PerWebRequest.UsingFactoryMethod(p => new Context())
                   .LifeStyle.Singleton);

            container.Register(
                Component.For<Context>().Named("ApplicationStartContext")
                    .LifeStyle.Singleton);

            #region RegisterServices

            Register<IFoodAndDrinkServices, FoodAndDrinkServices>(container);
            Register<IAccommodationServices,AccommodationServices>(container);
            Register<IShoopingServices,ShoopingServices>(container);
            Register<IHealthServices, HealthServices>(container);
            Register<IBankServices,BankServices>(container);
            Register<IContactServices, ContactServices>(container);
            Register<ITouristicServices, TouristicServices>(container);
            Register<ISportServices,SportsServices>(container);

            #endregion
        }

        public void Register<TInterface, TService>(IWindsorContainer container)
            where TInterface : class
            where TService : TInterface
        {

            container.Register(Component.For<TInterface>()
                  .ImplementedBy<TService>()
                  .LifestyleTransient());
        }
    }
}
