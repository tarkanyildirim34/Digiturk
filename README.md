 
Projede kullanidiginiz tasarim desenleri hangileridir? Bu desenleri neden kullandiniz? 
-Repository Pattern kullandim sebebi kod tekrarlarindan kaçinmak, hata yakalamayi kolaylastirmak kod yazimini ve okunusunu kolaylastirmak için.

 Kullandiginiz teknoloji ve kütüphaneler hakkinda daha önce tecrübeniz oldu mu? Tek tek
yazabilir misiniz?
-Bu projede kullanmis oldugum teknoloji ve kütüphaneler NopCommerce adinda açik kaynak kodlu e-ticaret yazilimi üzerinden esinlenerek modellendi daha önce bu yapida çalismam oldu.
- Mvc ile daha önce çalistim
-.Net Core Web Api ile daha önce eski isyerimde çalistigim oldu.
-.Net Core Web Api Authentication ile daha önce çalismam olmamisti

Daha genis vaktiniz olsaydi projeye neler eklemek isterdiniz? 
- Base service yazardim servis classlarimda crud islemlerimi base servisten türetirdim.
- Base api controller yazardim api controllerlarimda crud islemlerimi base servisten türetirdim.
- web api projesinde parametrelerini entityden degilde model classlarimdan parametre geçerdim.
- Auto Mapper yapardim.
- Authenticationdaki tokeni giris yapan kullanicida tutup controllerlara erisimi userdaki tokendan kontrol ettirirdim.(CurrentUser bilgisini tutardim)

Eklemek istediginiz bir yorumunuz var mi? 
-Projeyi olustururken bilmedigim teknolojileri arastirma firsati buldum,yaparken ve arastirirken keyif aldim.

Dipnot
Authentication aktif edildiginden ilk olarak /api/Login üzerinden application/json tipinde asagidaki kullanici bilgileri gönderilmelidir bu gönderim sonucunda token string olarak dönüs yapilmaktadir.
{
	"UserName":"admin",
	"Password":"123"
}
Daha sonra api controllerlara erisimde olusan token controllerlara gönderilmelidir. Ben testlerde postman uygulamasi üzerinden Authorization kismindan Bearer token seçildikten sonra Token key girdim ve testleri bu sekilde gerçeklestirdim.

Insert ve Update islemlerinde gönderilen post datasi json olarak asagidaki format gibi postman üzerinden gönderilebilir.
 {
        "articleId": 1,
        "Content": "Test Yorumu",
        "createUserId": 1,
        "createDate": "2019-07-31T14:01:44.863",
        "published": true,
        "deleted": false
    
    }

