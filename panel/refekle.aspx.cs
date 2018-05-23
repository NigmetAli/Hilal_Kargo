using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_refekle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            kurumsalSayfa hakkimizda = kurumsalSayfa.Select(6);

            hakkimizdaCKEditorControl.Text = hakkimizda.Icerik;


        }
    }
    // hakkımızda
    protected void Button1_Click(object sender, EventArgs e)
    {
        kurumsalSayfa hakkimizda = kurumsalSayfa.Select(6);

        hakkimizda.Icerik = hakkimizdaCKEditorControl.Text;

        Result<int> sonuc = hakkimizda.Update();
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