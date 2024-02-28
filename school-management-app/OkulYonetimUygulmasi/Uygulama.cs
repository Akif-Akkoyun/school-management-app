using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulmasi
{
    internal class Uygulama
    {
        private static Okul OKUL = new Okul();
        private int sayac = 0;

        public void Calistir()
        {
            SahteVeriGir();
            Menu();
            while (true)
            {
            label_121:
                string secim = SecimAl();
                if (secim == "1")
                {
                    TumOgrencileriListele();
                }
                else if (secim == "2")
                {
                    SubeyeGoreListele();
                }
                else if (secim == "3")
                {
                    CinsiyeteGoreListele();
                }
                else if (secim == "4")
                {
                    TariheGöreListele();
                }
                else if (secim == "5")
                {
                    IllereGoreListe();
                }
                else if (secim == "6")
                {
                    OgrencininTumNotlariniListele();
                }
                else if (secim == "7")
                {
                    OgrencininOkuduguKitaplariListele();
                }
                else if (secim == "8")
                {
                    EnBasriliBes();
                }
                else if (secim == "9")
                {
                    EnBasarisizUc();
                }
                else if (secim == "10")
                {
                    SubedekiEnBasariliBes();
                }
                else if (secim == "11")
                {
                    SubedekiEnBasarisizUc();
                }
                else if (secim == "12")
                {
                    OgrencininOrtalamasiniGör();
                }
                else if (secim == "13")
                {
                    SubeninOrtalamasiniGör();
                }
                else if (secim == "14")
                {
                    SonOkuduguKitabiGor();
                }
                else if (secim == "15")
                {
                    OgrenciEkle();
                }
                else if (secim == "16")
                {
                    OgrenciGuncelle();
                }
                else if (secim == "17")
                {
                    OgrenciSil();
                }
                else if (secim == "18")
                {
                    OgrenciAdresGir();
                }
                else if (secim == "19")
                {
                    OkunanKitapGir();
                }
                else if (secim == "20")
                {
                    NotGir();
                }
                else if (secim == "ÇIKIŞ")
                {
                    Cikis();
                }
                else if (secim == "LİSTE")
                {
                    Console.WriteLine();
                    Menu();
                    Console.WriteLine();
                    goto label_121;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                    ++sayac;
                }
                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için 'liste' çıkış yapmak için 'çıkış' yazın.");
            }
        }
        public string SecimAl()
        {
            if (sayac != 10)
            {
                Console.WriteLine();
                Console.Write("Yapmak istediginiz islemi seçiniz: ");
                return Console.ReadLine().ToUpper();
            }
            Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
            return "ÇIKIŞ";
        }
        public void Cikis() => Environment.Exit(0);
        public void TumOgrencileriListele()
        {
            Console.WriteLine("1-Bütün Ögrencileri Listele --------------------------------------------------");

            Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı".PadRight(5) + "Soyadı".PadRight(20) + "Not Ort.".PadRight(15) + "Okuduğu Kitap Say.".PadRight(10));
            Console.WriteLine("-------------------------------------------------------------------------------");

            OKUL.TumOgrenciListe();
        }

        public void SubeyeGoreListele()
        {
            Console.WriteLine("2-Şubeye Göre Öğrencileri Listele --------------------------------------------");
            Console.WriteLine();
            if (Uygulama.OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
            }
            else
            {
                Ogrenci.SUBE secim = Arayıcı.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                List<Ogrenci> yeniliste = OKUL.Ogrenciler.Where<Ogrenci>(a => a.Sube == secim).ToList<Ogrenci>();
                Console.WriteLine();
                OKUL.Listele(yeniliste);
            }
        }
        public void CinsiyeteGoreListele()
        {
            Console.WriteLine("3-Cinsiyete Göre Öğrencileri Listele -----------------------------------------");
            Console.WriteLine();
            if (Uygulama.OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
            }
            else
            {
                Ogrenci.CINSIYET secim = Arayıcı.CinsiyetAl("Listelemek istediğiniz cinsiyeti girin (K/E): ");
                List<Ogrenci> yeniliste = OKUL.Ogrenciler.Where<Ogrenci>(a => a.Cinsiyet == secim).ToList<Ogrenci>();
                Console.WriteLine();
                OKUL.Listele(yeniliste);
            }
        }
        public void TariheGöreListele()
        {
            Console.WriteLine("4-Dogum Tarihine Göre Ögrencileri Listele ------------------------------------");
            Console.WriteLine();
            if (Uygulama.OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
            }
            else
            {
                DateTime tarih = Arayıcı.TarihAl("Hangi tarihten sonraki ögrencileri listelemek istersiniz: ");
                List<Ogrenci> ogr = OKUL.Ogrenciler.Where(a => a.DogumTarihi > tarih).ToList();
                Console.WriteLine();
                OKUL.Listele(ogr);
            }
        }
        public void IllereGoreListe()
        {
            Console.WriteLine("5-Illere Göre Ögrencileri Listele --------------------------------------------");
            Console.WriteLine();
            if (OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
            }
            else
            {
                List<Ogrenci> ogr = OKUL.Ogrenciler.OrderBy(a => a.Adresi.Il).ToList();
                Console.WriteLine();
                OKUL.Illistele(ogr);
            }
        }
        public void OgrencininTumNotlariniListele()
        {
            Console.WriteLine("6-Ögrencinin notlarını görüntüle ---------------------------------------------");
            Console.WriteLine();
            if (OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
            }
            else
            {
                int no;
                while (true)
                {
                    Console.Write("Ögrencinin numarasi: ");
                    no = Convert.ToInt32(Console.ReadLine());

                    if (!OKUL.OgrenciVarMi(no))
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    else
                        break;
                }
                Console.Write("Ögrencinin Adı Soyadı: ");
                Console.WriteLine(Uygulama.OKUL.AdSoyAdGetir(no));
                Console.Write("Ögrencinin Subesi: ");
                Console.WriteLine(Uygulama.OKUL.Subele(no));
                Console.WriteLine();

                Ogrenci ogr = OKUL.Ogrenciler.Where(a => a.No == no).FirstOrDefault();
                if (ogr != null)
                {
                    ogr.Notlar.ToList();
                }
                OKUL.NotlariGoruntule(ogr.Notlar);
            }
        }
        public void OgrencininOkuduguKitaplariListele()
        {
            Console.WriteLine("7-Ögrencinin okudugu kitapları listele ---------------------------------------");
            Console.WriteLine();
            if (OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
            }
            else
            {
                int no;
                while (true)
                {
                    Console.Write("Ögrencinin numarasi: ");
                    no = Convert.ToInt32(Console.ReadLine());

                    if (!OKUL.OgrenciVarMi(no))
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    else
                        break;
                }
                Console.Write("Ögrencinin Adı Soyadı: ");
                Console.WriteLine(Uygulama.OKUL.AdSoyAdGetir(no));
                Console.Write("Ögrencinin Subesi: ");
                Console.WriteLine(Uygulama.OKUL.Subele(no));
                Console.WriteLine();

                Ogrenci ogr = OKUL.Ogrenciler.Where(a => a.No == no).FirstOrDefault();
                if (ogr != null)
                {
                    ogr.Kitaplar.ToList();
                }
                OKUL.KitaplariListele(ogr.Kitaplar);
            }
        }
        public void EnBasriliBes()
        {
            Console.WriteLine();
            Console.WriteLine("8-Okuldaki en basarılı 5 ögrenciyi listele -----------------------------------");
            List<Ogrenci> list = OKUL.Ogrenciler.OrderByDescending(a => a.Ortalama).Take(5).ToList();
            Console.WriteLine();
            OKUL.Listele(list);
        }
        public void EnBasarisizUc()
        {
            Console.WriteLine();
            Console.WriteLine("9-Okuldaki en basarısız 3 ögrenciyi listele ----------------------------------");
            List<Ogrenci> list = OKUL.Ogrenciler.OrderBy(a => a.Ortalama).Take(3).ToList();
            Console.WriteLine();
            OKUL.Listele(list);
        }
        public void SubedekiEnBasariliBes()
        {
            Console.WriteLine();
            Console.WriteLine("10-Subedeki en basarılı 5 ögrenciyi listele -----------------------------------");
            Ogrenci.SUBE secim = Arayıcı.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
            List<Ogrenci> list = OKUL.Ogrenciler.Where(a => a.Sube == secim).OrderByDescending(a => a.Ortalama).Take(5).ToList();
            Console.WriteLine();
            OKUL.Listele(list);
        }
        public void SubedekiEnBasarisizUc()
        {
            Console.WriteLine();
            Console.WriteLine("11-Subedeki en basarısız 3 ögrenciyi listele ----------------------------------");
            Ogrenci.SUBE secim = Arayıcı.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
            List<Ogrenci> list = OKUL.Ogrenciler.Where(a => a.Sube == secim).OrderBy(a => a.Ortalama).Take(3).ToList();
            Console.WriteLine();
            OKUL.Listele(list);
        }
        public void OgrencininOrtalamasiniGör()
        {
            Console.WriteLine();
            Console.WriteLine("12-Ögrencinin Not Ortalamasını Gör ----------------------------------");
            if (OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
            }
            else
            {
                int no;
                while (true)
                {
                    Console.Write("Ögrencinin numarasi: ");
                    no = Convert.ToInt32(Console.ReadLine());

                    if (!OKUL.OgrenciVarMi(no))
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    else
                        break;
                }
                Console.Write("Ögrencinin Adı Soyadı: ");
                Console.WriteLine(OKUL.AdSoyAdGetir(no));
                Console.Write("Ögrencinin Subesi: ");
                Console.WriteLine(OKUL.Subele(no));
                Console.WriteLine();
                Console.WriteLine("Ögrencinin not ortalaması: " + OKUL.OrtalamaGoster(no));
            }
        }
        public void SubeninOrtalamasiniGör()
        {
            Console.WriteLine();
            Console.WriteLine("13-Şubenin Not Ortalamasını Gör ----------------------------------");
            if (OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
            }
            else
            {
                Ogrenci.SUBE secim = Arayıcı.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                Console.WriteLine();
                float ort = OKUL.Ogrenciler.Where(a => a.Sube == secim).Average(a => a.Ortalama);
                Console.WriteLine(secim.ToString() + " subesinin not ortalaması: " + ort);
                Console.WriteLine();
            }
        }
        public void SonOkuduguKitabiGor()
        {
            Console.WriteLine();
            Console.WriteLine("14-Ögrencinin okudugu son kitabı listele ----------------------------");
            if (OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
            }
            else
            {
                int no;
                while (true)
                {
                    Console.Write("Ögrencinin numarasi: ");
                    no = Convert.ToInt32(Console.ReadLine());

                    if (!OKUL.OgrenciVarMi(no))
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    else
                        break;
                }
                Console.Write("Ögrencinin Adı Soyadı: ");
                Console.WriteLine(Uygulama.OKUL.AdSoyAdGetir(no));
                Console.Write("Ögrencinin Subesi: ");
                Console.WriteLine(Uygulama.OKUL.Subele(no));
                Console.WriteLine();

                List<string> metin = OKUL.SonKitapGetir(no);
                if (metin != null)
                {
                    Console.WriteLine(metin);
                    OKUL.SonKitapGor(metin);
                }
            }
        }
        public void OgrenciEkle()
        {
            Console.WriteLine();
            Console.WriteLine("15-Öğrenci Ekle -----------------------------------------------------");

            int no = OKUL.Ogrenciler.Count + 1;
            Console.WriteLine("Ögrencinin numarası: " + no);
            string ad = Uygulama.IlkHarfiBuyut(Arayıcı.YaziAl("Ögrencinin adı: "));
            string soyad = Uygulama.IlkHarfiBuyut(Arayıcı.YaziAl("Ögrencinin soyadı: "));
            Console.Write("Ögrencinin dogum tarihi: ");
            DateTime dogumTarihi = Convert.ToDateTime(Console.ReadLine());
            Ogrenci.CINSIYET cinsiyet = Arayıcı.CinsiyetAl("Ögrencinin cinsiyeti (K/E): ");
            Ogrenci.SUBE sube = Arayıcı.SubeAl("Ögrencinin subesi (A/B/C): ");
            Console.WriteLine(no.ToString() + " numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.");
            OKUL.OgrenciEkle(no, ad, soyad, dogumTarihi, cinsiyet, sube);
            Console.WriteLine();
        }
        public void OgrenciGuncelle()
        {
            Console.WriteLine("16-Ögrenci Güncelle -----------------------------------------------------------");

            if (OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede güncellenecek ögrenci yok.");
            }
            else
            {
                int no;
                while (true)
                {
                    Console.Write("Ögrencinin numarasi: ");
                    no = Convert.ToInt32(Console.ReadLine());

                    if (!OKUL.OgrenciVarMi(no))
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    else
                        break;
                }
                string ad = Uygulama.IlkHarfiBuyut(Arayıcı.YaziAl("Ögrencinin adı: "));
                string soyad = Uygulama.IlkHarfiBuyut(Arayıcı.YaziAl("Ögrencinin soyadı: "));
                Console.Write("Ögrencinin dogum tarihi: ");
                DateTime dogumTarihi = Convert.ToDateTime(Console.ReadLine());
                Ogrenci.CINSIYET cinsiyet = Arayıcı.CinsiyetAl("Ögrencinin cinsiyeti (K/E): ");
                Ogrenci.SUBE sube = Arayıcı.SubeAl("Ögrencinin subesi (A/B/C): ");
                Console.WriteLine(no.ToString() + " numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.");
                OKUL.Guncelle(no, ad, soyad, dogumTarihi, cinsiyet, sube);
            }
        }
        public void OgrenciSil()
        {
            Console.WriteLine();
            Console.WriteLine("17-Ögrenci sil ----------------------------------------------------------------");
            if (OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede silinecek ögrenci yok.");
            }
            else
            {
                int no;
                while (true)
                {
                    Console.Write("Ögrencinin numarasi: ");
                    no = Convert.ToInt32(Console.ReadLine());

                    if (!OKUL.OgrenciVarMi(no))
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    else
                        break;
                }
                Console.Write("Ögrencinin Adı Soyadı: ");
                Console.WriteLine(OKUL.AdSoyAdGetir(no));
                Console.Write("Ögrencinin Subesi: ");
                Console.WriteLine(OKUL.Subele(no));
                Console.WriteLine();
                Console.Write("Ögrenciyi silmek istediginize emin misiniz (E/H): ");

                string secim = Console.ReadLine().ToUpper();
                if (secim == "E")
                {
                    Ogrenci ogrenci = OKUL.Ogrenciler.Where(a => a.No == no).FirstOrDefault();
                    OKUL.Ogrenciler.Remove(ogrenci);
                    Console.WriteLine("Ögrenci basarılı bir sekilde silindi.");
                }
            }
        }
        public void OgrenciAdresGir()
        {
            Console.WriteLine();
            Console.WriteLine("18-Ögrencinin Adresini Gir ------------------------------------------");
            if (OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
            }
            else
            {
                int no;
                while (true)
                {
                    Console.Write("Ögrencinin numarasi: ");
                    no = Convert.ToInt32(Console.ReadLine());

                    if (!OKUL.OgrenciVarMi(no))
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    else
                        break;
                }
                string il = IlkHarfiBuyut(Arayıcı.YaziAl("İl: "));
                string ilce = IlkHarfiBuyut(Arayıcı.YaziAl("İlçe: "));
                OKUL.AdresEkle(no, il, ilce);
                Console.WriteLine();
                Console.WriteLine("Bilgiler sisteme girilmistir.");
            }
        }
        public void OkunanKitapGir()
        {
            Console.WriteLine();
            Console.WriteLine("19-Ögrencinin okudugu kitabı gir ------------------------------------");
            if (OKUL.Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede ögrenci yok.");
            }
            else
            {
                int no;
                while (true)
                {
                    Console.Write("Ögrencinin numarasi: ");
                    no = Convert.ToInt32(Console.ReadLine());

                    if (!OKUL.OgrenciVarMi(no))
                        Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    else
                        break;
                }
                Console.Write("Ögrencinin Adı Soyadı: ");
                Console.WriteLine(Uygulama.OKUL.AdSoyAdGetir(no));
                Console.Write("Ögrencinin Subesi: ");
                Console.WriteLine(Uygulama.OKUL.Subele(no));
                Console.WriteLine();

                Console.Write("Eklenecek Kitabin Adı: ");
                string kitapAdi = Uygulama.IlkHarfiBuyut(Console.ReadLine());
                OKUL.KitapEkle(no, kitapAdi);
                Console.WriteLine("Bilgiler sisteme girilmistir.");
            }
        }
        public void NotGir()
        {
            Console.WriteLine("20-Not Gir ----------------------------------------------------------");
            int no;
            while (true)
            {
                Console.Write("Ögrencinin numarasi: ");
                no = Convert.ToInt32(Console.ReadLine());

                if (!OKUL.OgrenciVarMi(no))
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                else
                    break;
            }
            Console.WriteLine(OKUL.AdSoyAdGetir(no));
            Console.Write("Eklemek istediginiz not adedi: ");
            int adet = Convert.ToInt32(Console.ReadLine());
            Console.Write("Not eklemek istediğiniz dersi giriniz: ");
            string ders = Console.ReadLine().ToUpper();
            for (int i = 1; i <= adet; i++)
            {
                Console.Write(i + ". notu girin : ");
                int not = int.Parse(Console.ReadLine());
                if (not < 0 || not > 100)
                {
                    Console.WriteLine("Girdiğiniz değer 0 ve 100 arasında olmalıdır.");
                    --i;
                }
                OKUL.NotEkle(no, ders, not);
            }
            Console.WriteLine();
            Console.WriteLine("Bilgiler sisteme girilmistir.");
        }
        public void Menu()
        {
            Console.WriteLine("------  Okul Yönetim Uygulamasi  -----");
            Console.WriteLine();
            Console.WriteLine("1 - Bütün öğrencileri listele");
            Console.WriteLine("2 - Şubeye göre öğrencileri listele");
            Console.WriteLine("3 - Cinsiyetine göre öğrencileri listele");
            Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine("5 - İllere göre sıralayarak öğrencileri listele");
            Console.WriteLine("6 - Öğrencinin tüm notlarını listele");
            Console.WriteLine("7 - Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("8 - Okuldaki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("9 - Okuldaki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("10 - Şubedeki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("11 - Şubedeki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("12 - Öğrencinin not ortalamasını gör");
            Console.WriteLine("13 - Şubenin not ortalamasını gör");
            Console.WriteLine("14 - Öğrencinin okuduğu son kitabı gör");
            Console.WriteLine("15 - Öğrenci ekle");
            Console.WriteLine("16 - Öğrenci güncelle");
            Console.WriteLine("17 - Öğrenci sil");
            Console.WriteLine("18 - Öğrencinin adresini gir");
            Console.WriteLine("19 - Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("20 - Öğrencinin notunu gir");
            Console.WriteLine();
            Console.WriteLine("çıkış yapmak için \"çıkış\" yazıp \"enter\"a basın.");
        }
        public void SahteVeriGir()
        {
            Uygulama.OKUL.OgrenciEkle(1, "Ali", "Aydemir", new DateTime(2000, 5, 4), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.B);
            Uygulama.OKUL.OgrenciEkle(2, "Akif", "Akkoyun", new DateTime(1997, 1, 1), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.A);
            Uygulama.OKUL.OgrenciEkle(3, "Cemile", "Nalbant", new DateTime(2001, 1, 1), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.C);
            Uygulama.OKUL.OgrenciEkle(4, "Gizem", "Akkoyun", new DateTime(2005, 10, 5), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.A);
            Uygulama.OKUL.OgrenciEkle(5, "Aylin", "Karsanbay", new DateTime(1995, 10, 25), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.B);
            Uygulama.OKUL.OgrenciEkle(6, "Müjde", "Çelik", new DateTime(1990, 12, 1), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.C);
            Uygulama.OKUL.OgrenciEkle(7, "Mahmut", "Deniz", new DateTime(2005, 8, 17), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.A);
            Uygulama.OKUL.OgrenciEkle(8, "Ahmet", "Kıymaz", new DateTime(1996, 7, 2), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.C);
            Uygulama.OKUL.OgrenciEkle(9, "Aycan", "Ay", new DateTime(2001, 05, 15), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.A);
            Uygulama.OKUL.OgrenciEkle(10, "Nilay", "Çevik", new DateTime(1997, 6, 12), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.C);
            Uygulama.OKUL.OgrenciEkle(11, "Ceren", "Cineli", new DateTime(2005, 2, 27), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.A);
            Uygulama.OKUL.OgrenciEkle(12, "Egehan", "Semerci", new DateTime(2002, 10, 21), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.B);
            Uygulama.OKUL.OgrenciEkle(13, "Merve", "Arga", new DateTime(1990, 4, 24), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.A);
            Uygulama.OKUL.OgrenciEkle(14, "Ayşe", "Mızmız", new DateTime(2022, 3, 5), Ogrenci.CINSIYET.Kiz, Ogrenci.SUBE.A);
            Uygulama.OKUL.OgrenciEkle(15, "Mustafa", "Efeoğlu", new DateTime(1990, 10, 10), Ogrenci.CINSIYET.Erkek, Ogrenci.SUBE.B);

            Uygulama.OKUL.NotEkle(1, "Türkçe", 15);
            Uygulama.OKUL.NotEkle(1, "Matematik", 95);
            Uygulama.OKUL.NotEkle(1, "Fen", 88);
            Uygulama.OKUL.NotEkle(1, "Sosyal", 20);

            Uygulama.OKUL.NotEkle(2, "Türkçe", 100);
            Uygulama.OKUL.NotEkle(2, "Matematik", 82);
            Uygulama.OKUL.NotEkle(2, "Fen", 85);
            Uygulama.OKUL.NotEkle(2, "Sosyal", 92);

            Uygulama.OKUL.NotEkle(3, "Türkçe", 100);
            Uygulama.OKUL.NotEkle(3, "Matematik", 82);
            Uygulama.OKUL.NotEkle(3, "Fen", 56);
            Uygulama.OKUL.NotEkle(3, "Sosyal", 90);

            Uygulama.OKUL.NotEkle(4, "Türkçe", 5);
            Uygulama.OKUL.NotEkle(4, "Matematik", 15);
            Uygulama.OKUL.NotEkle(4, "Fen", 10);
            Uygulama.OKUL.NotEkle(4, "Sosyal", 17);

            Uygulama.OKUL.NotEkle(5, "Türkçe", 90);
            Uygulama.OKUL.NotEkle(5, "Matematik", 90);
            Uygulama.OKUL.NotEkle(5, "Fen", 86);
            Uygulama.OKUL.NotEkle(5, "Sosyal", 85);

            Uygulama.OKUL.NotEkle(6, "Türkçe", 57);
            Uygulama.OKUL.NotEkle(6, "Matematik", 87);
            Uygulama.OKUL.NotEkle(6, "Fen", 16);
            Uygulama.OKUL.NotEkle(6, "Sosyal", 66);

            Uygulama.OKUL.NotEkle(7, "Türkçe", 10);
            Uygulama.OKUL.NotEkle(7, "Matematik", 5);
            Uygulama.OKUL.NotEkle(7, "Fen", 4);
            Uygulama.OKUL.NotEkle(7, "Sosyal", 4);

            Uygulama.OKUL.NotEkle(8, "Türkçe", 5);
            Uygulama.OKUL.NotEkle(8, "Matematik", 5);
            Uygulama.OKUL.NotEkle(8, "Fen", 6);
            Uygulama.OKUL.NotEkle(8, "Sosyal", 6);

            Uygulama.OKUL.NotEkle(9, "Türkçe", 100);
            Uygulama.OKUL.NotEkle(9, "Matematik", 100);
            Uygulama.OKUL.NotEkle(9, "Fen", 100);
            Uygulama.OKUL.NotEkle(9, "Sosyal", 100);

            Uygulama.OKUL.NotEkle(10, "Türkçe", 25);
            Uygulama.OKUL.NotEkle(10, "Matematik", 35);
            Uygulama.OKUL.NotEkle(10, "Fen", 10);
            Uygulama.OKUL.NotEkle(10, "Sosyal", 0);

            Uygulama.OKUL.NotEkle(11, "Türkçe", 65);
            Uygulama.OKUL.NotEkle(11, "Matematik", 75);
            Uygulama.OKUL.NotEkle(11, "Fen", 56);
            Uygulama.OKUL.NotEkle(11, "Sosyal", 47);

            Uygulama.OKUL.NotEkle(12, "Türkçe", 56);
            Uygulama.OKUL.NotEkle(12, "Matematik", 53);
            Uygulama.OKUL.NotEkle(12, "Fen", 72);
            Uygulama.OKUL.NotEkle(12, "Sosyal", 71);

            Uygulama.OKUL.NotEkle(13, "Türkçe", 52);
            Uygulama.OKUL.NotEkle(13, "Matematik", 18);
            Uygulama.OKUL.NotEkle(13, "Fen", 6);
            Uygulama.OKUL.NotEkle(13, "Sosyal", 66);

            Uygulama.OKUL.NotEkle(14, "Türkçe", 66);
            Uygulama.OKUL.NotEkle(14, "Matematik", 64);
            Uygulama.OKUL.NotEkle(14, "Fen", 60);
            Uygulama.OKUL.NotEkle(14, "Sosyal", 61);

            Uygulama.OKUL.NotEkle(15, "Türkçe", 50);
            Uygulama.OKUL.NotEkle(15, "Matematik", 68);
            Uygulama.OKUL.NotEkle(15, "Fen", 60);
            Uygulama.OKUL.NotEkle(15, "Sosyal", 96);

            Uygulama.OKUL.AdresEkle(1, "Aydın", "Söke");
            Uygulama.OKUL.AdresEkle(2, "İstanbul", "Kadıköy");
            Uygulama.OKUL.AdresEkle(3, "İzmir", "Alsancak");
            Uygulama.OKUL.AdresEkle(4, "Bursa", "Görükle");
            Uygulama.OKUL.AdresEkle(5, "Aydın", "Nazilli");
            Uygulama.OKUL.AdresEkle(6, "İstanbul", "Beşiktaş");
            Uygulama.OKUL.AdresEkle(7, "İzmir", "Basmane");
            Uygulama.OKUL.AdresEkle(8, "Bursa", "OsmanGazi");
            Uygulama.OKUL.AdresEkle(9, "Tokat", "Niksar");
            Uygulama.OKUL.AdresEkle(10, "Manisa", "AlaŞehir");
            Uygulama.OKUL.AdresEkle(11, "Eskişehir", "Odunpazarı");
            Uygulama.OKUL.AdresEkle(12, "Manisa", "KırkAğaç");
            Uygulama.OKUL.AdresEkle(13, "İstanbul", "Sarıyer");
            Uygulama.OKUL.AdresEkle(14, "İzmir", "Bornova");
            Uygulama.OKUL.AdresEkle(15, "Aydın", "Söke");

            Uygulama.OKUL.KitapEkle(1, "Nutuk");
            Uygulama.OKUL.KitapEkle(1, "Harry Potter and the Chamber of Secrets");
            Uygulama.OKUL.KitapEkle(2, "Senin Cahilliğin Benim Yaşamımı Etkiliyor");
            Uygulama.OKUL.KitapEkle(2, "Agatha Christie Eastern Express Murder");
            Uygulama.OKUL.KitapEkle(3, "Mustafa Kemal ATATÜRK");
            Uygulama.OKUL.KitapEkle(3, "Yüzüklerin Efendisi Yüzük Kardeşliği");
            Uygulama.OKUL.KitapEkle(4, "Daha Yeni Başlıyor");
            Uygulama.OKUL.KitapEkle(4, "Milenaya Mektuplar");
            Uygulama.OKUL.KitapEkle(5, "Başarıya Giden Yolda İletişim");
            Uygulama.OKUL.KitapEkle(5, "Dönüşüm");
            Uygulama.OKUL.KitapEkle(6, "Sis Ve Gece");
            Uygulama.OKUL.KitapEkle(6, "Vadideki Zambak");
            Uygulama.OKUL.KitapEkle(7, "Suç Ve Ceza");
            Uygulama.OKUL.KitapEkle(7, "Sefiller");
            Uygulama.OKUL.KitapEkle(8, "Sokratesin Savunması");
            Uygulama.OKUL.KitapEkle(8, "Savaş Ve Barış");
            Uygulama.OKUL.KitapEkle(9, "Küçük Prens");
            Uygulama.OKUL.KitapEkle(9, "Hayvan Çiftliği");
            Uygulama.OKUL.KitapEkle(10, "1984");
            Uygulama.OKUL.KitapEkle(10, "Mutlu Olma Sanatı");
            Uygulama.OKUL.KitapEkle(11, "Altıncı Koğuş");
            Uygulama.OKUL.KitapEkle(11, "Var Mısın?");
            Uygulama.OKUL.KitapEkle(12, "Cesur Yeni Dünya");
            Uygulama.OKUL.KitapEkle(12, "İnsan Ne ile Yaşar");
            Uygulama.OKUL.KitapEkle(13, "Yüz Başının Kızı");
            Uygulama.OKUL.KitapEkle(13, "Hamlet");
            Uygulama.OKUL.KitapEkle(14, "Aptalı Tanımak");
            Uygulama.OKUL.KitapEkle(14, "Bilimin Büyüsü");
            Uygulama.OKUL.KitapEkle(15, "Sokratesin Savunması");
            Uygulama.OKUL.KitapEkle(15, "Dahi Diktatör");
        }
        private static string IlkHarfiBuyut(string veri) => veri.Substring(0, 1).ToUpper() + veri.Substring(1).ToLower();
    }
}

