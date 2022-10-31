using PagedList;
using System;
using System.Net;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using u21589276_HW06.Models;
using System.Data.Entity;

namespace u21589276_HW06.Views
{
    public class productsController : Controller
    {
        private BikeStoresEntities db = new BikeStoresEntities();
        // GET: products
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            ViewBag.CurrentSort = sortOrder;

            //
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            //access products model
            var productsVModel = new productsVm();
            productsVModel.Brand = db.brands.ToList();
            productsVModel.Categories = db.categories.ToList();
            productsVModel.Products = db.products.ToList().ToPagedList(pageNumber, pageSize);

            //return results according to search
            if (!String.IsNullOrEmpty(searchString))
            {
                productsVModel.Products = db.products.ToList().Where(p => p.product_name.Contains(searchString)).ToPagedList(pageNumber, pageSize);
            }

            ViewBag.CurrentFilter = searchString;

            return View(productsVModel);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            return View();
        }

        
        // GET: products/Details/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var productdetails = new detailsVM();
            productdetails.Products = db.products.Where(p => p.product_id == id).ToList();
            productdetails.Brand = db.brands.ToList();
            productdetails.Categories = db.categories.ToList();
            productdetails.Stock = db.stocks.Where(s => s.product_id == id).ToList();
            productdetails.Stores = db.stores.ToList();
            //product product = db.products.Find(id);

            if (productdetails == null)
            {
                return HttpNotFound();
            }
            return View(productdetails);
        }

        [HttpPost]
        public ActionResult Createprod(string name, int brand, int category, short modelyear, decimal price)
        {
            db.products.Add(new product { product_name = name, brand_id = brand, category_id = category, list_price = price, model_year = modelyear });
            db.SaveChanges();
            string message = "Product has been added.";

            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.products.Where(p => p.product_id == id).ToList();

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = db.products.Find(id);
            db.products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //// POST: products/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "product_id,product_name,brand_id,category_id,model_year,list_price")] product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.products.Add(product);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(product);
        //}

        //// GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = db.products.Where(p => p.product_id == id).ToList();

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //// POST: products/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,product_name,brand_id,category_id,model_year,list_price")] product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }



        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
