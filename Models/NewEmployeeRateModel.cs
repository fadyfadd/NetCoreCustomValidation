using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreCustomValidation.Validations;

namespace NetCoreCustomValidation.Models
{
    public class NewEmployeeRateModel
    {
        [Display(Name = "Id")]
        public Int32? EmployeeRateId { set; get; }

        [Range(2010, 2030)]
        [Display(Name = "Year")]
        [Required]
        public Int32? Year { set; get; }

        [Display(Name = "Class")]
        [Required]
        public Int32? Class { set; get; }

        [Range(0, 10000)]
        [Required]
        [Display(Name = "Rate")]
        public Int32? Rate { set; get; }

        [LeadingTrailingSpaces]
        [Display(Name = "Remarks")]
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public String Remarks { set; get; }

        [DateRange("2000-10-10T12:00:00", "2022-10-10T12:00:00")]
        [DataType(DataType.Date)]
        [Display(Name = "Reference Date")]
        [Required]
        public DateTime? ReferenceDate { set; get; }

        public List<SelectListItem> Classes { set; get; } =
            new List<SelectListItem>()
            {new SelectListItem("Class A" , "1") , new SelectListItem("Class B" , "2") ,  new SelectListItem("Class C" , "3") };


    }
}
