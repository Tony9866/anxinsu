using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignetInternet_BusinessLayer.Models.Region
{
    class RegionModel
    {
    }

    public class ProvincesModel
    {
        public string provinceid { get; set; }
        public string province { get; set; }
    }

    public class CityModel
    {
        public string cityId { get; set; }
        public string city { get; set; }
    }

    public class AreaModel
    {
        public string areaid { get; set; }
        public string area { get; set; }
    }
}
