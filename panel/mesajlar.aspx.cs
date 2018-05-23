using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_mesajlar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        Label IdLabel = e.Item.FindControl("IdLabel") as Label;
        int id = Convert.ToInt32(IdLabel.Text);

        Response.Redirect("mesajlar-goster.aspx?Id=" + id.ToString());


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<int> islenecekler = islenecekMesajlar();
        if (islenecekler == null || islenecekler.Count == 0)
        {
            Labelbilgi.Text = "<p class='msg warning'><b>Hiçbir kayıt seçmediniz!</b></p>";
            return;
        }


        foreach (int id in islenecekler)
        {
            iletisimmesaj mesaj = iletisimmesaj.Select(id);
            mesaj.Durum = false;// okundu
            mesaj.Update();
        }
        AccessDataSource1.Select(DataSourceSelectArguments.Empty);
        ListView1.DataBind();
    }

    protected List<int> islenecekMesajlar()
    {
        List<int> liste = new List<int>();

        foreach (ListViewDataItem satir in ListView1.Items)
        {
            CheckBox cb = satir.FindControl("CheckBox1") as CheckBox;
            if (cb != null && cb.Checked)
            {
                Label IdLabel = satir.FindControl("IdLabel") as Label;
                int id = Convert.ToInt32(IdLabel.Text);

                liste.Add(id);
            }
        }

        return liste;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        List<int> islenecekler = islenecekMesajlar();
        if (islenecekler == null || islenecekler.Count == 0)
        {
            Labelbilgi.Text = "<p class='msg warning'><b>Hiçbir kayıt seçmediniz!</b></p>";
            return;
        }

        foreach (int id in islenecekler)
        {
            iletisimmesaj mesaj = iletisimmesaj.Select(id);
            mesaj.Durum = true;// okunmadı
            mesaj.Update();
        }
        AccessDataSource1.Select(DataSourceSelectArguments.Empty);
        ListView1.DataBind();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        List<int> islenecekler = islenecekMesajlar();
        if (islenecekler == null || islenecekler.Count == 0)
        {
            Labelbilgi.Text = "<p class='msg warning'><b>Hiçbir kayıt seçmediniz!</b></p>";
            return;
        }

        foreach (int id in islenecekler)
        {
            iletisimmesaj mesaj = iletisimmesaj.Select(id);
            mesaj.Delete();
        }
        AccessDataSource1.Select(DataSourceSelectArguments.Empty);
        ListView1.DataBind();

    }
}