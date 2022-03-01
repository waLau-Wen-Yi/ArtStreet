using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArtStreet.Home
{
    public partial class Art_Culture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void inp_ddl_ArtCulture_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(inp_ddl_ArtCulture.SelectedIndex)
            {
                case 1:
                    mv_ArtCulture.ActiveViewIndex = 0;
                    break;
                case 2:
                    mv_ArtCulture.ActiveViewIndex = 1;
                    break;
                case 3:
                    mv_ArtCulture.ActiveViewIndex = 2;
                    break;
                default:
                    mv_ArtCulture.ActiveViewIndex = -1;
                    break;
            }
        }
    }
}