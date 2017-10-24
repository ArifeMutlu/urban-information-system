using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using BodrumBilgiSistemleri.Models;
using Core.Dto;
using Core.Services;
using GifToolz.Models;

namespace BodrumBilgiSistemleri.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            var accomandtion = Services.AccommodationServices.GetAllAccommodation();
            var health = Services.HealthServices.GetAllHealth();
            var bank = Services.BankServices.GetAllBank();
            var contact = Services.ContactServices.GetAll();
            var shooping = Services.ShoopingServices.GetAllShooping();
            var touristic = Services.TouristicServices.GetAllTouristic();
            var sports = Services.SportsServices.GetSports();
            var food = Services.FoodAndDrink.GetAllFodAndDrink();

            var list = new List<ParameterDto>();
            list.AddRange(accomandtion);
            list.AddRange(health);
            list.AddRange(bank);
            list.AddRange(contact);
            list.AddRange(shooping);
            list.AddRange(touristic);
            list.AddRange(sports);
            list.AddRange(food);

            TempData["List"] = list;
            return View(list);
        }
        public PartialViewResult GetMap(int? data, int? typeId)
        {
            var model = (List<ParameterDto>)TempData.Peek("List");
            //   var model = Services.TouristicServices.GetAllTouristic();
            if (data == 1)
            {
                model = Services.FoodAndDrink.GetAllFodAndDrink();
            }
            else if (data == 2)
            {
                model = Services.TouristicServices.GetAllTouristic();
            }
            else if (data == 3)
            {
                model = Services.ShoopingServices.GetAllShooping();
            }
            else if (data == 4)
            {
                model = Services.SportsServices.GetSports();
            }
            else if (data == 5)
            {
                model = Services.AccommodationServices.GetAllAccommodation();
            }
            else if (data == 6)
            {
                model = Services.HealthServices.GetAllHealth();
            }
            else if (data == 6)
            {
                model = Services.BankServices.GetAllBank();
            }
            if (typeId != null)
            {
                if (data == 1)
                {
                    model = Services.FoodAndDrink.GetFilterTypeData(typeId);
                }
                else if (data == 2)
                {
                    model = Services.TouristicServices.GetFilterTypeData(typeId);
                }
                else if (data == 3)
                {
                    model = Services.ShoopingServices.GetFilterTypeData(typeId);
                }
                else if (data == 4)
                {
                    model = Services.SportsServices.GetFilterTypeData(typeId);
                }
                else if (data == 5)
                {
                    model = Services.AccommodationServices.GetFilterTypeData(typeId);
                }
                else if (data == 6)
                {
                    model = Services.HealthServices.GetFilterTypeData(typeId);
                }
                else if (data == 7)
                {
                    model = Services.BankServices.getFilterTypeData(typeId);
                }
            }
            return PartialView("_GetMap", model);
        }
        public PartialViewResult GetFilter()
        {
            return PartialView("_GetFilterPartial");
        }
        public PartialViewResult SideBar()
        {
            return PartialView("_SideBar");
        }
        public JsonResult GetFilterType(int catId)
        {
            var model = Services.FoodAndDrink.GetFoodAndDrinkType(catId);
            if (catId == 1)
            {
                model = Services.FoodAndDrink.GetFoodAndDrinkType(catId);
            }
            else if (catId == 2)
            {
                model = Services.TouristicServices.GetTouristicType(catId);
            }
            else if (catId == 3)
            {
                model = Services.ShoopingServices.GetShoopingType(catId);
            }
            else if (catId == 4)
            {
                model = Services.SportsServices.GetSportType(catId);
            }
            else if (catId == 5)
            {
                model = Services.AccommodationServices.GetAccommodationType(catId);
            }
            else if (catId == 6)
            {
                model = Services.HealthServices.GetHealthType(catId);
            }
            else if (catId == 7)
            {
                model = Services.BankServices.GetBankType(catId);
            }
            return Json(model);
        }
        public PartialViewResult GetFilterData(int typeId, int catId)
        {
            var model = Services.FoodAndDrink.GetAllFodAndDrink();
            if (catId == 1)
            {
                model = Services.FoodAndDrink.GetFilterTypeData(typeId);
            }
            return PartialView("_GetMap", model);
        }

        public PartialViewResult GetSmallMap()
        {
            return PartialView("_GetSmallMap");
        }

        public PartialViewResult GetMapDetail(int? id, string name)
        {
            var model = TempData.Peek("List") as List<ParameterDto>;
            var data = new ParameterDto
            {
                Name = "Bodrum",

                Phone = "23232",
                Url = "csds"
            };
            if (model != null && id != null && name != "")
            {
                 data = model.FirstOrDefault(x => x.Id == id && x.Name == name);
                if (data == null) throw new ArgumentNullException(nameof(data));
            }
            return PartialView("_GetMapDetail", data);
        }

        #region Yeme İçme

        #region SaveVenue
        public JsonResult SetCafeVenue(Rootobject venue)
        {
            Services.FoodAndDrink.SaveCafe(venue);
            return Json("s");
        }
        public JsonResult SetMarketVenue(Rootobject venue)
        {
            Services.FoodAndDrink.SaveMarket(venue);
            return Json(null);
        }
        public JsonResult SetClubVenue(Rootobject venue)
        {
            Services.FoodAndDrink.SaveClub(venue);
            return Json(null);
        }
        public JsonResult SetFastFoodVenue(Rootobject venue)
        {
            Services.FoodAndDrink.SaveFastFood(venue);
            return Json(null);
        }
        public JsonResult SetRestaurant(Rootobject venue)
        {
            Services.FoodAndDrink.SaveRestaurant(venue);
            return Json(null);
        }
        public JsonResult SetCuisineVenue(Rootobject venue)
        {
            Services.FoodAndDrink.SaveCuisine(venue);
            return Json(null);
        }
        public JsonResult SetBreakfastVenue(Rootobject venue)
        {
            Services.FoodAndDrink.SaveBreakfast(venue);
            return Json(null);
        }
        public JsonResult SetBarVenue(Rootobject venue)
        {
            Services.FoodAndDrink.SaveBar(venue);
            return Json(null);
        }


        #endregion

        #region GetVenue      

        #endregion

        #endregion

        #region Konaklama

        #region SaveVenue
        public JsonResult SetHotelVenue(Rootobject venue)
        {
            Services.AccommodationServices.SaveHotelVenu(venue);
            return Json(null);
        }
        public JsonResult SetHostelVenue(Rootobject venue)
        {
            Services.AccommodationServices.SaveHostel(venue);
            return Json(null);
        }
        public JsonResult SetHolidayVillage(Rootobject venue)
        {
            Services.AccommodationServices.SaveHolidayVillage(venue);
            return Json(null);
        }
        public JsonResult SetCamping(Rootobject venue)
        {
            Services.AccommodationServices.SaveCamping(venue);
            return Json(null);
        }
        #endregion

        #endregion

        #region Shooping
        public JsonResult SetMarket(Rootobject venue)
        {
            Services.ShoopingServices.SaveMarket(venue);
            return Json(null);
        }
        public JsonResult SetShoopingCentre(Rootobject venue)
        {
            Services.ShoopingServices.SaveShoopingMarket(venue);
            return Json(null);
        }
        #endregion

        #region Health

        public JsonResult SetPrivateHospital(Rootobject venue)
        {
            Services.HealthServices.SaveHospital(venue);
            return Json(null);
        }
        public JsonResult SetPharmacy(Rootobject venue)
        {
            Services.HealthServices.SavePharmacy(venue);
            return Json(null);
        }
        public JsonResult CommunityClinic(Rootobject venue)
        {
            Services.HealthServices.SaveClinic(venue);
            return Json(null);
        }

        #endregion

        #region Banka
        public JsonResult SetBanka(Rootobject venue)
        {
            Services.BankServices.SaveBank(venue);
            return Json(null);
        }
        public JsonResult SetAtm(Rootobject venue)
        {
            Services.BankServices.SaveAtm(venue);
            return Json(null);
        }
        #endregion

        #region Ptt
        public JsonResult SetPtt(Rootobject venue)
        {
            Services.ContactServices.SavePtt(venue);
            return Json(null);
        }
        public JsonResult SetKargo(Rootobject venue)
        {
            Services.ContactServices.SaveKargo(venue);
            return Json(null);
        }

        #endregion

        #region Touristic 

        public JsonResult SetInformation(Rootobject venue)
        {
            Services.TouristicServices.SaveTouristic(venue);
            return Json(null);
        }
        public JsonResult SetSeeingPlace(Rootobject venue)
        {
            Services.TouristicServices.SaveSeeingPlace(venue);
            return Json(null);
        }
        public JsonResult SetFestivalPlaces(Rootobject venue)
        {
            Services.TouristicServices.SaveFestivalPlaces(venue);
            return Json(null);
        }
        public JsonResult SetMuseum(Rootobject venue)
        {
            Services.TouristicServices.SaveMuseum(venue);
            return Json(null);
        }
        public JsonResult SetGift(Rootobject venue)
        {
            Services.TouristicServices.SaveGiftPlace(venue);
            return Json(null);
        }
        public JsonResult SetPlaj(Rootobject venue)
        {
            Services.TouristicServices.SavePlaj(venue);
            return Json(null);
        }
        public JsonResult SetHistorical(Rootobject venue)
        {
            Services.TouristicServices.SaveHistorical(venue);
            return Json(null);
        }
        #endregion

        #region Sports

        public JsonResult SetSports(Rootobject venue)
        {
            Services.SportsServices.SaveSports(venue);
            return Json(null);
        }

        #endregion
    }
}