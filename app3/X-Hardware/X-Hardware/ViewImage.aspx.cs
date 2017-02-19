using System.Linq;
using System;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using app0.App_Data;
using System.Data.Linq;

namespace app0
{
    public partial class ViewImage : System.Web.UI.Page
    {
        public ViewImage() { }

        private void Page_Load(object sender, System.EventArgs e)
        {
            try
            {
                string param = Request.QueryString["img"];
                string pic_id = param.Substring(0, param.Length - 5);
                char pic_size = param[pic_id.Length];
                Binary pic;

                XhDataContext db = new XhDataContext();
                XhImage image = db.XhImages.Single(i => i.img_id == Int32.Parse(pic_id));

                switch (pic_size)
                {
                    case ('s'):
                        pic = image.img_small;
                        break;
                    case ('m'):
                        pic = image.img_medium;
                        break;
                    case ('l'):
                        pic = image.img_large;
                        break;
                    default:
                        pic = null;
                        break;
                }

                Response.ContentType = "image/jpeg";
                Response.BinaryWrite(pic.ToArray());
            }
            catch
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}

