using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_katalogg_duzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["Id"] != null)
            {
                int id = Convert.ToInt32(Request["Id"]);

                ktlg hab = ktlg.Select(id);

                adiTextBox.Text = hab.Adi;
                //altbaslikTextBox1.Text = hab.AltBaslik;
                //Image1.ImageUrl = hab.Resim;
                //yazickeditor.Text = hab.Yazi;
                //tarihTextBox1.Text = hab.Tarih;
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        //string resim = "", mesaj = "";


        //if (ClassBLL.resimKaydet(FileUpload1, "~/panel/imgUrun", out resim, out mesaj))
        //{
        //    Image1.ImageUrl = resim;
        //}
        //if (FileUpload1.HasFile && mesaj != "")
        //{
        //    Labelbilgi.Text = mesaj;
        //    return;
        //}

        int id = Convert.ToInt32(Request["Id"]);

        string ad = "http://";



        if (ktlgTextBox.Text.StartsWith(ad))
        {
            ktlgTextBox.Text = ktlgTextBox.Text;
        }
        else
        {
            ktlgTextBox.Text = ad + ktlgTextBox.Text;

        }


        ktlg duzenle = ktlg.Select(id);

        duzenle.Adi = adiTextBox.Text;
        //duzenle.AltBaslik = altbaslikTextBox1.Text;
        //duzenle.Resim = Image1.ImageUrl;
        duzenle.Link = ktlgTextBox.Text;
        //duzenle.Tarih = tarihTextBox1.Text;
        //duzenle.Aktif = true;

        Result<int> sonuc = duzenle.Update();

        if (sonuc.HasError)
        {
            Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
            return;
        }
        else
        {
            Labelbilgi.Text = "<p class='msg done'><b>Kayıt Başarılı...</b></p>";
        }
    }
}