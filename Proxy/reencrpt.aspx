
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reencrpt.aspx.cs" Inherits="Proxy_reencrpt" %>

<!DOCTYPE html>

<html lang="en">

<head>

    <!-- Basic -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <!-- Mobile Metas -->
    <meta name="viewport" content="width=device-width, maximum-scale=1, initial-scale=1, user-scalable=0">

    <!-- Site Metas -->
    <title>Food Funday Restaurant - One page HTML Responsive</title>
    <meta name="keywords" content="">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Site Icons -->
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link rel="apple-touch-icon" href="images/apple-touch-icon.png">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <!-- Site CSS -->
    <link rel="stylesheet" href="css/style.css">
    <!-- Responsive CSS -->
    <link rel="stylesheet" href="css/responsive.css">
    <!-- color -->
    <link id="changeable-colors" rel="stylesheet" href="css/colors/orange.css" />

    <!-- Modernizer -->
    <script src="js/modernizer.js"></script>

    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head>

<body>
    <form id="f1" runat="server">    <div id="loader">
        <div id="status"></div>
    </div>
    <div id="site-header">
        <header id="header" class="header-block-top">
            <div class="container">
                <div class="row">
                    <div class="main-menu">
                        <!-- navbar -->
                        <nav class="navbar navbar-default" id="mainNav">
                            <div class="navbar-header">
                                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                                    <span class="sr-only">Toggle navigation</span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                </button>
                                <div class="logo">
                                    <a class="navbar-brand js-scroll-trigger logo-header" href="#">
                                      <h1><span style="color:white;font-size:60px">R</span> <span style="color:red;font-size:xx-large">BAC</span></h1>
                                    </a>
                                </div>
                            </div>
                            <div id="navbar" class="navbar-collapse collapse">
                                <ul class="nav navbar-nav navbar-right">
                                    <li class="active"><a href="home.aspx">Home</a></li>
                                    <li><a href="reencrpt.aspx">Re-Encrypt</a></li>
                                      <li><a href="../index/index.aspx">Logout</a></li>
                                     
                                </ul>
                            </div>
                            <!-- end nav-collapse -->
                        </nav>
                        <!-- end navbar -->
                    </div>
                </div>
                <!-- end row -->
            </div>
            <!-- end container-fluid -->
        </header>
        <!-- end header -->
    </div>
	<!-- end site-header -->
	
    
    <!-- end banner -->

    

    
    <!-- end special-menu -->

    
    <!-- end menu -->

    
    <!-- end team-main -->

    
    <!-- end gallery-main -->

    <div id="blog" class="blog-main pad-top-100 pad-bottom-100 parallax">
        <div class="container">
                <div class="row">
                 
                    <div class="col-lg-12">
                        
                        <br /><br />
                        

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-reponsive" OnRowDeleting="GridView1_RowDeleting" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" >
                              <Columns>
                                <asp:BoundField DataField="fid" HeaderText="#"  Visible="false"/>
                                <asp:BoundField DataField="Name" HeaderText="Owner Name" />
                                <asp:BoundField DataField="fname" HeaderText="File Name" />
                                <asp:BoundField DataField="discription" HeaderText="Description" />
                                <asp:BoundField DataField="date" HeaderText="Date " />
                                  <asp:TemplateField HeaderText="Re-encrypt">
                                      <ItemTemplate>
                                          <asp:Button ID="Button1" runat="server" Text="Re Encrypt" CssClass="btn btn-sm btn-success" CommandName="delete" />
                                      </ItemTemplate>
                                  </asp:TemplateField>
                            </Columns>
                              <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                              <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                              <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                              <RowStyle BackColor="White" ForeColor="#330099" />
                              <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                              <SortedAscendingCellStyle BackColor="#FEFCEB" />
                              <SortedAscendingHeaderStyle BackColor="#AF0101" />
                              <SortedDescendingCellStyle BackColor="#F6F0C0" />
                              <SortedDescendingHeaderStyle BackColor="#7E0000" />
                        </asp:GridView>
                        


                    </div>

                    

                </div>
			</div>
        <!-- end container -->
    </div>
    <!-- end blog-main -->

    
    <!-- end pricing-main -->

    
    <!-- end reservations-main -->

    
    <!-- end footer-main -->

    <a href="#" class="scrollup" style="display: none;">Scroll</a>

    

    <!-- ALL JS FILES -->
    <script src="js/all.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- ALL PLUGINS -->
    <script src="js/custom.js"></script>
        </form>

</body>

</html>
