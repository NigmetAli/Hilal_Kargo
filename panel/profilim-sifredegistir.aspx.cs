using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_sifre_degistir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(kullaniciAdiTextBox.Text))
        {
            Labelbilgi.Text = "<p class='msg warning'><b>Kullanıcı adınızı girmelisiniz</b></p>";
            return;
        }
        if (string.IsNullOrEmpty(Eskisifre.Text))
        {
            Labelbilgi.Text = "<p class='msg warning'><b>Eski şifrenizi girmelisiniz</b></p>";
            return;
        }
        if (string.IsNullOrEmpty(yenisifre1.Text))
        {
            Labelbilgi.Text = "<p class='msg warning'><b>Yeni şifre girmelisiniz</b></p>";
            return;
        }
        if (string.IsNullOrEmpty(yenisifre2.Text))
        {
            Labelbilgi.Text = "<p class='msg warning'><b>Şifre Tekrarını girmelisiniz</b></p>";
            return;
        }
        if (yenisifre1.Text.Length < 6)
        {
            Labelbilgi.Text = "<p class='msg warning'><b>Şifreniz en az 6 karakterden oluşmalı</b></p>";
            return;
        }

        if (yenisifre1.Text != yenisifre2.Text)
        {
            Labelbilgi.Text = "<p class='msg warning'><b>Girdiğiniz şifreler aynı değil!</b></p>";
            return;
        }


        kullanici kull = (kullanici)Session["kullanici"];

        Result<int> sonuc = new Result<int>(new Exception("Hata Oluştu!"));

        if (kull != null)
        {
            if (kull.KullaniciAdi != kullaniciAdiTextBox.Text.Trim() || kull.Sifre != Eskisifre.Text.Trim())
            {
                Labelbilgi.Text = "<p class='msg error'><b>Kullanıcı Adı ve/veya Şifre Hatalı! Tekrar Deneyiniz...</b></p>";
                return;
            }

            kull.Sifre = yenisifre1.Text.Trim();

            sonuc = kull.Update();
        }

        if (sonuc.HasError)
        {
            Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
            return;
        }
        else
        {
            Labelbilgi.Text = "<p class='msg done'><b>Kayıt Başarılı...</b></p>";
        }

    }
}