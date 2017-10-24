using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodrumBilgiSistemleri.Models;
using Castle.DynamicProxy.Generators;
using Castle.MicroKernel.Registration;
using Core.Dto;
using Core.Interfaces;
using Core.Uow;
using Domain.Domains;

namespace Core.Services
{
    public class ShoopingServices : IShoopingServices
    {
        public void SaveMarket(Rootobject market)
        {
            //var cat = new Category
            //{
            //    Name = "Alışveriş",
            //   Color = "#ff9600"
            //};
            //UnitOfWork.CurrentSession.Categories.Add(cat);

            var model = new ShoppingType
            {
                Name = "Market",
                CategoryId = 21,
            };
            UnitOfWork.CurrentSession.ShoppingTypes.Add(model);

            foreach (var item in market.response.venues)
            {
                var data = new Shopping
                {
                    Name = item.name,
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                    ShoppingTypeId = model.Id,
                    IconId = 16
                };
                UnitOfWork.CurrentSession.Shoppings.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveShoopingMarket(Rootobject mall)
        {
            var model = new ShoppingType
            {
                Name = "AVM",
                CategoryId = 21
            };
            UnitOfWork.CurrentSession.ShoppingTypes.Add(model);
            foreach (var item in mall.response.venues)
            {
                var data = new Shopping
                {
                    Name = item.name,
                    ShoppingTypeId = model.Id,
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Url = item.url ?? "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    IconId = 16
                };
                UnitOfWork.CurrentSession.Shoppings.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }

        public List<ParameterDto> GetAllShooping()
        {
            var model = UnitOfWork.CurrentSession.Shoppings.Select(x => new ParameterDto
            {
                Name = x.Name,
                Lat = x.Lat,
                Url = x.Url,
                Phone = x.Phone,
                Id = x.Id,
                Lng = x.Long,
                Icon = x.Icon.IconName,
                Color = x.ShoppingType.Category.Color
            }).ToList();
            return model;
        }

        public List<ParameterTypeDto> GetShoopingType(int catId)
        {
            var model = UnitOfWork.CurrentSession.ShoppingTypes.Select(x => new ParameterTypeDto
            {
                Name = x.Name,
                Id = x.Id,
                CatName = x.Category.Name,
                CatId = x.CategoryId
            }).ToList();

            return model;
        }

        public List<ParameterDto> GetFilterTypeData(int? catId)
        {
            var model =
                UnitOfWork.CurrentSession.Shoppings.Where(x => x.ShoppingTypeId == catId.Value)
                    .Select(x => new ParameterDto
                    {
                        Name = x.Name,
                        Lat = x.Lat,
                        Phone = x.Phone,
                        Url = x.Url,
                        Id = x.Id,
                        Color = x.ShoppingType.Category.Color,
                        Icon =x.Icon.IconName,
                        Lng = x.Long
                    }).ToList();
            return model;
        }

        //public List<ParameterDto> GetFilterTypeData(int? catId)
        //{
        //    var model=
        //}
    }
}
