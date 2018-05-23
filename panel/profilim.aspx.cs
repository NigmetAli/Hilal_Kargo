using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class profilim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            kullanici kul = (kullanici)Session["kullanici"];

            if (kul != null)
            {
                AdiTextBox.Text = kul.AdiSoyadi;
                telTextBox.Text = kul.Tel;
                MailTextBox.Text = kul.Mail;
                adresTextBox.Text = kul.Adres;
                kullaniciAdiTextBox.Text = kul.KullaniciAdi;
                sifre1TextBox1.Text = kul.Sifre;
            }
            else
                Response.Redirect("default.aspx");
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        kullanici kul = (kullanici)Session["kullanici"];

        Result<int> sonuc = new Result<int>(new Exception("Hata Oluştu!"));

        if (kul != null)
        {
            kul.AdiSoyadi = AdiTextBox.Text.Trim();
            kul.Tel = telTextBox.Text.Trim();
            kul.Mail = MailTextBox.Text.Trim();
            kul.Adres = adresTextBox.Text.Trim();
            kul.KullaniciAdi = kullaniciAdiTextBox.Text.Trim();
            kul.Sifre = sifre1TextBox1.Text.Trim();

            sonuc = kul.Update();
        }

        if (sonuc.HasError)
        {
            Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
            Session.Add("kullanici", kul);
            return;
        }
        else
        {
            Labelbilgi.Text = "<p class='msg done'><b>KAYIT BAŞARILI...</b></p>";
        }
    }
}