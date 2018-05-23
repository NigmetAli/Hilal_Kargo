<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="tagbulutu-yeni.aspx.cs" Inherits="panel_tagbulutu_yeni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="top-bar">
        <h1>Yeni Kelime</h1>
    </div>
    <br />
    <br />
    <div class="table">
        <img src="images/bg-th-left.gif" width="8" height="7" alt="" class="left" />
        <img src="images/bg-th-right.gif" width="7" height="7" alt="" class="right" />
        <table class="listing form" cellpadding="0" cellspacing="0">
            <tr>
                <th class="full" colspan="2"></th>
            </tr>
            <tr>
                <td class="first" width="70">Adı:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="adiTextBox" runat="server" MaxLength="100" size="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="adiTextBox"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="first" width="70">Link:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="LinkTxt" runat="server" MaxLength="100" size="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="LinkTxt"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td class="first" width="70"></td>
                <td class="last">
                    <asp:Button ID="Button1" runat="server" Text="KAYDET" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

