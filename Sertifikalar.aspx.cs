using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
public partial class Sertifikalar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();

        List<urunResim> galeriUrunResim = urunResim.SelectAll().ToList();

        foreach (var item in galeriUrunResim)
        {
            sb.Append("<li class=\"portfolio-item gutter\" style='height:300px;' ><div class=\"portfolio \"><div class=\"tt-overlay \"></div><img src=" + item.Resim.ResimdenTildayiKaldir() + " style='height:280px;' alt=\"\"><div class=\"portfolio-info\"></div><ul class=\"portfolio-details\"><li><a class=\"tt-lightbox\" href=\"" + item.Resim.ResimdenTildayiKaldir() + "\"><i class=\"fa fa-search \"></i></a></li></ul></div><!-- /.portfolio --></li>");
          
        
        }

        ltrGaleriResim.Text = sb.ToString();
    }
}