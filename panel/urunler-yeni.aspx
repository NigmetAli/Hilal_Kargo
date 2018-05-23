<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true"
    CodeFile="urunler-yeni.aspx.cs" Inherits="panel_urunler_yeni" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="top-bar">
        <h1>
            Yeni Sertifika</h1>
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
                    Sertifika Adı:
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="adiTextBox" runat="server" MaxLength="50" size="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="adiTextBox"></asp:RequiredFieldValidator>
                </td>
            </tr>
           
            <tr>
                <td class="first" width="70" style="height: 22px">
                    Resim:
                </td>
                <td class="last" style="height: 22px">
                    <asp:Image ID="Image1" runat="server" Width="150" Height="150" ImageUrl="images/logo.png" />
                    <br />
                     <span style=" color:Red; font-size:large;">Resim Boyutu 360x240 Oranında Olmalı!<br />yeni sertifika resimleri eklemek için sertifika kaydından sonra düzenle sayfasına gidiniz.</span><br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
                   
            <tr>
                <td class="first" width="70">
                </td>
                <td class="last">
                    <asp:Button ID="Button1" runat="server" Text="KAYDET" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
