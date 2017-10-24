using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BodrumBilgiSistemleri.Models;
using Core.Dto;

namespace Core.Interfaces
{
   public interface IFoodAndDrinkServices
   {
       void SaveCafe(Rootobject cafe);
       void SaveMarket(Rootobject market);
       void SaveClub(Rootobject club);
       void SaveFastFood(Rootobject fastFood);
       void SaveRestaurant(Rootobject restaurant);
       void SaveCuisine(Rootobject cuisine);
       void SaveBreakfast(Rootobject breakfast);
       void SaveBar(Rootobject bar);
       List<ParameterDto> GetAllFodAndDrink();
       List<ParameterTypeDto> GetFoodAndDrinkType(int catId);
       List<ParameterDto> GetFilterTypeData(int? typeId);
   }  
}
