# SinemaSinema
# SinemaBiletSatınAlmaUygulaması
Bu, C# ve Visual Studio kullanılarak geliştirilmiş bir windows form uygulamasıdır. Bu uygulama, kullanıcının bir sinemada film  için bilet satın almasını sağlar.
## Genel bakış
Bu projede, Sinema salonu Bilet gişesi  için geliştirilen sinema bilet satma ve bugün için satılan biletlerin gösterildiği kodların kaynağı yer almaktadır. Bu proje, C# dilinde yazılmış bir sinema bilet satma sistemi uygulamasını içermektedir.Proje temelde Sinema bilet satış projesi  Windows Form üzerinden yapılmaktadır.  Proje  kullanıcının istekleri doğrultusunda bilet satışı ve bilet bilgileri göstermeyi   amaçlamaktadır. Bu yönergeleri, projeyi kendi makinenizde çalıştırmak ve geliştirmek için kullanabilirsiniz.Bu uygulama, bir sinema salonunun bilet satış işlemlerini yönetmek için tasarlanmıştır. Kullanıcılar, mevcut filmler arasından seçim yapabilir, seans saatlerini görüntüleyebilir ve boş koltuklardan bilet satın alabilirler.Windows Form da tek bir form üzerinden tablar oluşturularak yapıldı.
## Proje Yapısı
Uygulama, aşağıdaki bileşenlerden oluşur:
SinemaSinema: Ana proje dosyası.
SinemaSinema.Data: Veritabanı işlemleri için gereken sınıfları içerir.
SinemaSinema.Models: Uygulama veri modelini tanımlayan sınıfları içerir.
SinemaSinema.Servisler: Uygulama iş mantığını içeren servis sınıflarını içerir.
Form1.cs: Ana uygulama formu ve kullanıcı arayüzü işlemlerini içerir.
## Kullanılan Teknolojiler
C#: Uygulama, C# programlama dili kullanılarak geliştirilmiştir.
SQLite: Hafif ve yerel bir veritabanı kullanılmıştır.
Windows Forms (WinForms): Kullanıcı arayüzü oluşturmak için Windows Forms kullanılmıştır.
## Fonksiyonlar
Film Listeleme: Mevcut filmleri listelemek için ComboBox kullanılır.
Seans Seçimi: Seçilen filmin uygun seans saatlerini görüntülemek için ComboBox kullanılır.
Koltuk Seçimi: Boş koltuklar arasından bilet satın almak için butonlar kullanılır.
Bilet Satışı: Seçilen koltuklar için bilet satış işlemi gerçekleştirilir.
Veritabanı İşlemleri: Veritabanından film, seans, salon ve bilet bilgileri çekilir ve güncellenir.
## Kurulum
Depoyu bilgisayarınıza klonlayın veya ZIP dosyası olarak indirin.
Visual Studio'da projeyi açın.
Proje bağımlılıklarını yüklemek için NuGet Paket Yöneticisi'ni kullanın.
Projeyi derleyin ve çalıştırın.
## Sınıflar
Bu proje aşağıdaki sınıflardan oluşmaktadır:
Film.cs:Filmleri temsil eden sınıfı içerir.
Salon.cs:Sinema salonlarını temsil eden sınıfı içerir.
Seans.cs:Film seanslarını temsil eden sınıfı içerir.
BiletBilgi.cs:Bilet rezervasyonlarını temsil eden sınıfı içerir.

## Kullanımı
###  Uygulama şu şekilde çalışır:
Program Çlıştırıldığında Windows Form açılır.Burdaki tüm veriler Sqlite'dan gelmektedir.Burda Vizyondaki filmler tabında Bugün oynayacak filmler ve bu filmlere ait  veriler  gösterilir.Burda combobox1 de film seçilir.Devam et butonuna basılır ve seans tabına geçilmiş olur.Burda seçilen film adı ve bugünün tarihi gözükür.Film seans saatleri combobox2 de gözükür ve biri seçilir. Devam et butonuna basılır ve salon tabına geçilmiş olur.Burda seçilen film ve seansa ait salon ile ilgili salon adı ,kapasitesi ve boş koltuk sayısı gösterilir. Devam et butonuna basılır ve bilet satış tabına geçilir.Musteri adı ve soyadı yerine girilir.Filmin oynayacağı gün yani bugün verisi gösterilir.Bilet adeti seçilir .1 bilet adeti fiyatı yazılı bu ekranda bilgilendirme amaçlı .Bu filme ait koltuklar sinema salonuna uygun olacak şekilde gösterilir.Burda o filme o seanstaki filme ait koltuklardan satılmış varsa kırmızı yoksa yeşil olarak koltukların rengi gözükür .Burda yukarıda giriilen bilet adeti kadar koltuk numarası seçilir.Bunlar ekranda seçilen koltuklar olarak yazdırılır.Seçilen koltuklar turuncu rengi alır.Bilet adeti ne göre toplam fiyat ekranda yazar.Satışı bitir  butonuna basınca bilet satılmış olur ve buraya kadar girilen veriler Sqlite data kayıt olur.Satılan bilet bilgileri tabına basılınca sQLite daki BiletBilgi tablosuna bağlanarak ordaki satılan bilet verileri gösterilir. 
Bu projeyi denerken örnek olarak Bodrum Seferi filmi 15:40 seansını deneyerek uygulamayı çalıştırabilirsiniz.
