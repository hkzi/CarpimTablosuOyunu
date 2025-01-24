using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpimTablosuOyunu
{
    public class GameModel
    {
        public int Sayi1 { get; set; }
        public int Sayi2 { get; set; }
        public int Puan { get; set; }
        public int DogruCevap { get; set; }
        public int HedefPuan { get; set; }
        public int EnYuksekPuan { get; set; } = 0;

        private Random random = new Random();

        // Cevap kontrol metodu
        public bool CevabiKontrolEt(int cevap)
        {
            if (cevap == DogruCevap)
            {
                Puan++;
                if (Puan > EnYuksekPuan)
                {
                    EnYuksekPuan = Puan;  // En yüksek puanı güncelle
                }
                return true;
            }
            return false;
        }

        // Rastgele soru oluşturma metodu
        public void RastgeleSoruOlustur(Random random)
        {
            Sayi1 = random.Next(1, 10);
            Sayi2 = random.Next(1, 10);
            DogruCevap = Sayi1 * Sayi2;
        }
    }
}
