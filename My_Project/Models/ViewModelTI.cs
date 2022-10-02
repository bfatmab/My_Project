using System;
using System.ComponentModel;

namespace My_Project.Models
{
    public class ViewModelTI
    {

        public int Id { get; set; }
        [DisplayName("Ogrenci No")]
        public int OgrNo { get; set; }
        [DisplayName("Ana Para")]
        public decimal AnaPara { get; set; }
        [DisplayName("Faiz Oranı")]
        public decimal FaizOran { get; set; }
        [DisplayName("Faiz Miktarı")]
        public decimal FaizMiktar { get; set; }
        [DisplayName("Toplam Tutar")]
        public decimal ToplamTutar { get; set; }
        [DisplayName("Kalan Borç ")]
        public decimal Kalanborc { get; set; }
        [DisplayName("Kredi Turu")]
        public string KrediTuru { get; set; }
        [DisplayName("Öğrenim Türü")]
        public string OgrenimTuru { get; set; }

        [DisplayName("Ödenmeyen Taksit Sayısı")]
        public int OdenmeyenSayisi { get; set; }


        public int ID { get; set; }
        [DisplayName("Taksit Sayısı")]
        public int TaksitNo { get; set; }
        [DisplayName("Kredi Numarası")]
        public int KrediNo { get; set; }
        [DisplayName("Taksit Miktarı")]
        public decimal TaksitMiktar { get; set; }
        [DisplayName("Ödeme Bilgisi")]
        public int ödemeBilgisi { get; set; }

        [DisplayName("Tarih")]
        public DateTime Tarih { get; set; }





    }
}
