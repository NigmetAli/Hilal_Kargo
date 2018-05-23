using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Labelbilgi.Text = "<p class='msg error'><b>Hata Oluştu!</b></p>";
        if (!IsPostBack)
        {

            if (Request["cikis"] != null)
            {

            }
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       int sonuc = ClassDAL.SifreHatirlat(TextBoxemail.Text);
        
       switch (sonuc)
       {
           case 0:
               Labelbilgi.Text = "<p class='msg error'>Sistemsel Bir Hata Oluştu.Lütfen Daha Sonra Tekrar Deneyiniz.</p>";
               TextBoxemail.Text = "";
               break;
           case 2:
               Labelbilgi.Text = "<p class='msg done'>Kullanıcı Adı ve Şifreniz E-Mail Adresinize Gönderilmiştir.</p>";
               TextBoxemail.Text = "";
               break;
           case 3:
               Labelbilgi.Text = "<p class='msg error'>E-Mail Adresinize Bilgiler Gönderilirken Hata Oluştu.Lütfen Daha Sonra Tekrar Deneyiniz.</p>";
               TextBoxemail.Text = "";
               break;
           case 4:
               Labelbilgi.Text = "<p class='msg error'>Bu E-Mail Adresi ile İlişkili Kullanıcı Bulunmamaktadır..</p>";
               TextBoxemail.Text = "";
               break;
           default:
               Labelbilgi.Text = "<p class='msg error'>Sistemsel Bir Hata Oluştu.Lütfen Daha Sonra Tekrar Deneyiniz.</p>";
               TextBoxemail.Text = "";
               break;
       }
    }

    protected void Buttongiris_Click(object sender, EventArgs e)
    {
        List<kullanici> kullanicilar = kullanici.SelectAll();

        kullanici kul = (from k in kullanici.SelectAll()
                         where k.KullaniciAdi == TextBoxkullaniciadi.Text && k.Sifre == TextBoxsifre.Text
                         select k).FirstOrDefault();
        

        if (kul == null)
        {
            Labelbilgi.Text = "<p class='msg error'><b>Kullanıcı Adı ve/veya Şifre Hatalı! Tekrar Deneyiniz...</b></p>";
            return;
        }

        Session.Add("kullanici", kul);

        aktivite akt = aktivite.SelectByKullaniciId(kul.Id);

        if (akt != null)
            Session.Add("bilgi", "Merhaba<br/><b>" + kul.AdiSoyadi + "</b><br/>Son Giriş Zamanınız<br/><b>" + akt.Tarih.ToString() + "</b>");

        aktivite yeni = new aktivite(kul.Id, DateTime.Now);
        try
        {
            Result<int> sonuc = yeni.Insert();
        }
        catch { }

        Response.Redirect("haberler.aspx");

    }
}