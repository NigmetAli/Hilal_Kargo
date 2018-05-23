<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Hizmetler.aspx.cs" Inherits="Hizmetler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- =-=-=-=-=-=-= PAGE BREADCRUMB =-=-=-=-=-=-= -->
    <section class="breadcrumbs-area parallex">
        <div class="container">
            <div class="row">
                <div class="page-title">
                    <div class="col-sm-12 col-md-6 kurumsalBaslik text-left">
                        <h3>HİZMETLERİMİZ /
                            <asp:Literal ID="ltrgelenhizmetadi" runat="server"></asp:Literal></h3>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- =-=-=-=-=-=-= PAGE BREADCRUMB END =-=-=-=-=-=-= -->

    <!-- =-=-=-=-=-=-= Our Services =-=-=-=-=-=-= -->
    <section class="section-padding-70 services-2" style="padding: 11px 0;">
        <div class="container">
            <!-- Row -->
            <div class="row">

                <div class="col-md-9 col-sm-12 col-md-push-3 col-xs-12">

                    <div id="post-slider" class="owl-carousel owl-theme margin-bottom-30">
                        <div class="item">
                            <a class="tt-lightbox" href="resimler/hizmet.png">
                                <img class="img-responsive" src="resimler/hizmet.png" alt=""></a>
                        </div>

                    </div>

                    <asp:Literal ID="ltraciklama" runat="server"></asp:Literal>

                </div>
                <!-- right column -->
                <div class="col-md-3 col-md-pull-9 col-sm-12 col-xs-12" id="side-bar">
                    <div class="theiaStickySidebar">
                        <div class="side-bar-services">
                            <ul class="side-bar-list">
                                <asp:Literal ID="ltrhizmetkat" runat="server"></asp:Literal>

                            </ul>
                        </div>
                    </div>

                </div>
            </div>
            <!-- Row End -->
        </div>
        <!-- end container -->
    </section>
    <!-- =-=-=-=-=-=-= Our Services-end =-=-=-=-=-=-= -->


</asp:Content>



