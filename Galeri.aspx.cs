using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class Galeri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        List<referans> galeriUrunResim = referans.SelectAll().ToList();

        foreach (var item in galeriUrunResim)
        {
            sb.Append("<li class=\"portfolio-item gutter\"><div class=\"portfolio\"><div class=\"tt-overlay\"></div><img src=" + item.Resim.ResimdenTildayiKaldir() + " style='width:360px;height:240px' alt=\"\"><div class=\"portfolio-info\"><a href=" + item.Resim.ResimdenTildayiKaldir() + " class=\"links\"></a></div><!-- /.project-info --><ul class=\"portfolio-details\"><li><a class=\"tt-lightbox\" href=" + item.Resim.ResimdenTildayiKaldir() + "><i class=\"fa fa-search\"></i></a></li><li></li></ul></div><!-- /.portfolio --></li>");
        }
        
        ltrGaleriResim.Text = sb.ToString();
    }
}