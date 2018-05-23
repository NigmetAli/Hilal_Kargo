using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kurumsal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        int gelenid = Convert.ToInt32(Request.QueryString["Id"]);
        if (Request.QueryString["Id"] == null)
        {
            kurumsalSayfa krm = kurumsalSayfa.SelectAll().FirstOrDefault();
            ltrbaslik.Text = krm.Adi;
            ltricerik.Text = krm.Icerik;

        }
        else
        {

            kurumsalSayfa krm = kurumsalSayfa.Select(gelenid);
            ltrbaslik.Text = "KURUMSAL / "+krm.Adi;
            ltricerik.Text = krm.Icerik;
            

        }


    }
}