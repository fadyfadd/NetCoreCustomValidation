using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreCustomValidation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace NetCoreCustomValidation.Controllers
{
    public class EmployeeRateController : Controller
    {
       
        private String CatInsuranceConnectionString = null;
        public EmployeeRateController(IOptions<AppSettings> settings)
        {
            CatInsuranceConnectionString = settings.Value.CatInsuranceConnectionString;
        }

        public IActionResult New()
        {
            return View(new NewEmployeeRateModel());
        }     

        public IActionResult SaveNew()
        {
            ModelState.AddModelError("", "Database Connection Error");
            return View("New" , new NewEmployeeRateModel());
        }       

        public IActionResult SaveEdited([Bind(Prefix = "EditEmployeRate.Year")] Int32 Year, [Bind(Prefix = "EditEmployeRate.Rate")] Int32 Rate)
        {
            return null; 
        }

   
    }
}