using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_urunler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    // ARA
    protected void Ara(object sender, EventArgs e)
    {
        string filtre = "";

        //if (txtadi.Text != "")
        //{
        //    if (filtre != "")
        //        filtre += " and ";
        //    filtre += " Adi like '%" + txtadi.Text.Trim() + "%'";
        //}

        //if (DropDownList1.SelectedValue != "-1")
        //{
        //    if (filtre != "")
        //        filtre += " and ";
        //    filtre += " FkKategori = " + DropDownList1.SelectedValue;
        //}
        
        AccessDataSource1.Select(DataSourceSelectArguments.Empty);
        AccessDataSource1.FilterExpression = filtre;
        ListView1.DataBind();
    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
       // DropDownList1.Items.Insert(0, new ListItem("Tüm Kategoriler", "-1"));
    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        Label IdLabel = e.Item.FindControl("IdLabel") as Label;
        int id = Convert.ToInt32(IdLabel.Text);

        if (e.CommandName == "sil")
        {
            urun ur = urun.Select(id);
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
            Response.Redirect("urunler-duzenle.aspx?Id=" + id.ToString());
        }

    }
}