<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="CEO_home" %>

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
            text-align:center;
        }
            ul li a:hover {
                color:red;
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

                    <div class="navbar-header"  style="background-image: url('images/d4.jpg');background-repeat:no-repeat ;background-size:cover; width:100%;height:150px" >
                        
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

                            <p align="justify"><span style="font-size:x-large;font-weight:bolder"></span>A hierarchical file system is how drives, folders, and files are displayed on an operating system. In a hierarchical file system, the drives, folders, and files are displayed in groups, which allows the user to see only the files they're interested in seeing. For example, in the picture the Windows directory (Windows\) folder hierarchy that contains the System32, Tasks, and Web folders. Each of these folders could have hundreds of their own files, but unless they are opened the files are not displayed.

In GUI operating systems such as Microsoft Windows, the user expands a drive or folder to see its contents by double-clicking the icon. Once the file or program is located, double-click the icon to open the file or execute the program.

In a non GUI operating system, such as MS-DOS or the Windows command line, the drive and directories are listed as text. For example, if you were on the C: drive and in the Windows spool directory, the MS-DOS path may look like the following example.

C:\Windows\System32\Spool>
Related pages
All questions relating to computer files and file extensions.
</p>
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
