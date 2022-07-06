<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_employee.aspx.cs" Inherits="CEO_manage_employee" %>

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
    <style>
        .cnt {
            border-radius:25px;box-shadow:2px 3px 8px grey;
        }
    </style>
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
                         <h4 align="center">Employee Registration</h4>
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

                        <div class="col-lg-6">
                            <table class="table table-condensed table-hover cnt"  >
                                
                                 <tr><td>&nbsp;</td></tr>
                                <tr>
                                
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" AutoCompleteType="Disabled" AutoPostBack="true"  placeholder="Name" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Name" ForeColor="#ff0000" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                                    <asp:Label ID="Label1" runat="server" Text="Invalid Name" ForeColor="Red" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                
                                <td>
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" AutoCompleteType="Disabled"  placeholder="Age"  ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Age" ForeColor="#ff0000" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="* Enter Valid Age" ForeColor="#ff0000" ControlToValidate="TextBox5" ValidationExpression="\d{2}"></asp:RegularExpressionValidator>

                                </td>
                            </tr>
                            <tr>
                                
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server"  RepeatDirection="Horizontal" style="text-align: center" >
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td>
                                    <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" CssClass="form-control" placeholder="Address"></asp:TextBox>
                                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Address" ForeColor="#ff0000" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                 
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" AutoCompleteType="Disabled" placeholder="Mail ID"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Email" ForeColor="#ff0000" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                                                                         <asp:RegularExpressionValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* Enter Valid Email" ForeColor="#ff0000" ControlToValidate="TextBox3" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                                </td>
                            </tr>
                            <tr>
         
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" AutoCompleteType="Disabled"  placeholder="contact"></asp:TextBox>
                                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="* Contact" ForeColor="#ff0000" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="* Enter Valid Phone NUmber" ForeColor="#ff0000" ControlToValidate="TextBox2" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                
                                <td>
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                </td>
                            </tr>
                            <tr>
                             <td align="center">
                                    <asp:Button ID="Button1" runat="server" Text="Register"  CssClass="btn btn-sm btn-success" OnClick="Button1_Click" />
                              </td>
                            </tr>
                        </table></div>
                    <div class="col-lg-6">
                        <asp:DataList ID="DataList1" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"  >
                            <ItemTemplate>
                                <table class="table table-hover">
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image1" runat="server" Height="114px" ImageUrl='<%# bind("pro_pic") %>' Width="169px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label8" runat="server" Text='<%# bind("name") %>' Height="15px" Width="20px"></asp:Label>
                                            
                                            <asp:BulletedList ID="BulletedList1" runat="server">
                                            </asp:BulletedList>
                                            <asp:Label ID="Label9" runat="server" Height="16px" Text='<%# bind("username") %>' Visible="False"></asp:Label>
                                            
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                   </div>
                   
                </div>
                <!--// Error Page Info -->

            </div>

            <!--// Error Page Content -->

            <!-- Copyright -->
            <div class="copyright-w3layouts py-xl-3 py-2 mt-xl-5 mt-4 text-center">
                <p>© 2018 Modernize . All Rights Reserved | Design by
                    ts 
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