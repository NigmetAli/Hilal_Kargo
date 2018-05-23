<%@ Page Title="" Language="C#" MasterPageFile="yonetim.master" AutoEventWireup="true" CodeFile="profilim-sifredegistir.aspx.cs" Inherits="panel_sifre_degistir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="table">
        <img src="images/bg-th-left.gif" width="8" height="7" alt="" class="left" />
        <img src="images/bg-th-right.gif" width="7" height="7" alt="" class="right" />
        <form method="post" action="?islem=yonetim_giris_kontrol">
        <table class="listing form" cellpadding="0" cellspacing="0">
            <tr>
                <th class="full" colspan="2">
                </th>
            </tr>
            <tr class="">
                <td class="first" width="70">
                    Kullanıcı Adı*:
                </td>
                <td class="last">
                    <asp:TextBox AutoCompleteType="None"  class="yazi_kutusu" ID="kullaniciAdiTextBox" runat="server"
                        MaxLength="50" size="20"></asp:TextBox>
                </td>
            </tr>
            <tr class="bg">
                <td class="first" width="70">
                    Eski Şifreniz*:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="Eskisifre" runat="server"  MaxLength="50" 
                        size="20" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr class="">
                <td class="first" width="70">
                    Yeni Şifreniz*:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="yenisifre1" runat="server"  MaxLength="50" 
                        size="20" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr class="bg">
                <td class="first" width="70">
                    Yeni Şifreniz Tekrar*:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="yenisifre2" runat="server"  MaxLength="50" 
                        size="20" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="first" width="70">
                </td>
                <td class="last">
                    <asp:Button ID="Button2" runat="server" class="buton" Text="KAYDET" OnClick="Button2_Click" />
                </td>
            </tr>
        </table>
        </form>
    </div>
</asp:Content>
