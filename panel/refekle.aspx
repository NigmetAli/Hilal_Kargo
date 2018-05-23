<%@ Page Title="" Language="C#" MasterPageFile="~/panel/yonetim.master" AutoEventWireup="true" CodeFile="refekle.aspx.cs" Inherits="panel_refekle" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Labelbilgi" runat="server"></asp:Label>
    <div style="width: 600px;">
        <asp:Label Font-Bold="true" Font-Size="X-Large" ID="Label2" runat="server" Text='Referanslar'></asp:Label>
    </div>
    <div style="width: 600px;">
        <CKEditor:CKEditorControl ID="hakkimizdaCKEditorControl" runat="server"></CKEditor:CKEditorControl>
    </div>
    <div style="width: 600px;">
        <asp:Button ID="Button1" CommandName="duzenle" runat="server" Text="Kaydet" OnClick="Button1_Click" />
    </div>
</asp:Content>
