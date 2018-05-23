<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- =-=-=-=-=-=-= HOME SLIDER =-=-=-=-=-=-= -->
    <div class="rev_slider_wrapper">
        <div class="rev_slider" data-version="5.0">
            <ul>

                <asp:Literal ID="ltrslider" runat="server"></asp:Literal>


            </ul>
        </div>
        <!-- end .rev_slider -->
    </div>
    <!--======= HOME SLIDER END =========-->

    <!-- =-=-=-=-=-=-= Services =-=-=-=-=-=-= -->
    <section class="custom-padding white" id="about-section-3" style="padding-top: 50px !important;">
        <!-- title-section -->
        <div class="main-heading text-center" style="margin-bottom: 25px !important; margin-top: -12px !important;">
            <h2>HİZMETLERİMİZ</h2>

        </div>
        <!-- End title-section -->
        <div class="container">
            <div class="main-boxes">
                <div class="row">
                    <asp:Literal ID="ltrhizmet" runat="server"></asp:Literal>
                    <!-- end col-sm-4 -->


                    <!-- end col-sm-4 -->

                </div>
            </div>
            <!-- end main-boxes -->
        </div>
        <!-- end container -->
    </section>
    <!-- =-=-=-=-=-=-= Services =-=-=-=-=-=-= -->


    <!-- =-=-=-=-=-=-= Our Services =-=-=-=-=-=-= -->
    <section class="custom-padding services">
        <div class="container">


            <!-- Row -->
            <div class="row" style="margin-top: -10px !important;">
                <div id="services">
                    <!-- Service Item List -->
                    <div class="item">
                        <!-- services grid -->
                        <div class="services-grid">
                            <div class="icons"><i class="flaticon-box-of-packing-for-delivery"></i></div>
                            <h4>paketleme ve depolama </h4>
                            <p>Sizin için en doğru paketleme ve taşıma yöntemlerini biliyoruz.</p>
                        </div>
                    </div>
                    <!-- services grid -->
                    <div class="item">
                        <div class="services-grid">
                            <div class="icons"><i class="flaticon-delivery-truck"></i></div>
                            <h4>Şehir İçi Nakliyat </h4>
                            <p>Adana evden eve taşımacılık hizmetleri kapsamında en güvenilir ve uygun fiyatlı hizmet.</p>
                        </div>
                    </div>
                    <!-- Service Item List -->
                    <div class="item">
                        <!-- services grid -->

                        <div class="services-grid">
                            <div class="icons"><i class="flaticon-view-symbol-on-delivery-opened-box"></i></div>
                            <h4>Sigortalı Taşımacılık</h4>
                            <p>Sigortalı taşımacılık kapsamında tüm eşyalarınızı taşıma öncesinde güvence altına alıyoruz.</p>
                        </div>
                    </div>
                    <!-- services grid -->
                    <div class="item">
                        <div class="services-grid">
                            <div class="icons"><i class="flaticon-delivery-truck-with-packages-behind"></i></div>
                            <h4>Asansörlü Taşımacılık </h4>
                            <p>Asansörlü taşımacılık hizmetlerimiz ile birlikte eşyalarınızı güven içerisinde taşıyoruz.</p>
                        </div>
                    </div>

                    <!-- Service Item List End -->
                </div>
            </div>
            <!-- Row End -->
        </div>
        <!-- end container -->
    </section>
    <!-- =-=-=-=-=-=-= Our Services-end =-=-=-=-=-=-= -->

    <!-- =-=-=-=-=-=-= Quote Seection =-=-=-=-=-=-= -->

    <section class="quote" id="quote">
        <div class="container">
            <div class="row clearfix">

                <!--Column-->
                <div class="col-md-7 col-sm-12 col-xs-12 ">
                    <div class="choose-title">
                        <h2>
                            <asp:Literal ID="ltrbasalik" runat="server"></asp:Literal>
                        </h2>

                        <asp:Literal ID="ltricerik" runat="server"></asp:Literal>



                    </div>
                </div>

                <!-- Quote Form -->
                <div class="col-md-5 col-sm-12 no-extra col-xs-12">
                    <div class="quotation-box">
                        <form action="http://templates.scriptsbundle.com/logistic-pro/demo/logistic-pro/contact.html" method="post">
                            <div class="row clearfix">
                                <img src="resimler/kurum.png" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <!-- =-=-=-=-=-=-= Quote Seection end=-=-=-=-=-=-= -->


    <!-- =-=-=-=-=-=-= Gallery =-=-=-=-=-=-= -->
    <section id="gallery" class="custom-padding">
        <div class="container">
            <!-- title-section -->
            <div class="main-heading text-center" style="margin-bottom: 20px !important; margin-top: -10px !important;">
                <h2>GALERİ</h2>
            </div>
            <!-- End title-section -->

            <div class="portfolio-container text-center">


                <ul id="portfolio-grid" class="three-column hover-two">
                    <asp:Literal ID="ltrAnasayfaGaleri" runat="server"></asp:Literal>
                </ul>
            </div>

            <!-- portfolio-container -->



        </div>
        <!-- end container -->
    </section>

    <%--<!-- =-=-=-=-=-=-= Our Clients =-=-=-=-=-=-= -->
    <section class="section-padding-70 services">
        <div class="container">
            <!-- title-section -->
            <div class="main-heading text-center" style="margin-top: -60px !important; margin-bottom: 25px !important;">
                <h2>our partners</h2>

            </div>
            <!-- End title-section -->

            <!-- Row -->
            <div class="row">
                <div id="clients" class="text-center">
                    <!-- Service Item List -->
                    <div class="item">
                        <div class="clients-grid">
                            <img class="img-responsive" alt="" src="images/clients/client_5.png">
                        </div>
                    </div>
                    <div class="item">
                        <div class="clients-grid">
                            <img class="img-responsive" alt="" src="images/clients/client_5.png">
                        </div>
                    </div>
                    <div class="item">
                        <div class="clients-grid">
                            <img class="img-responsive" alt="" src="images/clients/client_5.png">
                        </div>
                    </div>
                    <div class="item">
                        <div class="clients-grid">
                            <img class="img-responsive" alt="" src="images/clients/client_5.png">
                        </div>
                    </div>
                    <div class="item">
                        <div class="clients-grid">
                            <img class="img-responsive" alt="" src="images/clients/client_5.png">
                        </div>
                    </div>
                    <div class="item">
                        <div class="clients-grid">
                            <img class="img-responsive" alt="" src="images/clients/client_5.png">
                        </div>
                    </div>
                    <div class="item">
                        <div class="clients-grid">
                            <img class="img-responsive" alt="" src="images/clients/client_5.png">
                        </div>
                    </div>
                    <div class="item">
                        <div class="clients-grid">
                            <img class="img-responsive" alt="" src="images/clients/client_5.png">
                        </div>
                    </div>
                    <div class="item">
                        <div class="clients-grid">
                            <img class="img-responsive" alt="" src="images/clients/client_5.png">
                        </div>
                    </div>
                    <div class="item">
                        <div class="clients-grid">
                            <img class="img-responsive" alt="" src="images/clients/client_5.png">
                        </div>
                    </div>
                    <div class="item">
                        <div class="clients-grid">
                            <img class="img-responsive" alt="" src="images/clients/client_5.png">
                        </div>
                    </div>
                    <div class="item">
                        <div class="clients-grid">
                            <img class="img-responsive" alt="" src="images/clients/client_5.png">
                        </div>
                    </div>
                    <!-- Service Item List End -->
                </div>
            </div>
            <!-- Row End -->
        </div>
        <!-- end container -->
    </section>
    <!-- =-=-=-=-=-=-= Our Clients -end =-=-=-=-=-=-= -->--%>
</asp:Content>

