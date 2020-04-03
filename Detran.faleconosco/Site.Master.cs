﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Detran.faleconosco
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nome"] != null)
            {
                Label1.Text = Session["nome"].ToString();
            }
        }
        protected void logout_click(object sender, EventArgs e)
        {
            Session.Remove("nome");
        }
    }
}