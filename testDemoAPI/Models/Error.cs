using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testDemoAPI.Models
{
    public class Error
    {
        [Key]
        public int id { get; set; }
        public string message { get; set; }
        public string stacktrace { get; set; }
        public string innerException { get; set; }
        public string columnName { get; set; }
        public string columnValue { get; set; }       

    }
}
