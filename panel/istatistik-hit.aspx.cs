using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_istatistik_hit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            List<SayacIp> sayacipsi = SayacIp.SelectAll().OrderByDescending(r=>r.Tarih).ToList();
            RptDaire.DataSource = sayacipsi;
            RptDaire.DataBind();
        }
    }
}