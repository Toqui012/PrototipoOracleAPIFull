using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrototipoOracleAPIFull.Models;

namespace PrototipoOracleAPIFull.DTO
{
    public partial class RegionDTO
    {
        public decimal RegionId { get; set; }
        public string RegionName { get; set; }

        public RegionDTO()
        {

        }

        public RegionDTO(Models.Region region)
        {
            this.RegionId = region.RegionId;
            this.RegionName = region.RegionName;
        }
    }
}
