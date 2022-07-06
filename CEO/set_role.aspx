<%@ Page Language="C#" AutoEventWireup="true" CodeFile="set_role.aspx.cs" Inherits="CEO_set_role" %>

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
                    <a href="index.html">Modernize</a>
                </h1>
                <span>M</span>
            </div>
            <div class="profile-bg"></div>
            <ul class="list-unstyled components">
           <li><a href="home.aspx"><span>Home</span></a></li>
				<li><a href="manage_employee.aspx"><span>Manage_Employees</span></a></li>   
				<li><a href="manage_roles.aspx"><span>Manage_Roles</span></a></li>
                				<li><a href="Approve_requests.aspx"><span>Approve_Requests</span></a></li>

				<li><a href="set_roles_to_employees.aspx"><span>Set_roles_to_Employees</span></a></li> 
                                				
                        <li><a href="view_files.aspx"><span>View_Files</span></a></li> 
                                   <li><a href="Remove_Employees.aspx"><span>Remove Employees</span></a></li> 

                			
              <li>
                    <a href="../Index/index.aspx">
                        <i class="far fa-map"></i>
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
                         <h4 align="center">Set Roles</h4>
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
                  
                    <div class="col-lg-6">
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Set The Roles Of Employees" Font-Size="Large" Font-Underline="True" ForeColor="Blue"></asp:Label>
                        <br /><br />
                        <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="29px" ImageUrl="~/CEO/images/images.png" Visible="False" Width="26px"  CommandName="del"/>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <asp:Label ID="Label5" runat="server" ForeColor="#9999FF" Text='<%# bind("role") %>'></asp:Label>
                                <asp:Label ID="Label8" runat="server" Text='<%# bind("r_id") %>' Visible="False"></asp:Label>
                                <asp:Label ID="Label9" runat="server" Text='<%# bind("priority") %>' Visible="false"></asp:Label>
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:DataList ID="DataList2" runat="server" OnItemCommand="DataList2_ItemCommand">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="29px" ImageUrl="~/CEO/images/images.png" Visible="False" Width="26px" CommandName="del" />
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <asp:Label ID="Label5" runat="server" ForeColor="#6666FF" Text='<%# bind("role") %>'></asp:Label>
                                &nbsp;-
                                <asp:Label ID="Label6" runat="server" Text='<%# bind("sub_main_role") %>'></asp:Label>
                                <asp:Label ID="Label8" runat="server" Text='<%# bind("sb_id") %>' Visible="False"></asp:Label>
                                <asp:Label ID="Label9" runat="server" Text='<%# bind("priority") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:DataList ID="DataList3" runat="server" OnItemCommand="DataList3_ItemCommand">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="29px" ImageUrl="~/CEO/images/images.png" Visible="False" Width="26px" CommandName="del" />
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <asp:Label ID="Label5" runat="server" ForeColor="Blue" Text='<%# bind("role") %>'></asp:Label>
                                &nbsp;-
                                <asp:Label ID="Label6" runat="server" Text='<%# bind("sub_main_role") %>'></asp:Label>
                                -
                                <asp:Label ID="Label7" runat="server" Text='<%# bind("sub_role") %>'></asp:Label>
                                <asp:Label ID="Label8" runat="server" Text='<%# bind("s_id") %>' Visible="False"></asp:Label>
                                <asp:Label ID="Label9" runat="server" Text='<%# bind("priority") %>' Visible="False"></asp:Label>
                            </ItemTemplate>
                        </asp:DataList>
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="form-control btn btn-md btn-default" BackColor="#0099ff" OnClick="Button1_Click"  />
                        





                        

                        





                    </div>
                    <div class="col-lg-5" >

                      <br /><br />
<%--                        <asp:Label ID="Label5" runat="server" Text="Set Roles Here" Font-Size="Large" Font-Underline="True" ForeColor="Blue"></asp:Label>--%>
                        <br /><br />
                        <%--<asp:Panel ID="Panel1" runat="server" Visible="False">
                            <table class="table table-borderd table-respponsive">
                                <tr>
                                    <td>
                                        <br />
                                        <asp:Label ID="Label1" runat="server" Text="Roles" ForeColor="#990033"></asp:Label>
                                    </td>
                                    <td>
                                       
                                        <table class="table table-bordered table-responsive" >
                                            <tr>
                                                <td>
                                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatColumns="3" RepeatDirection="Horizontal">
                                                    </asp:RadioButtonList>
                                                </td>
                                            </tr>
                                        </table>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="Sub Roles" Visible="False" ForeColor="#990033"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatColumns="3" RepeatDirection="Horizontal" Visible="False">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:Label ID="Label3" runat="server" Text="Sub Roles Of Developer" Visible="False" ForeColor="#990033"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged" RepeatColumns="3" RepeatDirection="Horizontal" Visible="False">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>--%>
                       
                        <asp:Panel ID="Panel2" runat="server">
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
