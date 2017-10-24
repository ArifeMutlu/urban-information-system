using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodrumBilgiSistemleri.Models;
using Core.Dto;

namespace Core.Interfaces
{
   public interface IContactServices
   {
       void SavePtt(Rootobject ptt);
       void SaveKargo(Rootobject kargo);
       List<ParameterDto> GetAll();
   }
}
