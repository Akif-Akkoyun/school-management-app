using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulmasi
{
    internal class Arayıcı
    {
        public static string YaziAl(string yazi)
        {
            string s;
            while (true)
            {
                Console.Write(yazi);
                s = Console.ReadLine();
                if (int.TryParse(s, out int _))
                    Console.WriteLine("Hatalı islem tekrar girin.");
                else if (s != null && s == null)
                    Console.WriteLine("Veri girişi yapılmadı tekrar deneyin.");
                else
                    break;
            }
            return s;
        }
        public static Ogrenci.SUBE SubeAl(string str)
        {
            while (true)
            {
                Console.Write(str);
                string yazi = Console.ReadLine().ToUpper();
                switch (yazi)
                {
                    case "A":
                        goto label_50;
                    case "B":
                        goto label_51;
                    case "C":
                        goto label_52;
                    default:
                        Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                        break;
                }
            }
        label_50:
            return Ogrenci.SUBE.A;
        label_51:
            return Ogrenci.SUBE.B;
        label_52:
            return Ogrenci.SUBE.C;

        }
        public static Ogrenci.CINSIYET CinsiyetAl(string cnsyt)
        {
            while (true)
            {
                Console.Write(cnsyt);
                string yazi = Console.ReadLine().ToUpper();
                switch (yazi)
                {
                    case "K":
                        goto label_50;
                    case "E":
                        goto label_51;
                    default:
                        Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                        break;
                }
            }
        label_50:
            return Ogrenci.CINSIYET.Kiz;
        label_51:
            return Ogrenci.CINSIYET.Erkek;
        }

        public static DateTime TarihAl(string tarih)
        {
            DateTime sonuc;
            while (true)
            {
                Console.Write(tarih);
                if (!DateTime.TryParse(Console.ReadLine(), out sonuc))
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                else
                    break;
            }
            return sonuc;
        }
        public static string DersGir()
        {
            Console.Write("Not eklemek istediğiniz dersi giriniz: ");
            return Console.ReadLine().ToUpper();
        }
    }
}
