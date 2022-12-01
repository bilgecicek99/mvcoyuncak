using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using obenimdeoyuncagimvc.Models.Entity;


namespace obenimdeoyuncagimvc.Controllers
{
    public class oyuncakController : Controller
    {
        // GET: oyuncak
        mvc_oyuncakEntities db = new mvc_oyuncakEntities();
        public ActionResult Index()
        {
            var degerler = db.oyuncak.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult yenioyuncak()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult yenioyuncak(oyuncak p1)
        {

            var count = db.oyuncak.Count(u => u.barkodno == p1.barkodno);
            if (count > 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Böyle bir Kayıt var.');</script>");

            }
            else
            {
                db.oyuncak.Add(p1);
                db.SaveChanges();
            }

            return RedirectToAction("Index");


        }
        [HttpPost]
        public ActionResult sil(string barkodno)
        {
            var oyuncak = db.oyuncak.Find(barkodno);
            db.oyuncak.Remove(oyuncak);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    /*    public ActionResult emanetver(string barkodno)
        {
            var oyuncak = db.emanetoyuncaklar.Add(barkodno);

            //db.oyuncak.Remove(oyuncak);baro
           // db.SaveChanges();
            return RedirectToAction("Index");
        }*/

        public ActionResult oyuncakgetir(string barkodno)
        {
            var oyuncak = db.oyuncak.Find(barkodno);
            return View("oyuncakgetir", oyuncak);
        }
        public ActionResult guncelle(oyuncak p1)
        {
            var oyuncak = db.oyuncak.Find(p1.barkodno);
            oyuncak.barkodno = p1.barkodno;
            oyuncak.oyuncakadi = p1.oyuncakadi;
            oyuncak.oyuncakboyutu = p1.oyuncakboyutu;
            oyuncak.oyuncakyasgrubu = p1.oyuncakyasgrubu;
            oyuncak.ureticifirma = p1.ureticifirma;
            oyuncak.oyuncakturu = p1.oyuncakturu;
            oyuncak.stoksayisi = p1.stoksayisi;
            oyuncak.rafno =p1.rafno;
            oyuncak.kayıttarihi=p1.kayıttarihi;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}