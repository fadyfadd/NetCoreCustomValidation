using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCustomValidation.DataContext
{
    public class Area
    {
        public String AreaCode { set; get; }
        public String CountryCode { set; get; }
        public String AreaName { set; get; }
        public Country AreaCountry { set; get; }
        public IEnumerable<Fleet> AreaFleets { set; get; }
    }
}
