using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodrumBilgiSistemleri.Models;
using Core.Dto;

namespace Core.Interfaces
{
   public interface ITouristicServices
   {
       void SaveTouristic(Rootobject info);
       void SaveSeeingPlace(Rootobject seeing);
       void SaveFestivalPlaces(Rootobject venue);
       void SaveMuseum(Rootobject muze);
       void SaveGiftPlace(Rootobject gift);
       void SavePlaj(Rootobject plaj);
       void SaveHistorical(Rootobject historical);
       List<ParameterDto> GetAllTouristic();
       List<ParameterTypeDto> GetTouristicType(int catId);
       List<ParameterDto> GetFilterTypeData(int? typeId);
   }
}
