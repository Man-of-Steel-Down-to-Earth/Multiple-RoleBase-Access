<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="NewFolder1_index" %>

<!DOCTYPE html>

<html lang="en">
<head>
<title>Multiple Files Role Base Acess</title>
<!-- for-mobile-apps -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Freightage Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- //for-mobile-apps -->
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
<link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" media="all">
<!--web-fonts-->
<link href="//fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Lato:300,400,700" rel="stylesheet">
<!--//web-fonts-->
<!--//fonts-->
    <style>
        .curved {
            border-radius:35px;
        }
    </style>
</head>
<body>
<form id="f1" runat="server">

    <div class="banner-w3layouts" id="home">
		<!--Top-Bar-->
	<div class="header">
		<nav class="navbar navbar-default">
					<div class="navbar-header curved">
						
						<h1><a  href="#">File Hierarchy</a></h1>
					</div>
					<div class="top-nav-text">
						<div class="nav-contact-w3ls"><span class="glyphicon glyphicon glyphicon-phone" aria-hidden="true"></span><p>Call us now <br> <span class="call">+0 111 222 333</span></p></div> 
						<a class="page-scroll" href="#myModal2" data-toggle="modal" data-hover="LOGIN">LOGIN</a>
					</div>
					<!-- navbar-header -->
					<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
						<ul class="nav navbar-nav navbar-right">
							
						</ul>
					</div>
					<div class="clearfix"> </div>	
				</nav>
	
	</div>
		<!--//Top-Bar-->
			<!-- modal -->
	<div class="modal about-modal w3-agileits fade" id="myModal2" tabindex="-1" role="dialog">
		<div class="modal-dialog" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>						
				</div> 
				<div class="modal-body login-page "><!-- login-page -->     
									<div class="login-top sign-top">
										<div class="agileits-login">
										<h5>Login</h5>
                                            <asp:TextBox ID="TextBox1" runat="server" class="email" name="Email" placeholder="username" required=""></asp:TextBox>
                                                   <asp:TextBox ID="TextBox2" runat="server" class="password" name="Password" placeholder="Password" required=""></asp:TextBox>
											

											<div class="wthree-text"> 
												<ul> 
													<li>
														<label class="anim">
															<input type="checkbox" class="checkbox">
															<span> Remember me ?</span> 
														</label> 
													</li>
													<li> <a href="#">Forgot password?</a> </li>
												</ul>
												< </li>
												</ul>
												<div class="clearfix"> </div>
											</div>  
											<div class="w3ls-submit">
                                                <asp:Button ID="Button1" runat="server" Text="LOGIN" type="submit" value="LOGIN" OnClick="Button1_Click" />
												
                                                  	
											</div>	
										

										</div>  
									</div>
						</div>  
				</div> <!-- //login-page -->
			</div>
		</div>
	<!-- //modal --> 
	<!-- modal -->
	
	<!-- //modal --> 
<!--banner-->
		<!--Slider-->
			<div class="w3l_banner_info">
				<div class="col-md-7 slider">
					<div class="callbacks_container">
								<ul class="rslides" id="slider3">
									<li>
										<div class="slider_banner_info">
											 <p style="color:#d98787;font:bold">A business absolutely devoted to Customer Service Excellence will have only one worry about profits. They will be embarrassingly large.”							</li>
									<li>
										<div class="slider_banner_info">
											

											<p style="color:#0094ff">The purpose of business is to create and keep a customer</p>
										</div>

									</li>
									

								</ul>
					</div>
				</div>
				
		</div>
			<!--//Slider-->
			<div class="clearfix"></div>
						</div>

</form>
		
<!--//banner-->

<!-- welcome -->
	
	<!-- //welcome -->
<!-- Stats -->
	
	<!-- //Stats -->

<!-- capabilities -->
	
<!-- //capabilities -->
<!--team-->

<!--//team-->
<!-- gallery -->
		
		<!-- //gallery --> 	
<!--map-->
		
		<!-- modal -->
	<div class="modal about-modal w3-agileits fade" id="myModal1" tabindex="-1" role="dialog">
		<div class="modal-dialog" role="document">
			<div class="modal-content">
				<div class="modal-header">
					<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>						
				</div> 
				  
				</div> <!-- //login-page -->
			</div>
		</div>
	<!-- //modal --> 
<!--//map-->

	
<!-- js -->
<script type="text/javascript" src="js/jquery-2.1.4.min.js"></script>
<!-- jarallax-js -->
			<script src="js/jarallax.js"></script>
			<script src="js/SmoothScroll.min.js"></script>
			<script type="text/javascript">
			    /* init Jarallax */
			    $('.jarallax').jarallax({
			        speed: 0.5,
			        imgWidth: 1366,
			        imgHeight: 768
			    })
			</script>
<!-- //jarallax-js -->
					<!--banner Slider starts Here-->
						<script src="js/responsiveslides.min.js"></script>
							<script>
							    // You can also use "$(window).load(function() {"
							    $(function () {
							        // Slideshow 4
							        $("#slider3").responsiveSlides({
							            auto: true,
							            pager: true,
							            nav: false,
							            speed: 500,
							            namespace: "callbacks",
							            before: function () {
							                $('.events').append("<li>before event fired.</li>");
							            },
							            after: function () {
							                $('.events').append("<li>after event fired.</li>");
							            }
							        });

							    });
							 </script>

							<!--banner Slider starts Here-->


<!--light-box-files -->
<script src="js/modernizr.custom.js"></script>
<script src="js/jquery.chocolat.js"></script>
<link rel="stylesheet" href="css/chocolat.css" type="text/css" media="screen">
<!--//light-box-files -->
		<script type="text/javascript">
		    $(function () {
		        $('.gallery a').Chocolat();
		    });
		</script>
<!-- //js -->
<!-- start-smoth-scrolling -->
<script type="text/javascript" src="js/move-top.js"></script>
<script type="text/javascript" src="js/easing.js"></script>
<script type="text/javascript">
    jQuery(document).ready(function ($) {
        $(".scroll").click(function (event) {
            event.preventDefault();
            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
        });
    });
</script>
<!-- start-smoth-scrolling -->
<!--//footer-section-->
<!-- Starts-Number-Scroller-Animation-JavaScript -->		
<script type="text/javascript" src="js/numscroller-1.0.js"></script>
<!-- //Starts-Number-Scroller-Animation-JavaScript -->
<!-- smooth scrolling -->
	<script type="text/javascript">
	    $(document).ready(function () {
	        /*
                var defaults = {
                containerID: 'toTop', // fading element id
                containerHoverID: 'toTopHover', // fading element hover id
                scrollSpeed: 1200,
                easingType: 'linear' 
                };
            */
	        $().UItoTop({ easingType: 'easeOutQuart' });
	    });
	</script>
	<a href="#" id="toTop" style="display: block;"> <span id="toTopHover" style="opacity: 1;"> </span></a>
<!-- //smooth scrolling -->


<script type="text/javascript" src="js/bootstrap-3.1.1.min.js"></script>
</body>
</html>