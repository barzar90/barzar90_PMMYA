using DAL;
using Schema;
using System;
using System.Data;

namespace BL
{
    public class LDMFunctionalityBAL
    {
        #region Public variable declaration
        LDMFunctionalityDAL objLDMFunctionalityDAL = new LDMFunctionalityDAL();
        DataSet ds = new DataSet();
        int result = 0;
        #endregion
        //Mahesh Phase
        public DataSet GetAllBankName(LDMFunctionalitySchema objLDMFunctionalitySchema)
        {
            try
            {
                ds = objLDMFunctionalityDAL.GetAllBankName(objLDMFunctionalitySchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet SaveLDMFunctionality(LDMFunctionalitySchema objLDMFunctionalitySchema)
        {
            try
            {
                ds = objLDMFunctionalityDAL.SaveLDMFunctionality(objLDMFunctionalitySchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet getGrdLDMFunctionality(LDMFunctionalitySchema objLDMFunctionalitySchema)
        {
            try
            {
                ds = objLDMFunctionalityDAL.getGrdLDMFunctionality(objLDMFunctionalitySchema);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        //public int SaveMenuDeatails(MenuSchema objmenuschema)
        //{
        //    try
        //    {
        //        result = objLDMFunctionalityDAL.SaveLDMFFile(objmenuschema);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}
    }
}
