<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="katalogg-yeni.aspx.cs" Inherits="panel_katalogg_yeni" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="top-bar">
        <h1>
            Yeni Katalog</h1>
    </div>
    <br />
    <br />
    <div class="table">
        <img src="images/bg-th-left.gif" width="8" height="7" alt="" class="left" />
        <img src="images/bg-th-right.gif" width="7" height="7" alt="" class="right" />
        <table class="listing form" cellpadding="0" cellspacing="0">
            <tr>
                <th class="full" colspan="2">
                </th>
            </tr>
            <tr>
                <td class="first" width="70">
                    Katalog Adi:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="adiTextBox" runat="server" TextMode="MultiLine" Columns="50" Rows="5" MaxLength="250" size="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="adiTextBox"></asp:RequiredFieldValidator>
                </td>
            </tr>
                 <tr>
                <td class="first" width="70">
                    Katalog Linki:
                </td>
                 <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="ktlgTextBox" runat="server" TextMode="MultiLine" Columns="50" Rows="5" size="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="adiTextBox"></asp:RequiredFieldValidator>
                </td>
            </tr>     
           <%-- <tr>
                <td class="first" width="70" style="height: 22px">
                    Resim:
                </td>
                <td class="last" style="height: 22px">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <br />
                    <span style="color:Red;"></span>
                </td>
            </tr> --%>
           <%-- <tr>
                <td class="first" width="70">
                    Tarih:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="tarihTextBox1" runat="server" MaxLength="10" size="20"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td class="first" width="70">
                </td>
                <td class="last">
                    <asp:Button ID="Button1" runat="server" Text="KAYDET" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
    <asp:Label ID="Label1" runat="server" 
        Text="Eklemek İstediğiniz Kataloğun Tam Linkini (Adresini) Link Kısmına Yapıştırın !!"></asp:Label>
</asp:Content>
