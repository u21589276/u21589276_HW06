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
        public ActionResult Orders(DateTime? dateSearch,  string currentFilter, string sortOrder, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            var ordersviewModel = new ordersVm();
            ViewBag.CurrentSort = sortOrder;

            if (dateSearch == null)
            {
                
                page = 1;
                ordersviewModel.Orders = db.orders.ToList().ToPagedList(pageNumber, pageSize);
                ordersviewModel.OrderItems = db.order_items.ToList();
                ordersviewModel.Products = db.products.ToList();
            }
            else if (dateSearch != null)
            {
            
                ordersviewModel.Orders = db.orders.ToList().Where(o => o.order_date == dateSearch).ToPagedList(pageNumber, pageSize);
                ordersviewModel.OrderItems = db.order_items.ToList();
                ordersviewModel.Products = db.products.ToList();      
                //dateSearch = currentFilter;
            }

            //return results according to search
            //if (!String.IsNullOrEmpty(dateSearch))
            //{
            //    ordersviewModel.Orders = db.orders.ToList().Where(o => o.order_date == dateSearch)).ToPagedList(pageNumber, pageSize);
            //}

            ViewBag.CurrentFilter = dateSearch;
      
            return View(ordersviewModel);
        }
    }
}