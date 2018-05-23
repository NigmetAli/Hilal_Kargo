using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sbKurumsal = new StringBuilder();
        

        List<kurumsalSayfa> kurumsal = kurumsalSayfa.SelectAll();

        foreach (var item in kurumsal)
        {
            ltrKurumsalBaslik1.Text += "<li><a href='Kurumsal.aspx?Id="+item.Id+"'>" + item.Adi + "</a></li>";

        }

        haberler();
        Hizmetler();
    }

    public void haberler()
    {
        StringBuilder sbHaber = new StringBuilder();

        List<haber> haberler = haber.SelectAll().Take(2).ToList();

        foreach (var item in haberler)
        {
            sbHaber.Append("<div class=\"news-post\"><div class=\"icon\"></div><div class=\"news-content\"><figure class=\"image-thumb\"><img src="+ item.Resim.ResimdenTildayiKaldir() +" alt=\"\"></figure><a href=\"Haberler.aspx?Id="+ item.Id +"\">"+ item.Baslik.IcerikGetir(100) +"</a></div><div class=\"time\">June 21, 2016</div></div>");
        }

        ltrHaberler.Text = sbHaber.ToString();
    }

    public void Hizmetler()
    {
        StringBuilder sb2 = new StringBuilder();
        List<hizmet> hzmt = hizmet.SelectAll().OrderBy(a => Guid.NewGuid()).Take(4).ToList();
        foreach (var item in hzmt)
        {
            sb2.Append("<li><a href=\"#\">"+ item.Adi +"</a></li>");
        }

        ltrhizmet.Text = sb2.ToString();
    }
}
