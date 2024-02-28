using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulmasi
{
    internal class Ogrenci
    {
        public int No { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public float Ortalama
        {
            get
            {
                float sayi = (float)this.Notlar.Sum<DersNotu>(a => a.Not);
                return sayi = sayi / this.Notlar.Count;
            }
        }
        public SUBE Sube { get; set; }
        public CINSIYET Cinsiyet { get; set; }
        public Adres Adresi { get; set; }

        public List<DersNotu> Notlar = new List<DersNotu>();

        public List<string> Kitaplar = new List<string>();

        public int KitapSayisi => this.Kitaplar == null ? 0 : this.Kitaplar.Count;


        public enum SUBE
        {
            A, B, C
        }

        public enum CINSIYET
        {
            Kiz, Erkek
        }
        public void AdresEkle(string il, string ilce)
        {
            if (this.Adresi == null)
                this.Adresi = new Adres();
            this.Adresi.Il = il;
            this.Adresi.Ilce = ilce;
        }
    }





}
