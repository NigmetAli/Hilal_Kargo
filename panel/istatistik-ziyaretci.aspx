<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="istatistik-ziyaretci.aspx.cs" Inherits="panel_istatistik_ziyaretci" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="top-bar">
        <h1>Siteye Ziyaretçi Gönderenler</h1>
    </div>
    <br />
    <br />

    <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="AccessDataSource1">
        <AlternatingItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="Gun" runat="server" Text='<%# Eval("Dil") %>' />
                </td>
                <td>
                    <asp:Label ID="Tekil" runat="server" Text='<%# Eval("Sistem") %>' />
                </td>

                <td>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Browser") %>' />
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Link") %>' />
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Gonderen") %>' />
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text='<%# String.Format("{0:D}", Eval("Tarih")) %>' />
                </td>

            </tr>
        </AlternatingItemTemplate>
        <ItemTemplate>
            <tr>

                <td>
                    <asp:Label ID="Gun" runat="server" Text='<%# Eval("Dil") %>' />
                </td>
                <td>
                    <asp:Label ID="Tekil" runat="server" Text='<%# Eval("Sistem") %>' />
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Browser") %>' />
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Link") %>' />
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Gonderen") %>' />
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text='<%# String.Format("{0:D}", Eval("Tarih")) %>' />
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

                                <th id="Th2" runat="server">Ülke
                                </th>
                                <th id="Th3" runat="server">Sistem
                                </th>

                                <th id="Th5" runat="server">Tarayıcı
                                </th>
                                <th id="Th1" runat="server">Ziyaret Sayfası
                                </th>
                                <th id="Th6" runat="server">Gelen Url
                                </th>
                                <th id="Th7" runat="server"> Son Ziyaret Tarihi
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr3" runat="server">
                    <td id="Td2" runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
                        <asp:DataPager ID="DataPager1" PageSize="10" runat="server">
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
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/sistem.mdb"
        SelectCommand="SELECT * from ziyaretci order by Tarih Desc"></asp:AccessDataSource>
    <style type="text/css">
        #center-column {
            width: 682px !important;
            border: 1px solid #ccc;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
            padding: 12px 5px 0 5px;
            background:transparent;
        }
        #right-column .box {
            width:90px;
        }
        .top-bar {
            width: 670px !important;
        }

        table.listing {
            width: 680px !important;
        }

        #right-column {
            width: 100px !important;
        }
        #left-column {
            padding: 1px 4px 0 4px;
        }
    </style>
</asp:Content>

