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
    public class LeadingTrailingSpacesAttribute : ValidationAttribute
    {
        private String errorMessage = null;
        public LeadingTrailingSpacesAttribute(String errorMessage = null)
        {
            this.errorMessage = errorMessage;
        }
        public string GetErrorMessage()
        {
            if (errorMessage == null)
                return "Leading/Trailing spaces not allowed";
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
                if (value.ToString().Trim() != value.ToString())
                    return new ValidationResult(GetErrorMessage());
                else
                    return ValidationResult.Success;
            }


        }
    }

    public class LeadingTrailingSpacesAttributeAdapter : AttributeAdapterBase<LeadingTrailingSpacesAttribute>
    {

        public LeadingTrailingSpacesAttributeAdapter(LeadingTrailingSpacesAttribute attribute,
            IStringLocalizer stringLocalizer)
            : base(attribute, stringLocalizer)
        {

        }


        public override void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-leadingtrailingspaces", GetErrorMessage(context));          
        }

        public override string GetErrorMessage(ModelValidationContextBase validationContext)
        {
            return Attribute.GetErrorMessage();
        }
    }
}
