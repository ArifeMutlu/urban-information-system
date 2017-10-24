using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodrumBilgiSistemleri.Models;
using Core.Dto;

namespace Core.Interfaces
{
   public interface IBankServices
   {
       void SaveBank(Rootobject bank);
       void SaveAtm(Rootobject atm);
       List<ParameterDto> GetAllBank();
       List<ParameterTypeDto> GetBankType(int typeId);
       List<ParameterDto> getFilterTypeData(int? typeId);
   }
}
