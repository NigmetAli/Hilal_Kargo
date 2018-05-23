using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_katalogg_yeni : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string resim = "", mesaj = "";

        //if (!FileUpload1.HasFile)
        //{
        //    Labelbilgi.Text = "<p class='msg error'><b>Resim Dosyası Seçmelisiniz!</b></p>";
        //    return;
        //}

        //if (ClassBLL.resimKaydet(FileUpload1, "~/panel/imgUrun", out resim, out mesaj))
        //{
        //    //Image1.ImageUrl = resim;
        //}
        //if (FileUpload1.HasFile && mesaj != "")
        //{
        //    Labelbilgi.Text = mesaj;
        //    return;
        //}
        string ad = "http://";



        if (ktlgTextBox.Text.StartsWith(ad))
        {
            ktlgTextBox.Text = ktlgTextBox.Text;
        }
        else 
        {
            ktlgTextBox.Text = ad + ktlgTextBox.Text;
        
        }


        ktlg yeni = new ktlg();

        yeni.Adi = adiTextBox.Text;
        yeni.Link = ktlgTextBox.Text;

        Result<int> sonuc = yeni.Insert();

        if (sonuc.HasError)
        {
            Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
            return;
        }
        else
        {
            Response.Redirect("katalogg.aspx");
        }
    }
}