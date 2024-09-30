using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;


namespace MvcKutuphane.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        DBKUTUPHANEEntities2 db = new DBKUTUPHANEEntities2();
        public ActionResult Index()
        {
			var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
			return View(degerler);
		}
    }
}