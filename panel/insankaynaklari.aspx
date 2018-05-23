<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="insankaynaklari.aspx.cs" Inherits="panel_insankaynaklari" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="top-bar">
        <h1>İş Başvuru Listesi</h1>
    </div>
    <br />
    <br />

    <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="AccessDataSource1"
        OnItemCommand="ListView1_ItemCommand">
        <AlternatingItemTemplate>
            <tr class="bg">
                <td>
                    <%--<asp:Button class="buton" ID="Button1" runat="server" Text="Düzenle" CommandArgument='<%# Eval("Id") %>'
                        CommandName="duzenle" />--%>
                    <asp:Button class="buton" ID="Button3" runat="server" Text="Sil" CommandArgument='<%# Eval("Id") %>'
                        CommandName="sil" OnClientClick='return confirm("Silmek istediğinize emin misiniz?");' />
                </td>
                <td>
                    <asp:Label ID="AdiLabel" runat="server" Text='<%# Eval("Adi") %>' />
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Pozisyon") %>' />
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Telefon") %>' />
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Eposta") %>' />
                </td>
                <td>
                    <a href='<%# Cevir(Eval("Ek").ToString()) %>'>CV Görüntüle</a>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Tarih") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #E0FFFF; color: #333333;">
                <td>
                    <%--<asp:Button class="buton" ID="Button1" runat="server" Text="Düzenle" CommandArgument='<%# Eval("Id") %>'
                        CommandName="duzenle" />--%>
                    <asp:Button class="buton" ID="Button3" runat="server" Text="Sil" CommandArgument='<%# Eval("Id") %>'
                        CommandName="sil" OnClientClick='return confirm("Silmek istediğinize emin misiniz?");' />
                </td>
                <td>
                    <asp:Label ID="AdiLabel" runat="server" Text='<%# Eval("Adi") %>' />
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Pozisyon") %>' />
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Telefon") %>' />
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Eposta") %>' />
                </td>
                <td>
                    <a href='<%# Cevir(Eval("Ek").ToString()) %>' target="_blank">CV Görüntüle</a>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Tarih") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="Table1" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td1" runat="server">
                        <table id="itemPlaceholderContainer" runat="server" class="listing" cellpadding="0"
                            cellspacing="0">
                            <tr id="Tr2" runat="server" style="background-color: #E0FFFF; color: #333333;">
                                <th id="Th1" runat="server"></th>
                                <th id="Th2" runat="server">Adı Soyadı
                                </th>
                                <th id="Th4" runat="server">Başvurulan Pozisyon
                                </th>
                                <th id="Th5" runat="server">Telefon
                                </th>
                                <th id="Th6" runat="server">Eposta
                                </th>
                                <th id="Th7" runat="server">Ek
                                </th>
                                <th id="Th3" runat="server">
                                    Tarih
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
        SelectCommand="SELECT * from ik order by Tarih desc"></asp:AccessDataSource>
</asp:Content>

