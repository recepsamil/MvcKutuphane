﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;
namespace MvcKutuphane.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		// GET: Login
		DBKUTUPHANEEntities2 db = new DBKUTUPHANEEntities2();
		[HttpGet]
		public ActionResult GirisYap()
		{
			return View();
		}

		[HttpPost]
		public ActionResult GirisYap(TBLUYELER p)
		{
			var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
			if (bilgiler != null)
			{
				FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
				Session["Mail"]=bilgiler.MAIL.ToString();
				//TempData["ID"] = bilgiler.ID.ToString();
				//TempData["Ad"] = bilgiler.AD.ToString();
				//TempData["Soyad"] = bilgiler.SOYAD.ToString();
				//TempData["KullaniciAdi"] = bilgiler.KULLANICIADI.ToString();
				//TempData["Sifre"] = bilgiler.SIFRE.ToString();
				//TempData["OKUL"] = bilgiler.OKUL.ToString();
				return RedirectToAction("Index", "Panelim");
			}
			else
			{
				return View();
			}
		
		}

	}
}