using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_hizmetler_yeni : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            ddlDoldur();
        }
    }
    public static string ToLowerFonksiyonu(string deger)
    {
        CultureInfo c = CultureInfo.CurrentCulture;
        string sonuc = deger.ToLower(c);
        return sonuc;
    }
	public static string KeywordsDonustur(string Yazi)
    {
        try
        {
            string strSonuc =  Yazi.Trim();

            strSonuc = strSonuc.Replace("-", "+");
            strSonuc = strSonuc.Replace(" ", " ");
            strSonuc = strSonuc.Replace(",", ",");          

            strSonuc = strSonuc.Trim();
            //strSonuc = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9+]").Replace(strSonuc, ",");
            strSonuc = strSonuc.Trim();
            strSonuc = strSonuc.Replace("+", "-");
            return strSonuc;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static string UrlDonustur(string Yazi)
    {
        try
        {
            string strSonuc = ToLowerFonksiyonu(Yazi.Trim());

            strSonuc = strSonuc.Replace("-", "+");
            strSonuc = strSonuc.Replace(" ", "+");

            strSonuc = strSonuc.Replace("ç", "c");
            strSonuc = strSonuc.Replace("Ç", "C");

            strSonuc = strSonuc.Replace("ğ", "g");
            strSonuc = strSonuc.Replace("Ğ", "G");

            strSonuc = strSonuc.Replace("ı", "i");
            strSonuc = strSonuc.Replace("I", "İ");

            strSonuc = strSonuc.Replace("ö", "o");
            strSonuc = strSonuc.Replace("Ö", "O");

            strSonuc = strSonuc.Replace("ş", "s");
            strSonuc = strSonuc.Replace("Ş", "S");

            strSonuc = strSonuc.Replace("ü", "u");
            strSonuc = strSonuc.Replace("Ü", "U");

            strSonuc = strSonuc.Trim();
            strSonuc = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9+]").Replace(strSonuc, "");
            strSonuc = strSonuc.Trim();
            strSonuc = strSonuc.Replace("+", "-");
            return strSonuc;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string resim = "", mesaj = "";

        if (!FileUpload1.HasFile)
        {
            Labelbilgi.Text = "<p class='msg warning'><b>Resim Seçmelisiniz</b></p>";
            return;
        }

        if (ClassBLL.resimKaydet(FileUpload1, "~/panel/imgUrun", out resim, out mesaj))
        {
            Image1.ImageUrl = resim;
        }
        if (FileUpload1.HasFile && mesaj != "")
        {
            Labelbilgi.Text = mesaj;
            return;
        }
        hizmet yeni = new hizmet();

        yeni.Adi = adiTextBox.Text;

        yeni.Resim = Image1.ImageUrl;

        yeni.Aciklama = aciklamaCKEditorControl.Text;

        yeni.Sira = Convert.ToInt32(DropDownList1.SelectedValue);

        yeni.MetaKeyword = KeywordsDonustur(KeywordTxt.Text.Trim());
        yeni.MetaDescription = KeywordsDonustur(DescriptionTxt.Text.Trim());
        yeni.MetaTitle = TitleTxt.Text.Trim();
        yeni.SeoYazisi = UrlDonustur(adiTextBox.Text.Trim());
        Result<int> sonuc = yeni.Insert();

        if (sonuc.HasError)
        {
            Labelbilgi.Text = "<p class='msg error'><b>Hata :" + sonuc.CustomErrorMessage + "</b></p>";
            return;
        }
        else
        {
            Response.Redirect("hizmetler.aspx");
        }
    }
    protected void ddlDoldur()
    {
        if (DropDownList1.Items.Count == 0)
        {
            int b = hizmet.SelectAll().Count;
            for (int i = 0; i < b + 1; i++)
            {
                DropDownList1.Items.Insert(i, new ListItem(Convert.ToString(i + 1), Convert.ToString(i + 1)));
            }
        }
    }
}