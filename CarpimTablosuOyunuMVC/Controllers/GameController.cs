using Microsoft.AspNetCore.Mvc;
using CarpimTablosuOyunu;

namespace CarpimTablosuOyunuMVC.Controllers
{
    public class GameController : Controller
    {
        private static GameModel gameModel = new GameModel();
        private static Random rastgele = new Random();

        // Index sayfası, ilk açıldığında rastgele soru oluşturuluyor
        public IActionResult Index()
        {
            gameModel.RastgeleSoruOlustur(rastgele);  // İlk soru oluşturuluyor
            return View(gameModel);
        }

        [HttpPost]
        public IActionResult Kontrol(int cevap)
        {
            bool dogruMu = gameModel.CevabiKontrolEt(cevap);

            // Yeni soru oluşturuluyor (doğru veya yanlış cevap olsa da)
            gameModel.RastgeleSoruOlustur(rastgele);

            // Yanlış cevap verildiğinde ve hedef puana ulaşılmadıysa, hata mesajı gösterilir
            if (!dogruMu)
            {
                ViewBag.DogruMu = dogruMu;
            }

            // Puan hedefe ulaşıldığında, yalnızca yanlış cevapla "Tebrikler" sayfasına yönlendirilir.
            if (gameModel.Puan >= gameModel.HedefPuan && !dogruMu)
            {
                return RedirectToAction("Tebrikler");
            }

            return View("Index", gameModel);
        }


        [HttpPost]
        public IActionResult YeniOyun()
        {
            // Puanı sıfırlıyoruz
            gameModel.Puan = 0;

            // Yeni soru oluşturuluyor
            gameModel.RastgeleSoruOlustur(rastgele);

            // Yeni oyun başladığı için ana sayfaya yönlendiriyoruz
            return View("Index", gameModel);
        }


        // Tebrikler sayfası
        public IActionResult Tebrikler()
        {
            
            return View(gameModel);
        }
    }

}