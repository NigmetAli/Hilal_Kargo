using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_katalogg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(ListView1.DataKeys[e.Item.DataItemIndex].Value);

        if (e.CommandName == "sil")
        {
            ktlg ur = ktlg.Select(id);
            if (ur == null)
            {
                Labelbilgi.Text = "<p class='msg error'><b>KAYIT BULUNAMADI !</b></p>";
                return;
            }

            //ur.Aktif = false;
            //Result<int> sonuc = ur.Update();
            Result<int> sonuc = ur.Delete();

            if (sonuc.HasError)
            {
                Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
                return;
            }
            else
            {
                Labelbilgi.Text = "<p class='msg done'><b>BAŞARIYLA SİLİNDİ...</b></p>";
                AccessDataSource1.Select(DataSourceSelectArguments.Empty);
                ListView1.DataBind();
            }

        }
        else if (e.CommandName == "duzenle")
        {
            Response.Redirect("katalogg-duzenle.aspx?Id=" + id.ToString());
        }

    }
}