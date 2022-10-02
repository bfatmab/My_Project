using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace My_Project.Models
{
    public class ViewModel
    {

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [DisplayName("Başlangıç Tarihi")]
        public DateTime BaslangicTarihi { get; set; }
        [DisplayName("Geri Ödeme Başlangıç Tarihi")]
        public DateTime GeriOdemeBasTarihi { get; set; }


        [DisplayName("Ogrenci No")]
        public int OgrNo { get; set; }
        [DisplayName("Toplam Tutar")]
        public decimal AnaPara { get; set; }
        [DisplayName("Faiz Oranı")]
        public decimal FaizOran { get; set; }
        [DisplayName("Faiz Miktarı")]
        public decimal FaizMiktar { get; set; }
        [DisplayName("Toplam Tutar")]
   
        public decimal ToplamTutar { get; set; }
      
        [DisplayName("Kredi Turu")]
        public string KrediTuru { get; set; }
        [DisplayName("Öğrenim Türü")]
        public string OgrenimTuru { get; set; }


    }
}
