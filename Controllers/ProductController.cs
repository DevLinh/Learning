using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            QuanLySanPhamDataContext context = new QuanLySanPhamDataContext();
            List<Product> dsProduct = null;
            if (Request.QueryString.Count == 0)
            {
                dsProduct = context.Products.ToList();
            }
            else
            {
                double min = double.Parse(Request.QueryString["txtMin"]);
                double max = double.Parse(Request.QueryString["txtMax"]);
                dsProduct = context.Products.Where(x => x.UnitPrice >= min && x.UnitPrice <= max).ToList();
            }
            return View(dsProduct);
        }

        public ActionResult Details(int id)
        {
            QuanLySanPhamDataContext context = new QuanLySanPhamDataContext();
            Product p = context.Products.FirstOrDefault(x => x.Id == id);
            return View(p);
        }

        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                QuanLySanPhamDataContext context = new QuanLySanPhamDataContext();
                string productCode = Request.Form["ProductCode"];
                string catalogId = Request.Form["CatalogId"];
                string unitPrice = Request.Form["UnitPrice"];
                string productName = Request.Form["ProductName"];

                Product product = new Product();
                product.ProductCode = productCode;
                product.CatalogId = int.Parse(catalogId);
                product.UnitPrice = double.Parse(unitPrice);
                product.ProductName = productName;
                HttpPostedFileBase file = Request.Files["Picture"];
                if (file != null)
                {
                    string serverPath = HttpContext.Server.MapPath("~/Images");
                    string filePath = serverPath + "/" + file.FileName;
                    file.SaveAs(filePath);
                    product.Picture = file.FileName;
                }


                context.Products.InsertOnSubmit(product);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    
}