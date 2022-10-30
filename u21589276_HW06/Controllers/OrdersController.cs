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
        public ActionResult Orders(string dateSearch,  string currentFilter, string sortOrder, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            ViewBag.CurrentSort = sortOrder;
            if (dateSearch != null)
            {
                page = 1;
            }
            else
            {
                dateSearch = currentFilter;
            }

            var ordersviewModel = new ordersVm();
            ordersviewModel.Orders = db.orders.ToList().ToPagedList(pageNumber, pageSize);
            ordersviewModel.OrderItems = db.order_items.ToList();
            ordersviewModel.Products = db.products.ToList();

            //return results according to search
            if (!String.IsNullOrEmpty(dateSearch))
            {
                ordersviewModel.Orders = db.orders.ToList().Where(p => p.order_date.ToString().Contains(dateSearch)).ToPagedList(pageNumber, pageSize);
            }
            ViewBag.CurrentFilter = dateSearch;

           
            return View(ordersviewModel);
        }
    }
}