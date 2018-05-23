using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        List<slider> sld = slider.SelectAll();
        foreach (var item in sld)
        {
            sb.Append("<li data-index=\"rs-4\" data-transition=\"slidingoverlayhorizontal\" data-slotamount=\"default\" data-easein=\"default\" data-easeout=\"default\" data-masterspeed=\"default\" data-thumb=" + item.Resim.ResimdenTildayiKaldir() + " data-rotate=\"0\" data-saveperformance=\"off\" data-title=\"Web Show\" data-description=\"\"><img src=" + item.Resim.ResimdenTildayiKaldir() + "  alt=\"\"  data-bgposition=\"center center\" data-bgfit=\"cover\" data-bgrepeat=\"no-repeat\" class=\"rev-slidebg\" data-bgparallax=\"6\" data-no-retina></li>");

        }

        ltrslider.Text = sb.ToString();
        hizmetget();
        kurumsalicerik(700);
        galeriBolumu();
    }



    public void hizmetget()
    {
        StringBuilder sb2 = new StringBuilder();
        List<hizmet> hzmt = hizmet.SelectAll().OrderBy(a => Guid.NewGuid()).Take(3).ToList();
        foreach (var item in hzmt)
        {
            sb2.Append("<div class=\"col-sm-12 col-md-4 col-xs-12\"><div class=\"services-grid-1\"><div class=\"service-image\"><img alt=\"\" src=" + item.Resim.ResimdenTildayiKaldir() + " style='width:100%;height:240px;'></div><div class=\"services-text\"><h4 style='font-size:18px;' >" + item.Adi + "</h4><p>" + item.Aciklama.IcerikGetir(200) + "</p></div><div class=\"more-about\"><a class=\"btn btn-primary btn-lg\" href=\"Sehirici.aspx\">Detaylı İncele <i class=\"fa fa-chevron-circle-right\"></i></a></div></div><!-- end services-grid-1 --></div>");
        }

        ltrhizmet.Text = sb2.ToString();
    }
    public void kurumsalicerik(int uzunluk)
    {
        StringBuilder sb3 = new StringBuilder();
        kurumsalSayfa krm = kurumsalSayfa.SelectAll().FirstOrDefault();
        ltrbasalik.Text = krm.Adi;
        ltricerik.Text = krm.Icerik.IcerikGetir(uzunluk) + "<span><a href='Kurumsal.aspx?Id=" + krm.Id + "'>Devamı</a></span>";

    }

    public void galeriBolumu()
    {
        StringBuilder sbGaleri = new StringBuilder();

        List<referans> galeriUrunResim = referans.SelectAll().OrderBy(b => Guid.NewGuid()).Take(6).ToList();

        foreach (var item in galeriUrunResim)
        {
            sbGaleri.Append("<li class=\"portfolio-item gutter\"><div class=\"portfolio\"><div class=\"tt-overlay\"></div><img src=" + item.Resim.ResimdenTildayiKaldir() + " style='width:360px;height:240px' alt=\"\"><div class=\"portfolio-info\"><a href=" + item.Resim.ResimdenTildayiKaldir() + " class=\"links\"></a></div><!-- /.project-info --><ul class=\"portfolio-details\"><li><a class=\"tt-lightbox\" href=" + item.Resim.ResimdenTildayiKaldir() + "><i class=\"fa fa-search\"></i></a></li><li></li></ul></div><!-- /.portfolio --></li>");
        }

        ltrAnasayfaGaleri.Text = sbGaleri.ToString();
    }
}