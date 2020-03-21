using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCustomValidation.DataContext
{
    public class Country
    {
        public String CountryCode { set; get; }
        public String CountryName { set; get; }
        public IEnumerable<Area> CountryAreas { set; get; }
    }
}
