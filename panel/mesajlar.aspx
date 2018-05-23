<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true"
    CodeFile="mesajlar.aspx.cs" Inherits="panel_mesajlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function yonlendir(id) {
            window.location = "mesajlar-goster.aspx?Id=" + id;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="top-bar">
        <h1>
            İletişim Mesajları</h1>
    </div>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Okundu" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;<asp:Button
        ID="Button2" runat="server" Text="Okunmadı" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;<asp:Button
            ID="Button3" runat="server" Text="Sil" OnClientClick='return confirm("Silmek istediğinize emin misiniz?");'
            OnClick="Button3_Click" />
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="AccessDataSource1"
        OnItemCommand="ListView1_ItemCommand">
        <AlternatingItemTemplate>
            <tr class="<%# Eval("Durum").ToString() == "True" ? "okunmadi" : "bg" %>" style="cursor: pointer;">
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    <asp:Label Visible="false" ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td onclick="yonlendir(<%# Eval("Id") %>)">
                    <asp:Label ID="AdiLabel" runat="server" Text='<%# Eval("Isim") %>' />
                </td>
                <td onclick="yonlendir(<%# Eval("Id") %>)">
                    <a href='mailto:<%# Eval("Email") %>'>
                        <%# Eval("Email") %></a>
                </td>
                <td onclick="yonlendir(<%# Eval("Id") %>)">
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Telefon") %>' />
                </td>
                <td onclick="yonlendir(<%# Eval("Id") %>)">
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Konu") %>' />
                </td>
                <td onclick="yonlendir(<%# Eval("Id") %>)">
                    <asp:CheckBox ID="DurumCheckBox" runat="server" Checked='<%# Eval("Durum") %>' Enabled="false" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <ItemTemplate>
            <tr class="<%# Eval("Durum").ToString() == "True" ? "okunmadi" : "bg" %>" style="cursor: pointer;">
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    <asp:Label Visible="false" ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td onclick="yonlendir(<%# Eval("Id") %>)">
                    <asp:Label ID="AdiLabel" runat="server" Text='<%# Eval("Isim") %>' />
                </td>
                <td onclick="yonlendir(<%# Eval("Id") %>)">
                    <a href='mailto:<%# Eval("Email") %>'>
                        <%# Eval("Email") %></a>
                </td>
                <td onclick="yonlendir(<%# Eval("Id") %>)">
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Telefon") %>' />
                </td>
                <td onclick="yonlendir(<%# Eval("Id") %>)">
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Konu") %>' />
                </td>
                <td onclick="yonlendir(<%# Eval("Id") %>)">
                    <asp:CheckBox ID="DurumCheckBox" runat="server" Checked='<%# Eval("Durum") %>' Enabled="false" />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div style="margin-top: 30px; width: 500px">
                <label style="font-size: large;">
                    Mesajınız Bulunmuyor...</label>
            </div>
        </EmptyDataTemplate>
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
                                    Kimden
                                </th>
                                <th id="Th3" runat="server">
                                    E-posta
                                </th>
                                <th id="Th6" runat="server">
                                    Telefon
                                </th>
                                <th id="Th4" runat="server">
                                    Konu
                                </th>
                                <th id="Th5" runat="server">
                                    Okundu
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr3" runat="server">
                    <td id="Td2" runat="server" style="text-align: center; background-color: #5D7B9D;
                        font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
                        <asp:DataPager ID="DataPager1" PageSize="30" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField FirstPageText="İlk" ButtonType="Button" ShowFirstPageButton="True"
                                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField LastPageText="Son" ButtonType="Button" ShowLastPageButton="True"
                                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/panel.mdb"
        SelectCommand="SELECT * from iletisimmesaj order by Tarih Desc"></asp:AccessDataSource>
</asp:Content>
