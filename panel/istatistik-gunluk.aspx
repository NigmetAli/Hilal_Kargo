<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="istatistik-gunluk.aspx.cs" Inherits="panel_istatistik_gunluk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div class="top-bar">
        <h1>Günlük Ziyaretçileri</h1>
    </div>
    <br />
    <br />

    <asp:ListView ID="ListView1" runat="server"  DataSourceID="AccessDataSource1">
        <AlternatingItemTemplate>
            <tr>
                <td style="background: #e8e8e8;">
                    <asp:Label ID="Gun" runat="server" Text='<%# String.Format("{0:F}", Eval("Tarih")) %>' />
                </td>
                <td style="background: #e8e8e8;">
                    <asp:Label ID="Tekil" runat="server" Text='<%# Eval("gunluk") %>' />
                </td>
                <td style="background: #e8e8e8;">
                    <asp:Label ID="Cogul" runat="server" Text='<%# Eval("aylik") %>' />
                </td>
                <td style="background: #e8e8e8;">
                    <asp:Label ID="yillik" runat="server" Text='<%# Eval("yillik") %>' />
                </td>
                <td style="background: #e8e8e8;">
                    <asp:Label ID="toplam" runat="server" Text='<%# Eval("toplam") %>' />
                </td>

            </tr>
        </AlternatingItemTemplate>
        <ItemTemplate>
            <tr>              
                <td>
                    <asp:Label ID="Gun" runat="server" Text='<%# String.Format("{0:F}", Eval("Tarih")) %>' />
                </td>
               <td>
                    <asp:Label ID="Tekil" runat="server" Text='<%# Eval("gunluk") %>' />
                </td>
                <td>
                    <asp:Label ID="Cogul" runat="server" Text='<%# Eval("aylik") %>' />
                </td>
                <td>
                    <asp:Label ID="yillik" runat="server" Text='<%# Eval("yillik") %>' />
                </td>
                <td>
                    <asp:Label ID="toplam" runat="server" Text='<%# Eval("toplam") %>' />
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

                                <th id="Th2" runat="server">Tarih
                                </th>
                                <th id="Th3" runat="server">Günlük Ziyaretçi
                                </th>
                                <th id="Th4" runat="server">Aylık Ziyaretçi
                                </th>
                                <th id="Th5" runat="server">Yıllık Ziyaretçi
                                </th>
                                <th id="Th1" runat="server">Toplam Ziyaretçi
                                </th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr3" runat="server">
                    <td id="Td2" runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
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
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/sistem.mdb"
        SelectCommand="SELECT * from sayac order by Tarih Desc"></asp:AccessDataSource>
    <style type="text/css">
        #center-column {
            width: 682px !important;
            border: 1px solid #ccc;
            -webkit-border-radius: 10px;
            -moz-border-radius: 10px;
            border-radius: 10px;
            padding: 12px 5px 0 5px;
            background: transparent;
        }

        #right-column .box {
            width: 90px;
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

