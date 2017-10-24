using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using BodrumBilgiSistemleri.Models;
using Core.Dto;
using Core.Interfaces;
using Core.Uow;
using Domain;
using Domain.Domains;

namespace Core.Services
{
    public class FoodAndDrinkServices : IFoodAndDrinkServices
    {
        #region SaveVenue
        public void SaveCafe(Rootobject cafe)
        {
            var cat = new Category
            {
                Name = "Yeme İçme",
                Color = "#ff3748"
            };
            UnitOfWork.CurrentSession.Categories.Add(cat);

            var type = new FoodDrinkType
            {
                CategoryId = cat.Id,
                Name = "Kafe"
            };
            UnitOfWork.CurrentSession.FoodDrinkTypes.Add(type);
            int icon = 1;
            var IconName = UnitOfWork.CurrentSession.Icons.FirstOrDefault(x => x.IconName == "cafe");
            if (IconName != null)
            {
                icon = IconName.Id;
            }

            foreach (var item in cafe.response.venues)
            {
                var data = new FoodAndDrink
                {
                    TypeId = type.Id,
                    Name = item.name ?? "Cafe",
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Adress = item.location.address ?? "",
                    Phone = item.contact == null ? "" : item.contact.phone,
                    Url = item.url ?? "",
                    IconId = icon

                    //Description = item.menu.label,
                };
                UnitOfWork.CurrentSession.FoodAndDrinks.Add(data);

            }
            var model = UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveMarket(Rootobject market)
        {
            var type = new FoodDrinkType
            {
                CategoryId = 1,
                Name = "Market"
            };
            UnitOfWork.CurrentSession.FoodDrinkTypes.Add(type);
            foreach (var item in market.response.venues)
            {
                var data = new FoodAndDrink
                {
                    TypeId = type.Id,
                    Name = item.name ?? "Market",
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Adress = item.location.address ?? "",
                    Phone = item.contact == null ? "" : item.contact.phone,
                    Url = item.url == null ? "" : item.url
                    //Description = item.menu.label,
                };
                UnitOfWork.CurrentSession.FoodAndDrinks.Add(data);
            }
            var model = UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveClub(Rootobject club)
        {
            var type = new FoodDrinkType
            {
                CategoryId = 19,
                Name = "Gece Kulübü",
            };
            UnitOfWork.CurrentSession.FoodDrinkTypes.Add(type);
            foreach (var item in club.response.venues)
            {
                var model = new FoodAndDrink
                {
                    TypeId = type.Id,
                    Name = item.name ?? "Gece Kulübü",
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Adress = item.location.address ?? "",
                    Phone = item.contact == null ? "" : item.contact.phone,
                    Url = item.url ?? "",
                    IconId = 9
                };
                UnitOfWork.CurrentSession.FoodAndDrinks.Add(model);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveFastFood(Rootobject fastFood)
        {
            var type = new FoodDrinkType
            {
                CategoryId = 19,
                Name = "FastFood"
            };
            UnitOfWork.CurrentSession.FoodDrinkTypes.Add(type);
            foreach (var item in fastFood.response.venues)
            {
                var model = new FoodAndDrink
                {
                    TypeId = type.Id,
                    Name = item.name ?? "FastFood",
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Adress = item.location.address ?? "",
                    Phone = item.contact == null ? "" : item.contact.phone,
                    Url = item.url == null ? "" : item.url,
                    IconId = 5
                };
                UnitOfWork.CurrentSession.FoodAndDrinks.Add(model);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveRestaurant(Rootobject restaurant)
        {
            var type = new FoodDrinkType
            {
                CategoryId = 1,
                Name = "Restaurant"
            };
            UnitOfWork.CurrentSession.FoodDrinkTypes.Add(type);
            foreach (var item in restaurant.response.venues)
            {
                var model = new FoodAndDrink
                {
                    TypeId = type.Id,
                    Name = item.name ?? "Restaurant",
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Adress = item.location.address ?? "",
                    Phone = item.contact == null ? "" : item.contact.phone,
                    Url = item.url == null ? "" : item.url
                };
                UnitOfWork.CurrentSession.FoodAndDrinks.Add(model);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveCuisine(Rootobject cuisine)
        {
            var type = new FoodDrinkType
            {
                CategoryId = 19,
                Name = "Türk ve Dünya Mutfağı"
            };
            UnitOfWork.CurrentSession.FoodDrinkTypes.Add(type);
            foreach (var item in cuisine.response.venues)
            {
                var model = new FoodAndDrink
                {
                    TypeId = type.Id,
                    Name = item.name ?? "Türk Mutfağı",
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Adress = item.location.address ?? "",
                    Phone = item.contact == null ? "" : item.contact.phone,
                    Url = item.url ?? "",
                    IconId = 6
                };
                UnitOfWork.CurrentSession.FoodAndDrinks.Add(model);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveBreakfast(Rootobject breakfast)
        {
            var type = new FoodDrinkType
            {
                CategoryId = 19,
                Name = "Kahvaltı"
            };
            UnitOfWork.CurrentSession.FoodDrinkTypes.Add(type);
            foreach (var item in breakfast.response.venues)
            {
                var model = new FoodAndDrink
                {
                    TypeId = type.Id,
                    Name = item.name ?? "Kahvaltı",
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Adress = item.location.address ?? "",
                    Phone = item.contact == null ? "" : item.contact.phone,
                    Url = item.url == null ? "" : item.url,
                    IconId = 10
                };
                UnitOfWork.CurrentSession.FoodAndDrinks.Add(model);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveBar(Rootobject bar)
        {
            var type = new FoodDrinkType
            {
                CategoryId = 19,
                Name = "Bar"
            };
            UnitOfWork.CurrentSession.FoodDrinkTypes.Add(type);
            foreach (var item in bar.response.venues)
            {
                var model = new FoodAndDrink
                {
                    TypeId = type.Id,
                    Name = item.name ?? "Bar",
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Adress = item.location.address ?? "",
                    Phone = item.contact == null ? "" : item.contact.phone,
                    Url = item.url ?? "",
                    IconId = 11
                };
                UnitOfWork.CurrentSession.FoodAndDrinks.Add(model);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        #endregion

        #region GetMethods

        public List<ParameterDto> GetAllFodAndDrink()
        {
            var model = UnitOfWork.CurrentSession.FoodAndDrinks.Select(x => new ParameterDto
            {
                Name = x.Name,
                Lat = x.Lat,
                Lng = x.Long,
                Phone = x.Phone,
                Url = x.Url,
                Id = x.Id,
                Icon = x.Icon.IconName,
                Color = x.Type.Category.Color
            }).ToList();
            return model;
        }

        public List<ParameterTypeDto> GetFoodAndDrinkType(int catId)
        {
            var model = UnitOfWork.CurrentSession.FoodDrinkTypes.Select(x => new ParameterTypeDto
            {
                Name = x.Name,
                Id = x.Id,
                CatId = x.CategoryId,
                CatName = x.Category.Name
            }).ToList();
            return model;
        }

        public List<ParameterDto> GetFilterTypeData(int? typeId)
        {
            var model = (List<ParameterDto>)GetAllFodAndDrink();
            if (typeId != null)
            {
                 model =
                            UnitOfWork.CurrentSession.FoodAndDrinks.Where(x => x.TypeId == typeId).Select(x => new ParameterDto
                            {
                                Name = x.Name,
                                Lat = x.Lat,
                                Phone = x.Phone,
                                Url = x.Url,
                                Id = x.Id,
                                Color = x.Type.Category.Color,
                                Icon = x.Icon.IconName,
                                Lng = x.Long
                            }).ToList();
            }
        
            return model;

        }

        #endregion
    }
}
