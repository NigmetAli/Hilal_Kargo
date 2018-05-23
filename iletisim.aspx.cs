using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class iletisim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if( txtad.Text=="" || txtemail.Text=="" || txtkonu.Text=="" || txtmesaj.Text=="" )
        {
            SonucLbl.Text = "Lütfen alanları boş bırakmyınız..";
        }
        else{

     
        iletisimmesaj yeni = new iletisimmesaj();
        yeni.Isim = txtad.Text;
        yeni.Email = txtemail.Text;
        yeni.Telefon = "";
        yeni.Mesaj = txtmesaj.Text;
        yeni.Konu = txtkonu.Text;
        Result<int> sonuc = yeni.Insert();
        if (sonuc.HasError)
        {
            SonucLbl.Text = "Hata Mesajınız :" + sonuc.CustomErrorMessage;
        }
        else
        {
            SonucLbl.Text = "Mesajını iletilmiştir.En kısa sürede dönüş yapılacaktır.";
        }
               }

    }
}