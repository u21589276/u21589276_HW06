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
        public ActionResult Orders(string dateSearch, int? page)
        {
            //var orderItems = from pr in db.products join oitm in db.order_items 
            //                 on pr.product_id equals oitm.order_id join od in db.orders 
            //                 on oitm.order_id equals od.order_id
            //                 orderby oitm.item_id
            //                 select new
            //                 {
            //                     pr.product_name,
            //                     pr.list_price,
            //                     oitm.quantity,
            //                     oitm.item_id,
            //                     od.order_id,
            //                     od.order_date
            //                 };

            var allOrders = new[]
            {
                new ordersVm {OrderItems = db.order_items.ToList(), Orders = db.orders.ToList(), Products = db.products.ToList()}
            };


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(allOrders.ToPagedList(pageNumber, pageSize));
        }
    }
}