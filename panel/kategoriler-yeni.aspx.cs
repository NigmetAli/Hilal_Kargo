using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_kategoriler_yeni : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (adiTextBox.Text.Trim() == "")
        {
            Labelbilgi.Text = "<p class='msg warning'>Kategori adı belirtmelisiniz!</b></p>";
            return;
        }
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

        kategori yeni = new kategori();
        yeni.FkUstKategori = Convert.ToInt32(DropDownList1.SelectedValue);
        yeni.Adi = adiTextBox.Text.Trim();
        yeni.Aktif = true;
        yeni.Resim = Image1.ImageUrl;

        Result<int> sonuc = yeni.Insert();
        
        if (sonuc.HasError)
        {
            Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
            return;
        }
        else
        {
            Response.Redirect("kategoriler.aspx");
        }
    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("Üst Kategori Seçiniz", "1"));
    }
   
}