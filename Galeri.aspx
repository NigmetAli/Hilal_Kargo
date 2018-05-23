<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Galeri.aspx.cs" Inherits="Galeri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- =-=-=-=-=-=-= PAGE BREADCRUMB =-=-=-=-=-=-= -->
    <section class="breadcrumbs-area parallex">
        <div class="container">
            <div class="row">
                <div class="page-title">
                    <div class="col-sm-12 col-md-6 page-heading text-left">
                        <h3>Anılarımız </h3>
                        <h2>GALERİ</h2>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- =-=-=-=-=-=-= PAGE BREADCRUMB END =-=-=-=-=-=-= -->

    <!-- =-=-=-=-=-=-= Gallery =-=-=-=-=-=-= -->
    <section id="gallery" class="custom-padding">
        <div class="container">

            <div class="portfolio-container text-center">

                
                <ul id="portfolio-grid" class="three-column hover-two">
                    <!--GALERİYE RESİM ÇEK -->
                    <asp:Literal ID="ltrGaleriResim" runat="server"></asp:Literal>
                </ul>
            </div>

            <!-- portfolio-container -->



        </div>
        <!-- end container -->
    </section>
    <!-- =-=-=-=-=-=-= Blog & News end =-=-=-=-=-=-= -->


</asp:Content>



