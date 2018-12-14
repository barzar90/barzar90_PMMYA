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
    public partial class FrmSuccessStories : System.Web.UI.Page
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
                GetSuccesstoriesVideo();
            }
        }


        protected void GetSuccesstoriesVideo()
        {
            objAlbumSchema.TypeId = 2;
            ds = objAlbumBL.GetAllVideosById(objAlbumSchema);
            LV_Events.DataSource = ds;
            LV_Events.DataBind();

        }
    }
}