using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodrumBilgiSistemleri.Models;
using Core.Dto;

namespace Core.Interfaces
{
   public interface IAccommodationServices
   {
       void SaveHotelVenu(Rootobject hotel);
       void SaveHostel(Rootobject hostel);
       void SaveHolidayVillage(Rootobject holidatVillage);
       void SaveCamping(Rootobject camping);
       List<ParameterDto> GetAllAccommodation();
       List<ParameterDto> GetFilterTypeData(int? typeId);
       List<ParameterTypeDto> GetAccommodationType(int typeId);
   }
}
