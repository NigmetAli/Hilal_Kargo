<%@ Page Title="" Language="C#" MasterPageFile="yonetim.master" AutoEventWireup="true"
    CodeFile="profilim.aspx.cs" Inherits="profilim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
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
                    Adınız Soyadınız*:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="AdiTextBox" runat="server" MaxLength="50" size="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="AdiTextBox"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="">
                <td class="first" width="70">
                    Kullanıcı Adınız*:
                </td>
                <td class="last">
                    <asp:TextBox  class="yazi_kutusu" ID="kullaniciAdiTextBox" runat="server"
                        MaxLength="50" size="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="kullaniciAdiTextBox"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="">
                <td class="first" width="70">
                    Şifreniz*:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="sifre1TextBox1" runat="server"  MaxLength="50" 
                        size="20" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="sifre1TextBox1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="bg">
                <td class="first" width="70">
                    Telefonunuz*:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="telTextBox" runat="server" MaxLength="50" size="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="telTextBox"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="bg">
                <td class="first" width="70">
                    e-Mail*:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="MailTextBox" runat="server" MaxLength="50" size="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="MailTextBox"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="bg">
                <td class="first" width="70">
                    Adres:
                </td>
                <td class="last">
                    <asp:TextBox  ID="adresTextBox" runat="server" Rows="3" Columns="50" TextMode="MultiLine" MaxLength="255" size="20"></asp:TextBox> 
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
    </div>
</asp:Content>
