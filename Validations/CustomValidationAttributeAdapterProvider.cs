﻿using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCustomValidation.Validations
{
    public class CustomValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private readonly IValidationAttributeAdapterProvider baseProvider =
            new ValidationAttributeAdapterProvider();

        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute,
            IStringLocalizer stringLocalizer)
        {
            if (attribute is LeadingTrailingSpacesAttribute classicMovieAttribute)
            {
                return new LeadingTrailingSpacesAttributeAdapter(classicMovieAttribute, stringLocalizer);
            }
            else if (attribute is DateRangeAttribute dateRangeAttribute)
            {
                return new DateRangeAttributeAdapter(dateRangeAttribute, stringLocalizer);
            }

            return baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }

}
