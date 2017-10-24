using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domains;

namespace Domain
{
    public class Context : DbContext
    {
        public Context()
            : base("DefaultConnection")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodDrinkType> FoodDrinkTypes { get; set; }
        public DbSet<FoodAndDrink> FoodAndDrinks { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<AccommodationType> AccommodationTypes { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<ShoppingType> ShoppingTypes { get; set; }
        public DbSet<Shopping> Shoppings { get; set; }
        public DbSet<HealthType> HealthTypes { get; set; }
        public DbSet<Health> Healths { get; set; }
        public DbSet<BankType> BankTypes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<TouristicType> TouristicTypes { get; set; }
        public DbSet<Touristic> Touristics { get; set; }
        public DbSet<SportTypes> SportTypeses { get; set; }
        public DbSet<Sport>  Sports { get; set; }
    }
}
