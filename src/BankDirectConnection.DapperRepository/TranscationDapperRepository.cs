using BankDirectConnection.Domain.TransferBO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.DapperRepository
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/13 17:17:38
	===============================================================================================================================*/
    public class TranscationDapperRepository
    {

        //public async Task<List<SalesOrder>> Fetch(QueryParam Param)
        //{
        //    List<SalesOrder> collection = null;
        //    using (var conn = SqlConnectionFactory.CreateSqlConnection())
        //    {
        //        conn.Open();

        //        string sql = $"SELECT  top {Param.limit} {Param.select} FROM T_SalesOrder t0 left JOIN T_SalesOrderItem t1 on t0.DocEntry = t1.DocEntry {Param.filter + " " + Param.orderby} ";
        //        try
        //        {
        //            var coll = await conn.QueryParentChildAsync<SalesOrder, SalesOrderItem, int>(sql, p => p.DocEntry, p => p.SalesOrderItems, splitOn: "DocEntry");
        //            collection = coll.ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //        return collection;
        //    }
        //}


        public void Save(ITranscations Transcations)
        {
            using (IDbConnection conn = SqlConnectionFactory.CreateSqlConnection())
            {
                conn.Open();
                IDbTransaction dbTransaction = conn.BeginTransaction();
                try
                {
                    string insertSql = @"insert into T_SalesOrder(OMSDocEntry,OMSDocDate,DocType,BusinessType,PlatformCode,CardCode,OrderPaied,Freight,PayMethod,Comments,CreateDate,UpdateDate) 
                                    values(@OMSDocEntry,@OMSDocDate,@DocType,@BusinessType,@PlatfromCode,@CardCode,@OrderPaied,@Freight,@Paymenthod,@Comments,@CreateDate,@UpdateDate)select SCOPE_IDENTITY();";
                    //string insertItemSql = @"insert into T_SalesOrderItem(DocEntry,LineNum,OMSDocEntry,OMSLineNum,ItemCode,Quantity,Price,ItemPaied) 
                    //                           values(@DocEntry,@LineNum,@OMSDocEntry,@OMSLineNum,@ItemCode,@Quantity,@Price,@ItemPaied)";

                    object DocEntry =  conn.ExecuteScalar(insertSql,
                        new
                        {
                            //OMSDocEntry = SalesOrder.OMSDocEntry,
                            //OMSDocDate = SalesOrder.OMSDocDate,

                            //DocType = SalesOrder.DocType,
                            //BusinessType = SalesOrder.BusinessType,
                            //PlatfromCode = SalesOrder.PlatformCode,
                            //CardCode = SalesOrder.CardCode,
                            //OrderPaied = SalesOrder.OrderPaied,
                            //Freight = SalesOrder.Freight,
                            //Paymenthod = SalesOrder.PayMethod,
                            //Comments = SalesOrder.Comments,
                            //CreateDate = DateTime.Now,
                            //UpdateDate = SalesOrder.UpdateDate
                        }, dbTransaction);
                    // saveRlt.ReturnUniqueKey = DocEntry.ToString();//回传保存订单的主键
                    // await conn.ExecuteAsync(insertItemSql, DocumentItemHandle<SalesOrderItem>.GetDocumentItems(SalesOrder.SalesOrderItems, Convert.ToInt32(DocEntry)), dbTransaction);

                    dbTransaction.Commit();
                    //saveRlt.Code = 0;
                }
                catch (Exception ex)
                {
                    dbTransaction.Rollback();
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
        }
    }
}
