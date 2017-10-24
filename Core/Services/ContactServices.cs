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
    public class ContactServices : IContactServices
    {
        public void SavePtt(Rootobject ptt)
        {
            var cat = new Category
            {
                Name = "İletişim",
                //IconId = 2
            };
            UnitOfWork.CurrentSession.Categories.Add(cat);

            var type = new ContactType
            {
                Name = "Ptt",
                CategoryId = cat.Id
            };
            UnitOfWork.CurrentSession.ContactTypes.Add(type);

            foreach (var item in ptt.response.venues)
            {
                var data = new Domain.Domains.Contact
                {
                    Name = item.name,
                    ContactTypeId = type.Id,
                    Lat = item.location != null ? item.location.lat : "",
                    Long = item.location != null ? item.location.lng : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? ""
                };
                UnitOfWork.CurrentSession.Contacts.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveKargo(Rootobject kargo)
        {
            var type = new ContactType
            {
                Name = "Kargo",
                CategoryId = 9
            };
            UnitOfWork.CurrentSession.ContactTypes.Add(type);

            foreach (var item in kargo.response.venues)
            {
                var data = new Domain.Domains.Contact
                {
                    Name =item.name,
                    Long = item.location!=null?item.location.lng:"",
                    Lat = item.location!=null?item.location.lat:"",
                    Phone = item.contact!=null?item.contact.phone:"",
                    Url = item.url??"",
                    ContactTypeId = type.Id
                };
                UnitOfWork.CurrentSession.Contacts.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }

        public List<ParameterDto> GetAll()
        {
            var model = UnitOfWork.CurrentSession.Contacts.Select(x => new ParameterDto
            {
                Name = x.Name,
                Lat = x.Lat,
                Url = x.Url,
                Phone = x.Phone,
                Id = x.Id,
                Lng = x.Long
            }).ToList();
            return model;
        }
    }
}
