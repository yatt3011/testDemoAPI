using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testDemoAPI.Models
{
    public class Platform
    {
        [Key]
        public int platformId { get; set; }
        public string uniqueName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-ddTHH:mm:ss.fffZ}")]
        public DateTime createdAt { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-ddTHH:mm:ss.fffZ}")]
        public DateTime updatedAt { get; set; }
        public ICollection<Well> wells { get; set; }
    }
}
