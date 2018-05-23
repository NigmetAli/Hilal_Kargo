using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_baner_duzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["Id"].ToString()))
            {
                int id = Convert.ToInt32(Request["Id"].ToString());

                slider duzenle = slider.Select(id);

                adiTextBox.Text = duzenle.Yazi;

                Image1.ImageUrl = duzenle.Resim;
               

                //ListView1.DataSource = urunTablo.SelectByFkUrun(id);
                //ListView1.DataBind();
            }
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request["Id"].ToString());

        slider duzenle = slider.Select(id);


        string resim = "", mesaj = "";

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


        duzenle.Yazi = adiTextBox.Text;
        duzenle.Resim = Image1.ImageUrl;
       

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