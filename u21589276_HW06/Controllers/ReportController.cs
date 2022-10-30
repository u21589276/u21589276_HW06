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
                         join pr in db.products on oitem.product_id equals pr.product_id
                         join cat in db.categories on pr.category_id equals cat.category_id
                              select new
                              {
                                  oitem.item_id,
                                  oitem.order_id,
                                  oitem.list_price,
                                  orders.order_date,
                                  cat.category_id
                              }; 

            reportdata = new reportVm
            {   
                Jan = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 1 && u.category_id == 6).Count(),
                Feb = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 2 && u.category_id == 6).Count(),
                Mar = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 3 && u.category_id == 6).Count(),
                Apr = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 4 && u.category_id == 6).Count(),
                May = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 5 && u.category_id == 6).Count(),
                Jun = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 6 && u.category_id == 6).Count(),
                Jul = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 7 && u.category_id == 6).Count(),
                Aug = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 8 && u.category_id == 6).Count(),
                Sept = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 9 && u.category_id == 6).Count(),
                Oct = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 10 && u.category_id == 6).Count(),
                Nov = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 11 && u.category_id == 6).Count(),
                Dec = mtBike.ToList().Where(u => Convert.ToDateTime(u.order_date).Month == 12 && u.category_id == 6).Count()
            };

            return View(reportdata);
        }
    }
}