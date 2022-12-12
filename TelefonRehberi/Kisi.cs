using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TelefonRehberi.Interfaces;

namespace TelefonRehberi
{
    public class Kisi : IKisi, IComparable
    {
        private string ad;
        private string soyad;
        private string numara;

        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public string Numara { get => numara; set => numara = value; }

        public Kisi()
        {

        }
        public Kisi(string ad, string soyad, string numara)
        {
            Ad = ad;
            Soyad = soyad;
            Numara = numara;
        }

        public override string ToString()
        {
            return Ad + " " + Soyad;
        }

        public int CompareTo(object obj)
        {
            var diger = (Kisi)obj;
            return string.Compare(this.ToString(), diger.ToString());
        }
    }
}