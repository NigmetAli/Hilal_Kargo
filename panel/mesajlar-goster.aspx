<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true"
    CodeFile="mesajlar-goster.aspx.cs" Inherits="panel_mesajlar_goster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="one-third grid_3">
        <p>
            <label for="name">
                İSİM:
            </label>
            <label runat="server" id="isim" style="font-size:large;">asdf</label>
        </p>
        <p>
            <label for="email">
                E-POSTA:
            </label>
            <a runat="server" id="email" style="font-size:large;">asdf</a>
        </p>
        <p>
            <label for="subject">
                TELEFON:
            </label>
            <label runat="server" id="Label1" style="font-size:large;">asdf</label>
        </p>
            <label for="subject">
                KONU:
            </label>
            <label runat="server" id="konu" style="font-size:large;">asdf</label>
        </p>
    </div>
    <div class="one_third grid_4">
        <label for="message" class="message_label">
            MESAJ:
        </label>
        <textarea runat="server" name="message" id="message" style="font-size:large;" cols="70" rows="5"></textarea>
        <span class="clear"></span>
    </div>
</asp:Content>
