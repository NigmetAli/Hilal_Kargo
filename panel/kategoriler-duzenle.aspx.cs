using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_kategoriler_duzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request["Id"]))
            {
                int id = Convert.ToInt32(Request["Id"]);

                Session.Add("Id", id);

                kategori duzenle = kategori.Select(id);
                adiTextBox.Text = duzenle.Adi;
                if (duzenle.FkUstKategori > 1)
                    DropDownList1.SelectedValue = duzenle.FkUstKategori.ToString();
                  
                CheckBox1.Checked = duzenle.Aktif;
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (adiTextBox.Text.Trim() == "")
        {
            Labelbilgi.Text = "<p class='msg warning'>Kategori adı belirtmelisiniz!</b></p>";
            return;
        }
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


        kategori duzenle = kategori.Select((int)Session["Id"]);

        duzenle.Adi = adiTextBox.Text;
        duzenle.Resim = Image1.ImageUrl;
        duzenle.Aktif = CheckBox1.Checked;

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
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("Üst Kategori Seçiniz", "1"));
    }

    protected void Button3_Click(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(Request["Id"]);


            kategori ur = kategori.Select(id);
            if (ur == null)
            {
                Labelbilgi.Text = "<p class='msg error'><b>KAYIT BULUNAMADI !</b></p>";
                return;
            }


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
                Response.Redirect("kategoriler.aspx");

            }

        
    }
}