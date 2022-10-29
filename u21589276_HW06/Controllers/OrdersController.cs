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
    public class OrdersController : Controller
    {
        private BikeStoresEntities db = new BikeStoresEntities();
        // GET: Orders
        public ActionResult Orders( string dateSearch)
        {
            return View(db.orders.ToList());
        }
    }
}