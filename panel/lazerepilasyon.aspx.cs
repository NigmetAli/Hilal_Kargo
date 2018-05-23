using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_lazerepilasyon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        Label IdLabel = e.Item.FindControl("IdLabel") as Label;
        int id = Convert.ToInt32(IdLabel.Text);

        if (e.CommandName == "sil")
        {
            lazer ur = lazer.Select(id);
            if (ur == null)
            {
                Labelbilgi.Text = "<p class='msg error'><b>KAYIT BULUNAMADI !</b></p>";
                return;
            }


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
            Response.Redirect("lazerepilasyon-duzenle.aspx?Id=" + id.ToString());
        }

    }
}