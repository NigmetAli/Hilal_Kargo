using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Drawing.Imaging;

using System.Net; //HttpWebRequest ve Response için.
using System.Text; //Stringbuilder ve Encoding için
using System.Text.RegularExpressions; // regex için
using System.IO; //StreamReader için
/// <summary>
/// Summary description for ClassBLL
/// </summary>
public static class ClassBLL
{
    public static string SQLInjectionaKarsiTemizle(this string metin)
    {
        metin = Regex.Replace(metin, ",", "");
        metin = Regex.Replace(metin, "/", "");
        metin = Regex.Replace(metin, "\n", "");
        metin = Regex.Replace(metin, "/?", "");
        metin = Regex.Replace(metin, "/*", "");
        metin = Regex.Replace(metin, "'", "");
        metin = Regex.Replace(metin, "&", "");
        metin = Regex.Replace(metin, "<", "");
        metin = Regex.Replace(metin, ">", "");
        metin = Regex.Replace(metin, "=", "");

        return metin;
    }

    public static string BuSayfaninAdi(this System.Web.UI.Page sayfa)
    {
        string[] kelimeler = sayfa.AppRelativeVirtualPath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
        string syf = kelimeler[kelimeler.Length - 1];

        kelimeler = syf.Split(new string[] { ".aspx", "-" }, StringSplitOptions.RemoveEmptyEntries);
        return kelimeler[0];
    }

    public static bool PostBackControlBuMu(this System.Web.UI.Page sayfa, string kontrolAdi)
    {
        string postbackControlName = sayfa.Request.Params.Get("__EVENTTARGET");

        if (postbackControlName.EndsWith(kontrolAdi))
            return true;
        return false;
    }

    public static bool PostBackControlBuMu(this System.Web.UI.Page sayfa, System.Web.UI.Control cntrl)
    {
        string postbackControlName = sayfa.Request.Params.Get("__EVENTTARGET");

        if (postbackControlName == cntrl.ClientID)
            return true;
        return false;
    }

    public static string VirguldenSonraXKarakter(string deger, int karakterSayisi)
    {
        string donusDegeri = deger;

        if (deger.Contains(","))
        {
            string[] kelimeler = deger.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            if (kelimeler[1].Length > karakterSayisi)
                kelimeler[1] = kelimeler[1].Substring(0, karakterSayisi);

            donusDegeri = kelimeler[0] + "," + kelimeler[1];
        }

        return donusDegeri;
    }

    public static decimal VirguldenSonraXKarakter(decimal value, int karakterSayisi)
    {
        string deger = value.ToString();

        string donusDegeri = deger;

        if (deger.Contains(","))
        {
            string[] kelimeler = deger.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            if (kelimeler[1].Length > karakterSayisi)
                kelimeler[1] = kelimeler[1].Substring(0, karakterSayisi);

            donusDegeri = kelimeler[0] + "," + kelimeler[1];
        }

        return Convert.ToDecimal(donusDegeri);
    }

    public static string TarihiKes(DateTime tarih)
    {
        if (tarih != null)
        {
            return tarih.ToString().Substring(0, 10);
        }
        else
            return "";
    }

    public static string TarihiKes(object t)
    {
        if (t == DBNull.Value)
            return "";

        DateTime tarih = Convert.ToDateTime(t);
        if (tarih != null)
        {
            return tarih.ToString().Substring(0, 10);
        }
        else
            return "";
    }

    public static string IlkXKarakter(string deger, int X)
    {
        if (deger.Length > X)
            return deger.Substring(0, X);
        return deger;
    }

    public static string UrldenResimAdiGetir(string deger)
    {
        string[] kelimeler = deger.Split(new string[] { "/", "\\" }, StringSplitOptions.RemoveEmptyEntries);
        string resimUrl = kelimeler[kelimeler.Length - 1];

        return resimUrl;
    }

    public static string ResimdenTildayiKaldir(this string deger)
    {

        string dil = (string)HttpContext.Current.Session["dil"];

        if (dil == "en")
            return deger.Replace("~", "..");

        if (deger.StartsWith("~"))
            return deger.Substring(2, deger.Length - 2);
        return deger;
    }

    public static bool ResimBoyutlandir(string boyutlanacakResminYolu, string boyutlanmisResminYolu, int boyut, ImageFormat format)
    {
        Bitmap bmp = new Bitmap(boyutlanacakResminYolu);  //Küçülmesini istedigimiz resmi seçiyoruz
        using (Bitmap OriginalBM = bmp)
        {
            double ResimYukseklik = OriginalBM.Height;
            double ResimUzunluk = OriginalBM.Width;
            double oran = 0;
            if (ResimUzunluk > ResimYukseklik && ResimUzunluk > boyut) //Eğer resmin genişliği yüksekliginden büyükse veya 150 pxden büyükse
            {
                oran = ResimUzunluk / ResimYukseklik;
                ResimUzunluk = boyut; //Resmin genişliğini 150 olarak atayacak ve aşağıda o genişliğe göre yüksekliği bulacak.
                ResimYukseklik = boyut / oran;
            }
            else if (ResimYukseklik > ResimUzunluk && ResimYukseklik > boyut) //Buradada yukarıdaki işlemin tersini yapıp genişliği otomatik bulacak.
            {
                oran = ResimYukseklik / ResimUzunluk;
                ResimYukseklik = boyut;
                ResimUzunluk = boyut / oran;
            }
            else // genişlik yükseklik eşit
            {
                ResimYukseklik = boyut;
                ResimUzunluk = boyut;
            }

            Size newSize = new Size(Convert.ToInt32(ResimUzunluk), Convert.ToInt32(ResimYukseklik)); //Resmi yeniden boyutlandırıyoruz.

            Bitmap Resizebm = new Bitmap(OriginalBM, newSize);
            OriginalBM.Dispose();

            Resizebm.Save(boyutlanmisResminYolu, format);

        }


        return true;
    }

    public static string ZamanaGoreResimAdiGetir()
    {
        string resimadi = DateTime.Now.ToString().Replace(".", "");
        resimadi = resimadi.Replace(":", "");
        resimadi = resimadi.Replace(" ", "");
        resimadi = resimadi.Replace("/", "");
        resimadi = resimadi.Replace("\\", "");

        return resimadi;
    }

    public static bool DosyaKaydet(this System.Web.UI.WebControls.FileUpload fileupload, string yol, out string dosya, out string mesaj)
    {
        mesaj = "";
        dosya = yol;
        if (fileupload.HasFile)
        {
            string dosyamiz = fileupload.FileName.ToLower();
            try
            {
                string resimurl = ClassBLL.ZamanaGoreResimAdiGetir();

                dosya += "/" + resimurl;

                string yeniyol = System.Web.HttpContext.Current.Server.MapPath(yol) + "\\" + resimurl;

                fileupload.SaveAs(yeniyol);

                return true;
            }
            catch (Exception exc)
            {

                mesaj = exc.Message;
            }
            return false;
        }
        return false;
    }
    public static bool resimKaydet(this System.Web.UI.WebControls.FileUpload fileupload, string yol, out string resim, out string mesaj)
    {
        mesaj = "";
        resim = yol;

        if (fileupload.HasFile)
        {
            string tamponresim = fileupload.FileName.ToLower();

            if (!tamponresim.EndsWith("jpeg") && !tamponresim.EndsWith("gif") && !tamponresim.EndsWith("png") && !tamponresim.EndsWith("image/pjpeg") && !tamponresim.EndsWith("jpg"))
            {
                mesaj = "jpeg, jpg , png, gif formatlarından birini seçiniz...";
                return false;
            }

            try
            {
                string resimurl = ClassBLL.ZamanaGoreResimAdiGetir();

                string[] kelimeler = tamponresim.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                string uzanti = kelimeler[kelimeler.Length - 1];

                resimurl += "." + uzanti;
                resim += "/" + resimurl;

                string yeniyol = System.Web.HttpContext.Current.Server.MapPath(yol) + "\\" + resimurl;

                fileupload.SaveAs(yeniyol);

                return true;

            }
            catch (Exception exc)
            {
                mesaj = exc.Message;

            }

            return false;
        }
        return false;
    }

    public static bool resimKaydet(this System.Web.UI.WebControls.FileUpload fileupload, string yol, int boyut, out string resim, out string mesaj)
    {
        mesaj = "";
        resim = yol;


        if (fileupload.HasFile)
        {
            string tamponresim = fileupload.FileName.ToLower();

            if (!tamponresim.EndsWith("jpeg") && !tamponresim.EndsWith("gif") && !tamponresim.EndsWith("png") && !tamponresim.EndsWith("image/pjpeg") && !tamponresim.EndsWith("jpg"))
            {
                mesaj = "jpeg, jpg , png, gif formatlarından birini seçiniz...";
                return false;
            }

            try
            {
                string resimurl = ClassBLL.ZamanaGoreResimAdiGetir();

                string[] kelimeler = tamponresim.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                string uzanti = kelimeler[kelimeler.Length - 1];

                resimurl += "." + uzanti;
                resim += "/" + resimurl;

                string yeniyol = System.Web.HttpContext.Current.Server.MapPath(yol) + "\\" + resimurl;

                fileupload.SaveAs(yeniyol);

                ImageFormat imgformat = uzanti.resimFormati();

                ResimBoyutlandir(yeniyol, yeniyol, boyut, imgformat);

                return true;

            }
            catch (Exception exc)
            {
                mesaj = exc.Message;

            }

            return false;

        }
        return false;
    }

    public static bool resimKaydet2(this System.Web.UI.WebControls.FileUpload fileupload, string yol, out string resim, out string mesaj)
    {
        mesaj = "";
        resim = yol;

        if (fileupload.HasFile)
        {
            string tamponresim = fileupload.FileName.ToLower();

            if (!tamponresim.EndsWith("jpeg") && !tamponresim.EndsWith("gif") && !tamponresim.EndsWith("png") && !tamponresim.EndsWith("image/pjpeg") && !tamponresim.EndsWith("jpg"))
            {
                mesaj = "jpeg, jpg , png, gif formatlarından birini seçiniz...";
                return false;
            }

            try
            {
                string resimurl = ClassBLL.ZamanaGoreResimAdiGetir();

                string[] kelimeler = tamponresim.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                string uzanti = kelimeler[kelimeler.Length - 1];

                //resimurl += "." + uzanti;

                string buyukresim = resimurl + "_buyuk." + uzanti;
                string kucukresim = resimurl + "_kucuk." + uzanti;
                string ortaresim = resimurl + "." + uzanti;

                resim += "/" + ortaresim;

                string buyukresimyol = System.Web.HttpContext.Current.Server.MapPath(yol) + "\\" + buyukresim;
                string kucukresimyol = System.Web.HttpContext.Current.Server.MapPath(yol) + "\\" + kucukresim;
                string ortaresimyol = System.Web.HttpContext.Current.Server.MapPath(yol) + "\\" + ortaresim;

                fileupload.SaveAs(buyukresimyol); // buyuk resim kaydediliyor
                //fileupload.SaveAs(kucukresimyol); // buyuk resim kaydediliyor
                //fileupload.SaveAs(ortaresimyol); // buyuk resim kaydediliyor


                ImageFormat imgformat = uzanti.resimFormati();

                bool sonuc = ResimBoyutlandir(buyukresimyol, ortaresimyol, 256, imgformat); // orta resim kaydediliyor
                if (!sonuc)
                    return sonuc;
                sonuc = ResimBoyutlandir(buyukresimyol, kucukresimyol, 56, imgformat); // kucuk resim kaydediliyor
                if (!sonuc)
                    return sonuc;

                return true;

            }
            catch (Exception exc)
            {
                mesaj = exc.Message;

            }

            return false;
        }
        return false;
    }
    
    public static ImageFormat resimFormati(this string uzanti)
    {
        uzanti = uzanti.ToLower();
        switch (uzanti)
        {
            case "bmp": return ImageFormat.Bmp;
            case "emf": return ImageFormat.Emf;
            case "exif": return ImageFormat.Exif;
            case "gif": return ImageFormat.Gif;
            case "icon": return ImageFormat.Icon;
            case "jpg":
            case "jpeg":
            case "image/pjpeg": return ImageFormat.Jpeg;
            case "memorybmp": return ImageFormat.MemoryBmp;
            case "png": return ImageFormat.Png;
            case "tiff": return ImageFormat.Tiff;
            case "wmf": return ImageFormat.Wmf;
            default: return ImageFormat.Jpeg;
        }
    }

    public static string WhosDomainToolsFlagGetir(object ulke)
    {
        string u = ulke.ToString();

        if (u.Contains("-"))
        {
            string[] kelimeler = u.Split(new string[] { ".", "-" }, StringSplitOptions.RemoveEmptyEntries);
            return kelimeler[1].ToLower();
        }
        else if (u.Length > 2) return u.Substring(0, 2).ToLower();
        return u.ToLower();
    }

    public static string IcerikGetir(this string icerik, int karakterSayisi)
    {
        string sonuc = "";
        char[] metin = icerik.ToCharArray();
        for (int i = 0; i < metin.Length && sonuc.Length < karakterSayisi; i++)
        {
            if (metin[i] == '<')
            {
                while (metin[i] != '>')
                    i++;
            }
            else
                sonuc += metin[i];
        }
        sonuc = sonuc.Replace("&nbsp;", " ");
        return sonuc + "..";
    }

    public static string AyAdi(int ayno)
    {
        switch (ayno)
        {
            case 1: return "OCAK";
            case 2: return "ŞUBAT";
            case 3: return "MART";
            case 4: return "NİSAN";
            case 5: return "MAYIS";
            case 6: return "HAZİRAN";
            case 7: return "TEMMUZ";
            case 8: return "AĞUSTOS";
            case 9: return "EYLÜL";
            case 10: return "EKİM";
            case 11: return "KASIM";
            case 12: return "ARALIK";
        }

        return "HATA";
    }

    public static string YouTubeVideosundanResimBul(string videoLinki)
    {
        string sonuc = "";

        string[] kelimeler = videoLinki.Split(new string[] { "embed/", "src=" }, StringSplitOptions.RemoveEmptyEntries);
        string embeddenSonrasi = kelimeler[2];

        string[] kelimeler2 = embeddenSonrasi.Split(new string[] { "'", "\"", "?" }, StringSplitOptions.RemoveEmptyEntries);
        sonuc = "http://i3.ytimg.com/vi/" + kelimeler2[0] + "/default.jpg";
        //sonuc = "http://i1.ytimg.com/vi/" + kelimeler2[0] + "/default.jpg";
        //sonuc = "http://i2.ytimg.com/vi/" + kelimeler2[0] + "/default.jpg";
        //sonuc = "http://i3.ytimg.com/vi/" + kelimeler2[0] + "/default.jpg";

        return sonuc;
    }

    public static string BaskaSiteyeMailgonder(string url, string name, string phone, string konu, string email, string mesaj, string kime)
    {
        try
        {

            var ilkSayfaIcerigi = IlkIstek(url);
            var viewState = AlanDegeriniBul(ilkSayfaIcerigi, "__VIEWSTATE");
            var eventValidation = AlanDegeriniBul(ilkSayfaIcerigi, "__EVENTVALIDATION");
            var gonderilecekVeri = string.Format("{0}={1}",
                 HttpUtility.UrlEncode("name"),
                 HttpUtility.UrlEncode(name));
            gonderilecekVeri += string.Format("&{0}={1}",
                 HttpUtility.UrlEncode("phone"),
                 HttpUtility.UrlEncode(phone));
            gonderilecekVeri += string.Format("&{0}={1}",
                 HttpUtility.UrlEncode("email"),
                 HttpUtility.UrlEncode(email));
            gonderilecekVeri += string.Format("&{0}={1}",
                 HttpUtility.UrlEncode("subject"),
                 HttpUtility.UrlEncode(konu));
            gonderilecekVeri += string.Format("&{0}={1}",
                 HttpUtility.UrlEncode("towho"),
                 HttpUtility.UrlEncode(kime));
            gonderilecekVeri += string.Format("&{0}={1}",
                 HttpUtility.UrlEncode("message"),
                 HttpUtility.UrlEncode(mesaj));
            gonderilecekVeri += string.Format("&{0}={1}",
                 HttpUtility.UrlEncode("__EVENTTARGET"),
                 HttpUtility.UrlEncode("Button1"));
            gonderilecekVeri += string.Format("&{0}={1}",
                 HttpUtility.UrlEncode("__EVENTARGUMENT"),
                 HttpUtility.UrlEncode(string.Empty));
            gonderilecekVeri += string.Format("&{0}={1}",
                 HttpUtility.UrlEncode("__VIEWSTATE"),
                 HttpUtility.UrlEncode(viewState));
            gonderilecekVeri += string.Format("&{0}={1}",
                 HttpUtility.UrlEncode("__EVENTVALIDATION"),
                 HttpUtility.UrlEncode(eventValidation));
            var tampon = Encoding.UTF8.GetBytes(gonderilecekVeri);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = tampon.Length;
            webRequest.Proxy = new WebProxy((string)null, true);
            webRequest.CookieContainer = new CookieContainer();
            using (var istekStream = webRequest.GetRequestStream())
            {
                istekStream.Write(tampon, 0, tampon.Length);
            }
            var yanit = (HttpWebResponse)webRequest.GetResponse();
            var yanitIcerigi = string.Empty;
            using (var responseStream = yanit.GetResponseStream())
            {
                var streamReader = new StreamReader(responseStream);
                yanitIcerigi = streamReader.ReadToEnd();
            }

            return yanitIcerigi;
        }
        catch { return ""; }
    }

    private static string IlkIstek(string sayfaAdresi)
    {
        var webClient = new WebClient();
        using (var stream = webClient.OpenRead(sayfaAdresi))
        {
            var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }
    }

    private static string AlanDegeriniBul(string sayfaIcerigi, string alanAdi)
    {
        var pattern = "<input.*id=\"" + alanAdi + "\".*value=\"(?<deger>.*?)\".*/>";
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);
        var match = regex.Match(sayfaIcerigi);
        if (match != null && match.Groups["deger"].Success && match.Groups.Count > 0)
        {
            return match.Groups["deger"].Value;
        }
        return string.Empty;
    }
}