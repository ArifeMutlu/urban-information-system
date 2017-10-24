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
    public class BankServices : IBankServices
    {
        public void SaveBank(Rootobject bank)
        {
            var cat = new Category()
            {
                Name = "Banka",
             //   IconId = 2
            };
            UnitOfWork.CurrentSession.Categories.Add(cat);

            var type = new BankType
            {
                Name = "Banka Şubeleri",
                CategoryId = cat.Id
            };
            UnitOfWork.CurrentSession.BankTypes.Add(type);

            foreach (var item in bank.response.venues)
            {
                var data = new Bank
                {
                    Name = item.name,
                    BankTypeId = type.Id,
                    Long = item.location != null ? item.location.lng : "",
                    Lat = item.location != null ? item.location.lat : "",
                    Phone = item.contact != null ? item.contact.phone : "",
                    Url = item.url ?? "",
                };
                UnitOfWork.CurrentSession.Banks.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }
        public void SaveAtm(Rootobject atm)
        {
            var type = new BankType
            {
                Name = "Atm",
                CategoryId = 7
            };
            UnitOfWork.CurrentSession.BankTypes.Add(type);

            foreach (var item in atm.response.venues)
            {
                var data = new Bank
                {
                    Name = item.name,
                    Long = item.location != null ? item.location.lng : "",
                    Lat = item.location != null ? item.location.lat : "",
                    BankTypeId = type.Id,
                    Url = item.url ?? "",
                    Phone = item.contact != null ? item.contact.phone : ""
                };
                UnitOfWork.CurrentSession.Banks.Add(data);
            }
            UnitOfWork.CurrentSession.SaveChanges();
        }

        public List<ParameterDto> GetAllBank()
        {
            var model = UnitOfWork.CurrentSession.Banks.Select(x => new ParameterDto
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

        public List<ParameterTypeDto> GetBankType(int typeId)
        {
            var model = UnitOfWork.CurrentSession.BankTypes.Select(x => new ParameterTypeDto
            {
                Name = x.Name,
                Id = x.Id,
                CatName = x.Category.Name,
                CatId = x.CategoryId
            }).ToList();
            return model;
        }

        public List<ParameterDto> getFilterTypeData(int? typeId)
        {
            var model=UnitOfWork.CurrentSession.Banks.Where(x=>x.BankTypeId==typeId).Select(x=>new ParameterDto {
                Name = x.Name,
                Id = x.Id,
                Lat = x.Lat,
                Phone = x.Phone,
                Url = x.Url,
                Color = x.BankType.Category.Color,
                Icon = x.Icon.IconName,
                Lng = x.Long
            }).ToList();
            return model;
        }
    }
}
