using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCustomValidation.Validations
{
    public class DateRangeAttribute  : ValidationAttribute
    {
        public DateTime FirstDate { set; get; }
        public DateTime SecondDate { set; get; }
        public String errorMessage;

        public DateRangeAttribute(String firstDate , String secondDate , String errorMessage = null)
        { 
            this.FirstDate = Convert.ToDateTime(firstDate);
            this.SecondDate = Convert.ToDateTime(secondDate);
            this.errorMessage = errorMessage;
        }
        
        public string GetErrorMessage()
        {
            if (errorMessage == null)
                return "Date Range not valid";
            else
                return this.errorMessage;
        }
        
        protected override ValidationResult IsValid(object value,
          ValidationContext validationContext)
        {
            if (value == null || value.ToString() == "")
                return ValidationResult.Success;
            else
            {
                var dateValue = DateTime.Parse(value.ToString());

                if (DateTime.Compare(dateValue , FirstDate) >= 0 && DateTime.Compare(dateValue , SecondDate) <= 0)
                    return ValidationResult.Success;
                else
                    return new ValidationResult(GetErrorMessage());
                
            }
        }
    
    }

    public class DateRangeAttributeAdapter : AttributeAdapterBase<DateRangeAttribute>
    {

        public DateRangeAttributeAdapter(DateRangeAttribute attribute,
         IStringLocalizer stringLocalizer)
         : base(attribute, stringLocalizer)
        {

        }
        public override void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-daterange", GetErrorMessage(context));
            MergeAttribute(context.Attributes, "data-val-daterange-date1", String.Format("{0:yyyy-MM-ddTHH:mm:ss}" , Attribute.FirstDate) );
            MergeAttribute(context.Attributes, "data-val-daterange-date2", String.Format("{0:yyyy-MM-ddTHH:mm:ss}", Attribute.SecondDate));

        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return Attribute.GetErrorMessage();
        }
    }
}
