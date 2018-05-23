using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_tagbulutu_duzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["Id"].ToString()))
            {
                int id = Convert.ToInt32(Request["Id"].ToString());

                ktlg duzenle = ktlg.Select(id);

                adiTextBox.Text = duzenle.Adi;

                LinkTxt.Text = duzenle.Link;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(Request["Id"].ToString());

        ktlg duzenle = ktlg.Select(id);

        duzenle.Adi = adiTextBox.Text.Trim();

        duzenle.Link = LinkTxt.Text.Trim();


        Result<int> sonuc = duzenle.Update();

        if (sonuc.HasError)
        {
            Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
            return;
        }
        else
        {
            Response.Redirect("tagbulutu.aspx");
        }
    }
}