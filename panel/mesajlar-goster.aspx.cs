using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_mesajlar_goster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !string.IsNullOrEmpty(Request["Id"]))
        {
            int id = Convert.ToInt32(Request["Id"]);
            iletisimmesaj mesaj = iletisimmesaj.Select(id);

            if (mesaj != null)
            {
                isim.InnerText = mesaj.Isim;
                email.HRef = "mailto:" + mesaj.Email;
                email.InnerText = mesaj.Email;
                konu.InnerText = mesaj.Konu;
                message.Value = mesaj.Mesaj;
                Label1.InnerText = mesaj.Telefon;

                mesaj.Durum = false;
                mesaj.Update();
            }
        }
    }
}