<%@ Page Language="C#" AutoEventWireup="true" CodeFile="my_requsets.aspx.cs" Inherits="Employee_my_requsets" %>

<!DOCTYPE html>

<html lang="zxx">

<head>
	<title>Extended File Hierarchy</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<meta charset="utf-8">
	<meta name="keywords" content="Accrue a Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design" />
	<script>
	    addEventListener("load", function () {
	        setTimeout(hideURLbar, 0);
	    }, false);

	    function hideURLbar() {
	        window.scrollTo(0, 1);
	    }
	</script>
	<link href="css/bootstrap.css" rel='stylesheet' type='text/css' />
	<link href="css/style.css" rel='stylesheet' type='text/css' />
	<link href="css/fontawesome-all.css" rel="stylesheet">
	<link href="/../fonts.googleapis.com/css?family=Raleway:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i&amp;subset=latin-ext"
	    rel="stylesheet">
	<link href="/../fonts.googleapis.com/css?family=Varela+Round" rel="stylesheet">
</head>
<body>
    <form id="f1" runat="server">
	<!--/banner-->
	<div class="banner-inner" id="home">
		<!-- header -->
		<header>
			<nav class="navbar navbar-expand-lg navbar-light bg-light top-header">
				<h1 class="logo">
					<a class="navbar-brand" href="index.html">
						<i class="fab fa-accusoft"></i>
						<span>File Hierarchy </span>
					</a>
				</h1>
				<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
				    aria-expanded="false" aria-label="Toggle navigation">
					<span class="navbar-toggler-icon">
						<i class="fas fa-bars"></i>
					</span>
				</button>
				<div class="collapse navbar-collapse" id="navbarSupportedContent">
					<ul class="navbar-nav ml-auto">
						<li class="nav-item ">
							<a class="nav-link ml-lg-0" href="home.aspx">Home
								
							</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="upload_files.aspx">Upload Files</a>
						</li>
						<li class="nav-item active">
							<a class="nav-link" href="my_requsets.aspx">My Request
                                <span class="sr-only">(current)</span>
							</a>
						</li>
						<li class="nav-item dropdown">
							<a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true"
							    aria-expanded="false">
								other
							</a>
							<div class="dropdown-menu" aria-labelledby="navbarDropdown">
								<a class="dropdown-item text-center" href="approved_files.aspx">Approved Files</a>
								<a class="dropdown-item text-center" href="access_denied_files.aspx">Denied Files</a>
								<a class="dropdown-item text-center" href="access_files.aspx">acess files</a>
                                <a class="dropdown-item text-center" href="change_profile.aspx">Edit Profile</a>
								<a class="dropdown-item text-center" href="view_my_uploaded_files.aspx">Update Assigned Privacies</a>

							</div>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="../index/index.aspx">logout</a>
						</li>
						<li class="search">
							<a class="play-icon popup-with-zoom-anim" href="#small-dialog">
								<i class="fas fa-search"></i>
							</a>
							<div id="small-dialog" class="mfp-hide">
								<div class="search-top">
									<div class="search-inn">
										
											<input class="form-control" type="search" name="search" value="Type something..." onfocus="this.value = '';" onblur="if (this.value == '') {this.value = '';}">
											<button class="btn2">
												<i class="fas fa-search"></i>
											</button>
										
									</div>
									<p>Accrue</p>
								</div>
							</div>
						</li>
					</ul>
				</div>
				<!-- <form class="form-inline my-2 my-lg-0">
							  <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
							  <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
							</form> -->
			</nav>
		</header>
		<!-- //header -->
		<!-- /banner-text -->
		   <div class="ban-inner-content text-center">
			   <ol class="breadcrumb justify-content-center">
					<li class="breadcrumb-item">
						<a href="index.html">Home</a>
					</li>
					<li class="breadcrumb-item active">Request</li>
				</ol>
			</div>
		<!-- //banner-text -->
	</div>
	<!-- //banner -->
	<!-- contact -->
	<section class="bottom-banner-w3layouts contact">
		<div class="container">
                <div class="row">
                 
                    <div class="col-lg-12">
                        
                        <br />
                        <div class="text-center">

                                                        <asp:Label ID="Label2" runat="server" Text="My Requests" ForeColor="#cc0000" Font-Size="Large" ></asp:Label>

                        </div>
                        <br />
                        

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-reponsive" Visible="False" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                              <Columns>
                                <asp:BoundField DataField="r_id" HeaderText="#"  Visible="false"/>
                                <asp:BoundField DataField="fname" HeaderText="File Name" />
                             <asp:BoundField DataField="request_by" HeaderText="Requset from" />

                                <asp:BoundField DataField="request_date" HeaderText="Requested Date" />
                                 <asp:TemplateField HeaderText="Accept/Reject">
                                      <ItemTemplate>
                                          <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-sm btn-success" CommandName="delete">Accept Request</asp:LinkButton>
                                          <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-sm btn-success" CommandName="update">Reject Request</asp:LinkButton>
                                         <%-- <asp:Button ID="Button1" runat="server" Text="Accept Request" CssClass="btn btn-sm btn-success" CommandName="delete" />
                                          <asp:Button ID="Button2" runat="server" Text="Reject Request" CssClass="btn btn-sm btn-success" CommandName="update" />--%>

                                          <br />
                                          <br />
                                          <asp:Label ID="Label1" runat="server" Text='<%# bind("fname") %>' Visible="False"></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        
                        <div class="text-center">

                                                <asp:Label ID="Label4" runat="server" Text="No Requests......" Font-Bold="true" Visible="false" Font-Size="Large" ForeColor="#ff0000"></asp:Label>

                        </div>

                    </div>

                    

                </div>
			</div>
		
	</section>
	<!-- //contact -->
	<!--footer -->
	<%--<footer>
		<div class="container">
			<div class="row footer-top">
				<div class="col-lg-3 footer-grid-w3ls">
					<div class="footer-title">
						<h3>About Us</h3>
					</div>
					<div class="footer-text">
						<p>Curabitur non nulla sit amet nislinit tempus convallis quis ac lectus. lac inia eget consectetur sed, convallis at
							tellus. Nulla porttitor accumsana tincidunt.</p>
						<div class="social-icon footer text-left mt-4">
							<div class="icon-social">
								<a href="#" class="button-footr">
									<i class="fab fa-facebook-f"></i>
								</a>
								<a href="#" class="button-footr">
									<i class="fab fa-twitter"></i>
								</a>
								<a href="#" class="button-footr">
									<i class="fab fa-dribbble"></i>
								</a>

							</div>
						</div>
					</div>
				</div>
				<div class="col-lg-3 footer-grid-w3ls">
					<div class="footer-title">
						<h3>Get in touch</h3>
					</div>
					<div class="contact-info">
						<h4>Location :</h4>
						<p>0926k 4th block building, king Avenue, New York City.</p>
						<div class="phone">
							<h4>Contact :</h4>
							<p>Phone : +121 098 8907 9987</p>
							<p>Email :
								<a href="mailto:info@example.com">info@example.com</a>
							</p>
						</div>
					</div>
				</div>
				<div class="col-lg-3 footer-grid-w3ls">
					<div class="footer-title">
						<h3>Useful Links</h3>
					</div>
					<ul class="links">
						<li>
							<a href="index.html">Home</a>
						</li>
						<li>
							<a href="about.html">About</a>
						</li>
						<li>
							<a href="blog.html">Blog</a>
						</li>
						<li>
							<a href="projects.html">Projects</a>
						</li>
						<li>
							<a href="contact.html">Contact Us</a>
						</li>
					</ul>
				</div>
				<div class="col-lg-3 footer-grid-w3ls">
					<div class="footer-title">
						<h3>Subscribe</h3>
					</div>
					<div class="footer-text">
						<p>By subscribing to our mailing list you will always get latest news and updates from us.</p>
						

					</div>
				</div>
			</div>
			<div class="copyright mt-4">
				<p class="copy-right text-center ">&copy; 2018 Accrue. All Rights Reserved | Design by
					<a href="http://w3layouts.com/"> W3layouts </a>
				</p>
			</div>
		</div>
	</footer>--%>
	<!-- //footer -->

	<!-- //Custom-JavaScript-File-Links -->
	<a href="#home" class="scroll" id="toTop" style="display: block;">
		<span id="toTopHover" style="opacity: 1;"> </span>
	</a>
	<!-- js -->
	<script src="js/jquery-2.2.3.min.js"></script>
	<!-- flexSlider -->
	<script defer src="js/jquery.flexslider.js"></script>
	<script>
	    // Can also be used with $(document).ready()
	    $(window).load(function () {
	        $('.flexslider').flexslider({
	            animation: "slide"
	        });
	    });
	</script>
	<!-- //flexSlider -->
	<!--pop-up-box-->
	<link href="css/popuo-box.css" rel="stylesheet" type="text/css" media="all" />
	<script src="js/jquery.magnific-popup.js" ></script>
	<!--//pop-up-box-->
	<script>
	    $(document).ready(function () {
	        $('.popup-with-zoom-anim').magnificPopup({
	            type: 'inline',
	            fixedContentPos: false,
	            fixedBgPos: true,
	            overflowY: 'auto',
	            closeBtnInside: true,
	            preloader: false,
	            midClick: true,
	            removalDelay: 300,
	            mainClass: 'my-mfp-zoom-in'
	        });

	    });
	</script>
	<!--//search-bar-->

	<!-- carousel -->
	<script src="js/owl.carousel.js"></script>
	<script>
	    $(document).ready(function () {
	        $('.owl-carousel').owlCarousel({
	            loop: true,
	            margin: 10,
	            responsiveClass: true,
	            responsive: {
	                0: {
	                    items: 1,
	                    nav: true
	                },
	                600: {
	                    items: 1,
	                    nav: false
	                },
	                900: {
	                    items: 1,
	                    nav: false
	                },
	                1000: {
	                    items: 1,
	                    nav: true,
	                    loop: false,
	                    margin: 20
	                }
	            }
	        })
	    })
	</script>
	<!-- //carousel -->
	<!--/ start-smoth-scrolling -->
	<script src="js/move-top.js"></script>
	<script src="js/easing.js"></script>
	<script>
	    jQuery(document).ready(function ($) {
	        $(".scroll").click(function (event) {
	            event.preventDefault();
	            $('html,body').animate({
	                scrollTop: $(this.hash).offset().top
	            }, 900);
	        });
	    });
	</script>
<!--// end-smoth-scrolling -->
	<script>
	    $(document).ready(function () {
	        /*
									var defaults = {
							  			containerID: 'toTop', // fading element id
										containerHoverID: 'toTopHover', // fading element hover id
										scrollSpeed: 1200,
										easingType: 'linear' 
							 		};
									*/

	        $().UItoTop({
	            easingType: 'easeOutQuart'
	        });

	    });
	</script>
	
	<!-- /js -->
	  <script src="js/bootstrap.js"></script>
	<!-- //js -->
        </form>
</body>
</html>
