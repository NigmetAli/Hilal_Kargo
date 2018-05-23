using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_kurumsal_yeni : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string resim = "", mesaj = "";


        kurumsalSayfa yeni = new kurumsalSayfa();

        yeni.Adi = adiTextBox.Text;
        yeni.Icerik = aciklamaCKEditorControl.Text;
       
        Result<int> sonuc = yeni.Insert();

        if (sonuc.HasError)
        {
            Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
            return;
        }
        else
        {
            Response.Redirect("kurumsal.aspx");
        }
    }
}