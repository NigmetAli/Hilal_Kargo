﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_referanslarr_yeni : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string resim = "", mesaj = "";

        if (!FileUpload1.HasFile)
        {
            Labelbilgi.Text = "<p class='msg warning'><b>Resim Seçmelisiniz</b></p>";
            return;
        }

        if (ClassBLL.resimKaydet(FileUpload1, "~/panel/imgUrun", out resim, out mesaj))
        {
            Image1.ImageUrl = resim;
        }
        if (FileUpload1.HasFile && mesaj != "")
        {
            Labelbilgi.Text = mesaj;
            return;
        }
        referans yeni = new referans();

        yeni.Adi = adiTextBox.Text;

        yeni.Resim = Image1.ImageUrl;

        yeni.Aciklama = "";


        Result<int> sonuc = yeni.Insert();

        if (sonuc.HasError)
        {
            Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
            return;
        }
        else
        {
            Response.Redirect("referanslarr.aspx");
        }
    }
}