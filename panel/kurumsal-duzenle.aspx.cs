using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_kurumsal_duzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["Id"].ToString()))
            {
                int id = Convert.ToInt32(Request["Id"].ToString());

                kurumsalSayfa duzenle = kurumsalSayfa.Select(id);

                adiTextBox.Text = duzenle.Adi;
                aciklamaCKEditorControl.Text = duzenle.Icerik;
               

                //ListView1.DataSource = urunTablo.SelectByFkUrun(id);
                //ListView1.DataBind();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request["Id"].ToString());

        kurumsalSayfa duzenle = kurumsalSayfa.Select(id);


       


        duzenle.Adi = adiTextBox.Text;
        duzenle.Icerik = aciklamaCKEditorControl.Text;


        Result<int> sonuc = duzenle.Update();

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