<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="lazerepilasyon-yeni.aspx.cs" Inherits="panel_lazerepilasyon_yeni" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="top-bar">
        <h1>Yeni İcerik</h1>
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
                <td class="first" width="70">Sıra:
                </td>
                <td class="last">
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="first" width="70">Adı:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="adiTextBox" runat="server" MaxLength="50" size="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="adiTextBox"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="first" width="70" style="height: 22px">Resim:
                </td>
                <td class="last" style="height: 22px">
                    <asp:Image ID="Image1" runat="server" Width="150" Height="150" ImageUrl="images/logo.png" />
                    <br />
                    <span style="color: Red; font-size: large;">Resim Boyutu 300x250 Oranında Olmalı!</span><br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="first" width="70">Açıklama:
                </td>
                <td class="last">
                    <CKEditor:CKEditorControl ID="aciklamaCKEditorControl" runat="server"></CKEditor:CKEditorControl>
                </td>
            </tr>
              <tr>
                <td class="first" width="70">Meta Title(<b style="color:red;font-size: 10px;font-weight: normal;">Max 80 Karakter</b>):
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="TitleTxt" TextMode="MultiLine" runat="server" MaxLength="80" Style="height: 70px; width: 480px; margin-left: 10px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="KeywordTxt"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="first" width="70">Meta Keyword(<b style="color:red;font-size: 10px;font-weight: normal;">Max 20 Kelime</b>):
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="KeywordTxt" TextMode="MultiLine" MaxLength="140" runat="server" style="height: 70px;width: 480px;margin-left: 10px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="KeywordTxt"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="first" width="70">Meta Description(<b style="color:red;font-size: 10px;font-weight: normal;">Max 160 Karakter</b>):
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="DescriptionTxt" TextMode="MultiLine" runat="server" MaxLength="160"  style="height: 70px;width: 480px;margin-left: 10px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="DescriptionTxt"></asp:RequiredFieldValidator>
                </td>
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

