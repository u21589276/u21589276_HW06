using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using u21589276_HW06.Models;
using PagedList;

namespace u21589276_HW06.Controllers
{
    public class ReportController : Controller
    {
        private BikeStoresEntities db = new BikeStoresEntities();
        // GET: Report
        public ActionResult Report()
        {
            reportVm reportdata = null;

            //access  model
            var mtBike = from oitem in db.order_items join orders in db.orders on oitem.order_id equals orders.order_id
                              select new
                              {
                                  oitem.item_id,
                                  oitem.order_id,
                                  oitem.list_price,
                                  orders.order_date,
                              };

            reportdata = new reportVm
            {   
                Jan = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 1).Count(),
                Feb = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 2).Count(),
                Mar = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 3).Count(),
                Apr = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 4).Count(),
                May = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 5).Count(),
                Jun = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 6).Count(),
                Jul = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 7).Count(),
                Aug = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 8).Count(),
                Sept = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 9).Count(),
                Oct = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 10).Count(),
                Nov = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 11).Count(),
                Dec = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 12).Count()
            };

            return View(reportdata);
        }
    }
}