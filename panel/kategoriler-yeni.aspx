<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true"
    CodeFile="kategoriler-yeni.aspx.cs" Inherits="panel_kategoriler_yeni" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="top-bar">
        <h1>
            Yeni Kategori</h1>
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
                    Kategori Adı :
                </td>
                <td class="last">
                    <asp:TextBox class="yazi_kutusu" ID="adiTextBox" runat="server" MaxLength="50" size="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        SetFocusOnError="true" ForeColor="Red" ControlToValidate="adiTextBox"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td class="first" width="70">
                    Üst Kategori :
                </td>
                <td class="last">
                <asp:DropDownList ID="DropDownList1" runat="server" 
                        DataSourceID="AccessDataSource1" DataTextField="Adi" DataValueField="Id" 
                        ondatabound="DropDownList1_DataBound">
                </asp:DropDownList>

                    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
                        DataFile="~/App_Data/panel.mdb" 
                        SelectCommand="SELECT [Id], [Adi] FROM [kategori] order by FkUstKategori "></asp:AccessDataSource>

                </td>
                
            </tr>
             <tr>
                <td class="first" width="70" style="height: 22px">
                    Resim:
                </td>
                <td class="last" style="height: 22px">
                    <asp:Image ID="Image1" runat="server" Width="150" Height="150" ImageUrl="images/logo.png" />
                    <br />
                     <span style=" color:Red; font-size:large;">Resim Boyutu 150X150 Oranında Olmalı!</span><br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="first" width="70">
                </td>
                <td class="last">
                    <asp:Button ID="Button1" CssClass="buton" runat="server" Text="KAYDET" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
