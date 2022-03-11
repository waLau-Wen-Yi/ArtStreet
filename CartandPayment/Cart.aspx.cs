using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtStreet.CartandPayment
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContentPlaceHolder cp = PreviousPage.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            if (cp != null)
            {
                TextBox t = (TextBox)cp.FindControl("txt1");
                Label labelId = ((Label)DataList1.FindControl("artistName"));
                labelId.Text = t.Text;
            }

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
           

        }
    }
}