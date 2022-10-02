using Microsoft.AspNetCore.Mvc;
using My_Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace My_Project.Controllers
{

    public class HomeController : Controller
    {

        VeriTabani veri = new VeriTabani();
        ViewModel viewModel = new ViewModel();

        public IActionResult Listele()
        {
            var ogrencis = veri.OgrenciListele();

            return View(ogrencis);
        }
        public IActionResult OgrenciBilgileriListesi()
        {
            var ogrencis = veri.OgrenciBilgileriListesi();
            return View(ogrencis);

        }
        public IActionResult TaksitListele()
        {
            var taksits=veri.TaksitListele( );
            return View(taksits);
        }
        public IActionResult OgrenciEkle()
        {

            return View();
        }
        [HttpPost]
        public IActionResult OgrenciEkle(Ogrenci ogrenci)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VeriTabani veri2 = new VeriTabani();

                    if (veri2.OgrenciEkle(ogrenci))
                    {
                        ViewBag.Message = "Yeni kayıt başarıyla gerçekleşti";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
        public IActionResult IslemEkle(int id)
        {
            var islem = new Islem()
            {
                OgrNo = id
            };
            return View(islem);
        }

        [HttpPost]
        public IActionResult IslemEkle(Islem islem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VeriTabani veri3 = new VeriTabani();
                    Islem data = new Islem();
                    //data.OgrenimTuru=deneme

                    if (veri3.IslemEkle(islem))
                    {
                        ViewBag.Message = "Ekleme işlemi başarıyla gerçekleşti";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }

        }
        public IActionResult Taksitlendir(int id)
        {
            
            var taksit = new Taksit()
            {
                KrediNo = id
                
               
             };
            return View(taksit);


        }

        [HttpPost]
        public IActionResult Taksitlendir(Taksit taksit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    VeriTabani veri3 = new VeriTabani();
               
                    

                    if (veri3.Taksitlendir(taksit))
                    {
                        ViewBag.Message = "Ekleme işlemi başarıyla gerçekleşti";
                    }
                }

                return View();
            }
            catch 
            {

                return View();
            }


        }

        public IActionResult OgrenciIslemSecimi(int id)
        {
            VeriTabani veri = new VeriTabani();
            try
            {
                if (veri.OgrenciIslemSecimi(id))
                {
                    ViewBag.AlertMsg = "Öğrenci işlemi seçim  işlemi başarı ile gerçekleşti";
                }
                return RedirectToAction("IslemListele");
            }
            catch
            {

                return View();
            }
        }
        public IActionResult OgrenciSil(int id)
        {
            try
            {
                VeriTabani veri = new VeriTabani();
                if (veri.OgrenciSilmek(id))
                {
                    ViewBag.AlertMsg = "Silme işlemi başarı ile gerçekleşti";
                }
                //yönlendirme methodu
                return RedirectToAction("Listele");
            }
            catch
            {

                return View();
            }
        }
        public IActionResult IslemSil(int id)
        {
            try
            {
                if (veri.IslemSil(id))
                {
                    ViewBag.AlertMsg = "Silme işlemi başarı ile gerçekleşti";
                }
                return RedirectToAction("IslemListele");

            }
            catch
            {

                return View();
            }

        }
        
        public ActionResult Yapilandir(int id ,Islem islemss)
        {
            //var islems = veri.OgrenciListele().FirstOrDefault(x => x.OgrNo == id)
            //return View(islems);

            VeriTabani veri = new VeriTabani();
            var islem = veri.IslemListele(islemss.Id).FirstOrDefault(x => x.OgrNo == id);
            return View(islem);

        }
        [HttpPost]
        public ActionResult Yapilandir(Islem islem)
        {
            try
            {

                veri.Yapilandir(islem);
                return RedirectToAction("Listele");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult TaksitEdit(int id,Taksit taksits)
        {
            VeriTabani veri = new VeriTabani();
            var taksit = veri.TaksitListele(taksits.ID).FirstOrDefault(x => x.ID == id);
            return View(taksit);

        }
        [HttpPost]
        public ActionResult TaksitEdit(ViewModelTI taksit)
        {
            try
            {
                veri.TaksitEdit(taksit);
                return RedirectToAction("TaksitListele");
            }
            catch 
            {

                return View();
            }
        }
        public IActionResult IslemListele(int id)
        {

            var views = veri.IslemListele(id);

            return View(views);
        }
        public IActionResult TaksitIslemDetay(int id)
        {
            var views = veri.TaksitIslemDetay(id);
            return View(views.ToList());
           
        }


    }
}
