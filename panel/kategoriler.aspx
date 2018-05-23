<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true"
    CodeFile="kategoriler.aspx.cs" Inherits="kategoriler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="css/jquery.treeview.css" type="text/css" />
    <script type="text/javascript" src="js/jquery.treeview.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("ul:[id=kategoriler]").treeview();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="top-bar">
        <h1>
            Kategoriler</h1>
    </div>
    <br />
    <br />
    <div style="background-color: transparent;">
        <%=kategoriGetir() %>
    </div>
    <%--<asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" 
        DataSourceID="AccessDataSource1" onitemcommand="ListView1_ItemCommand">
        <AlternatingItemTemplate>
            <tr class="bg">
                <td>
                    <asp:Button class="buton" ID="Button1" runat="server" Text="Düzenle" CommandName="duzenle" />
                    <asp:Button class="buton" ID="Button3" runat="server" Text="Sil" CommandName="sil"
                        OnClientClick='return confirm("Silmek istediğinize emin misiniz?");' />
                    <asp:Label Visible="false" ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="AdiLabel" runat="server" Text='<%# Eval("Adi") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Button class="buton" ID="Button1" runat="server" Text="Düzenle" CommandName="duzenle" />
                    <asp:Button class="buton" ID="Button3" runat="server" Text="Sil" CommandName="sil"
                        OnClientClick='return confirm("Silmek istediğinize emin misiniz?");' />
                    <asp:Label Visible="false" ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="AdiLabel" runat="server" Text='<%# Eval("Adi") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="listing" cellpadding="0"
                            cellspacing="0">
                            <tr runat="server" style="background-color: #E0FFFF; color: #333333;">
                                <th runat="server">
                                    Id
                                </th>
                                <th runat="server">
                                    Adi
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/panel.mdb"
        SelectCommand="SELECT * FROM [kategori] WHERE ([Aktif] = ?) and FkUstKategori<0">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="Aktif" Type="Boolean" />
        </SelectParameters>
    </asp:AccessDataSource>--%>
</asp:Content>
