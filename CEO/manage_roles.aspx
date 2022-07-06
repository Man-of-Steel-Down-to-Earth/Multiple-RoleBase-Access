<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_roles.aspx.cs" Inherits="CEO_manage_roles" %>

<!DOCTYPE html>

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
        ul li a {
            padding-bottom:30px;
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

                    <div class="navbar-header" style="background-image: url('images/d4.jpg');background-repeat:no-repeat ;background-size:cover; width:100%;height:100px">
                        <h4 align="center">Manage Roles</h4>
                        <div class="text-right">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="false" CssClass="btn btn-sm btn-primary">Add Roles</asp:LinkButton>
			                 <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CausesValidation="false" CssClass="btn btn-sm btn-primary">Remove Roles</asp:LinkButton>
      
                         </div>
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
                <div class="paragraph-agileits-w3layouts">
                   <div class="row">

                        <div class="col-lg-12">



                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <table class="table table-hover ">
                            <tr>
                                <td>
                                    <table class="table table-hover">
                                        <tr>
                                            <td colspan="2">
                                                <div class="text-center">
                                                <asp:Label ID="Label1" runat="server" Text="Add Roles" Font-Size="Large"></asp:Label>
                                                    </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="Role"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="* Enter Role" ForeColor="#ff0000" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Priority Of roles</td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList12" runat="server" CssClass="form-control">
                                                    <asp:ListItem>Select Priority</asp:ListItem>
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div class="text-center">
                                                <asp:Button ID="Button1" runat="server" CausesValidation="false" Text="Add Role" OnClick="Button1_Click" CssClass="btn btn-sm btn-primary"/>
                                                    <br />   <br />   <br />   
                                                    </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table class="table table-hover">
                                        <tr>
                                            <td colspan="2">
                                                <div class="text-center">
                                                <asp:Label ID="Label3" runat="server" Text="Add Sub Roles" Font-Size="Large"></asp:Label>
                                                    </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="Roles"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="SubRole"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                                                                                                                                       
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Enter SubRole" ForeColor="#ff0000" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Priority Of roles</td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList11" runat="server" CssClass="form-control">
                                                    <asp:ListItem>Select Priority</asp:ListItem>
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div class="text-center">
                                                <asp:Button ID="Button2" runat="server" CausesValidation="false" Text="Add Sub Role" OnClick="Button2_Click" CssClass="btn btn-sm btn-primary"/>
                                                    </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="table table-hover">
                                        <tr>
                                            <td colspan="2">
                                                <div class="text-center">
                                                <asp:Label ID="Label6" runat="server" Text="Add Sub Roles Of Technologies" Font-Size="Large"></asp:Label>
                                       </div>
     </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="Role"></asp:Label>
                                            </td>
                                            <td>
                                                
                                                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged1">
                                                        </asp:DropDownList>
                                                    
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" Text="Sub Role"></asp:Label>
                                            </td>
                                            <td>
                                                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label9" runat="server" Text="Sub Roles of Sub Role"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                                                                                                                                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Enter Role" ForeColor="#ff0000" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>


                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Priority Of roles</td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control">
                                                    <asp:ListItem>Select Priority</asp:ListItem>
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div class="text-center">
                                                <asp:Button ID="Button3" runat="server" CausesValidation="false" Text="Add SubRoles Of Technologies" OnClick="Button3_Click" CssClass="btn btn-sm btn-primary" />
                                                    </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                </asp:View>
                <asp:View ID="View2" runat="server">

                    <table class="table table-hover">
                            <tr>
                                <td>
                                    <table class="table table-hover">
                                        <tr>
                                            <td colspan="2">
                                                <div class="text-center">
                                                <asp:Label ID="Label10" runat="server" Text="Remove Roles" Font-Size="Large"></asp:Label>
                                                    </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label11" runat="server" Text="Role"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList8" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div class="text-center">
                                                <asp:Button ID="Button4" runat="server" Text="Remove Role" OnClick="Button4_Click" CssClass="btn btn-sm btn-primary"/>
                                                    <br />  <br />   <br />   
                                                    </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table class="table table-hover">
                                        <tr>
                                            <td colspan="2">
                                                <div class="text-center">
                                                <asp:Label ID="Label12" runat="server" Text="Remove Sub Roles" Font-Size="Large"></asp:Label>
                                                    </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label13" runat="server" Text="Roles"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList5" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label14" runat="server" Text="SubRole"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList9" runat="server" CssClass="form-control" OnSelectedIndexChanged="DropDownList9_SelectedIndexChanged"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div class="text-center">
                                                <asp:Button ID="Button5" runat="server" Text="Remove Sub Role" OnClick="Button5_Click" CssClass="btn btn-sm btn-primary"/>
                                                    </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="table table-hover">
                                        <tr>
                                            <td colspan="2">
                                                <div class="text-center">
                                                                                                    <asp:Label ID="Label15" runat="server" Text="Remove Sub Roles Of Technologies" Font-Size="Large"></asp:Label>
                                       </div>
     </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label16" runat="server" Text="Role"></asp:Label>
                                            </td>
                                            <td>
                                                
                                                        <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged1">
                                                        </asp:DropDownList>
                                                    
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label17" runat="server" Text="Sub Role"></asp:Label>
                                            </td>
                                            <td>
                                                        <asp:DropDownList ID="DropDownList7" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label18" runat="server" Text="Sub Roles of Sub Role"></asp:Label>
                                            </td>
                                            <td>
                                               <asp:DropDownList ID="DropDownList10" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td colspan="2">
                                                <div class="text-center">
                                                <asp:Button ID="Button6" runat="server" Text="Remove SubRoles Of Technologies" OnClick="Button6_Click" CssClass="btn btn-sm btn-primary" />
                                                    </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>

                </asp:View>
            </asp:MultiView>
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