using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.Mvc;
using TelerikDemo.Models;

namespace TelerikDemo.Controllers
{
    public class TelerikAjaxGridController : Controller
    {

        private readonly TelerikDemoContext _telerikDemoContext;
        public TelerikAjaxGridController(TelerikDemoContext telerikDemoContext)
        {
            _telerikDemoContext = telerikDemoContext;
        }

         public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Read([FromBody]DataSourceRequest r)
        {
            var allcars = _telerikDemoContext.Cars;
            var dm = allcars.Select(s=> new CarViewModel
            {
                Id = s.Id,
                Make = s.Make,
                AirConditioner = s.AirConditioner,
                CarType = s.CarType,
                Model = s.Model,
                Year = s.Year,
                DateModified = s.DateModifed
            }).ToDataSourceResult(r.Take, r.Skip, r.Sort, r.Filter);
            return new JsonResult(dm);
        }

        [HttpPost]
        public JsonResult Create([FromBody]IEnumerable<CarViewModel> cars)
        {
            var carsmodels = cars.Select(s => new Car
            {
                Make = s.Make,
                AirConditioner = s.AirConditioner,
                CarType = s.CarType,
                Model = s.Model,
                Year = s.Year
            });
            _telerikDemoContext.Cars.AddRange(carsmodels);
            _telerikDemoContext.SaveChanges();
            var carsvm = carsmodels.Select(s => new CarViewModel
            {
                Id = s.Id,
                Make = s.Make,
                AirConditioner = s.AirConditioner,
                CarType = s.CarType,
                Model = s.Model,
                Year = s.Year,
                DateModified = s.DateModifed
            });
            return new JsonResult(carsvm);
        }

        [HttpPost]
        public JsonResult Update([FromBody]IEnumerable<CarViewModel> cars)
        {
            var carsmodels = cars.Select(s => new Car
            {
                Id = s.Id??0,
                Make = s.Make,
                AirConditioner = s.AirConditioner,
                CarType = s.CarType,
                Model = s.Model,
                Year = s.Year,
                DateModifed = s.DateModified
            });

            _telerikDemoContext.UpdateRange(carsmodels);
            _telerikDemoContext.SaveChanges();

            return new JsonResult(cars);
        }

        [HttpPost]
        public JsonResult Destroy([FromBody]IEnumerable<CarViewModel> cars)
        {
            var carsmodels = cars.Select(s => new Car
            {
                Id = s.Id ?? 0,
                Make = s.Make,
                AirConditioner = s.AirConditioner,
                CarType = s.CarType,
                Model = s.Model,
                Year = s.Year,
                DateModifed = s.DateModified
            });


            _telerikDemoContext.Cars.RemoveRange(carsmodels);
            _telerikDemoContext.SaveChanges();

            return new JsonResult(cars);
        }
    }
}