<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="istatistik-hit.aspx.cs" Inherits="panel_istatistik_hit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="yesil_uyari_kutusu">
        <p>Sol menüden ilgili linke tıklayınız</p>
    </div>
    <style type="text/css">
        .yesil_uyari_kutusu {
            top: 2px;
            padding: 2px 2px 2px 2px;
            color: #990000;
            border: 1px solid #00CC00;
            background: #CCFFCC;
            margin: 2px 2px 2px 2px;
            background: url('http://adanapaintball.net/yonetim-images/ico_success.png') 2px 0px no-repeat #DFFAD3;
            border-color: #72CB67;
        }
    </style>
    <asp:Repeater ID="RptDaire" runat="server">
        <HeaderTemplate>
            <h4 class="widgettitle" style="width: 485px; display: block; float: left;">Günlük Sayaç</h4>
            <table id="dyntable" class="table table-bordered responsive">
                <colgroup>

                    <col class="con1" />
                    <col class="con0" />
                    <col class="con1" />
                    <col class="con0" />
                    <col class="con1" />
                </colgroup>
                <thead>
                    <tr>
                        <th width="15%" style="font-weight: bold; font-size: 14px; text-transform: uppercase; font-family: Candara;">Sıra No</th>
                        <th width="30%" style="font-weight: bold; font-size: 14px; text-transform: uppercase; font-family: Candara;">Giriş Yapan IP</th>
                        <th width="25%" style="font-weight: bold; font-size: 14px; text-transform: uppercase; font-family: Candara;">Tıklama Sayısı</th>
                        <th width="40%" style="font-weight: bold; font-size: 14px; text-transform: uppercase; font-family: Candara;">Tarih</th>
                    </tr>

                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="gradeX">
                <td style="font-family: Candara; font-size: 14px; font-weight: bold; line-height: 28px; vertical-align: middle;"><%#(((RepeaterItem)Container).ItemIndex+1).ToString() %> </td>
                <td style="font-family: Candara; font-size: 14px; font-weight: bold; line-height: 28px; vertical-align: middle;"><%#Eval("Ip") %></td>
                <td style="font-family: Candara; font-size: 14px; font-weight: bold; line-height: 28px; vertical-align: middle;"><%#Eval("Hit") %></td>
                <td style="font-family: Candara; font-size: 14px; font-weight: bold; line-height: 28px; vertical-align: middle;"><%#Eval("Tarih","{0:D}") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <style type="text/css" title="currentStyle">
        @import "../panel/Cs/demo_page.css";
        @import "../panel/Cs/demo_table.css";
    </style>
    <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/css/jquery.dataTables.css" />
    <link type="text/css" href="css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript" src="Script/jquery.js"></script>
    <script type="text/javascript" language="javascript" src="Script/jquery.dataTables.js"></script>
    <script type="text/javascript">
        function pageLoad() {
            jQuery('#dyntable').dataTable({
                "iDisplayLength": 15,
                "oLanguage": {
                    "sUrl": "turkce/kaynak.txt"
                },
            });
            $("#dyntable tr input").each(function (i) {
                if ($(this).attr('checked') == 'checked') {
                    $(this).parent().parent().css("background-color", "#eaf7de");
                } else {
                    $(this).parent().parent().css("background", "#f2a7a7");
                }
            });
        }
    </script>
    <style type="text/css">
        #top-navigation li a {
            font-size: 11px;
        }
        .yesil_uyari_kutusu p {
            margin-top: 12px;
        }
    </style>
</asp:Content>

