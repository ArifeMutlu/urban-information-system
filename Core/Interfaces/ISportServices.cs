using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodrumBilgiSistemleri.Models;
using Core.Dto;

namespace Core.Interfaces
{
   public interface ISportServices
   {
       void SaveSports(Rootobject sport);
       List<ParameterDto> GetSports();
       List<ParameterTypeDto> GetSportType(int catId);
       List<ParameterDto> GetFilterTypeData(int? catId);
   }
}
