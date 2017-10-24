using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodrumBilgiSistemleri.Models;
using Core.Dto;

namespace Core.Interfaces
{
    public interface IHealthServices
    {
        void SaveHospital(Rootobject hospital);
        void SavePharmacy(Rootobject pharmacy);
        void SaveClinic(Rootobject clinic);
        List<ParameterDto> GetAllHealth();
        List<ParameterDto> GetFilterTypeData(int? typeId);
        List<ParameterTypeDto> GetHealthType(int catId);
    }
}
