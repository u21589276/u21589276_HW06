using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21589276_HW06.Models
{
    public class detailsVM
    {
        public List<product> Products { get; set; }
        public List<category> Categories { get; set; }
        public List<brand> Brand { get; set; }
        public List<store> Stores { get; set; }
        public List<stock> Stock { get; set; }
    }
}