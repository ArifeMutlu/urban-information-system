using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodrumBilgiSistemleri.Models;
using Core.Dto;
using Core.Interfaces;
using Core.Uow;
using Domain.Domains;

namespace Core.Services
{
    public class SportsServices : ISportServices
    {
        public void SaveSports(Rootobject sport)
        {
            var cat = new Category
            {
                Name = "Sports",
              Color = "#af6502"
            };
            UnitOfWork.CurrentSession.Categories.Add(cat);

            var type = new SportTypes
            {
                Name = "Spor Salonu",
                CategoryId = cat.Id,
               
            };
            UnitOfWork.CurrentSession.SportTypeses.Add(type);

            foreach (var item in sport.response.venues)
            {
                var data = new Sport
                {
                    Name = item.name,
                    Lat = item.location != null ? item.location.lat : "",
                    Long = item.location != null ? item.location.lng : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                    SportTypesId = type.Id,
                    IconId = 23
                };
                UnitOfWork.CurrentSession.Sports.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();

        }

        public List<ParameterDto> GetSports()
        {
            var model = UnitOfWork.CurrentSession.Sports.Select(x => new ParameterDto
            {
                Name = x.Name,
                Lat = x.Lat,
                Url = x.Url,
                Phone = x.Phone,
                Id = x.Id,
                Lng = x.Long,
                Color = x.SportTypes.Category.Color,
                Icon = x.Icon.IconName
            }).ToList();
            return model;
        }

        public List<ParameterTypeDto> GetSportType(int catId)
        {
            var model = UnitOfWork.CurrentSession.SportTypeses.Select(x => new ParameterTypeDto
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
                UnitOfWork.CurrentSession.Sports.Where(x => x.SportTypesId == catId).Select(x => new ParameterDto
                {
                    Name = x.Name,
                    Lat = x.Lat,
                    Phone = x.Phone,
                    Url = x.Url,
                    Id = x.Id,
                    Color = x.SportTypes.Category.Color,
                    Icon = x.Icon.IconName,
                    Lng = x.Long
                }).ToList();
            return model;
        }
    }
}
