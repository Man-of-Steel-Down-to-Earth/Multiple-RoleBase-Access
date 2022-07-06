<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Approve_requests.aspx.cs" Inherits="CEO_Approve_requests" %>

<!DOCTYPE html>


<html lang="en">

<head>
    <title>Modernize an Admin Panel Category Bootstrap Responsive Web Template | Blank page :: w3layouts</title>
    <!-- Meta Tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8">
    <meta name="keywords" content="Modernize Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template,
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola web design" />
    <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
    <!-- //Meta Tags -->

    <!-- Style-sheets -->
    <!-- Bootstrap Css -->
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
    <!-- Bootstrap Css -->
    <!-- Common Css -->
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
    <!--// Common Css -->
    <!-- Nav Css -->
    <link rel="stylesheet" href="css/style4.css">
    <!--// Nav Css -->
    <!-- Fontawesome Css -->
    <link href="css/fontawesome-all.css" rel="stylesheet">
    <!--// Fontawesome Css -->
    <!--// Style-sheets -->

    <!--web-fonts-->
    <link href="http://localhost:1061/fonts.googleapis.com/css?family=Poiret+One" rel="stylesheet">
    <link href="http://localhost:1061/fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet">
    <!--//web-fonts-->
</head>

<body>
    <form id="f1" runat="server">
    <div class="wrapper">
        <!-- Sidebar Holder -->
       <nav id="sidebar">
            <div class="sidebar-header">
                <h1>
                    <a href="index.html">File Hierarchy</a>
                </h1>
                <span>M</span>
            </div>
            <div class="profile-bg"></div>
            <ul class="list-unstyled components">
           <li><a href="home.aspx"><span>Home</span></a></li>
				<li><a href="manage_employee.aspx"><span>Manage Employees</span></a></li>   
				<li><a href="manage_roles.aspx"><span>Manage Roles</span></a></li>
              <li><a href="Approve_requests.aspx"><span>Approve Requests</span></a></li>
				<li><a href="set_roles_to_employees.aspx"><span>Set roles to Employees</span></a></li> 		
                        <li><a href="view_files.aspx"><span>View Files</span></a></li> 
                                   <li><a href="Remove_Employees.aspx"><span>Remove Employees</span></a></li> 

                			
              <li>
                    <a href="../Index/index.aspx">
                        
                        Logout
                    </a>
                </li>
            </ul>
        </nav>
        <!-- Page Content Holder -->
        <div id="content">
            <!-- top-bar -->
            <nav class="navbar navbar-default mb-xl-5 mb-4">
                <div class="container-fluid">

                    <div class="navbar-header"  style="background-image: url('images/d4.jpg');background-repeat:no-repeat ;background-size:cover; width:100%;height:100px">
                         <h4 align="center">Approved Requests</h4>
                    </div>
                    <!-- Search-from -->
                    
                    <!--// Search-from -->
                    
                </div>
            </nav>
            <!--// top-bar -->

            <!-- main-heading -->
          
            <!--// main-heading -->

            <!-- Error Page Content -->
            <div class="blank-page-content">

                <!-- Error Page Info -->
                <div class="paragraph-agileits-w3layouts" style="text-align:center">
                   <div class="row">

                        <div class="col-lg-12">

                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-reponsive" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
                              <Columns>
                                <asp:BoundField DataField="r_id" HeaderText="#" />
                                <asp:BoundField DataField="fname" HeaderText="File Name" />
                             <asp:BoundField DataField="request_by" HeaderText="Requset from" />

                                <asp:BoundField DataField="request_date" HeaderText="Requested Date" />
                                 <asp:TemplateField>
                                      <ItemTemplate>
                                          <asp:Button ID="Button1" runat="server" Text="Accept Request" CssClass="btn btn-sm btn-success" CommandName="delete" />
                                          <asp:Button ID="Button2" runat="server" Text="Reject Request" CssClass="btn btn-sm btn-success" CommandName="update" />

                                          <br />
                                          <br />
                                          <asp:Label ID="Label1" runat="server" Text='<%# bind("fname") %>' Visible="False"></asp:Label>
                                      </ItemTemplate>
                                  </asp:TemplateField>
                            </Columns>
                                <EmptyDataTemplate>
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" Text="No Requests!!!!!"></asp:Label>
                                </EmptyDataTemplate>
                        </asp:GridView>
                        </div>
                    
                   </div>
                   
                </div>
                <!--// Error Page Info -->

            </div>

            <!--// Error Page Content -->

            <!-- Copyright -->
            <div class="copyright-w3layouts py-xl-3 py-2 mt-xl-5 mt-4 text-center">
                <p>© 2018 Modernize . All Rights Reserved | Design by
                    ts </a>
                </p>
            </div>
            <!--// Copyright -->
        </div>
    </div>

    </form>
    <!-- Required common Js -->
    <script src='js/jquery-2.2.3.min.js'></script>
    <!-- //Required common Js -->

    <!-- Sidebar-nav Js -->
    <script>
        $(document).ready(function () {
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
            });
        });
    </script>
    <!--// Sidebar-nav Js -->

    <!-- dropdown nav -->
    <script>
        $(document).ready(function () {
            $(".dropdown").hover(
                function () {
                    $('.dropdown-menu', this).stop(true, true).slideDown("fast");
                    $(this).toggleClass('open');
                },
                function () {
                    $('.dropdown-menu', this).stop(true, true).slideUp("fast");
                    $(this).toggleClass('open');
                }
            );
        });
    </script>
    <!-- //dropdown nav -->

    <!-- Js for bootstrap working-->
    <script src="js/bootstrap.min.js"></script>
    <!-- //Js for bootstrap working -->

</body>

</html>