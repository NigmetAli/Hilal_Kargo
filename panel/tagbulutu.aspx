<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="tagbulutu.aspx.cs" Inherits="panel_tagbulutu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="top-bar">
        <h1>
            Tag Bulutu</h1>
    </div>
    <br />
    <br />
    <table id="Table1" runat="server">
        <tr>
            <td>
           
            </td>
        </tr>
    </table>
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" 
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
               
                <td>
                    <asp:Label ID="LinkLabel" runat="server" Text='<%# Eval("Link") %>' />
                </td>
                
            </tr>
        </AlternatingItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #E0FFFF; color: #333333;">
                <td>
                    <asp:Button class="buton" ID="Button1" runat="server" Text="Düzenle" CommandName="duzenle" />
                    <asp:Button class="buton" ID="Button3" runat="server" Text="Sil" CommandName="sil"
                        OnClientClick='return confirm("Silmek istediğinize emin misiniz?");' />
                    <asp:Label Visible="false" ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="AdiLabel" runat="server" Text='<%# Eval("Adi") %>' />
                </td>
               
                <td>
                    <asp:Label ID="LinkLabel" runat="server" Text='<%# Eval("Link") %>' />
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
                                <th id="Th1" runat="server">
                                </th>
                                <th id="Th2" runat="server">
                                Adı
                                </th>
                                
                                <th id="Th4" runat="server">
                                    Linki
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
        
        SelectCommand="SELECT * from [ktlg]">
    </asp:AccessDataSource>
</asp:Content>

