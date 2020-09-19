using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testDemoAPI.Models
{
    public class ChartDashboard
    {
        [Key]
        public string name { get; set; }
        public double value { get; set; }
    }
}
