# Kütüphane-Otomasyon
Kütüphane yönetimini kolaylaştıran c# ve sql kullanarak yapılmış bir program


programın form görünüşleri "Proje formlar" klasöründe mevcuttur 

! Maalesef Sql dosyasını kaybettim , Proje formlar klasöründe yapısı var ordan bakarak benzerini yapabilirsiniz

kitap takibi, kullanıcı yönetimi, ödünç alma/iade işlemleri ve istatistiksel analizler gibi işlevleri içeren bir Windows Forms uygulaması olarak tasarlanmış. Proje yapısını incelediğimde şu dosya ve bileşenleri görüyorum:

📂 Proje Yapısı
Ana Modüller:

kitap_takip.cs → Kitap yönetimi ve takibi için.

kitap_eklee.cs → Yeni kitap eklemek için.

kayıt.cs → Kullanıcı kayıt işlemleri.

istatistikler.cs → Kütüphane ile ilgili istatistikleri görüntülemek için.

hakkında.cs → Uygulama hakkında bilgiler içeren pencere.

ayarlar.cs → Kullanıcı veya sistem ayarlarıyla ilgili bölüm.

Veritabanı:

Model1.edmx → Entity Framework kullanıyorsun gibi görünüyor. Bu, SQL Server veritabanı ile etkileşim için ORM (Object-Relational Mapping) kullanıldığını gösterir.

Kaynak Dosyaları:

.resx dosyaları (örneğin: person.resx, kitap_takip.resx) → Formlarda kullanılan yerelleştirme veya UI kaynaklarını içeren dosyalar olabilir.

Diğer Dosyalar:

App.config → Veritabanı bağlantı string’i ve konfigürasyon ayarları burada olabilir.

packages.config → NuGet bağımlılıklarını takip eden dosya.

📌 Projenin Genel İşleyişi
* Kullanıcılar Sisteme Kayıt Olur veya Giriş Yapar.

* Kitaplar Eklenir ve Takip Edilir.

* Kullanıcı yeni kitap ekleyebilir (kitap_eklee.cs).

* Kitaplar listelenebilir ve filtrelenebilir (kitap_takip.cs).

* Ödünç Alma ve İade İşlemleri Yapılır.

*** İstatistikler Gösterilir.

Hangi kitaplar en çok okunmuş?

En aktif kullanıcı kim?

* Ayarlar ve Kullanıcı Bilgileri Güncellenir.


