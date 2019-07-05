using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// this based on some code that telerik made openesource see below
// a third party made the Nuget Package Kendo.DynamicLinqCore - note the default one didnt work!
// https://www.telerik.com/blogs/kendo-ui-open-sources-dynamic-linq-helpers
// https://github.com/kendo-labs/dlinq-helpers // kendo made this
// https://github.com/linmasaki/Kendo.DynamicLinqCore // someone else made this - I suppose from the above code
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

        // DataSourceRequest is defined in the Kendo.DynamicLinqCore - it matches the model that kendo grid uses for filtering/paging and sorting on the server
        [HttpPost]
        public JsonResult Read([FromBody]DataSourceRequest r)
        {
            var allcars = _telerikDemoContext.Cars;

            // ToDataSourceResult is an extension that Kendo.DynamicLinqCore defines to dynamically apply server paging/filters and sorting all together
            var dm = allcars.Select(s=> new CarViewModel
            {
                Id = s.Id,
                Make = s.Make,
                AirConditioner = s.AirConditioner,
                CarType = s.CarType,
                Model = s.Model,
                Year = s.Year,
                DateModified = s.DateModified
            }).ToDataSourceResult(r.Take, r.Skip, r.Sort, r.Filter);

            // when the Json gets sent back asp.net core converts the properties to camelCase standard Json. 
            return new JsonResult(dm); 
        }

        [HttpPost]
        public JsonResult Create([FromBody]IEnumerable<CarViewModel> cars)
        {
            // we need to project the vm that is bound in the request to 
            // a set of Car model objects to insert into the database
            // this could be done using AutoMapper or similarto simplify
            var carsmodels = cars.Select(s => new Car
            {
                // id is null so dont include
                Make = s.Make,
                AirConditioner = s.AirConditioner,
                CarType = s.CarType,
                Model = s.Model,
                Year = s.Year,
                DateModified = s.DateModified
            });
            _telerikDemoContext.Cars.AddRange(carsmodels);
            _telerikDemoContext.SaveChanges();

            // For consistency project back to a view model
            // the kendo grid needs to be updated with the Ids of the freshly inserted Entities
            var carsvm = carsmodels.Select(s => new CarViewModel
            {
                Id = s.Id,
                Make = s.Make,
                AirConditioner = s.AirConditioner,
                CarType = s.CarType,
                Model = s.Model,
                Year = s.Year,
                DateModified = s.DateModified
            });
            return new JsonResult(carsvm);
        }

        [HttpPost]
        public JsonResult Update([FromBody]IEnumerable<CarViewModel> cars)
        {
            // for updating the UpdateRange EF core function will update matching entities as long as the Id is available and matches. The kendo grid shouldnt sent id null when it updates
            var carsmodels = cars.Select(s => new Car
            {
                Id = s.Id??0,
                Make = s.Make,
                AirConditioner = s.AirConditioner,
                CarType = s.CarType,
                Model = s.Model,
                Year = s.Year,
                DateModified = s.DateModified
            });

            _telerikDemoContext.UpdateRange(carsmodels);
            _telerikDemoContext.SaveChanges();

            return new JsonResult(cars);
        }

        [HttpPost]
        public JsonResult Destroy([FromBody]IEnumerable<CarViewModel> cars)
        {
            // for updating the RemoveRange EF core function will remove matching entities as long as the Id is available and matches. The kendo grid shouldnt sentd id null when it deletes an existing row!

            var carsmodels = cars.Select(s => new Car
            {
                Id = s.Id ?? 0,
                Make = s.Make,
                AirConditioner = s.AirConditioner,
                CarType = s.CarType,
                Model = s.Model,
                Year = s.Year,
                DateModified = s.DateModified
            });


            _telerikDemoContext.Cars.RemoveRange(carsmodels);
            _telerikDemoContext.SaveChanges();

            return new JsonResult(cars);
        }
    }
}