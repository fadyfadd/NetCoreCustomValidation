using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCustomValidation.DataContext
{
   
     public class Fleet
    {
        public Int32 FleetId { set; get; }

        public Int32 FleetSerial { set; get; }

        public String FleetNo { set; get; }

        public String AreaCode { set; get; }

        public DateTime FleetCommissionDate { set; get; }

        public Double FleetLandedCost { set; get; }

        public Int32 FleetKindCode { set; get; }

        public Area FleetArea { set; get; }
    }
}
