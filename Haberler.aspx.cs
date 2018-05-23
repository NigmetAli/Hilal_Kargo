using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Haberler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        int gelenid = Convert.ToInt32(Request.QueryString["Id"]);

        List<haber> hzmt = haber.SelectAll();
        foreach (var item in hzmt)
        {
            sb.Append("<li><a href='Haberler.aspx?Id=" + item.Id + "' style='    padding: 12px 14px;font-size: 15px;'>" + item.Baslik + "</a></li>");

        }
        ltrHaberKategori.Text = sb.ToString();
        

        if (Request.QueryString["Id"] == null)
        {
            haber hz = haber.SelectAll().FirstOrDefault();
            ltrGelenHaberAdi.Text = hz.Baslik;
            ltrHaber.Text = hz.Yazi;
           
        }
        else
        {

            haber hz = haber.Select(gelenid);
            ltrGelenHaberAdi.Text = hz.Baslik;
            ltrHaber.Text = hz.Yazi;

        }




    }
}