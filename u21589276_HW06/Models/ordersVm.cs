using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u21589276_HW06.Models
{
    public class ordersVm
    {
        public List<product> Products { get; set; }
        public List<order_items> OrderItems { get; set; }
        public PagedList.IPagedList<order> Orders { get; set; }

    }
}