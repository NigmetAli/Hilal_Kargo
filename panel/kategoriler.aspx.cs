using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class kategoriler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    //{
    //    Label IdLabel = e.Item.FindControl("IdLabel") as Label;
    //    int id = Convert.ToInt32(IdLabel.Text);

    //    if (e.CommandName == "sil")
    //    {
    //        kategori ur = kategori.Select(id);
    //        if (ur == null)
    //        {
    //            Labelbilgi.Text = "<p class='msg error'><b>KAYIT BULUNAMADI !</b></p>";
    //            return;
    //        }

    //        ur.Aktif = false;
    //        Result<int> sonuc = ur.Update();

    //        if (sonuc.HasError)
    //        {
    //            Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
    //            return;
    //        }
    //        else
    //        {
    //            Labelbilgi.Text = "<p class='msg done'><b>BAŞARIYLA SİLİNDİ...</b></p>";
    //            AccessDataSource1.Select(DataSourceSelectArguments.Empty);
    //            ListView1.DataBind();
    //        }

    //    }
    //    else if (e.CommandName == "duzenle")
    //    {
    //        Response.Redirect("kategoriler-duzenle.aspx?Id=" + id.ToString());
    //    }

    //}

    protected string kategoriGetir()
    {
        string sonuc = "<ul id='kategoriler' class='filetree'>";

        List<kategori> liste = kategori.SelectAll();

        IEnumerable<kategori> anabasliklar = from ana in liste
                                             where ana.FkUstKategori == 1
                                             select ana;

        foreach (kategori menu in anabasliklar)
        {
            yenileyen(menu, liste, ref sonuc);
        }

        sonuc += "</ul>";
        return sonuc;
    }

    protected void yenileyen(kategori menu, IEnumerable<kategori> liste, ref string sonuc)
    {

        IEnumerable<kategori> altbasliklar = from alt in liste
                                             where alt.FkUstKategori == menu.Id
                                             select alt;

        string kirmizi = "";

        if (!menu.Aktif)
        {
            kirmizi = "color:Red;";
        }

        if (altbasliklar.Count() > 0) // folder
        {
            sonuc += "<li><span class='folder'><a  style='" + kirmizi + " font-size: 14px; font-weight: bolder; padding-left: 5px;' href='kategoriler-duzenle.aspx?Id=" + menu.Id + "'>" + menu.Adi + "</a></span>";
            sonuc += "<ul style='background-color: transparent;'>";
            foreach (kategori altmenu in altbasliklar)
            {
                yenileyen(altmenu, liste, ref sonuc);
            }
            sonuc += "</ul></li>";
        }
        else // file
        {
            int KategoriId = Convert.ToInt32(Request["KategoriId"]);
            string classs = "";

            if (menu.Id == KategoriId)
                classs = "class='kutuKategoriAnaSeviye_selected'";


            sonuc += "<li><span class='file'><a " + classs + " style='" + kirmizi + " font-size: 14px; font-weight: bolder; padding-left: 5px;' href='kategoriler-duzenle.aspx?Id=" + menu.Id + "'>" + menu.Adi + "</a></span></li>";
        }
    }

   
}