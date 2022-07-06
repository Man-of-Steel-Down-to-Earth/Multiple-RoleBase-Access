<%@ Page Language="C#" AutoEventWireup="true" CodeFile="set_roles_to_employees.aspx.cs" Inherits="CEO_set_roles_to_employees" %>

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
        .zoom:hover {
            transform:scale(0.9);
            overflow:visible;
           transition:ease-in-out 2s;
           background-color:lightskyblue;
           z-index:2;
        }
            .zoom:hover .remove {
                overflow:visible;
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
                         <h4 align="center">Assign Roles </h4>
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
                   <div class="container">
                <div class="row">
  
                    <div class="col-lg-12 remove" style="overflow-x:scroll" >
                        

                        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand" OnEditCommand="DataList1_EditCommand" OnCancelCommand="DataList1_CancelCommand" OnUpdateCommand="DataList1_UpdateCommand1" CellSpacing="10" >
                            <EditItemTemplate>
                                <table class="table table-hover " style="border: thick solid #808080;  " >
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image1" runat="server" CssClass="img img-circle" Height="120px" ImageUrl='<%# bind("pro_pic") %>' Width="150px" />
                                            <br />
                                            
                                            <span class=" fa fa-graduation-cap" style="font-size:large"></span>&nbsp; <br />
                                        </td>
                                        <td rowspan="4">
                                            <table>
                                                <tr>
                                                    <td>
                                                                <span class="fa fa-user" style="font-size:large"></span
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox1" runat="server"  Text='<%# bind("name") %>' ></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                                        <span class="fa fa-phone" style="border-bottom-color:forestgreen; font-size: large;"></span>&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# bind("contact") %>'></asp:TextBox>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        <span class="fa fa-envelope" style="font-size:large"></span>&nbsp;
                                          
                                                    </td>
                                                    <td>
                                                          <asp:Label ID="Label14" runat="server" Text='<%# bind("email") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                        <span class="fa fa-home" style="font-size:large"></span>&nbsp;
                                       
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# bind("address") %>'></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table> 
                                           
                                        
                                        </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="3">
                                                <asp:Button ID="Button1" runat="server" CommandName="update" CssClass="butt button-4" Text="update" />
                                                &nbsp;&nbsp;
                                                 <asp:Button ID="Button3" runat="server" CommandName="cancel" CssClass="butt1 button-4" Text="Cancel" BackColor="#FF5050" />
                                            </td>
                                        </tr>
                                     
                                </table>
                            </EditItemTemplate>
                            <ItemTemplate >
                              <div class="zoom">
                                    <table class="table table-hover " style="border: thick solid #808080">
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image1" runat="server" CssClass="img img-rounded" Height="120px" ImageUrl='<%# bind("pro_pic") %>' Width="150px" />
                                            </td>
                                        <td>
                                      <span class="fa fa-user" style="font-size:large"></span> <br />   
                                             <asp:Label ID="Label12" runat="server"  Text='<%# bind("name") %>'></asp:Label><br />
                                             <span class="fa fa-phone"  style="border-bottom-color:forestgreen; font-size: large;"></span><br />
                                            <asp:Label ID="Label15" runat="server" Text='<%# bind("contact") %>'></asp:Label> 
                                            </td>
                                        </tr>
                                        <tr>

                                            <td>
                                                    <span class=" fa fa-graduation-cap" style="font-size:large"></span> &nbsp;            Designation:<br />
                                            </td>
                                            <td>
                                            <span class="fa fa-envelope" style="font-size:large"></span> &nbsp; <asp:Label ID="Label14" runat="server" Text='<%# bind("email") %>'></asp:Label>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
<asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# bind("username") %>' CommandName="set_role" Text='<%# bind("username") %>' Visible="False"></asp:LinkButton>
                                            <asp:BulletedList ID="BulletedList1" runat="server" ForeColor="blue">
                                            </asp:BulletedList>
                                            </td>
                                            <td>
 <span class="fa fa-home" style="font-size:large"></span> &nbsp;  <asp:Label ID="Label13" runat="server" Text='<%# bind("address") %>'></asp:Label>
                                            </td>
                                        </tr>

                                             
                              
                                            
                                         
                                   
                                  
                                    
                                        <tr>
                                            <td colspan="2">
                                            
  <asp:Button ID="Button1" runat="server" Text="Edit" CssClass=" btn btn-info btn-sm" CommandName="edit"/>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                              <asp:Button ID="Button2" runat="server" Text="Change Designation" CssClass=" btn btn-info btn-sm" CommandName="upd" CommandArgument='<%# bind("username") %>'/>
                                            </td>
                                        </tr>
                                   
                                   
                                  
                                    
                                </table>
                              </div>
                            </ItemTemplate>
                            <SeparatorStyle BorderStyle="Dashed" BorderWidth="8px" />
                        </asp:DataList>
                           <asp:Panel ID="Panel2" runat="server" Visible="false">
                            <asp:Image ID="Image2" runat="server"  ImageUrl="~/index/7661.jpg"  CssClass="img img-responsive  img-rounded"   Height="289px" Width="356px"/>
                        </asp:Panel>
                        
                    </div>
                    

                    
                       
                     


                  

                    <div class="col-lg-1"></div>

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
