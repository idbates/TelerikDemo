using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.DynamicLinqCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TelerikDemo.Models;

namespace TelerikDemo.Pages.TelerikAjaxRazorGrid
{
    public class IndexModel : PageModel
    {
        private readonly TelerikDemoContext _telerikDemoContext;
        public IndexModel(TelerikDemoContext telerikDemoContext)
        {
            _telerikDemoContext = telerikDemoContext;
        }


        public void OnGet()
        {

        }

        public JsonResult OnPostListData([FromBody]DataSourceRequest r)
        {
            var allcars = _telerikDemoContext.Cars;
            var dm = allcars.ToDataSourceResult(r.Take, r.Skip, r.Sort, r.Filter);
            return new JsonResult(dm);
        }
    }
}