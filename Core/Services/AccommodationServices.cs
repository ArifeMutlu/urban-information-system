using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BodrumBilgiSistemleri.Models;
using Core.Dto;
using Core.Interfaces;
using Core.Uow;
using Domain.Domains;

namespace Core.Services
{
    public class AccommodationServices : IAccommodationServices
    {
        public void SaveHotelVenu(Rootobject hotel)
        {
            var cat = new Category
            {
                Name = "Konaklama",
                Color = "#95dd38"
            };
            UnitOfWork.CurrentSession.Categories.Add(cat);

            var type = new AccommodationType
            {
                CategoryId = cat.Id,
                Name = "Hotel"
            };
            UnitOfWork.CurrentSession.AccommodationTypes.Add(type);

            foreach (var item in hotel.response.venues)
            {
                var accomodation = new Accommodation
                {
                    Name = item.name,
                    AccommodationTypeId = type.Id,
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Adress = item.location.address,
                    Url = item.url ?? "",
                    Phone = item.contact == null ? "" : item.contact.phone,
                    IconId = 12
                };
                UnitOfWork.CurrentSession.Accommodations.Add(accomodation);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveHostel(Rootobject hostel)
        {
            var type = new AccommodationType
            {
                CategoryId = 20,
                Name = "Pansiyon"
            };
            UnitOfWork.CurrentSession.AccommodationTypes.Add(type);
            foreach (var item in hostel.response.venues)
            {
                var accomodation = new Accommodation
                {
                    Name = item.name,
                    AccommodationTypeId = type.Id,
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Adress = item.location.address,
                    Url = item.url ?? "",
                    Phone = item.contact == null ? "" : item.contact.phone,
                    IconId = 13
                };
                UnitOfWork.CurrentSession.Accommodations.Add(accomodation);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveHolidayVillage(Rootobject holidatVillage)
        {
            var type = new AccommodationType
            {
                CategoryId = 20,
                Name = "Tatil Köyü"
            };
            UnitOfWork.CurrentSession.AccommodationTypes.Add(type);
            foreach (var item in holidatVillage.response.venues)
            {
                var accomodation = new Accommodation
                {
                    Name = item.name,
                    AccommodationTypeId = type.Id,
                    Lat = item.location.lat,
                    Long = item.location.lng,
                    Adress = item.location.address,
                    Url = item.url ?? "",
                    Phone = item.contact == null ? "" : item.contact.phone,
                    IconId = 14
                };
                UnitOfWork.CurrentSession.Accommodations.Add(accomodation);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveCamping(Rootobject camping)
        {
            var type = new AccommodationType
            {
                CategoryId = 20,
                Name = "Kamp Alanı"
            };
            UnitOfWork.CurrentSession.AccommodationTypes.Add(type);

            foreach (var item in camping.response.venues)
            {
                if (item.location.city == "Bodrum")
                {
                    var accomodation = new Accommodation
                    {
                        Name = item.name,
                        AccommodationTypeId = type.Id,
                        Lat = item.location.lat,
                        Long = item.location.lng,
                        Adress = item.location.address,
                        Url = item.url ?? "",
                        Phone = item.contact == null ? "" : item.contact.phone,
                        IconId = 15
                    };
                    UnitOfWork.CurrentSession.Accommodations.Add(accomodation);
                }
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }

        public List<ParameterDto> GetAllAccommodation()
        {
            var model = UnitOfWork.CurrentSession.Accommodations.Select(x => new ParameterDto
            {
                Name = x.Name,
                Lat = x.Lat,
                Url = x.Url,
                Phone = x.Phone,
                Id = x.Id,
                Lng = x.Long,
                Icon = x.Icon.IconName,
                Color = x.AccommodationType.Category.Color
            }).ToList();
            return model;
        }

        public List<ParameterDto> GetFilterTypeData(int? typeId)
        {
            var model = UnitOfWork.CurrentSession.Accommodations.Where(x=>x.AccommodationTypeId==typeId).Select(x => new ParameterDto
            {
                Name = x.Name,
                Id = x.Id,
                Lat = x.Lat,
                Phone = x.Phone,
                Url = x.Url,
                Color = x.AccommodationType.Category.Color,
                Icon = x.Icon.IconName,
                Lng = x.Long
            }).ToList();
            return model;
        }

        public List<ParameterTypeDto> GetAccommodationType(int typeId)
        {
            var model = UnitOfWork.CurrentSession.AccommodationTypes.Select(x => new ParameterTypeDto
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
