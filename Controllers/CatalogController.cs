using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Learning.Models;

namespace Learning.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        public ActionResult Index()
        {
            QuanLySanPhamDataContext context = new QuanLySanPhamDataContext();
            List<Catalog> dsCatalog = context.Catalogs.ToList();
            return View(dsCatalog);
        }
        public ActionResult SanPhams(int catalogId)
        {
            QuanLySanPhamDataContext context = new QuanLySanPhamDataContext();
            List<Product> dsProducts = context.Products.Where(x => x.CatalogId == catalogId).ToList();
            return View(dsProducts);
        }
        public ActionResult Create()
        {
            if(Request.Form.Count > 0)
            {
                string catalogCode = Request.Form["CatalogCode"];
                string catalogName = Request.Form["CatalogName"];

                QuanLySanPhamDataContext context = new QuanLySanPhamDataContext();

                Catalog catalog = new Catalog();
                catalog.CatalogCode = catalogCode;
                catalog.CatalogName = catalogName;
                context.Catalogs.InsertOnSubmit(catalog);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}