<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sertifikalar.aspx.cs" Inherits="Sertifikalar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <!-- =-=-=-=-=-=-= PAGE BREADCRUMB =-=-=-=-=-=-= -->
    <section class="breadcrumbs-area parallex">
        <div class="container">
            <div class="row">
                <div class="page-title">
                    <div class="col-sm-12 col-md-6 kurumsalBaslik text-left">
                        <h3> </h3>
                        <h3>SERTİFİKALAR</h3>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- =-=-=-=-=-=-= PAGE BREADCRUMB END =-=-=-=-=-=-= -->

    <!-- =-=-=-=-=-=-= Gallery =-=-=-=-=-=-= -->
    <section id="gallery" class="custom-padding ">
        <div class="container">

            <div class="portfolio-container text-center ">

                
                <ul id="portfolio-grid" class="three-column hover-two" ">
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


