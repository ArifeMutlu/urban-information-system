using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodrumBilgiSistemleri.Models;
using Castle.MicroKernel.Registration;
using Core.Dto;

namespace Core.Interfaces
{
   public interface IShoopingServices
   {
       void SaveMarket(Rootobject market);
       void SaveShoopingMarket(Rootobject mall);
       List<ParameterDto> GetAllShooping();
       List<ParameterTypeDto> GetShoopingType(int catId);
       List<ParameterDto> GetFilterTypeData(int? catId);
   }
}
