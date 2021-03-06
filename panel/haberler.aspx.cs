﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_haberler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    // ARA
    protected void Ara(object sender, EventArgs e)
    {
        //string filtre = "";

        //if (txtadi.Text != "")
        //{
        //    if (filtre != "")
        //        filtre += " and ";
        //    filtre = " Baslik like '%" + txtadi.Text.Trim() + "%' or AltBaslik like '%" + txtadi.Text.Trim() + "%' or  Resim like '%" +
        //        txtadi.Text.Trim() + "%' or  Yazi like '%" + txtadi.Text.Trim() + "%' or  Tarih like '%" + txtadi.Text.Trim() + "%'  ";
        //}

        //AccessDataSource1.Select(DataSourceSelectArguments.Empty);
        //AccessDataSource1.FilterExpression = filtre;
        //ListView1.DataBind();
    }
    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(ListView1.DataKeys[e.Item.DataItemIndex].Value);

        if (e.CommandName == "sil")
        {
            haber ur = haber.Select(id);
            if (ur == null)
            {
                Labelbilgi.Text = "<p class='msg error'><b>KAYIT BULUNAMADI !</b></p>";
                return;
            }

            //ur.Aktif = false;
            //Result<int> sonuc = ur.Update();
            Result<int> sonuc = ur.Delete();

            if (sonuc.HasError)
            {
                Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
                return;
            }
            else
            {
                Labelbilgi.Text = "<p class='msg done'><b>BAŞARIYLA SİLİNDİ...</b></p>";
                AccessDataSource1.Select(DataSourceSelectArguments.Empty);
                ListView1.DataBind();
            }

        }
        else if (e.CommandName == "duzenle")
        {
            Response.Redirect("haberler-duzenle.aspx?Id=" + id.ToString());
        }

    }
}