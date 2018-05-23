using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_yonetim : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Expires = 1;
        Response.ExpiresAbsolute = DateTime.Now - new TimeSpan(0, 0, 1);
        Response.AddHeader("pragma", "no-cache");
        Response.AddHeader("cache-control", "private");
        Response.CacheControl = "no-cache";

        string[] kelimeler = Page.AppRelativeVirtualPath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
        string sayfa = kelimeler[kelimeler.Length - 1];

        kelimeler = sayfa.Split(new string[] { ".aspx", "-" }, StringSplitOptions.RemoveEmptyEntries);
        sayfa = kelimeler[0];

        if (Session["kullanici"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            if (Session["bilgi"] != null)
            {
                bilgi.InnerHtml = (string)Session["bilgi"];
            }


            switch (sayfa)
            {
                case "Default":
                    li_giris.Attributes.Add("class", "active");

                    altmenu.InnerHtml = "";
                    break;
                case "tagbulutu":
                    li_tag.Attributes.Add("class", "active");

                    altmenu.InnerHtml = "<li><strong><a href='tagbulutu-yeni.aspx'>Kelime Ekle</a></strong></li>";
                    break;
                case "profilim":
                    li_profil.Attributes.Add("class", "active");

                    altmenu.InnerHtml = "<li><strong><a href='profilim-sifredegistir.aspx'>Şifre Değiştir</a></strong></li>";
                    break;

                case "baner":
                    li_baner.Attributes.Add("class", "active");

                    altmenu.InnerHtml = "<li><strong><a href='baner-yeni.aspx'>Yeni Baner</a></strong></li>";
                    break;
                //case "lazerepilasyon":
                //    li_lazeruygulama.Attributes.Add("class", "active");

                //    altmenu.InnerHtml = "<li><strong><a href='lazerepilasyon-yeni.aspx'>Yeni Uygulama</a></strong></li>";
                //    break;
                case "haberler":
                    li_haber.Attributes.Add("class", "active");

                    altmenu.InnerHtml = "<li><strong><a href='haberler-yeni.aspx'>Yeni Haber</a></strong></li>";
                    break;
                //case "maillist":
                //    li_mail.Attributes.Add("class", "active");

                //    altmenu.InnerHtml = "<li><strong><a href='#'></a></strong></li>";
                //    break;
                //case "kategoriler":
                //    li_kategori.Attributes.Add("class", "active");

                //    altmenu.InnerHtml = "<li><strong><a href='kategoriler-yeni.aspx'>Yeni Kategori</a></strong></li>";
                //    break;
                //case "insankaynaklari":
                //    li_insankaynaklari.Attributes.Add("class", "active");

                //    altmenu.InnerHtml = "<li><strong><a href='#'></a></strong></li>";
                //    break;
                case "urunler":
                    li_urun.Attributes.Add("class", "active");

                    altmenu.InnerHtml = "<li><strong><a href='urunler-yeni.aspx'>Yeni Sertifika</a></strong></li>";
                    break;
                case "kurumsal":
                    li_kurum.Attributes.Add("class", "active");

                    altmenu.InnerHtml = "<li><strong><a href='kurumsal-yeni.aspx'>Yeni Sayfa</a></strong></li>";
                    break;
                case "mesajlar":
                    li_mesaj.Attributes.Add("class", "active");

                    altmenu.InnerHtml = "";
                    break;
                case "istatistik":
                    li_istatistik.Attributes.Add("class", "active");
                    altmenu.InnerHtml += "<li><strong><a href='istatistik.aspx'>Günlük İstatistik</a></strong></li>";
                    altmenu.InnerHtml += "<li><strong><a href='istatistik-hit.aspx'>Günlük Hit(IP ve Tarih Bazlı)</a></strong></li>";
                    altmenu.InnerHtml += "<li><strong><a href='istatistik-gunluk.aspx'>Toplam İstatistik</a></strong></li>";
                    //altmenu.InnerHtml += "<li><strong><a href='istatistik-ziyaretci.aspx'>Ziyaretçi Gönderenler</a></strong></li>";
                    //altmenu.InnerHtml += "<li><strong><a href='istatistik-gelenip.aspx'>Gelen Ip Adresleri</a></strong></li>";
                    break;
                case "referanslarr":
                    li_referans.Attributes.Add("class", "active");

                    altmenu.InnerHtml = "<li><strong><a href='referanslarr-yeni.aspx'>Yeni Resim</a></strong></li>";
                    break;
                case "hizmetler":
                    li_hizmet.Attributes.Add("class", "active");

                    altmenu.InnerHtml = "<li><strong><a href='hizmetler-yeni.aspx'>Yeni İcerik</a></strong></li>";
                    break;
                default:
                    li_giris.Attributes.Add("class", "active");

                    altmenu.InnerHtml = "";
                    break;

            }

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        // çıkış işlemleri
        Session.Abandon();

        Response.Redirect("Default.aspx");
    }
}
