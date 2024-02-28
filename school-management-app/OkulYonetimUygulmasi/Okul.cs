using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulmasi
{
    internal class Okul
    {
        public List<Ogrenci> Ogrenciler = new List<Ogrenci>();

        public void OgrenciEkle(int no, string ad, string soyad, DateTime dogumTarihi, Ogrenci.CINSIYET cinsiyet, Ogrenci.SUBE sube)
        {
            Ogrenci o = new Ogrenci();
            o.Ad = ad;
            o.No = no;
            o.Soyad = soyad;
            o.DogumTarihi = dogumTarihi;
            o.Cinsiyet = cinsiyet;
            o.Sube = sube;
        
            this.Ogrenciler.Add(o);
        }
        public void Guncelle(int no, string isim, string soyisim, DateTime dogumTarihi, Ogrenci.CINSIYET cinsiyet, Ogrenci.SUBE sube)
        {
            Ogrenci ogrenci = Ogrenciler.Where<Ogrenci>((a => a.No == no)).FirstOrDefault<Ogrenci>();
            if (ogrenci == null)
                return;
            if (isim != null)
                ogrenci.Ad = isim;
            if (soyisim!=null)
                ogrenci.Soyad = soyisim;
            if (dogumTarihi != DateTime.MinValue)
                ogrenci.DogumTarihi = dogumTarihi;
            if (cinsiyet != 0)
                ogrenci.Cinsiyet = cinsiyet;
            if (sube != 0)
                ogrenci.Sube = sube;
        }        
        public void NotEkle(int no, string ders,int not )
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o!=null)
            {
                o.Notlar.Add(new DersNotu(ders, not));
            }
        }
        public void AdresEkle(int no, string il, string ilce) => this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>()?.AdresEkle(il, ilce);

        public void KitapEkle(int no,string kitapadi)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            if (o != null)
            {
                o.Kitaplar.Add(kitapadi);
            }
        }
        
        public void TumOgrenciListe()
        {
            if (Ogrenciler.Count==0)
            {
                Console.WriteLine("Listelenecek ögrenci yok.");
            }
            else
            {
                foreach (Ogrenci item in Ogrenciler)
                {
                    
                    Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + (item.Ad + " " + item.Soyad).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.KitapSayisi);
                }
            }
        }
        public void Listele(List<Ogrenci> liste)
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Listelenecek ögrenci yok.");
            }
            else
            {
                Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı " + "Soyadı".PadRight(21) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.");
                Console.WriteLine("-------------------------------------------------------------------------------");
                foreach (Ogrenci ogrenci in liste)
                    Console.WriteLine(ogrenci.Sube.ToString().PadRight(10) + ogrenci.No.ToString().PadRight(10) + (ogrenci.Ad + " " + ogrenci.Soyad).PadRight(25) + ogrenci.Ortalama.ToString().PadRight(15) + ogrenci.KitapSayisi.ToString());
            }
        }
        public void Illistele(List<Ogrenci> liste)
        {
            if (liste.Count == 0)
            {
                Console.WriteLine("Listelenecek ögrenci yok.");
            }
            else
            {
                Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı " + "Soyadı".PadRight(21) + "Sehir".PadRight(15) + "Semt");
                Console.WriteLine("-------------------------------------------------------------------------------");
                foreach (Ogrenci ogrenci in liste)
                    Console.WriteLine(ogrenci.Sube.ToString().PadRight(10) + ogrenci.No.ToString().PadRight(10) + (ogrenci.Ad + " " + ogrenci.Soyad).PadRight(25) + ogrenci.Adresi.Il.ToString().PadRight(15) + ogrenci.Adresi.Ilce.ToString());
            }
        }
        public bool OgrenciVarMi(int no) => this.Ogrenciler.Where<Ogrenci>((Func<Ogrenci, bool>)(a => a.No == no)).FirstOrDefault<Ogrenci>() != null;
        public string AdSoyAdGetir(int no)
        {
            Ogrenci ogr = Ogrenciler.Where<Ogrenci>(a => a.No == no).FirstOrDefault<Ogrenci>();
            string o = "";
            if (ogr!=null)
            {
                o = ogr.Ad + " " + ogr.Soyad;
            }
            return o;
        }
        public Ogrenci.SUBE Subele(int no)
        {
            Ogrenci ogr = Ogrenciler.Where(a => a.No == no).FirstOrDefault();
            return ogr != null ? ogr.Sube : Ogrenci.SUBE.A;
        }
        public void NotlariGoruntule(List<DersNotu> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Öğrenciye ait bir not bulunmamaktadır");
            }
            else
            {
                Console.WriteLine("Dersin Adi".PadRight(15) + "Notu");
                Console.WriteLine("-------------------------------------------------------------------------------");
                foreach (DersNotu not in list)
                    Console.WriteLine(not.DersAdi.ToString().PadRight(15) + not.Not.ToString());
            }
        }
        public void KitaplariListele(List<string> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Öğrenciye ait bir kitap bulunmamaktadır");
            }
            else
            {
                Console.WriteLine("Okudugu Kitaplar".PadRight(15));
                Console.WriteLine("-------------------------------------------------------------------------------");
                int sayac = 0;
                foreach (var kitap in list)
                {
                    sayac++;
                    Console.WriteLine(sayac+"-"+kitap);
                }
            }
        }
        public void SonKitapGor(List<string> list)
        {
            
            if (list.Count == 0)
            {
                Console.WriteLine("Öğrenciye ait bir kitap bulunmamaktadır");
            }
            else
            {
                Console.WriteLine("Son Okuduğu Kitap".PadRight(15));
                Console.WriteLine("-------------------------------------------------------------------------------");
                int sayac = 0;
                foreach (var kitap in list)
                {
                    sayac++;
                    Console.WriteLine("-"+kitap);
                }
            }
        }
        public List<string> SonKitapGetir(int no)
        {
            Ogrenci ogr = Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            List<string> liste = ogr.Kitaplar.ToList();
            liste.Reverse();
            return liste.Take(1).ToList();
        }
        public float OrtalamaGoster(int no)
        {
            Ogrenci ogr = Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            return ogr.Ortalama;
        }
    }    
}
