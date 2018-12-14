using DAL;
using Schema;
using System;
using System.Data;

namespace BL
{
    public class LDMFunBAL
    {
        #region Public variable declaration
        private LDMFunDAL objLDMFunDL = new LDMFunDAL();
        private DataSet ds = new DataSet();
        private readonly int result = 0;
        #endregion
        
        public DataSet LDMInsert(LDMFunSchema objLDMFuncSchema)
        {
            try
            {
                ds = objLDMFunDL.LDM_Insert(objLDMFuncSchema);

                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetGridViewData(LDMFunSchema objLDMFuncSchema)
        {
            try
            {
                ds = objLDMFunDL.GetGridViewData(objLDMFuncSchema);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        //Search
        public DataSet SearchGridData(string searchTxt)
        {
            try
            {
                ds = objLDMFunDL.SearchGridData(searchTxt);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        //Search Bank
        public DataSet SearchBankGridData(string searchTxt, LDMFunSchema objLDMFuncSchema)
        {
            try
            {
                ds = objLDMFunDL.SearchBankGridData(searchTxt, objLDMFuncSchema);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        //Search District
        public DataSet SearchDistrictGridData(string searchTxt, LDMFunSchema objLDMFuncSchema)
        {
            try
            {
                ds = objLDMFunDL.SearchDistrictGridData(searchTxt, objLDMFuncSchema);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        //Search State
        public DataSet SearchStateGridData(string searchTxt, LDMFunSchema objLDMFuncSchema)
        {
            try
            {
                ds = objLDMFunDL.SearchStateGridData(searchTxt, objLDMFuncSchema);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        public DataSet GetBankName(LDMFunSchema objLDMFunSchema)
        {
            try
            {
                ds = objLDMFunDL.GetBankName(objLDMFunSchema);

                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }
        
        //Get Bank Id
        public DataSet GetAllBank(string BankName)
        {
            try
            {
                ds = objLDMFunDL.GetAllBank(BankName);

                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }
        //Get District ID
        public DataSet GetAllDistrict(string DistrictName)
        {
            try
            {
                ds = objLDMFunDL.GetAllDistrict(DistrictName);

                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        //Get Category ID
        public DataSet GetAllCategory(string CategoryName)
        {
            try
            {
                ds = objLDMFunDL.GetAllCategory(CategoryName);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        // Reports Bank
        public DataSet GetBankViewReport(LDMFunSchema objLDMFuncSchema)
        {
            try
            {
                ds = objLDMFunDL.GetBankViewReport(objLDMFuncSchema);

                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        // Reports District
        public DataSet GetDistrictViewReport(LDMFunSchema objLDMFuncSchema)
        {
            try
            {
                ds = objLDMFunDL.GetDistrictViewReport(objLDMFuncSchema);

                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        // Reports State
        public DataSet GetStateViewReport(LDMFunSchema objLDMFuncSchema)
        {
            try
            {
                ds = objLDMFunDL.GetStateViewReport(objLDMFuncSchema);

                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        //Best Five Bank Performance
        public DataSet GetTopBestBank(LDMFunSchema objLDMFuncSchema)
        {
            try
            {
                ds = objLDMFunDL.GetTopBestBank(objLDMFuncSchema);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }

        //Best Five District Performance
        public DataSet GetTopBestDistrict(LDMFunSchema objLDMFuncSchema)
        {
            try
            {
                ds = objLDMFunDL.GetTopBestDistrict(objLDMFuncSchema);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                ds = null;
            }
        }
        
    }
}
