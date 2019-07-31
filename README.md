 
Projede kullanidiginiz tasarim desenleri hangileridir? Bu desenleri neden kullandiniz? 
-Repository Pattern kullandim sebebi kod tekrarlarindan ka�inmak, hata yakalamayi kolaylastirmak kod yazimini ve okunusunu kolaylastirmak i�in.

 Kullandiginiz teknoloji ve k�t�phaneler hakkinda daha �nce tecr�beniz oldu mu? Tek tek
yazabilir misiniz?
-Bu projede kullanmis oldugum teknoloji ve k�t�phaneler NopCommerce adinda a�ik kaynak kodlu e-ticaret yazilimi �zerinden esinlenerek modellendi daha �nce bu yapida �alismam oldu.
- Mvc ile daha �nce �alistim
-.Net Core Web Api ile daha �nce eski isyerimde �alistigim oldu.
-.Net Core Web Api Authentication ile daha �nce �alismam olmamisti

Daha genis vaktiniz olsaydi projeye neler eklemek isterdiniz? 
- Base service yazardim servis classlarimda crud islemlerimi base servisten t�retirdim.
- Base api controller yazardim api controllerlarimda crud islemlerimi base servisten t�retirdim.
- web api projesinde parametrelerini entityden degilde model classlarimdan parametre ge�erdim.
- Auto Mapper yapardim.
- Authenticationdaki tokeni giris yapan kullanicida tutup controllerlara erisimi userdaki tokendan kontrol ettirirdim.(CurrentUser bilgisini tutardim)

Eklemek istediginiz bir yorumunuz var mi? 
-Projeyi olustururken bilmedigim teknolojileri arastirma firsati buldum,yaparken ve arastirirken keyif aldim.

Dipnot
Authentication aktif edildiginden ilk olarak /api/Login �zerinden application/json tipinde asagidaki kullanici bilgileri g�nderilmelidir bu g�nderim sonucunda token string olarak d�n�s yapilmaktadir.
{
	"UserName":"admin",
	"Password":"123"
}
Daha sonra api controllerlara erisimde olusan token controllerlara g�nderilmelidir. Ben testlerde postman uygulamasi �zerinden Authorization kismindan Bearer token se�ildikten sonra Token key girdim ve testleri bu sekilde ger�eklestirdim.

Insert ve Update islemlerinde g�nderilen post datasi json olarak asagidaki format gibi postman �zerinden g�nderilebilir.
 {
        "articleId": 1,
        "Content": "Test Yorumu",
        "createUserId": 1,
        "createDate": "2019-07-31T14:01:44.863",
        "published": true,
        "deleted": false
    
    }

