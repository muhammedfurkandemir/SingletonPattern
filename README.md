# SingletonPattern
Singleton deseninin amacı
Singleton bir nesnenin sadece bir örneğinin olduğundan emin olmak ve bu nesneye ihtiyacınız olduğunda kodunuzda her yerde aynı (ve tek örneğin) çağırılmasını sağlamak için kullanılır.

Sorun
Singleton deseni SOLID programlama prensiplerinin en başında gelen tekil sorumluluk prensibine (Ara: Single Responsibility Principle) aykırılığa neden olan iki sorunu tek seferde çözüyor:

Bir sınıfın tek bir örneğinin olduğuna emin olun: Neden bir sınıfa ait birden fazla örnek var önemli olsun ki? En sık karşılaşılan sebep paylaşılan bir kaynağa – örneğin bir veritabanı veya dosyaya erişimi kontrol etmektir.

Nasıl çalışıyor? Farzedin ki bir nesne oluşturdunuz, daha sonra bir başka yerde daha bu nesneye ihtiyacınız oldu ve tekrar oluşturdunuz. Eğer oluşturduğunuz bu nesne singleton desenindeyse yeni bir nesne yerine var olan mevcut nesne geri dönecektir.

Bu davranış normal bir oluşturucu (constructor) ile mümkün değildir, çünkü tasarımı gereği oluşturucular her zaman yeni bir nesne döndürmek zorundadır.

İstemciler sürekli aynı nesne ile çalıştıklarını farkında bilme olmayacaktır.
2. O örneğe global bir erişim noktası sağlayın. Bazı önemli objeleri saklamak için kullandığınız global değişkenler oluyor mu? Bu yöntem her ne kadar kullanışlı olsa da güvenilir değildir çünkü herhangi bir kod bu nesnelerin üzerine yazıp uygulamanızın çökmesine neden olabilir.

Singleton deseni aynı global değişkenlerde olduğu gibi nesneye istediğiniz yerde ulaşabilmesinizi sağlar ve aynı zamanda başka bir kodun nesnenizin üzerine yazmasını da engeller.

Bu sorunun bir yönü daha var: sorun 1’i çözen kodun programın her yerine dağılmasını istemezsiniz, bu çözümün tek bir sınıf içinde olması -özellikle de kodunuzun geri kalanı zaten ona bağlıysa- çok daha iyidir.

Çözüm
Tüm singleton uyarlamaları için aşağıdaki iki adım ortaktır:

Varsayılan constructor’ı özel (private) yapın, böylede diğer nesneler bu singleton sınıfı ile new operatörünü kullanamazlar.
Constructor olarak görev yapacak statik bir oluşturma metodu yazın. Aslında bu metod arka planda özel constructor’ı çağıracak ve bunu statik bir alana kaydedecektir. Bu metoda daha sonra gelen tüm çağrılar ön belleğe alınmış bu nesneyi gönderecektir.
Kodunuz Singleton sınıfına erişebiliyorsa Singleton’un statik metoduna da erişebilir. Bu metod her çağrıldığında aynı nesne döndürülecektir.

Uygulanabilirlik
Programınızda kullandığınız bir sınıfın tüm istemcilerin kullanabileceği sadece tek bir örneğinin olması için singleton desenini kullanabilirsiniz; örneğin bir programın farkı bölümlerinde kullanılan bir veritabanı nesnesi.

Singleton deseni kendi özel oluşturma metodu dışında nesne oluşturulasını engeller. Bu özel meto daha önce oluşturulmuş bir nesne varsa onu, yoksa yeni oluşturacacağı nesneyi döndürür.

Global değişkenler üzerinde daha sıkı bir kontrole ihtiyacınız olduğunda singleton desenini kullanın.

Global değişkenlerin aksine Singleton deseni bir sınıfın her zaman tek bir örneğini olmasını garanti eder. Singleton sınıfının kendisi dışında hiç bir şey önbellekteki örneği değiştiremez.

Not: Sınırlamayı ayarlayabilir ya da tamamen ortadan kaldırıp birden fazla Singleton örneği oluşturulmasını sağlayabilirsiniz. getInstance metodunuzun içeriğini değiştirerek sınıfınızın istediğiniz davranışı göstermesini sağlayabilirsiniz.

Diğer tasarım desenleri/kalıpları ile ilişkisi
Facade (yapısal tasarım deseni) sınıfları çoğu zaman Singleton’a dönüştürülebilir çünkü çoğu zaman tek bir facade nesnesi yeterlidir.
Eğer tüm paylaşılan durumları tek bir flyweight (yapısal tasarım deseni) nesnesine indirgeyebilseydiniz Flyweight Singleton’a benzeyebilirdi. Ancak bu tasarım desenleri arasında iki fark vardır;
Singleton’ların yalnızca tek bir örneği olmalıdır. Oysa bir flyweight sınıfı farklı içsel durumlara sahip birden çok örneğe sahip olabilir.
Singleton objeleri değiştirilebilir (mutable) olabilir fakat flyweight nesneleri değiştirilebilir değillerdir. (immutable)
Abstract Factory, Builder ve Prototype desenleri Singleton olarak uyarlanabilirler.
