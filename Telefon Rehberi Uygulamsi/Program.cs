using System;
using TelefonRehberi;
using TelefonRehberi.Enum;

namespace Telefon_Rehberi_Uygulamsi
{
    class Program
    {
        static void Main(string[] args)
        {
            var rehber = new Rehber();
            var devam = true;
            while (devam)
            {
                int secim = 0;
                var yön = new SiralamaYon();

                Console.WriteLine("lütfen yapmak istediğiniz işlemi seçin");
                Console.WriteLine("************************************************");
                Console.WriteLine("(1) Yeni Numara kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı güncelleme");
                Console.WriteLine("(4) Rehhberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                Console.WriteLine("(6) Rehberden Çıkmak");
                secim = Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        rehber.NumaraEkle();
                        break;
                    case 2:
                        rehber.NumaraGuncelle();
                        break;
                    case 3:
                        rehber.NumaraSil();
                        break;
                    case 4:
                        int secim2;
                        Console.WriteLine("(1) A-Z");
                        Console.WriteLine("(2) Z-A");
                        secim2 = int.Parse(Console.ReadLine());
                        if (secim2 == 1)
                            yön = SiralamaYon.A_Z;
                        if (secim2 == 1)
                            yön = SiralamaYon.Z_A;
                        rehber.RehberListele(yön);
                        break;
                    case 5:
                        rehber.RahberdeArama();
                        break;
                    case 6:
                        devam = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
