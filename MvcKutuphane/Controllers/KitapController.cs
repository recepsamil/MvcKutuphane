using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
	[Authorize]	
	public class KitapController : Controller
	{
		// GET: Kitap
		DBKUTUPHANEEntities2 db = new DBKUTUPHANEEntities2();
		public ActionResult Index(string p)
		{
			var kitaplar = from ktp in  db.TBLKITAP select ktp;
			if (!string.IsNullOrEmpty(p))
			{
				kitaplar = kitaplar.Where(k => k.AD.Contains(p));
			}

			return View(kitaplar.ToList());
		}

		[HttpGet]
		public ActionResult KitapEkle()
		{
			List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
													 select new SelectListItem
													 {
														 Text = i.AD,
														 Value = i.ID.ToString()
													 }).ToList();
			ViewBag.dgr1 = deger1;


			List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
													 select new SelectListItem
													 {
														 Text = i.AD + ' ' + i.SOYAD,
														 Value = i.ID.ToString()
													 }).ToList();
			ViewBag.dgr2 = deger2;
			return View();
		}

		[HttpPost]
		public ActionResult KitapEkle(TBLKITAP p)
		{
			var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
			var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
			p.TBLKATEGORI = ktg;
			p.TBLYAZAR = yzr;
			db.TBLKITAP.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult KitapSil(int id)
		{
			var kitap = db.TBLKITAP.Find(id);
			db.TBLKITAP.Remove(kitap);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult KitapGetir(int id)
		{
			var ktp = db.TBLKITAP.Find(id);
			List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
													 select new SelectListItem
													 {
														 Text = i.AD,
														 Value = i.ID.ToString()
													 }).ToList();
			ViewBag.dgr1 = deger1;

			List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
													 select new SelectListItem
													 {
														 Text = i.AD + ' ' + i.SOYAD,
														 Value = i.ID.ToString()
													 }).ToList();
			ViewBag.dgr2 = deger2;

			return View("KitapGetir", ktp);
		}

		public ActionResult KitapGuncelle(TBLKITAP p)
		{
			var kitap = db.TBLKITAP.Find(p.ID);
			kitap.AD = p.AD;
			kitap.BASIMYIL = p.BASIMYIL;
			kitap.SAYFA = p.SAYFA;
			kitap.YAYINEVİ = p.YAYINEVİ;
			kitap.DURUM = true;
			var ktg = db.TBLKATEGORI.Where(ktp => ktp.ID == p.TBLKATEGORI.ID).FirstOrDefault();
			var yzr = db.TBLYAZAR.Where(y => y.ID == p.TBLYAZAR.ID).FirstOrDefault();
			kitap.KATEGORİ =ktg.ID;
			kitap.YAZAR = yzr.ID;
			db.SaveChanges();
			return RedirectToAction("Index");
		}














	}
}