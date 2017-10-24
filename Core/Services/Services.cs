using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Ioc;

namespace Core.Services
{
    public class Services
    {
        public static IFoodAndDrinkServices FoodAndDrink
        {
            get { return ServiceIoc.Container.Resolve<IFoodAndDrinkServices>(); }
        }
        public static IAccommodationServices AccommodationServices
        {
            get { return ServiceIoc.Container.Resolve<IAccommodationServices>(); }
        }
        public static IShoopingServices ShoopingServices
        {
            get { return ServiceIoc.Container.Resolve<IShoopingServices>(); }
        }
        public static IHealthServices HealthServices
        {
            get { return ServiceIoc.Container.Resolve<IHealthServices>(); }
        }
        public static IBankServices BankServices
        {
            get { return ServiceIoc.Container.Resolve<IBankServices>(); }
        }
        public static IContactServices ContactServices
        {
            get { return ServiceIoc.Container.Resolve<IContactServices>(); }
        }
        public static ITouristicServices TouristicServices
        {
            get { return ServiceIoc.Container.Resolve<ITouristicServices>(); }
        }
        public static ISportServices SportsServices
        {
            get { return ServiceIoc.Container.Resolve<ISportServices>(); }
        }
    }
}
