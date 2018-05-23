using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_bayiler_duzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["Id"].ToString()))
            {
                int id = Convert.ToInt32(Request["Id"].ToString());

                bayi duzenle = bayi.Select(id);

                adiTextBox.Text = duzenle.Bayi_adi;

                Image1.ImageUrl = duzenle.Resim;

                aciklamaCKEditorControl.Text = duzenle.Bayi_aciklama;
            }
        }
              
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request["Id"].ToString());

        bayi duzenle = bayi.Select(id);


        string resim = "", mesaj = "";

        if (FileUpload1.HasFile)
        {

            if (ClassBLL.resimKaydet(FileUpload1, "~/panel/imgUrun",700, out resim, out mesaj))
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


        duzenle.Bayi_adi = adiTextBox.Text;
        duzenle.Resim = Image1.ImageUrl;
        duzenle.Bayi_aciklama = aciklamaCKEditorControl.Text;



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