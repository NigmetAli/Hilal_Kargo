using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_urunler_duzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["Id"].ToString()))
            {
                int id = Convert.ToInt32(Request["Id"].ToString());
                
                urun duzenle = urun.Select(id);

                adiTextBox.Text = duzenle.Adi;
               
                Image1.ImageUrl = duzenle.Resim;
                //DropDownList2.SelectedValue = duzenle.FkKategori.ToString();
              

                //ListView1.DataSource = urunTablo.SelectByFkUrun(id);
                //ListView1.DataBind();
                int id2 = Convert.ToInt32(Request["Id"].ToString());

                Session.Add("urunid", id2);
            }
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request["Id"].ToString());

        urun duzenle = urun.Select(id);


        string resim = "",mesaj="";

        if (FileUpload1.HasFile)
        {

            if (ClassBLL.resimKaydet(FileUpload1, "~/panel/imgUrun", out resim, out mesaj))
            {
                Image1.ImageUrl = resim;
            }
            if (FileUpload1.HasFile && mesaj != "")
            {
                Labelbilgi.Text = mesaj;
                return;
            }
        resim = Image1.ImageUrl;
        }

        
        duzenle.Adi = adiTextBox.Text;
        duzenle.Resim = Image1.ImageUrl;
        duzenle.Aciklama = " ";
       // duzenle.FkKategori = Convert.ToInt32(DropDownList2.SelectedValue);
        
        //duzenle.Aciklama = aciklamaCKEditorControl.Text;


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
    // resim sil
    protected void Button3_Click(object sender, EventArgs e)
    {

        string resim = "", mesaj = "";

        //if (!FileUpload4.HasFile)
        //{
        //    Labelbilgi.Text = "<p class='msg warning'><b>Resim Seçmediniz!</b></p>";
        //    return;
        //}
        //if (ClassBLL.resimKaydet2(FileUpload4, "~/panel/imgUrun", out resim, out mesaj))
        //{
        //    //Image1.ImageUrl = resim;
        //}
        //if (FileUpload4.HasFile && mesaj != "")
        //{
        //    Labelbilgi.Text = mesaj;
        //    return;
        //}

        urunResim yeni = new urunResim();

        yeni.FkUrun =   Convert.ToInt32(Request["Id"].ToString());
        yeni.Resim = resim;

        Result<int> sonuc = yeni.Insert();

        if (sonuc.HasError)
        {
            Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
            return;
        }
        else
        {
            //Labelbilgi.Text = "<p class='msg done'><b>Kayıt Başarılı...</b></p>";
            //AccessDataSource2.Select(DataSourceSelectArguments.Empty);
            //Repeater1.DataBind();
        }

    }
    // resim sil
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Label IdLabel = e.Item.FindControl("IdLabel") as Label;
        int id = Convert.ToInt32(IdLabel.Text);

        if (e.CommandName == "sil")
        {
            urunResim silinecek = urunResim.Select(id);
            if (silinecek == null)
            {
                Labelbilgi.Text = "<p class='msg error'><b>KAYIT BULUNAMADI !</b></p>";
                return;
            }

            Result<int> sonuc = silinecek.Delete();

            //if (sonuc.HasError)
            //{
            //    Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
            //    return;
            //}
            //else
            //{
            //    Labelbilgi.Text = "<p class='msg done'><b>BAŞARIYLA SİLİNDİ...</b></p>";
            //    AccessDataSource2.Select(DataSourceSelectArguments.Empty);
            //    Repeater1.DataBind();
            //}

        }

    }
   
     
}