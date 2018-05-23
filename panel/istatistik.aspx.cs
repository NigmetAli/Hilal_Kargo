using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_istatistik : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            List<tblSayacGunluk> listele = tblSayacGunluk.SelectAll().OrderByDescending(r=>r.Gun).ToList();
            RptDaire.DataSource = listele;
            RptDaire.DataBind();
        }
    }
}