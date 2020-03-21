using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using NetCoreCustomValidation.DataContext;
using NetCoreCustomValidation.Models;

namespace NetCoreCustomValidation.Controllers
{
    public class FleetController : Controller
    {

        private String CatInsuranceConnectionString = null;
        public FleetController(IOptions<AppSettings> settings)
        {
            CatInsuranceConnectionString = settings.Value.CatInsuranceConnectionString;
        }


        public async Task<IActionResult> Index(
        string sortOrder,
        string searchString,
        int? showFleetId,
        int? pageNumber)
        {
            ViewData["FleetIdSortParam"] = sortOrder == "FleetId" ? "FleetId_desc" : "FleetId";
            ViewData["FleetAreaSortParam"] = sortOrder == "FleetArea" ? "FleetArea_desc" : "FleetArea";
            ViewData["FleetSerialSortParam"] = sortOrder == "FleetSerial" ? "FleetSerial_desc" : "FleetSerial";
            ViewData["FleetCommDateSortParam"] = sortOrder == "FleetCommDate" ? "FleetCommDate_desc" : "FleetCommDate";
            ViewData["FleetKindSortParam"] = sortOrder == "FleetKind" ? "FleetKind_desc" : "FleetKind";
            ViewData["FleetLandedCostSortParam"] = sortOrder == "FleetLandedCost" ? "FleetLandedCost_desc" : "FleetLandedCost";
            var fleets = new DbDataContext(CatInsuranceConnectionString).Fleets.Include(f => f.FleetArea).
                Where(f => String.IsNullOrEmpty(searchString) || f.FleetId.ToString().Contains(searchString)
                || f.AreaCode.ToString().Contains(searchString) || f.FleetCommissionDate.ToShortDateString().Contains(searchString)
                || f.FleetKindCode.ToString().Contains(searchString) || f.FleetSerial.ToString().Contains(searchString) || f.FleetLandedCost.ToString().Contains(searchString)).
                OrderBy(f => f.FleetId);


            if (searchString != null)
                ViewData["SearchString"] = searchString;

            switch (sortOrder)
            {
                case "FleetId":
                    fleets = fleets.OrderBy(f => f.FleetId);
                    ViewData["CurrentSort"] = "FleetId";
                    break;
                case "FleetId_desc":
                    fleets = fleets.OrderByDescending(f => f.FleetId);
                    ViewData["CurrentSort"] = "FleetId_desc";
                    break;
                case "FleetArea":
                    fleets = fleets.OrderBy(f => f.AreaCode);
                    ViewData["CurrentSort"] = "FleetArea";
                    break;
                case "fleetArea_desc":
                    fleets = fleets.OrderByDescending(f => f.AreaCode);
                    ViewData["CurrentSort"] = "FleetArea_desc";
                    break;
                case "FleetSerial":
                    fleets = fleets.OrderBy(f => f.FleetSerial);
                    ViewData["CurrentSort"] = "FleetSerial";
                    break;
                case "FleetSerial_desc":
                    fleets = fleets.OrderByDescending(f => f.FleetSerial);
                    ViewData["CurrentSort"] = "FleetSerial_desc";
                    break;
                case "FleetCommDate":
                    fleets = fleets.OrderBy(f => f.FleetCommissionDate);
                    ViewData["CurrentSort"] = "FleetCommDate";
                    break;
                case "FleetCommDate_desc":
                    fleets = fleets.OrderByDescending(f => f.FleetCommissionDate);
                    ViewData["CurrentSort"] = "FleetCommDate_desc";
                    break;
                case "FleetKind":
                    fleets = fleets.OrderBy(f => f.FleetKindCode);
                    ViewData["CurrentSort"] = "FleetKind";
                    break;
                case "FleetKind_desc":
                    fleets = fleets.OrderByDescending(f => f.FleetKindCode);
                    ViewData["CurrentSort"] = "FleetKind_desc";
                    break;
                case "FleetLandedCost":
                    fleets = fleets.OrderBy(f => f.FleetLandedCost);
                    ViewData["CurrentSort"] = "FleetLandedCost";
                    break;
                case "FleetLandedCost_desc":
                    fleets = fleets.OrderByDescending(f => f.FleetLandedCost);
                    ViewData["CurrentSort"] = "FleetLandedCost_desc";
                    break;
                default:
                    fleets = fleets.OrderBy(f => f.FleetId);
                    ViewData["CurrentSort"] = "FleetId";
                    break;
            }

            int pageSize = 7;
            var data = await PaginatedList<Fleet>.CreateAsync(fleets, pageNumber ?? 0, pageSize);

            if (showFleetId != null)
            {
                for (int i = 0; i <= data.Count() - 1; i++)
                {
                    int currentPage = i / pageSize;

                    if (showFleetId == data[i].FleetId)
                    {
                        ViewData["ShowFleetId"] = data[i].FleetId;
                        data.PageIndex = currentPage;
                        break;
                    }
                }
            }

            return View(data);

        }


        public IActionResult Tree()
        {
            var countries = new DbDataContext(CatInsuranceConnectionString).Countries.Include(c => c.CountryAreas).ThenInclude(c => c.AreaFleets).
                Where(c => c.CountryAreas.Where(c => c.AreaFleets.Count() != 0).Any()).ToList();


            return View(new FleetTreeModel() { Countries = countries });
        }
    }
}