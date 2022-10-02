using System.ComponentModel;

namespace My_Project.Models
{
    public class Islem
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
    
        [DisplayName("Kredi Turu")]
        public string KrediTuru { get; set; }
        [DisplayName("Öğrenim Türü")]
        public string OgrenimTuru { get; set; }

        Taksit taksit = new Taksit();
           
        
    }
}
