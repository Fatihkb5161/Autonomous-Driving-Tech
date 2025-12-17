/* 
 * Bu uygulama, öğrenci notlarının ortalamasını hesaplar
 * ve geçme durumlarını belirler. Ayrıca en yüksek ortalamaya sahip öğrenciyi tespit eder.
 * Clean Code prensipleri (anlamlı adlandırma, SRP, OOP, test edilebilirlik) dikkate alınarak yapılandırılmıştır.
 * Loglama için Microsoft.Extensions.Logging kullanılmıştır.
 * 
 * Yazar: Fatih Küçükbıyık
 * Tarih: 03.07.2025
 */

using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;


namespace NotHesapla
{
    public interface IStudent
    {
        // IStudent: Tüm öğrenci sınıflarının implement etmesi gereken temel işlevleri tanımlar.
        string GetIsim();
        List<int> GetNotlar();
    }

    class Student : IStudent
    {
        private string OgrenciIsmi { get; set; }
        private List<int> OgrenciNotlari { get; set; }
        private static ILogger<Student> _logger;

        public Student(string isim, List<int> notlar)
        {
            // Student: Öğrenci bilgilerini ve notlarını temsil eden sınıf.
            // Constructor içinde notların 0-100 arasında olup olmadığı kontrol edilir.
            // Logger ile hatalı not girişleri kayıt altına alınır.

            using var serviceProvider = new ServiceCollection()
            .AddLogging(config => config.AddConsole())
            .BuildServiceProvider();

            _logger = serviceProvider.GetService<ILogger<Student>>();
            OgrenciIsmi = isim;
            foreach (int not in notlar)
            {
                if (not < 0 || not > 100)
                {
                    _logger.LogError("Hatalı not: Öğrenci notları 0 ile 100 arasında olmalı.");
                    throw new ArgumentException("Notlar 0 ile 100 arasında olmalı");
                }
            }
            OgrenciNotlari = notlar; 
        }

        public string GetIsim ()
        {
            return OgrenciIsmi;
        }
        public List<int> GetNotlar()
        {
            return OgrenciNotlari;
        }
    }
    
    public interface IOrtalama
    {
        public double OrtalamaHesapla(List<int> notlar);
    }

    public class BasitOrtalama: IOrtalama
    {
        // BasitOrtalama: Notların aritmetik ortalamasını hesaplar.
        // Ortalama = Notların toplamı / Not sayısı
        public double OrtalamaHesapla(List<int> notlar) 
        {
            int Toplam = 0;
            int NotSayisi = 0;
            foreach(int not in notlar)
            {
                Toplam += not;
                NotSayisi++;
            }

            return Math.Round((double)Toplam / NotSayisi);
        }
    }

    public class AgirlikliOrtalama : IOrtalama
    {
        // AgirlikliOrtalama: Her notu, ona ait kredi katsayısıyla çarparak ağırlıklı ortalama hesaplar.
        // Kredi listesi sabit (3, 2, 5) olarak alınmıştır.
        public double OrtalamaHesapla(List<int> notlar)
        {
            var DersKredisi = new List<int> { 3, 2, 5 }; // Derslerin Kredisi
            int Toplam = 0;
            int ToplamKredi = 0;
            int Counter = 0;

            foreach (int not in notlar)
            {
                Toplam += not * DersKredisi[Counter];
                ToplamKredi += DersKredisi[Counter];
                Counter++;
            }

            return Math.Round((double)Toplam / ToplamKredi);
        }
    }

    public class GecisKontrolu
    {
        // GecisKontrolu: Ortalama 60 ve üzeriyse öğrenciyi "geçti" olarak değerlendirir.
        public bool OgrenciGecti(double ortalama)
        {
            if (ortalama >= 60)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }
    }

    public class EnYuksekOrtalama
    {
        // EnYuksekOrtalama: Öğrenciler arasından en yüksek ortalamaya sahip olanı bulur.
        // Logger ile geçici en yüksek öğrenci bilgisi kaydedilir.

        private static ILogger<EnYuksekOrtalama> _logger;
        public KeyValuePair<string, double> EnYuksek(Dictionary<string, double> dict)
        {
            using var serviceProvider = new ServiceCollection()
            .AddLogging(config => config.AddConsole())
            .BuildServiceProvider();

            _logger = serviceProvider.GetService<ILogger<EnYuksekOrtalama>>();
            KeyValuePair<string, double> EnYuksek = new KeyValuePair<string, double>("", double.MinValue);

            foreach (var student in dict)
            {
                if (student.Value > EnYuksek.Value)
                {
                    EnYuksek = student;
                    _logger.LogDebug($"Şu an en yüksek ortalama: {EnYuksek.Key}{(EnYuksek.Value)}");
                }
            }
            
            return EnYuksek;
        }
    }

    public class TabloYazdir
    {
        // TabloYazdir: Konsola başlık ve ayraç çizgilerini yazdırır.
        // Görselliği artırmak amacıyla kullanılır.
        public void BaslikYazdir()
        {
            // Başlık
            Console.WriteLine("{0,-15} | {1,20} | {2,20} | {3,20} |", "İsim", "Basit Ortalama", "Ağırlıklı Ortalama", "Geçme Durumu");
            Console.WriteLine(new string('-', 86));
        }

        public void AltYazdir()
        {   // Alt çizgiler
            Console.WriteLine(new string('-', 86));
        }
    }

    class Program
    {
        private static ILogger<Program> _logger;
        static void Main(string[] args)
        {
            // Main: Uygulamanın giriş noktasıdır.
            // Öğrenciler tanımlanır, ortalamalar hesaplanır ve sonuçlar yazdırılır.
            // ILogger ile uygulama başlangıcı ve genel çıktı bilgileri loglanır.


            using var serviceProvider = new ServiceCollection()
            .AddLogging(config => config.AddConsole())
            .BuildServiceProvider();

            _logger = serviceProvider.GetService<ILogger<Program>>();

            _logger.LogInformation("Program başlatıldı...");

            List<Student> Ogrenciler = new List<Student>();
            var Ortalamalar = new Dictionary<string, double>();
            int GecenOgrenciSayisi = 0;

            Student Ali = new Student("Ali", new List<int> { 90, 85, 100 });
            Student Ayse = new Student("Ayşe", new List<int> { 45, 50, 60 });
            Student Mehmet = new Student("Mehmet", new List<int> { 70, 80, 75 });
            Student Zeynep = new Student("Zeynep", new List<int> { 0, 30, 20 });

            Ogrenciler.Add(Ali);
            Ogrenciler.Add(Ayse);
            Ogrenciler.Add(Mehmet);
            Ogrenciler.Add(Zeynep);

            BasitOrtalama basitOrtalama = new BasitOrtalama();
            AgirlikliOrtalama agirlikliOrtalama = new AgirlikliOrtalama();
            GecisKontrolu gecisKontrolu = new GecisKontrolu();
            EnYuksekOrtalama enYuksekOrtalama = new EnYuksekOrtalama();
            TabloYazdir tabloYazdir = new TabloYazdir();


            tabloYazdir.BaslikYazdir();
            foreach (Student student in Ogrenciler)
            {
                double OgrBasitOrt = basitOrtalama.OrtalamaHesapla(student.GetNotlar());
                double OgrAgirOrt = agirlikliOrtalama.OrtalamaHesapla(student.GetNotlar());
                string Gecti;

                if(gecisKontrolu.OgrenciGecti(OgrBasitOrt))
                {
                    Gecti = "Geçti";
                    GecenOgrenciSayisi++;
                    Ortalamalar.Add(student.GetIsim(), OgrBasitOrt); // Ortalama altında kalan öğrencilerin karşılaştırılması gerekmiyor.
                }
                else { Gecti = "Kaldı"; }

                Console.WriteLine("{0,-15} | {1,20:F2} | {2,20:F2} | {3,20:F2} |", student.GetIsim(), OgrBasitOrt, OgrAgirOrt, Gecti);
            }
            tabloYazdir.AltYazdir();

            _logger.LogInformation($"Toplam geçen öğrenci sayısı: {GecenOgrenciSayisi}");
            KeyValuePair<string, double> EnYuksekOrtOgr = enYuksekOrtalama.EnYuksek(Ortalamalar);
            _logger.LogInformation($"En yüksek ortalamaya sahip öğrenci: {EnYuksekOrtOgr.Key}, Ortalaması: {EnYuksekOrtOgr.Value}");
            
        }
    }
}