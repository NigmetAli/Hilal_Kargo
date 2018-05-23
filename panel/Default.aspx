<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta http-equiv="content-language" content="tr" />
    <meta name="robots" content="noindex,nofollow" />
    <link rel="stylesheet" media="screen,projection" type="text/css" href="css/reset.css" />
    <!-- RESET -->
    <link rel="stylesheet" media="screen,projection" type="text/css" href="css/main.css" />
    <!-- MAIN STYLE SHEET -->
    <!--[if lte IE 6]><link rel="stylesheet" media="screen,projection" type="text/css" href="YonetimPaneli/css/main-ie6.css" /><![endif]-->
    <!-- MSIE6 -->
    <link rel="stylesheet" media="screen,projection" type="text/css" href="css/style.css" />
    <!-- GRAPHIC THEME -->
    <link rel="stylesheet" media="screen,projection" type="text/css" href="css/mystyle.css" />
    <!-- WRITE YOUR CSS CODE HERE -->
    <script type="text/javascript" src="js/toggle.js"></script>
    <title>Giriş</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main-02">
        <div id="login-top">
        </div>
        <div id="login-box">
            <!-- Logo -->
            <center>
                <p class="nom t-center">
                    <a href="default.aspx">
                       <img src="Images/logo.png" alt="logo" width="400"height="100" title="Siteye Git" />
                    </a>
                </p>
               <span style="color:#0085cc; font-weight:bold; font-size:large; font-family:Berlin Sans FB Demi;">By Selebrum Media</span></center>
            <!-- Messages -->
            <asp:Label ID="Labelbilgi" runat="server" Text="<p class='msg info'><b>Kullanıcı Adı</b> ve <b>Şifre</b>nizi Giriniz.</p>"></asp:Label>
            <!-- Form -->
            <asp:Panel ID="Panel1" runat="server" DefaultButton="Buttongiris">
                <table class="nom nostyle">
                    <tr>
                        <td style="width: 90px;">
                            <label for="login-user">
                                <strong>Kullanıcı Adı:</strong></label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxkullaniciadi" runat="server" CssClass="input-text" Width="280"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red"  ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true"
                                ErrorMessage="*" ControlToValidate="TextBoxkullaniciadi"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="login-pass">
                                <strong>Şifre:</strong></label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxsifre" runat="server" CssClass="input-text" Width="280" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ForeColor="Red"  ID="RequiredFieldValidator1" runat="server" SetFocusOnError="true"
                                ErrorMessage="*" ControlToValidate="TextBoxsifre"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <span class="f-right"><a href="javascript:toggle('sendpass');">Şifremi Unuttum?</a></span>
                            <span class="f-left low" style="display: none;">
                                <input type="checkbox" name="" value="" id="login-remember" />
                                <label for="login-remember">
                                    Beni Hatırla</label></span>
                        </td>
                    </tr>
                    <!-- Show/Hide -->
                    <tr id="sendpass" style="display: none;">
                        <td>
                            <label for="login-sendpass">
                                <strong>E-mail:</strong></label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxemail" runat="server" CssClass="input-text f-left" Width="230"
                                ValidationGroup="email"></asp:TextBox>
                            <asp:RequiredFieldValidator  ForeColor="Red" ID="RequiredFieldValidator5" Display="Dynamic" runat="server"
                                SetFocusOnError="true" ErrorMessage="*" ControlToValidate="TextBoxemail" ValidationGroup="email"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator1" runat="server" ErrorMessage="*"
                                SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic" ControlToValidate="TextBoxemail" ValidationGroup="email">
                            </asp:RegularExpressionValidator>
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="Button1" runat="server" Text="Gönder" OnClick="Button1_Click" ValidationGroup="email" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="t-right">
                            <asp:Button ID="Buttongiris" runat="server" Text="Giriş Yap &raquo;" CssClass="input-submit"
                                OnClick="Buttongiris_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <!-- /login-box -->
        <div id="login-bottom">
        </div>
    </div>
    <!-- /main -->
    </form>
</body>
</html>
