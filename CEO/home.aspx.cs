﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CEO_home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Session["user"] == "")
            {
                Response.Redirect("../Index/index.aspx");

            }
        
    }
}