using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using obenimdeoyuncagimvc.Models.Entity;

namespace obenimdeoyuncagimvc.Controllers
{
    public class sepetController : Controller
    {
        // GET: uye

        mvc_oyuncakEntities db = new mvc_oyuncakEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var degerler = db.sepet.ToList();
            return View(degerler);

        }
        
        //[Route("/sepet/SepeteEkle/{barkodno}")]
        public ActionResult SepeteEkle(String barkodno)
        {

            var sepetDbInstance =  db.oyuncak.Find(barkodno);

            sepet x = new sepet();
            x.barkodno = sepetDbInstance.barkodno;
            x.oyuncakadi = sepetDbInstance.oyuncakadi;
            x.ureticifirma = sepetDbInstance.ureticifirma;
            x.oyuncakboyutu = sepetDbInstance.oyuncakboyutu;
            x.oyuncakyasgrubu = sepetDbInstance.oyuncakyasgrubu;
            x.teslimtarihi = "28.11.2022";
            x.iadetarihi = "28.11.2022";

            db.sepet.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult temizle(string barkodno)
        {
            var sepet = db.sepet.Find(barkodno);
            db.sepet.Remove(sepet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult uyebilgiekle(FormCollection form)
        {
            System.Diagnostics.Debug.WriteLine(form["barkodno"]+"1215156156");
            var DbInstanceuye = db.uye.Find(form["tc"]);
           
            var DbIntancesepet = db.sepet.Find(form["barkodno"]);
            uye x = new uye();
            sepet y = new sepet();  
            x.tc = DbInstanceuye.tc;
            x.adsoyad = DbInstanceuye.adsoyad;
            x.yas= DbInstanceuye.cinsiyet;
            x.cinsiyet = DbInstanceuye.cinsiyet;
            x.telefon = DbInstanceuye.telefon;
            y.barkodno = form["barkodno"];
            y.oyuncakadi = DbIntancesepet.oyuncakadi;

            y.ureticifirma = DbIntancesepet.ureticifirma;
            y.oyuncakboyutu = DbIntancesepet.oyuncakboyutu;
            y.oyuncakyasgrubu = DbIntancesepet.oyuncakyasgrubu;
            y.oyuncaksayisi = DbIntancesepet.oyuncaksayisi;
            y.teslimtarihi = "28.11.2022";
            y.iadetarihi = "28.11.2022";
            emanetoyuncaklar eo = new emanetoyuncaklar();
            eo.tc = x.tc;
            eo.adsoyad = x.adsoyad;
            eo.yas = x.yas;
            eo.telefon = x.telefon;
            eo.barkodno = form["barkodno"];
            eo.oyuncakadi = y.oyuncakadi;
            eo.ureticifirma = y.ureticifirma;
            eo.oyuncakboyutu = y.oyuncakboyutu;
            eo.oyuncakyasgrubu = y.oyuncakyasgrubu;
            eo.oyuncaksayisi = y.oyuncaksayisi;
            eo.teslimtarihi = y.teslimtarihi;
            eo.iadetarihi = y.iadetarihi;

            db.emanetoyuncaklar.Add(eo);
           
            db.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}