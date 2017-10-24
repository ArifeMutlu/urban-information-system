using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
    public class TouristicServices : ITouristicServices
    {
        public void SaveTouristic(Rootobject info)
        {
            var cat = new Category
            {
                Name = "Turistik",
                Color = "#ffda00"
            };
            UnitOfWork.CurrentSession.Categories.Add(cat);
            var type = new TouristicType
            {
                Name = "Bilgilendirme",
                CategoryId = cat.Id
            };
            UnitOfWork.CurrentSession.TouristicTypes.Add(type);
            foreach (var item in info.response.venues)
            {
                var data = new Touristic
                {
                    Name = item.name,
                    Long = item.location != null ? item.location.lng : "",
                    Lat = item.location != null ? item.location.lat : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                    TouristicTypeId = type.Id,
                    IconId = 17
                };
                UnitOfWork.CurrentSession.Touristics.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }

        public void SaveSeeingPlace(Rootobject seeing)
        {
            var type = new TouristicType
            {
                Name = "Manzara seyir noktaları",
                CategoryId = 22
            };
            UnitOfWork.CurrentSession.TouristicTypes.Add(type);

            foreach (var item in seeing.response.venues)
            {
                var data = new Touristic
                {
                    Name = item.name,
                    Long = item.location != null ? item.location.lng : "",
                    Lat = item.location != null ? item.location.lat : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                    TouristicTypeId = type.Id,
                    IconId = 18
                };
                UnitOfWork.CurrentSession.Touristics.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }

        public void SaveFestivalPlaces(Rootobject venue)
        {
            var cat = new Category();
            var category = UnitOfWork.CurrentSession.Categories.FirstOrDefault(x => x.Name == "Turistik");
            if (category != null)
            {
                cat = category;
            }
            else
            {
                cat = new Category
                {
                    Name = "Turistik",
                    Color = "#ffda00"
                };
                UnitOfWork.CurrentSession.Categories.Add(cat);
            }
            var type = new TouristicType
            {
                Name = "Festival Alanları",
                CategoryId = cat.Id
            };
            UnitOfWork.CurrentSession.TouristicTypes.Add(type);

            foreach (var item in venue.response.venues)
            {
                var data = new Touristic
                {
                    Name = item.name,
                    Long = item.location != null ? item.location.lng : "",
                    Lat = item.location != null ? item.location.lat : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                    TouristicTypeId = type.Id,
                    IconId = 9
                };
                UnitOfWork.CurrentSession.Touristics.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }

        public void SaveMuseum(Rootobject muze)
        {
            var cat = new Category();
            var category = UnitOfWork.CurrentSession.Categories.FirstOrDefault(x => x.Name == "Turistik");
            if (category != null)
            {
                cat = category;
            }
            else
            {
                cat = new Category
                {
                    Name = "Turistik",
                    Color = "#ffda00"
                };
                UnitOfWork.CurrentSession.Categories.Add(cat);
            }
            var type = new TouristicType
            {
                Name = "Müze",
                CategoryId = cat.Id,
            };
            UnitOfWork.CurrentSession.TouristicTypes.Add(type);
            foreach (var item in muze.response.venues)
            {
                var data = new Touristic
                {
                    Name = item.name,
                    Long = item.location != null ? item.location.lng : "",
                    Lat = item.location != null ? item.location.lat : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                    TouristicTypeId = type.Id,
                    IconId = 19
                };
                UnitOfWork.CurrentSession.Touristics.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();

        }
        public void SaveGiftPlace(Rootobject gift)
        {
            var cat = new Category();
            var category = UnitOfWork.CurrentSession.Categories.FirstOrDefault(x => x.Name == "Turistik");
            if (category != null)
            {
                cat = category;
            }
            else
            {
                cat = new Category
                {
                    Name = "Turistik",
                    Color = "#ffda00"
                };
                UnitOfWork.CurrentSession.Categories.Add(cat);
            }

            var type = new TouristicType
            {
                Name = "Hediyelik Eşya",
                CategoryId = cat.Id
            };
            UnitOfWork.CurrentSession.TouristicTypes.Add(type);
            foreach (var item in gift.response.venues)
            {
                var data = new Touristic
                {
                    Name = item.name,
                    Long = item.location != null ? item.location.lng : "",
                    Lat = item.location != null ? item.location.lat : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                    TouristicTypeId = type.Id,
                    IconId = 20
                };
                UnitOfWork.CurrentSession.Touristics.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SavePlaj(Rootobject plaj)
        {
            var cat = new Category();
            var category = UnitOfWork.CurrentSession.Categories.FirstOrDefault(x => x.Name == "Turistik");
            if (category != null)
            {
                cat = category;
            }
            else
            {
                cat = new Category
                {
                    Name = "Turistik",
                    Color = "#ffda00"
                };
                UnitOfWork.CurrentSession.Categories.Add(cat);
            }
            var type = new TouristicType
            {
                Name = "Plaj",
                CategoryId = cat.Id
            };
            UnitOfWork.CurrentSession.TouristicTypes.Add(type);
            foreach (var item in plaj.response.venues)
            {
                var data = new Touristic
                {
                    Name = item.name,
                    Long = item.location != null ? item.location.lng : "",
                    Lat = item.location != null ? item.location.lat : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                    TouristicTypeId = type.Id,
                    IconId = 21
                };
                UnitOfWork.CurrentSession.Touristics.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveHistorical(Rootobject historical)
        {
            var cat = new Category();
            var category = UnitOfWork.CurrentSession.Categories.FirstOrDefault(x => x.Name == "Turistik");
            if (category != null)
            {
                cat = category;
            }
            else
            {
                cat = new Category
                {
                    Name = "Turistik",
                    Color = "#ffda00"
                };
                UnitOfWork.CurrentSession.Categories.Add(cat);
            }
            var type = new TouristicType
            {
                Name = "Tarihi Yapılar",
                CategoryId = cat.Id
            };
            UnitOfWork.CurrentSession.TouristicTypes.Add(type);
            foreach (var item in historical.response.venues)
            {
                var data = new Touristic
                {
                    Name = item.name,
                    Long = item.location != null ? item.location.lng : "",
                    Lat = item.location != null ? item.location.lat : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                    TouristicTypeId = type.Id,
                    IconId = 19
                };
                UnitOfWork.CurrentSession.Touristics.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }

        public List<ParameterDto> GetAllTouristic()
        {
            var model = UnitOfWork.CurrentSession.Touristics.Select(x => new ParameterDto
            {
                Name = x.Name,
                Lat = x.Lat,
                Url = x.Url,
                Phone = x.Phone,
                Id = x.Id,
                Lng = x.Long,
                Color = x.TouristicType.Category.Color,
                Icon = x.Icon.IconName
            }).ToList();
            return model;
        }

        public List<ParameterTypeDto> GetTouristicType(int catId)
        {
            var model = UnitOfWork.CurrentSession.TouristicTypes.Select(x => new ParameterTypeDto
            {
                Name = x.Name,
                Id = x.Id,
                CatName = x.Category.Name,
                CatId = x.CategoryId
            }).ToList();
            return model;
        }

        public List<ParameterDto> GetFilterTypeData(int? typeId)
        {
            var model = GetAllTouristic();
            if (typeId != null)
            {
                 model =
                UnitOfWork.CurrentSession.Touristics.Where(x => x.TouristicTypeId == typeId)
                    .Select(x => new ParameterDto
                    {
                        Name = x.Name,
                        Lat = x.Lat,
                        Phone = x.Phone,
                        Url = x.Url,
                        Id = x.Id,
                        Color = x.TouristicType.Category.Color,
                        Icon = x.Icon.IconName,
                        Lng = x.Long
                    }).ToList();
            }
            
            return model;
        }
    }
}
