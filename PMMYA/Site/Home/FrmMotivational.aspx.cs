using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BL;
using Schema;
using DAL;

namespace PMMYA.Site.Home
{
    public partial class FrmMotivational : System.Web.UI.Page
    {
        #region Public variable declaration
        AlbumBL objAlbumBL = new AlbumBL();
        AlbumSchema objAlbumSchema = new AlbumSchema();
        DataSet ds;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMotivationalVideo();
            }
        }

        protected void Page_PreRender(Object sender, EventArgs e)
        {
            //GetMotivationalVideo();
        }


        protected void GetMotivationalVideo()
        {
            objAlbumSchema.TypeId = 1;
            ds = objAlbumBL.GetAllVideosById(objAlbumSchema);
            LV_Events.DataSource = ds;
            LV_Events.DataBind();

        }
    }
}