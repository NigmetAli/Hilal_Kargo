using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Hizmetler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        int gelenid = Convert.ToInt32(Request.QueryString["Id"]);

        List<hizmet> hzmt = hizmet.SelectAll().OrderBy(z => z.Sira).ToList();
        foreach (var item in hzmt)
        {
            sb.Append("<li><a href='Hizmetler.aspx?Id=" + item.Id + "' style='    padding: 12px 14px;font-size: 15px;'>" + item.Adi + "</a></li>");

        }
        ltrhizmetkat.Text = sb.ToString();


        if (Request.QueryString["Id"] == null)
        {
            hizmet hz = hizmet.SelectAll().FirstOrDefault();
            ltrgelenhizmetadi.Text = hz.Adi;
            ltraciklama.Text = hz.Aciklama;

        }
        else
        {

            hizmet hz = hizmet.Select(gelenid);
            ltrgelenhizmetadi.Text = hz.Adi;
            ltraciklama.Text = hz.Aciklama;

        }




    }
}