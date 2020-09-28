using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testDemoClient.Models
{
    public class PlatformDummy
    {
        [Key]
        public int platformId { get; set; }
        public string uniqueName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-ddTHH:mm:ss.fffZ}")]
        public DateTime? lastUpdated { get; set; }
        public ICollection<WellDummy> wellDummies { get; set; }
    }
}
