using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using obenimdeoyuncagimvc.Models.Entity;
using obenimdeoyuncagimvc.Controllers;

namespace obenimdeoyuncagimvc.Controllers
{
    public class emanetverController : Controller
    {
        // GET: emanetver
        mvc_oyuncakEntities db = new mvc_oyuncakEntities();
        public ActionResult Index()
        {
            var emanetler = db.emanetoyuncaklar.ToList();
            return View(emanetler);
        }
        //public actionresult emanetver(string barkodno)
        //{

        //    var sepetdbınstance = db.sepet.where(b => b.barkodno == barkodno).firstordefault();


        //    emanetoyuncaklar x = new emanetoyuncaklar();
        //    x.tc = emanetoyuncaklardbınstance.tc;
        //    x.adsoyad = emanetoyuncaklardbınstance.adsoyad;
        //    x.yas = emanetoyuncaklardbınstance.yas;
        //    x.barkodno = emanetoyuncaklardbınstance.barkodno;
        //    x.oyuncakadi = emanetoyuncaklardbınstance.oyuncakadi;
        //    x.ureticifirma = emanetoyuncaklardbınstance.ureticifirma;
        //    x.oyuncakboyutu = emanetoyuncaklardbınstance.oyuncakboyutu;
        //    x.oyuncakyasgrubu = emanetoyuncaklardbınstance.oyuncakyasgrubu;
        //    x.oyuncaksayisi = emanetoyuncaklardbınstance.oyuncaksayisi;

        //    x.teslimtarihi = "28.11.2022";
        //    x.iadetarihi = "28.11.2022";

        //    db.emanetoyuncaklar.add(x);
        //    db.savechanges();
        //    return view("ındex");
        //}
        [HttpPost]
        public ActionResult sil(string tc)
        {
            var emanetoyuncaklar = db.emanetoyuncaklar.Find(tc);
            db.emanetoyuncaklar.Remove(emanetoyuncaklar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}