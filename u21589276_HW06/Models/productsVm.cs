using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21589276_HW06.Models
{
    public class productsVm
    {
        public PagedList.IPagedList<product> Products { get; set; }
        public List<category> Categories { get; set; }
        public List<brand> Brand { get; set; }
    }
}