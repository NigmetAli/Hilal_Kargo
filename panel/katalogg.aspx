<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="katalogg.aspx.cs" Inherits="panel_katalogg" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="top-bar">
        <h1>
            Kataloglar</h1>
    </div>
    <br />
    <br />
   
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="AccessDataSource1"
        OnItemCommand="ListView1_ItemCommand">
        <AlternatingItemTemplate>
            <tr class="bg">
                <td>
                    <asp:Button class="buton" ID="Button1" runat="server" Text="Düzenle" CommandArgument='<%# Eval("Id") %>'
                        CommandName="duzenle" />
                    <asp:Button class="buton" ID="Button3" runat="server" Text="Sil" CommandArgument='<%# Eval("Id") %>'
                        CommandName="sil" OnClientClick='return confirm("Silmek istediğinize emin misiniz?");' />
                </td>
                <td>
                    <asp:Label ID="AdiLabel" runat="server" Text='<%# Eval("Adi") %>' />
                </td>
                <%--<td>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("AltBaslik") %>' />
                </td>
                <td>
                    <asp:Image ID="Image1" Width="100"  runat="server" ImageUrl='<%# Eval("Resim") %>' />
                </td>--%>
                <%--<td>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Tarih") %>' />
                </td>--%>
            </tr>
        </AlternatingItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #E0FFFF; color: #333333;">
                <td>
                    <asp:Button class="buton" ID="Button1" runat="server" Text="Düzenle" CommandArgument='<%# Eval("Id") %>'
                        CommandName="duzenle" />
                    <asp:Button class="buton" ID="Button3" runat="server" Text="Sil" CommandArgument='<%# Eval("Id") %>'
                        CommandName="sil" OnClientClick='return confirm("Silmek istediğinize emin misiniz?");' />
                </td>
                <td>
                    <asp:Label ID="AdiLabel" runat="server" Text='<%# Eval("Adi") %>' />
                </td>
                <%--<td>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("AltBaslik") %>' />
                </td>
                <td>
                    <asp:Image ID="Image1" Width="100" runat="server" ImageUrl='<%# Eval("Resim") %>' />
                </td>--%>
                <%--<td>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Tarih") %>' />
                </td>--%>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="Table1" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td1" runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="listing" cellpadding="0"
                            cellspacing="0">
                            <tr id="Tr2" runat="server" style="background-color: #E0FFFF; color: #333333;">
                                <th id="Th1" runat="server">
                                </th>
                                <th id="Th2" runat="server">
                                    Katalog Adı
                                </th>
                                <%--<th id="Th5" runat="server">
                                    Alt Başlık
                                </th>
                                <th id="Th4" runat="server">
                                    Resim
                                </th>--%>
                                <%--<th id="Th3" runat="server">
                                    Tarih
                                </th>--%>
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
        SelectCommand="SELECT * from [ktlg] "></asp:AccessDataSource>
</asp:Content>
