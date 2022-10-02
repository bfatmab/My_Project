using System;
using System.ComponentModel;

namespace My_Project.Models
{
    public class Taksit
    {

        public int ID { get; set; }

        [DisplayName("Taksit No")]
        public int TaksitNo { get; set; }

        [DisplayName("Kredi NO")]
        public int KrediNo { get; set; }

        [DisplayName("Kalan Borç ")]
        public decimal Kalanborc { get; set; }
        [DisplayName("Taksit Miktarı")]
        public decimal TaksitMiktar { get; set; }

        [DisplayName("Ödeme Bilgisi")]
        public int ödemeBilgisi { get; set; }
        [DisplayName("Toplam Tutar")]
        public decimal ToplamTutar { get; set; }


        [DisplayName("Taksit Tarihi")]
        public DateTime Tarih { get; set; }

    }
}
