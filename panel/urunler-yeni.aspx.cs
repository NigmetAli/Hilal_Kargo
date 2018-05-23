using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_urunler_yeni : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
 
    protected void Button1_Click(object sender, EventArgs e)
    {
        string resim = "",mesaj="" ;

        if (!FileUpload1.HasFile)
        {
            Labelbilgi.Text = "<p class='msg warning'><b>Resim Seçmelisiniz</b></p>";
            return;
        }

        if (ClassBLL.resimKaydet(FileUpload1, "~/panel/imgUrun",out resim, out mesaj))
        {
            Image1.ImageUrl = resim;
        }
        if (FileUpload1.HasFile && mesaj != "")
        {
            Labelbilgi.Text = mesaj;
            return;
        }
        urun yeni = new urun();

        yeni.Adi = adiTextBox.Text;
        yeni.Aciklama = " ";
        yeni.Resim = Image1.ImageUrl;
        yeni.Aktif = true;
        yeni.FkKategori = 0;
        yeni.Kumas = "";
        yeni.Aciklama = "";

        Result<int> sonuc = yeni.Insert();

        if (sonuc.HasError)
        {
            Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
            return;
        }
        else
        {
            Response.Redirect("urunler.aspx");
        }
    }
}