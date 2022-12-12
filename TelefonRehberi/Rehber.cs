using System;
using System.Collections.Generic;
using System.Text;
using TelefonRehberi.Enum;
using TelefonRehberi.Interfaces;

namespace TelefonRehberi
{
    public class Rehber : IRehber
    {
        private List<Kisi> RehberListe;

        public Rehber()
        {
            RehberListe = new List<Kisi>();
            RehberListe.Add(new Kisi("Candar", "Tozan", "05393644530"));
            RehberListe.Add(new Kisi("Ali", "Tokmak", "05353746021"));
            RehberListe.Add(new Kisi("Raskoln", "Razda", "05456497160"));
            RehberListe.Add(new Kisi("Uğur", "Tozan", "05409874532"));
            RehberListe.Add(new Kisi("Osman", "Yılmaz", "05303214570"));
            RehberListe.Sort();
        }

        public void NumaraEkle()
        {

            Console.Write($"{"Lütfen isim giriniz",-30}");
            string ad = Console.ReadLine();
            Console.Write($"{"Lütfen soyisim girin",-30}");
            var soyad = Console.ReadLine();
            Console.Write($"{"Lütfen telefon numarası girin",-30}");
            var numara = Console.ReadLine();

            var yeniKisi = new Kisi(ad, soyad, numara);
            RehberListe.Add(yeniKisi);
        }

        public void NumaraGuncelle()
        {
            RehberListe.Sort();

            Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını girin :");
            string guncellenecek = Console.ReadLine();
            bool mevcut = false;
            foreach (var kisi in RehberListe)
            {
                if (kisi.Ad == guncellenecek || kisi.Soyad == guncellenecek)
                {
                    Console.Write("Yeni numrarayı girin :");
                    string yeniNumara = Console.ReadLine();
                    kisi.Numara = yeniNumara;
                    mevcut = true;
                    return;
                }
            }
            if (!mevcut)
            {
                int secim;
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapın.");
                Console.WriteLine($"{"* Güncellemeyi sonlandırmak için : (1)",-25}");
                Console.WriteLine($"{"* Yeniden denemek için : (1)",-25}");
                secim = int.Parse(Console.ReadLine());
                if (secim == 1)
                {
                    return;
                }
                if (secim == 2)
                {
                    NumaraGuncelle();
                }
            }
        }

        public void NumaraSil()
        {
            RehberListe.Sort();

            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını girin : ");
            string silenecek = Console.ReadLine();

            foreach (var kisi in RehberListe)
            {
                if(kisi.Ad == silenecek || kisi.Soyad == silenecek)
                {
                    Console.Write("{0} isimli kişiyi silinmek üzere, onaylıyor musunuz ?(y/n) ", kisi);
                    string yn = Console.ReadLine();
                    if(yn == "y")
                    {
                        RehberListe.Remove(kisi);
                        return;
                    }
                    else
                    {
                        return;
                    }
                    
                }
            }
            int secim;
            Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapın.");
            Console.WriteLine($"{"* Silmeyi sonlandırmak için : (1)",-25}");
            Console.WriteLine($"{"* Yeniden denemek için : (1)",-25}");
            secim = int.Parse(Console.ReadLine());
            if(secim == 1)
            {
                return;
            }
            if(secim == 2)
            {
                NumaraSil();
            }
        }

        public void RahberdeArama()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine("************************************************\n");
            Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
            int secim = int.Parse(Console.ReadLine());
            if(secim == 1)
            {
                İsimSoyisimAra();
            }
            else if(secim == 2)
            {
                NumaraAra();
            }
        }

        private void NumaraAra()
        {
            RehberListe.Sort();
            Console.Write("Aranacak numayrayı girin :");
            var numara = Console.ReadLine();
            bool mevcut = false;
            Console.WriteLine("Arama sonuçlarınız :");
            Console.WriteLine("************************************************");
            foreach (var kisi in RehberListe)
            {
                if(kisi.Numara == numara)
                {
                    Console.WriteLine("isim: {0}", kisi.Ad);
                    Console.WriteLine("Soyisim: {0}", kisi.Soyad);
                    Console.WriteLine("Numara: {0}", kisi.Numara);
                    Console.WriteLine("-");
                    mevcut = true;
                }
            }
            if (!mevcut)
            {
                Console.WriteLine("Aranılan numara mevcut değil.");
            }
        }

        private void İsimSoyisimAra()
        {
            RehberListe.Sort();
            Console.Write("Aranacak adı ya da soyadını girin :");
            var aranacak = Console.ReadLine();
            bool mevcut = false;
            Console.WriteLine("Arama sonuçlarınız :");
            Console.WriteLine("************************************************");
            foreach (var kisi in RehberListe)
            {
                if (kisi.Ad == aranacak || kisi.Soyad == aranacak)
                {
                    Console.WriteLine("isim: {0}", kisi.Ad);
                    Console.WriteLine("Soyisim: {0}", kisi.Soyad);
                    Console.WriteLine("Numara: {0}", kisi.Numara);
                    Console.WriteLine("-");
                    mevcut = true;
                }
            }
            if (!mevcut)
            {
                Console.WriteLine("Aranılan numara mevcut değil.");
            }
        }

        public void RehberListele(SiralamaYon siralamaYon)
        {
            if (siralamaYon == SiralamaYon.A_Z)
            {
                RehberListe.Sort();
                RehberListe.Reverse();
                Console.WriteLine("Telefon Rehberi");
                Console.WriteLine("************************************************");

                foreach (var kisi in RehberListe)
                {
                    Console.WriteLine("isim: {0}", kisi.Ad);
                    Console.WriteLine("Soyisim: {0}", kisi.Soyad);
                    Console.WriteLine("Numara: {0}", kisi.Numara);
                    Console.WriteLine("-");
                }
            }
            else if(siralamaYon == SiralamaYon.Z_A)
            {
                RehberListe.Sort();
                Console.WriteLine("Telefon Rehberi");
                Console.WriteLine("************************************************");

                foreach (var kisi in RehberListe)
                {
                    Console.WriteLine("isim: {0}", kisi.Ad);
                    Console.WriteLine("Soyisim: {0}", kisi.Soyad);
                    Console.WriteLine("Numara: {0}", kisi.Numara);
                    Console.WriteLine("-");
                }
            }
        }
    }
}
