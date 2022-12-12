using System;
using System.Collections.Generic;
using System.Text;
using TelefonRehberi.Enum;

namespace TelefonRehberi.Interfaces
{
    public interface IRehber
    {
        public void NumaraEkle();
        public void NumaraSil();
        public void NumaraGuncelle();
        public void RehberListele(SiralamaYon siralamaYon);
        public void RahberdeArama();
    }
}
