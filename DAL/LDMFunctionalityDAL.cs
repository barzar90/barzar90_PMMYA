using System;
using System.Data.SqlClient;
using Schema;
using System.Text;
using System.Data;
using Helper;

namespace DAL
{
    public class LDMFunctionalityDAL
    {
        //Mahesh Phase
        public DataSet GetAllBankName(LDMFunctionalitySchema objLDMFunctionalitySchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@DistrictId", SqlDbType.Int);
                //param[0].Value = objLDMFunctionalitySchema.Type;

                //using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetBankName", param))
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetBankName"))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        public DataSet SaveLDMFunctionality(LDMFunctionalitySchema objLDMFunctionalitySchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                var param = new SqlParameter[]
                     {
                         new SqlParameter("@BankId",objLDMFunctionalitySchema.BankId == 0 ? 0 :objLDMFunctionalitySchema.BankId),
                         new SqlParameter("@No_AppliReceived",objLDMFunctionalitySchema.NumOfAppReceive == 0 ? 0 :objLDMFunctionalitySchema.NumOfAppReceive),
                         new SqlParameter("@No_AppliApproved",objLDMFunctionalitySchema.NumOfAppApprove == 0 ? 0 :objLDMFunctionalitySchema.NumOfAppApprove),
                         new SqlParameter("@No_AppliRejected",objLDMFunctionalitySchema.NumOfAppReject == 0 ? 0 :objLDMFunctionalitySchema.NumOfAppReject),
                         new SqlParameter("@Total_Amt_Approved",objLDMFunctionalitySchema.TotAmntApprove == 0 ? 0 :objLDMFunctionalitySchema.TotAmntApprove),
                         new SqlParameter("@Total_Amt_Rejected",objLDMFunctionalitySchema.TotAmntRejecte == 0 ? 0 :objLDMFunctionalitySchema.TotAmntRejecte),
                         new SqlParameter("@Total_Amt_Recovery",objLDMFunctionalitySchema.TotAmntOfRecovery == 0 ? 0 :objLDMFunctionalitySchema.TotAmntOfRecovery),
                         new SqlParameter("@DistrictID",objLDMFunctionalitySchema.DistrictId == 0 ? 0 :objLDMFunctionalitySchema.DistrictId),
                         new SqlParameter("@InsertFrom",objLDMFunctionalitySchema.InsertFrom == null ? (object)DBNull.Value :objLDMFunctionalitySchema.InsertFrom),
                         new SqlParameter("@InsertBy",objLDMFunctionalitySchema.InsertBy == null ? (object)DBNull.Value :objLDMFunctionalitySchema.InsertBy),
                         new SqlParameter("@InsertOn",objLDMFunctionalitySchema.InsertOn == null ? (object)DBNull.Value :objLDMFunctionalitySchema.InsertOn)
                         //new SqlParameter("@InsertOn",objLDMFunctionalitySchema.TotAmntOfRecovery == null ? (object)DBNull.Value :objLDMFunctionalitySchema.TotAmntOfRecovery)                         
                     };

                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "Usp_LDMFunctinalityForm", param))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        public DataSet getGrdLDMFunctionality(LDMFunctionalitySchema objLDMFunctionalitySchema)
        {
            SqlConnection objConn = SQLHelper.OpenConnection();
            try
            {
                //SqlParameter[] param = new SqlParameter[1];
                //param[0] = new SqlParameter("@DistrictId", SqlDbType.Int);
                //param[0].Value = objLDMFunctionalitySchema.Type;

                //using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "usp_GetBankName", param))
                using (DataSet ds = SQLHelper.ExecuteDataset(objConn, null, CommandType.StoredProcedure, "GetGrdLDMFunctionality"))
                {
                    return ds;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                SQLHelper.CloseConnection(objConn);
            }
        }

        //public int SaveLDMFFile(LDMFunctionalitySchema objmenuschema)
        //{
        //    try
        //    {
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

    }
}
