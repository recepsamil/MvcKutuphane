using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models;
namespace MvcKutuphane.Controllers
{
   public class GrafikController : Controller
   {
      // GET: Grafik
      public ActionResult Index()
      {
         return View();
      }

      public ActionResult KitapResult()
      {
         return Json(liste());
      }

      public List<Grafik> liste()
      {
         List<Grafik> cs = new List<Grafik>();
         cs.Add(new Grafik()
         {
            yayinevi = "Yapı Kredi",
            sayi = 8
         });
         cs.Add(new Grafik()
         {
            yayinevi = "Can",
            sayi = 6
         });
         cs.Add(new Grafik()
         {
            yayinevi = "Kültür",
            sayi = 2
         });
         return cs;
      }

   }
}