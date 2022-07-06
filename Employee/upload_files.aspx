<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload_files.aspx.cs" Inherits="Employee_upload_files" %>

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
	<link href="//fonts.googleapis.com/css?family=Raleway:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i&amp;subset=latin-ext"
	    rel="stylesheet">
	<link href="//fonts.googleapis.com/css?family=Varela+Round" rel="stylesheet">
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
						<li class="nav-item active">
							<a class="nav-link" href="upload_files.aspx">Upload Files
                                <span class="sr-only">(current)</span>
							</a>
						</li>
						<li class="nav-item">
							<a class="nav-link" href="my_requsets.aspx">My Request</a>
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
					<li class="breadcrumb-item active">Uploads</li>
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
                        
                        <br /><br />
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                            <asp:View ID="View1" runat="server">

                                <table class="table table-hover" style="border-style:double;border-color:#905a5a;background-color:#ead6d6">
                                    <tr>
                                        <td colspan="2">
                                            <div class="text-center"><asp:Label ID="Label1" runat="server" Text="Upload Files" Font-Size="Large" Font-Underline="True" ForeColor="#336600"></asp:Label></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="FileName" ForeColor="Black"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Enter Filename" ForeColor="#ff0000" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" Text="Description" ForeColor="Black"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" CssClass="form-control" AutoCompleteType="Disabled" ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Enter Discription" ForeColor="#ff0000" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Upload File" ForeColor="Black"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">&nbsp;
                                            <div class="text-center">
                                                <asp:Button ID="Button1" runat="server" Text="Upload"  CssClass="btn btn-sm btn-success" OnClick="Button1_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>

                            </asp:View>
                            <asp:View ID="View2" runat="server">
                              <div class="container">
                                  <div class="row">
                                      <div class="col-lg-2"></div>
                                       <div class="col-lg-10">
<asp:DataList ID="DataList1" runat="server" CssClass="table table-bordered table-hover table-responsive" OnItemDataBound="DataList1_ItemDataBound" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="2000px">
                                    <AlternatingItemStyle BackColor="#F7F7F7" />
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <ItemTemplate>
                                        <table class="table table-bordered table-hover table-responsive">
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                    <asp:Label ID="Label5" runat="server" Text='<%# bind("role") %>' ForeColor="Black"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DataList ID="DataList2" runat="server" CssClass="table table-bordered table-hover table-responsive" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" GridLines="Both">
                                                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                                        <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                                        <ItemTemplate>
                                                            <table class="table table-bordered table-hover table-responsive" >
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="CheckBox2" runat="server" />
                                                                        <asp:Label ID="Label6" runat="server" Text='<%# bind("sub_main_role") %>' ForeColor="Black"></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label80" runat="server" ForeColor="Black" Text='<%# bind("priority") %>' Visible="False" Font-Size="X-Large"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DataList ID="DataList3" runat="server">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="CheckBox3" runat="server" />
                                                                                <asp:Label ID="Label7" runat="server" Text='<%# bind("sub_role") %>' ForeColor="Black"></asp:Label>
                                                                                <asp:Label ID="Label8" runat="server" ForeColor="Black" Text='<%# bind("Priority") %>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:DataList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                    </asp:DataList>
                                                </td>
                                            </tr>
                                           
                                        </table>
                                    </ItemTemplate>
                                    <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                </asp:DataList>


                                       </div>
                                       <div class="col-lg-2"></div>
                                  </div>
                              </div>
                                
                                   
                                <div class="text-center">
                            <asp:Button ID="Button2" runat="server" Text="Privacy" CssClass="btn btn-sm btn-success" OnClick="Button2_Click" />
                                </div>
                            </asp:View>
                        </asp:MultiView>




                        

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