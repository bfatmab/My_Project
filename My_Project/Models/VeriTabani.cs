
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace My_Project.Models
{
    public class VeriTabani
    {
        Islem islem = new Islem();
        public string conString = ConfigurationManager.ConnectionStrings["addConnectionString"].ConnectionString;

        public IList<ViewModel> OgrenciListele()
        {
            List<ViewModel> list = new List<ViewModel>();
            string coon = ConfigurationManager.ConnectionStrings["addConnectionString"].ConnectionString;

            SqlConnection conn = new SqlConnection(coon);
            string sql = "select OgrenciBilgi.ID,Ad,Soyad,baslangicTarihi,geriOdemeBasTarihi,ogrNO,toplamTutar,krediTuru,ogrenimTuru from OgrenciBilgi  inner join Islemler on  OgrenciBilgi.ID=Islemler.ogrNO";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter sdt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdt.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                ViewModel view = new ViewModel();
                view.Id = Convert.ToInt32(item["ID"]);
                view.Ad = item["Ad"].ToString();
                view.Soyad = item["Soyad"].ToString();
                view.BaslangicTarihi = Convert.ToDateTime(item["BaslangicTarihi"]);
                view.GeriOdemeBasTarihi = Convert.ToDateTime(item["GeriOdemeBasTarihi"]);

                view.OgrNo = Convert.ToInt32(item["ogrNO"]);

                view.ToplamTutar = Convert.ToDecimal(item["toplamTutar"]);
                view.KrediTuru = item["krediTuru"].ToString();
                view.OgrenimTuru = item["ogrenimTuru"].ToString();

                list.Add(view);

            }
            return list;


        }

        public IList<Ogrenci> OgrenciBilgileriListesi()
        {

            List<Ogrenci> list = new List<Ogrenci>();
            string coon = ConfigurationManager.ConnectionStrings["addConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(coon);
            string sql = "select * from OgrenciBilgi";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter sdt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdt.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Ogrenci ogrenci = new Ogrenci();
                ogrenci.Id = Convert.ToInt32(item["ID"]);
                ogrenci.Ad = item["Ad"].ToString();
                ogrenci.Soyad = item["Soyad"].ToString();
                ogrenci.BaslangicTarihi = Convert.ToDateTime(item["BaslangicTarihi"]);
                ogrenci.GeriOdemeBasTarihi = Convert.ToDateTime(item["GeriOdemeBasTarihi"]);

                list.Add(ogrenci);
            }
            return list;
        }

        public bool OgrenciEkle(Ogrenci ogrenci)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd2 = new SqlCommand("INSERT INTO OgrenciBilgi (Ad,Soyad,BaslangicTarihi,GeriOdemeBasTarihi) values(@Ad,@Soyad,@BaslangicTarihi,@GeriOdemeBasTarihi)", connection);
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("@Ad", ogrenci.Ad);
                cmd2.Parameters.AddWithValue("@Soyad", ogrenci.Soyad);
                cmd2.Parameters.AddWithValue("@BaslangicTarihi", ogrenci.BaslangicTarihi);
                cmd2.Parameters.AddWithValue("@GeriOdemeBasTarihi", ogrenci.GeriOdemeBasTarihi);

                connection.Open();
                i = cmd2.ExecuteNonQuery();
                connection.Close();

            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Taksitlendir(Taksit taksit)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {

                connection.Open();

                string sorgu = $"INSERT INTO Taksitler(taksitNo,krediNo,taksitMiktar,odemeBilgisi,kalanBorc,tarih)values(@taksitNo,@krediNo,@taksitMiktar,@odemeBilgisi,@kalanBorc,@tarih)";
                


                for (int j = 0; j < taksit.TaksitNo; j++)
                {
                    SqlCommand cmd = new SqlCommand(sorgu, connection);

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@taksitNo", j + 1);
                    cmd.Parameters.AddWithValue("@krediNo", taksit.KrediNo);
                    var deger = taksit.ToplamTutar / taksit.TaksitNo;
                    cmd.Parameters.AddWithValue("@taksitMiktar", deger);

                    cmd.Parameters.AddWithValue("@odemeBilgisi", 0);

                    cmd.Parameters.AddWithValue("@kalanBorc", taksit.Kalanborc);
                    cmd.Parameters.AddWithValue("@tarih", taksit.Tarih.AddMonths(j * 1));

                    i = cmd.ExecuteNonQuery();


                }
                connection.Close();




                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public IList<Taksit> TaksitListele()
        {
            List<Taksit> list = new List<Taksit>();
            string coon = ConfigurationManager.ConnectionStrings["addConnectionString"].ConnectionString;

            SqlConnection conn = new SqlConnection(coon);
            string sql = "select * from Taksitler";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter sdt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdt.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                Taksit view = new Taksit();
                view.ID = Convert.ToInt32(item["ID"]);
                view.TaksitNo = Convert.ToInt32(item["taksitNo"]);
                view.KrediNo = Convert.ToInt32(item["krediNo"]);

                view.TaksitMiktar = Convert.ToDecimal(item["taksitMİktar"]);
                view.ödemeBilgisi = Convert.ToInt32(item["odemeBilgisi"]);
                view.Tarih = Convert.ToDateTime(item["tarih"]);


                list.Add(view);

            }
            return list;

        }
        public bool OgrenciIslemSecimi(int id)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "select *from Islemler where ID=@Id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", id);

            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool OgrenciSilmek(int id)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "delete from OgrenciBilgi where ID=@Id";
                SqlCommand cmd3 = new SqlCommand(sql, connection);
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.AddWithValue("@Id", id);


                connection.Open();
                i = cmd3.ExecuteNonQuery();
                connection.Close();

            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public IList<ViewModelTI> TaksitIslemDetay(int id)
        {
            List<ViewModelTI> list = new List<ViewModelTI>();
            string coon = ConfigurationManager.ConnectionStrings["addConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(coon);
            string sql = $"select i.ID ,t.krediNo, t.odemeBilgisi, sum(t.taksitMiktar) kalanBorc, count(*) odenmeyenTaksitSayi, i.ogrNO, i.anaPara, i.faizOran, i.faizMiktar, i.toplamTutar, i.krediTuru, i.ogrenimTuru from Taksitler t left outer join Islemler i on t.krediNo = i.ID where t.odemeBilgisi=0 group by i.ID ,t.krediNo, t.odemeBilgisi,t.kalanBorc, i.ogrNO, i.anaPara, i.faizOran, i.faizMiktar, i.toplamTutar, i.krediTuru, i.ogrenimTuru having i.ID={id}";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter sdt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdt.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                ViewModelTI detay = new ViewModelTI();
                detay.ID = Convert.ToInt32(item["ID"]);
                detay.KrediNo = Convert.ToInt32(item["krediNo"]);
                detay.ödemeBilgisi = Convert.ToInt32(item["odemeBilgisi"]);
                //detay.TaksitMiktar = Convert.ToDecimal(item["taksitMiktar"]);
                detay.OgrNo = Convert.ToInt32(item["ogrNO"]);
                detay.AnaPara = Convert.ToDecimal(item["anaPara"]);
                detay.FaizOran = Convert.ToDecimal(item["faizOran"]);
                detay.FaizMiktar = Convert.ToDecimal(item["faizMiktar"]);
                detay.ToplamTutar = Convert.ToDecimal(item["toplamTutar"]);
                detay.KrediTuru = item["krediTuru"].ToString();
                detay.OgrenimTuru = item["ogrenimTuru"].ToString();
                detay.Kalanborc = Convert.ToDecimal(item["kalanBorc"]);

                detay.KrediNo = Convert.ToInt32(item["krediNo"]);
                detay.OdenmeyenSayisi = Convert.ToInt32(item["odenmeyenTaksitSayi"]);





                list.Add(detay);
            }
            return list;
        }


        public IList<Islem> IslemListele(int id)
        {
            IList<Islem> views = new List<Islem>();
            using (SqlConnection conn = new SqlConnection(conString))
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
         
                cmd.CommandText = $"select *from Islemler where ogrNO={id}";

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    views.Add(new Islem
                    {
                        Id = Convert.ToInt32(item["ID"]),
                        OgrNo = Convert.ToInt32(item["ogrNO"]),
                        AnaPara = Convert.ToDecimal(item["anaPara"]),
                        FaizOran = Convert.ToDecimal(item["faizOran"]),
                        FaizMiktar = Convert.ToDecimal(item["faizMiktar"]),
                        ToplamTutar = Convert.ToDecimal(item["toplamTutar"]),
                        KrediTuru = item["krediTuru"].ToString(),
                        OgrenimTuru = item["ogrenimTuru"].ToString(),

                        //KrediNo = Convert.ToInt32(item["krediNo"]),
                        //ödemeBilgisi = Convert.ToInt32(item["odemeBilgisi"]),



                    });
                }
                conn.Close();

            }
            return views;

        }
        public IList<ViewModelTI> ListeleIki()
        {
            IList<ViewModelTI> views = new List<ViewModelTI>();
            using (SqlConnection conn = new SqlConnection(conString))
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                
                cmd.CommandText = $"select *from Islemler, inner join Taksilert t on i.ID=t.krediNo ";

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    views.Add(new ViewModelTI
                    {
                        Id = Convert.ToInt32(item["ID"]),
                        OgrNo = Convert.ToInt32(item["ogrNO"]),
                        AnaPara = Convert.ToDecimal(item["anaPara"]),
                        FaizOran = Convert.ToDecimal(item["faizOran"]),
                        FaizMiktar = Convert.ToDecimal(item["faizMiktar"]),
                        ToplamTutar = Convert.ToDecimal(item["toplamTutar"]),
                        KrediTuru = item["krediTuru"].ToString(),
                        OgrenimTuru = item["ogrenimTuru"].ToString(),

                        //KrediNo = Convert.ToInt32(item["krediNo"]),
                        //ödemeBilgisi = Convert.ToInt32(item["odemeBilgisi"]),



                    });
                }
                conn.Close();

            }
            return views;

        }
        public bool IslemSil(int id)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "delete from Islemler where ID=@Id";
                SqlCommand cmd3 = new SqlCommand(sql, connection);
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.AddWithValue("@Id", id);


                connection.Open();
                i = cmd3.ExecuteNonQuery();
                connection.Close();

            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IslemEkle(Islem islem)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd2 = new SqlCommand("INSERT INTO Islemler (ogrNO,anaPara,faizOran,faizMiktar,toplamTutar,krediTuru,ogrenimTuru) values(@ogrNO,@anaPara,@faizOran,@faizMiktar,@toplamTutar,@krediTuru,@ogrenimTuru)", connection);
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@ogrNO", islem.OgrNo);
                cmd2.Parameters.AddWithValue("@anaPara", islem.AnaPara);
                cmd2.Parameters.AddWithValue("@faizOran", islem.FaizOran);
                var miktar = (islem.AnaPara * islem.FaizOran) / 100;

                cmd2.Parameters.AddWithValue("@faizMiktar", miktar);
                var toplam = (islem.AnaPara + miktar);
                cmd2.Parameters.AddWithValue("@toplamTutar", toplam);

                cmd2.Parameters.AddWithValue("@krediTuru", islem.KrediTuru);
                cmd2.Parameters.AddWithValue("@ogrenimTuru", islem.OgrenimTuru);

                connection.Open();
                i = cmd2.ExecuteNonQuery();
                connection.Close();

            }

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TaksitEdit(ViewModelTI view)
        {
            int i = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sorgu = @"UPDATE Taksitler SET odemeBilgisi=@odemeBilgisi,krediNo=@krediNo where ID=@ID";
                SqlCommand cmd = new SqlCommand(sorgu, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@ID", view.ID);
                cmd.Parameters.AddWithValue("@taksitNo", view.TaksitNo);
                cmd.Parameters.AddWithValue("@krediNo", view.KrediNo);
                cmd.Parameters.AddWithValue("@odemeBilgisi", view.ödemeBilgisi);
                cmd.Parameters.AddWithValue("@kalanBorc", view.Kalanborc);
                cmd.Parameters.AddWithValue("@tarih", view.Tarih);


                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public bool Yapilandir(Islem islem)
        {
            int i = 0;

            using (SqlConnection conn = new SqlConnection(conString))
            {
                string sorgu = @"update Islemler set anaPara=@anaPara, faizOran=@faizOran,faizMiktar=@faizMiktar,toplamTutar=@toplamTutar,krediTuru=@krediTuru,@ogrenimTuru=@ogrenimTuru where ogrNO=@ogrNO";
                SqlCommand cmd = new SqlCommand(sorgu, conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", islem.Id);
                cmd.Parameters.AddWithValue("@ogrNO", islem.OgrNo);
                cmd.Parameters.AddWithValue("@anaPara", islem.AnaPara);
                cmd.Parameters.AddWithValue("@faizOran", islem.FaizOran);
                var miktar = (islem.AnaPara * islem.FaizOran) / 100;

                cmd.Parameters.AddWithValue("@faizMiktar", miktar);
                var toplam = (islem.AnaPara + miktar);
                cmd.Parameters.AddWithValue("@toplamTutar", toplam);

                cmd.Parameters.AddWithValue("@krediTuru", islem.KrediTuru);
                cmd.Parameters.AddWithValue("@ogrenimTuru", islem.OgrenimTuru);
                conn.Open();
                i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public IList<Taksit> TaksitListele(int id)
        {
            IList<Taksit> taksits = new List<Taksit>();
            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"select * from Taksitler where ID={id}";

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);

                foreach (DataRow item in dt.Rows)
                {
                    taksits.Add(new Taksit
                    {
                        ID = Convert.ToInt32(item["ID"]),
                        TaksitNo = Convert.ToInt32(item["taksitNo"]),
                        KrediNo = Convert.ToInt32(item["krediNo"]),

                        TaksitMiktar = Convert.ToDecimal(item["taksitMiktar"]),
                        ödemeBilgisi = Convert.ToInt32(item["odemeBilgisi"]),
                        Tarih = Convert.ToDateTime(item["tarih"])


                    });
                }
                conn.Close();

            }
            return taksits;

        }


    }
}
