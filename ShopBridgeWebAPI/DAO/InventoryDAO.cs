using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopeBride.Models;
using System.Data;
using System.Data.SqlClient;
using log4net;

namespace ShopeBride.DAO
{
    public class InventoryDAO
    {
        ILog log4netlogger = log4net.LogManager.GetLogger("File");
        internal List<GetInvetoryDetailResponseBO> GetInventoryDetails()
        {
            List<GetInvetoryDetailResponseBO> lstResponseBO = new List<GetInvetoryDetailResponseBO>();
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet = SqlHelper.SqlHelper.ExecuteDataset(SqlHelper.SqlHelper.Connect(), CommandType.StoredProcedure, "Proc_API_GetInventoryDetails", null);
                if (objDataSet != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow objDataRow in objDataSet.Tables[0].Rows)
                    {
                        GetInvetoryDetailResponseBO objResponse = new GetInvetoryDetailResponseBO();
                        objResponse.InventoryId = Convert.ToInt32(objDataRow["InventoryId"].ToString());
                        objResponse.InventoryName = Convert.ToString(objDataRow["InvetoryName"]);
                        objResponse.Description = Convert.ToString(objDataRow["Description"]);
                        objResponse.Price = Convert.ToInt32(objDataRow["Price"]);
                        objResponse.CreatedBy = Convert.ToInt32(objDataRow["CreatedBy"]);
                        objResponse.CreatedOn = Convert.ToDateTime(objDataRow["CreatedOn"]);

                        lstResponseBO.Add(objResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                log4netlogger.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - " + ex);
            }
            return lstResponseBO;
        }

        internal InventoryResponseBO DeleteInventoryDetails(DeleteInvetoryRequestBO objRequest)
        {
            InventoryResponseBO objResponse = new InventoryResponseBO();
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[2];
                objSqlParam[0] = new SqlParameter("@InventoryId", SqlDbType.Int) { Value = objRequest.InventoryId };
                objSqlParam[1] = new SqlParameter("@IsDeleted", SqlDbType.Bit) { Value = objRequest.IsDeleted };
                if (SqlHelper.SqlHelper.ExecuteNonQuery(SqlHelper.SqlHelper.Connect(), CommandType.StoredProcedure, "Proc_API_DeleteInventoryDetails", objSqlParam) > 0)
                {
                    objResponse.errCode = 0;
                }
            }
            catch (Exception ex)
            {
                log4netlogger.Error(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }
            return objResponse;
        }

        internal InventoryResponseBO UpdateInventoryDetails(InventoryRequestBO objRequest)
        {
            InventoryResponseBO objResponse = new InventoryResponseBO();
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[5];
                objSqlParam[0] = new SqlParameter("@InventoryId", SqlDbType.Int) { Value = objRequest.InventoryId };
                objSqlParam[1] = new SqlParameter("@InventoryName", SqlDbType.VarChar) { Value = objRequest.InventoryName };
                objSqlParam[2] = new SqlParameter("@Description", SqlDbType.VarChar) { Value = objRequest.Description };
                objSqlParam[3] = new SqlParameter("@Price", SqlDbType.Int) { Value = objRequest.Price };
                objSqlParam[4] = new SqlParameter("@IsActive", SqlDbType.Bit) { Value = objRequest.IsActive };
                if (SqlHelper.SqlHelper.ExecuteNonQuery(SqlHelper.SqlHelper.Connect(), CommandType.StoredProcedure, "Proc_API_UpdateInventoryDetails", objSqlParam) > 0)
                {
                    objResponse.errCode = 0;
                }
            }
            catch (Exception ex)
            {
                log4netlogger.Error(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }
            return objResponse;
        }

        internal InventoryResponseBO SaveInventoryDetails(InventoryRequestBO objRequest)
        {
            InventoryResponseBO objResponse = new InventoryResponseBO();
            try
            {
                SqlParameter[] objSqlParam = new SqlParameter[3];
                objSqlParam[0] = new SqlParameter("@InventoryName", SqlDbType.VarChar) { Value = objRequest.InventoryName };
                objSqlParam[1] = new SqlParameter("@Description", SqlDbType.VarChar) { Value = objRequest.Description };
                objSqlParam[2] = new SqlParameter("@Price", SqlDbType.Int) { Value = objRequest.Price };
                if (SqlHelper.SqlHelper.ExecuteNonQuery(SqlHelper.SqlHelper.Connect(), CommandType.StoredProcedure, "Proc_API_SaveInventoryDetails", objSqlParam) > 0)
                {
                    objResponse.errCode = 0;
                }
            }
            catch (Exception ex)
            {
                log4netlogger.Error(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }
            return objResponse;
        }
    }
}