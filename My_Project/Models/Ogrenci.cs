using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace My_Project.Models
{
    public class Ogrenci
    {

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [DisplayName("Başlangıç Tarihi")]
        public DateTime BaslangicTarihi { get; set; }
        [DisplayName("Geri Ödeme Başlangıç Tarihi")]
        public DateTime GeriOdemeBasTarihi { get; set; }

      


        public Islem Islem { get; set; } = new Islem();

        

    }
}
