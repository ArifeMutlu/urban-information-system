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
    public class HealthServices : IHealthServices
    {
        public void SaveHospital(Rootobject hospital)
        {
            var cat = new Category
            {
                Name = "Sağlık",
                Color ="#aa76f7"
            };
            UnitOfWork.CurrentSession.Categories.Add(cat);

            var type = new HealthType
            {
                Name = "Devlet Hastahane",
                CategoryId = cat.Id,
            };
            UnitOfWork.CurrentSession.HealthTypes.Add(type);

            foreach (var item in hospital.response.venues)
            {
                var health = new Health
                {
                    Name = item.name,
                    HealthTypeId = type.Id,
                    Lat = item.location != null ? item.location.lat : "",
                    Long = item.location != null ? item.location.lng : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                    IconId = 24
                };
                UnitOfWork.CurrentSession.Healths.Add(health);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SavePharmacy(Rootobject pharmacy)
        {
            var type = new HealthType
            {
                Name = "Eczane",
                CategoryId = 30
            };
            UnitOfWork.CurrentSession.HealthTypes.Add(type);
            foreach (var item in pharmacy.response.venues)
            {
                var data = new Health
                {
                    Name = item.name,
                    HealthTypeId = type.Id,
                    Lat = item.location != null ? item.location.lat : "",
                    Long = item.location != null ? item.location.lng : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                    IconId = 24
                };
                UnitOfWork.CurrentSession.Healths.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveClinic(Rootobject clinic)
        {
            var type = new HealthType
            {
                Name = "Sağlık Ocağı",
                CategoryId = 30
            };
            UnitOfWork.CurrentSession.HealthTypes.Add(type);


            foreach (var item in clinic.response.venues)
            {
                var data = new Health
                {
                    Name = item.name,
                    HealthTypeId = type.Id,
                    Lat = item.location != null ? item.location.lat : "",
                    Long = item.location != null ? item.location.lng : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                    IconId = 24
                };
                UnitOfWork.CurrentSession.Healths.Add(data);
              
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }

        public List<ParameterDto> GetAllHealth()
        {
            var model = UnitOfWork.CurrentSession.Healths.Select(x => new ParameterDto
            {
                Name = x.Name,
                Lat = x.Lat,
                Url = x.Url,
                Phone = x.Phone,
                Id = x.Id,
                Lng = x.Long,
                Color = x.HealthType.Category.Color,
                Icon = x.Icon.IconName
            }).ToList();
            return model;
        }

        public List<ParameterDto> GetFilterTypeData(int? typeId)
        {
            var model = UnitOfWork.CurrentSession.Healths.Where(x => x.HealthTypeId == typeId).Select(x => new ParameterDto
            {
                Name = x.Name,
                Id = x.Id,
                Lat = x.Lat,
                Phone = x.Phone,
                Url = x.Url,
                Color = x.HealthType.Category.Color,
                Icon = x.Icon.IconName,
                Lng = x.Long
            }).ToList();
            return model;
        }

        public List<ParameterTypeDto> GetHealthType(int catId)
        {
            var model = UnitOfWork.CurrentSession.HealthTypes.Select(x => new ParameterTypeDto
            {
                Name = x.Name,
                Id = x.Id,
                CatName = x.Category.Name,
                CatId = x.CategoryId
            }).ToList();
            return model;
        }
    }
}
