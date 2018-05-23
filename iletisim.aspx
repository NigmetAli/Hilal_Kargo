<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="iletisim.aspx.cs" Inherits="iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- =-=-=-=-=-=-= PAGE BREADCRUMB =-=-=-=-=-=-= -->
    <section class="breadcrumbs-area parallex">
        <div class="container">
            <div class="row">
                <div class="page-title">
                    <div class="col-sm-12 col-md-6 kurumsalBaslik text-left">
                        <h4> </h4>
                        <h3>İLETİŞİM</h3>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- =-=-=-=-=-=-= PAGE BREADCRUMB END =-=-=-=-=-=-= -->
    
    <!-- =-=-=-=-=-=-= Google Map =-=-=-=-=-=-= -->
  <section id="google-map">
			<div class="container-fluid no-padding">
				<div id="map">
                    <iframe style="width: 100%; height:450px !important; padding-left: 1px;" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=tr&amp;geocode=&amp;q=Mavi+Blv,+Adana,+T%C3%BCrkiye&amp;aq=&amp;sll=37.026711,35.308127&amp;sspn=0.009713,0.021136&amp;ie=UTF8&amp;hq=&amp;hnear=Mavi+Blv,+Adana,+T%C3%BCrkiye&amp;t=m&amp;z=14&amp;ll=37.028183,35.283783&amp;output=embed" ></iframe>

				</div>
			</div><!-- container-fluid end -->
</section>

    <!-- =-=-=-=-=-=-= Google Map End =-=-=-=-=-=-= -->

    <!-- =-=-=-=-=-=-= Contact Us =-=-=-=-=-=-= -->
    <section id="contact-us" class="padding-yukari-30">
        <div class="container">
            <!-- Row -->
            <div class="row">

                <div class="col-md-6 satirArasi">

                    

                
                        <div class="col-sm-6">
                            <!-- Name -->
                            <div class="form-group">
                                <label>İsim<span class="required">*</span></label>
                                 <asp:TextBox ID="txtad" placeholder="İsim"  class="form-control" runat="server"></asp:TextBox>
                                
                                 </div>
                        </div>
                        <!-- End col-sm-6 -->

                        <div class="col-sm-6">
                            <!-- Email -->
                            <div class="form-group">
                                <label for="email">E-Mail<span class="required">*</span></label>
                   
                                <asp:TextBox ID="txtemail" placeholder="E-Mail" class="form-control" runat="server"></asp:TextBox>
                                
                                  </div>
                        </div>
                        <!-- End col-sm-6 -->


                        <div class="col-sm-12">
                            <!-- Email -->
                            <div class="form-group">
                                <label>Konu<span class="required">*</span></label>
                                <asp:TextBox ID="txtkonu" placeholder="Konu"  class="form-control" runat="server"></asp:TextBox>
                                    </div>
                        </div>
                        <!-- End col-sm-12 -->


                        <div class="col-sm-12">
                            <!-- Comment -->
                            <div class="form-group">
                                <label>Mesaj<span class="required">*</span></label>
                                    <asp:TextBox ID="txtmesaj" placeholder="Mesajınız"  class="form-control" runat="server"></asp:TextBox>
                              
                            
                            
                            </div>
                        </div>
                        <!-- End col-sm-12 -->

                        <div class="col-sm-12 text-center">
                          
                                        <asp:Button ID="submit" runat="server" Text="Gönder" OnClick="submit_Click" /><br />
                   <asp:Label ID="SonucLbl" runat="server"></asp:Label>       </div>
                        <!-- End col-sm-6 -->


                </div>

                <div class="col-md-6  ">

                    <div class="notice success" id="success">
                        <p>Mesajınız için teşekkürler. Mailinizi kontrol edip size elimizden gelnin en iyisini sunacağız.</p>
                    </div>



                    <span style="color: #016db6">İLETİŞİM BİLGİLERİ</span><br>
                    <br>
                    <span style="color: #016db6;">Adres : </span>
                    Adana O.S.B. Baklalı Cad. No: 25 Sarıçam-ADANA-TURKEY
                                <br>
                    <span style="color: #016db6;">Telefon : </span>
                    +90 322 394 41 54
                                <br>
                    <span style="color: #016db6;">Fax : </span>(322) 394 41 45
            
            <br>
                    <span style="color: #016db6">E-Mail : </span>
                    info@akdenizirmik.com<br>

                </div>



                <div class="clearfix"></div>
            </div>
            <!-- Row End -->
        </div>
        <!-- end container -->
    </section>
    <!-- =-=-=-=-=-=-= Contact Us End =-=-=-=-=-=-= -->











<!-- =-=-=-=-=-=-= JQUERY =-=-=-=-=-=-= --> 
<script src="js/jquery.min.js"></script> 
<!-- Bootstrap Core Css  --> 
<script src="js/bootstrap.min.js"></script>
    <!-- Dropdown Hover  -->
     <script src="js/bootstrap-dropdownhover.min.js"></script><!-- Jquery Easing --> 
<script type="text/javascript" src="js/easing.js"></script> 
<!-- Jquery Counter --> 
<script src="js/jquery.countTo.js"></script> 
<!-- Jquery Waypoints --> 
<script src="js/jquery.waypoints.js"></script> 
<!-- Jquery Appear Plugin --> 
<script src="js/jquery.appear.min.js"></script> 
<!-- Jquery Shuffle Portfolio --> 
<script src="js/jquery.shuffle.min.js"></script> 
<!-- Carousel Slider  --> 
<script src="js/carousel.min.js"></script> 
<!-- Jquery Parallex --> 
<script src="js/jquery.stellar.min.js"></script> 
<!--Style Switcher --> 
<script src="js/color-switcher.js"></script> 
<!-- Gallery Magnify  --> 
<script src="js/magnific-popup/jquery.magnific-popup.min.js"></script>
 <!-- Sticky Bar  -->
    <script src="js/theia-sticky-sidebar.js"></script> 
<!-- Template Core JS --> 
<script src="js/custom.js"></script>

<!-- Google Map For This Page Only --> 
<script type="text/javascript" src="js/map.js"></script>
<script type="text/javascript" src="js/validator.min.js"></script>
<script type="text/javascript">
(function($){
    "use strict";

	$('#contactForm').validator().on('submit', function (e) {
  if (e.isDefaultPrevented()) {
    // handle the invalid form...
  } else {
	  $("#yes").html('Processsing...');
	  $('#loader').show();
     $.ajax({
          type:"POST",
          url:'php/contact.php',
          data: $("#contactForm").serialize(),//only input
          
          success: function(response){
           if(response == "success"){
            $('#success').show();
            $('#loader').hide();
			$("#yes").html('Done Email...');
            $( '#contactForm' ).each(function(){
             this.reset();
            });
						
           }
          }
         });
		 return false;
  }
})
	
	})(jQuery);
</script>





</asp:Content>


