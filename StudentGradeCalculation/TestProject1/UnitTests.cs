using Xunit;
using NotHesapla;

namespace Test
{
    public class BasitOrtalamaTest
    {
        // BasitOrtalama sýnýfýnýn doðru ortalama hesaplayýp hesaplamadýðýný test eder.
        private readonly List<int> Notlar = new List<int> { 80, 90, 100 };
        [Fact]
        public void BasitOrtalamaTestEt()
        {
            var Hesaplayici = new BasitOrtalama();
            var Sonuc = Hesaplayici.OrtalamaHesapla(Notlar);

            Assert.Equal(90, Sonuc);
        }

    }

    public class AgirlikliOrtalamaTest
    {
        // AgirlikliOrtalama sýnýfýnýn doðru aðýrlýklý ortalamayý hesaplayýp hesaplamadýðýný test eder.
        private readonly List<int> Notlar = new List<int> { 80, 90, 100 };

        [Fact]
        public void AgirlikliOrtalamaTestEt()
        {
            var Hesaplayici = new AgirlikliOrtalama();
            var Sonuc = Hesaplayici.OrtalamaHesapla(Notlar);
            Assert.Equal(90, Sonuc); // sonuc=92 - expected=90, testin hatayý yakalayýp yakalayamadýðýný kontrol eder.
        }
    }

    public class GecisKontrolTest
    {
        // GecisKontrolu sýnýfýnýn geçme/kalmayý doðru deðerlendirip deðerlendirmediðini test eder.
        private readonly GecisKontrolu Kontrol = new GecisKontrolu();
        private readonly double GecerOrt = 75;
        [Fact]
        public void GecisKontrolTestEt()
        {
            bool Sonuc = Kontrol.OgrenciGecti(GecerOrt);
            Assert.True(Sonuc);
        }
    }

    public class EnYuksekOrtTest
    {
        // EnYuksekOrtalama sýnýfýnýn doðru öðrenciyi bulup bulmadýðýný test eder.
        [Fact]
        public void EnYuksekOrtTestET()
        {
            Dictionary<string, double> Ortalamalar = new Dictionary<string, double>();
            KeyValuePair<string, double> Expected = new KeyValuePair<string, double> ();
            EnYuksekOrtalama enYuksekOrtalama = new EnYuksekOrtalama();
            Ortalamalar.Add("Mustafa", 72);
            Ortalamalar.Add("Kaan", 45);

            KeyValuePair<string, double> sonuc = enYuksekOrtalama.EnYuksek(Ortalamalar);
            foreach(var i in Ortalamalar)
            {
                Expected = i;
            }


            Assert.Equal(Expected, sonuc); // sonuc = Mustafa - Expected = Kaan, testin hatayý yakalayýp yakalayamadýðýný kontrol eder.
        }
    }
}