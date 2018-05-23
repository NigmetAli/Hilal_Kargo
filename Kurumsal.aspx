<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kurumsal.aspx.cs" Inherits="Kurumsal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- =-=-=-=-=-=-= PAGE BREADCRUMB =-=-=-=-=-=-= -->
    <section class="breadcrumbs-area parallex">
        <div class="container">
            <div class="row">
                <div class="page-title">
                    <div class="col-sm-12 col-md-6 kurumsalBaslik text-left">
                     
                        
      <h2> <asp:Literal ID="ltrbaslik" runat="server"></asp:Literal></h2> 
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- =-=-=-=-=-=-= PAGE BREADCRUMB END =-=-=-=-=-=-= -->

<asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <!-- =-=-=-=-=-=-= About Section =-=-=-=-=-=-= -->

    <section class="padding-yukari">
        <div class="container">
            <div class="row clearfix">
                <!--Column-->
                <div class="col-md-7 col-sm-12 col-xs-12 ">
                    <div class="about-title">
                      <asp:Literal ID="ltricerik" runat="server"></asp:Literal>
                    </div>

                </div>

                <!-- RIght Grid Form -->
                <div class="col-md-5 col-sm-12 col-xs-12 our-gallery">
                    <a class="tt-lightbox" href="images/about-company-1.png"> <img class="img-responsive margin-bottom-30" alt="Image" src="images/about-company-1.png"></a>
                </div>
            </div>
        </div>
    </section>

    <!-- =-=-=-=-=-=-= About End =-=-=-=-=-=-= -->

</asp:Content>



