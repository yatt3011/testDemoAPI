using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testDemoClient.Models
{
    public class Dashboard
    {
        [Key]
        public int dashboardId { get; set; }
        public bool success { get; set; }
        public ICollection<ChartDashboard> chartDonut { get; set; }
        public ICollection<ChartDashboard> chartBar { get; set; }
        public ICollection<TableUser> tableUsers { get; set; }
    }
}
