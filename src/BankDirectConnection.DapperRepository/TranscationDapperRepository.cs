using BankDirectConnection.Domain.Model;
using BankDirectConnection.Domain.Service;
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

        public async Task<ITranscations> Fetch(string ClientId)
        {
            ITranscations collection = null;
            using (var conn = SqlConnectionFactory.CreateSqlConnection())
            {
                conn.Open();

                //string sql = $"SELECT  top {Param.limit} {Param.select} FROM T_SalesOrder t0 left JOIN T_SalesOrderItem t1 on t0.DocEntry = t1.DocEntry {Param.filter + " " + Param.orderby} ";
                string sql = @"select *";
                try
                {
                    //var coll = await conn.QueryParentChildAsync<ITranscations, Transcations, int>(sql, p => p.DocEntry, p => p.SalesOrderItems, splitOn: "DocEntry");
                    //collection = coll.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return collection;
            }
        }


        public void SaveTransList(List<TransModel> Trans)
        {
            foreach (var item in Trans)
            {
                this.SaveTranscation(item);
            }
        }
        public async Task SaveTransListAsync(List<TransModel> Trans)
        {
            foreach (var item in Trans)
            {
                await this.SaveTranscationAsync(item);
            }
        }
        public void SaveTranscation(TransModel TransModel)
        {
            using (IDbConnection conn = SqlConnectionFactory.CreateSqlConnection())
            {
                conn.Open();
                IDbTransaction dbTransaction = conn.BeginTransaction();
                try
                {
                    string insertSql = @"INSERT INTO T_EDF_Trans (EDIId ,ClientId ,TransWay ,BusinessType ,PaymentCur ,PaymentType ,Purpose ,Priority ,TransDate ,TransTime ,FeeType ,FeeAcct ,Comments ,BankId ,BankName ,AcctId ,AcctName ,TransCode ,TransAmount) 
                                            VALUES (@EDIId ,@ClientId ,@TransWay ,@BusinessType ,@PaymentCur ,@PaymentType ,@Purpose ,@Priority ,@TransDate ,@TransTime ,@FeeType ,@FeeAcct ,@Comments ,@BankId ,@BankName ,@AcctId ,@AcctName ,@TransCode ,@TransAmount)";
                    string insertItemSql = @"INSERT INTO T_EDF_TransDetail (EDIId ,ClientId ,LineId ,BankId ,BankName ,AcctId ,AcctName ,ReciepterIdType ,ReciepterIdCode ,AcctType ,ReceipterType ,TransAmount ,TransCur ,SWIFTCode ,Rate) 
                                            VALUES (@EDIId ,@ClientId ,@LineId ,@BankId ,@BankName ,@AcctId ,@AcctName ,@ReciepterIdType ,@ReciepterIdCode ,@AcctType ,@ReceipterType ,@TransAmount ,@TransCur ,@SWIFTCode ,@Rate)";
                   conn.ExecuteScalar(insertSql,
                        new
                        {
                            EDIId = TransModel.EDIId,//ediid不可重复，如果为22位，肯定出错
                            ClientId = TransModel.ClientId,
                            TransWay = TransModel.TransWay,
                            BusinessType = TransModel.BusinessType,
                            PaymentCur = TransModel.PaymentCur,
                            PaymentType = TransModel.PaymentType,
                            Purpose = TransModel.Purpose,
                            Priority = TransModel.Priority,
                            TransDate = TransModel.TransDate,
                            TransTime = TransModel.TransTime,
                            FeeType = TransModel.FeeType,
                            FeeAcct = TransModel.FeeAcct,
                            Comments = TransModel.Comments,
                            BankId = TransModel.BankId,
                            BankName = TransModel.BankName,
                            AcctId = TransModel.AcctId,
                            AcctName = TransModel.AcctName,
                            TransCode = TransModel.TransCode,
                            TransAmount = TransModel.TransAmount
                        }, dbTransaction);
                    conn.Execute(insertItemSql,TransModel.TransDetails, dbTransaction);                                      
                    dbTransaction.Commit();
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

        public async Task SaveTranscationAsync(TransModel TransModel)
        {
            using (IDbConnection conn = SqlConnectionFactory.CreateSqlConnection())
            {
                conn.Open();
                IDbTransaction dbTransaction = conn.BeginTransaction();
                try
                {
                    string insertSql = @"INSERT INTO T_EDF_Trans (EDIId ,ClientId ,TransWay ,BusinessType ,PaymentCur ,PaymentType ,Purpose ,Priority ,TransDate ,TransTime ,FeeType ,FeeAcct ,Comments ,BankId ,BankName ,AcctId ,AcctName ,TransCode ,TransAmount) 
                                            VALUES (@EDIId ,@ClientId ,@TransWay ,@BusinessType ,@PaymentCur ,@PaymentType ,@Purpose ,@Priority ,@TransDate ,@TransTime ,@FeeType ,@FeeAcct ,@Comments ,@BankId ,@BankName ,@AcctId ,@AcctName ,@TransCode ,@TransAmount)";
                    string insertItemSql = @"INSERT INTO T_EDF_TransDetail (EDIId ,ClientId ,LineId ,BankId ,BankName ,AcctId ,AcctName ,ReciepterIdType ,ReciepterIdCode ,AcctType ,ReceipterType ,TransAmount ,TransCur ,SWIFTCode ,Rate) 
                                            VALUES (@EDIId ,@ClientId ,@LineId ,@BankId ,@BankName ,@AcctId ,@AcctName ,@ReciepterIdType ,@ReciepterIdCode ,@AcctType ,@ReceipterType ,@TransAmount ,@TransCur ,@SWIFTCode ,@Rate)";
                    await conn.ExecuteScalarAsync(insertSql,
                         new
                         {
                             EDIId = TransModel.EDIId,
                             ClientId = TransModel.ClientId,
                             TransWay = TransModel.TransWay,
                             BusinessType = TransModel.BusinessType,
                             PaymentCur = TransModel.PaymentCur,
                             PaymentType = TransModel.PaymentType,
                             Purpose = TransModel.Purpose,
                             Priority = TransModel.Priority,
                             TransDate = TransModel.TransDate,
                             TransTime = TransModel.TransTime,
                             FeeType = TransModel.FeeType,
                             FeeAcct = TransModel.FeeAcct,
                             Comments = TransModel.Comments,
                             BankId = TransModel.BankId,
                             BankName = TransModel.BankName,
                             AcctId = TransModel.AcctId,
                             AcctName = TransModel.AcctName,
                             TransCode = TransModel.TransCode,
                             TransAmount = TransModel.TransAmount
                         }, dbTransaction);
                    await conn.ExecuteAsync(insertItemSql, TransModel.TransDetails, dbTransaction);
                    dbTransaction.Commit();
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

        public void UpdateTransCode(string EDIId,string ClientId,string TransCode)
        {
            using (IDbConnection conn = SqlConnectionFactory.CreateSqlConnection())
            {
                conn.Open();
                IDbTransaction dbTransaction = conn.BeginTransaction();
                try
                {
                    string updateSql = @"update T_EDF_Trans set TransCode = '@TransCode' where EDIId = '@EDIId' and ClientId = '@ClientId'";
                    conn.ExecuteScalar(updateSql,
                         new
                         {
                             TransCode = TransCode,
                             EDIId = EDIId,
                             ClientId = ClientId
                         }, dbTransaction);
                    conn.Execute(updateSql, dbTransaction);
                    dbTransaction.Commit();
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

        public async Task UpdateTransCodeAsync(string EDIId, string ClientId, string TransCode)
        {
            using (IDbConnection conn = SqlConnectionFactory.CreateSqlConnection())
            {
                conn.Open();
                IDbTransaction dbTransaction = conn.BeginTransaction();
                try
                {
                    string updateSql = @"update T_EDF_Trans set TransCode = '@TransCode' where EDIId = '@EDIId' and ClientId = '@ClientId'";
                    conn.ExecuteScalar(updateSql,
                         new
                         {
                             TransCode = TransCode,
                             EDIId = EDIId,
                             ClientId = ClientId
                         }, dbTransaction);
                    await conn.ExecuteAsync(updateSql, dbTransaction);
                    dbTransaction.Commit();
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

        public async Task UpdateTransListAsync(IResResult ResResult)
        {
            using (IDbConnection conn = SqlConnectionFactory.CreateSqlConnection())
            {
                conn.Open();
                IDbTransaction dbTransaction = conn.BeginTransaction();
                try
                {
                    string updateSql = @"update T_EDF_Trans set TransCode = '@TransCode' where EDIId = '@EDIId' and ClientId = '@ClientId'";
                    foreach (var item in ResResult.Response)
                    {
                        await conn.ExecuteScalarAsync(updateSql,
                         new
                         {
                             TransCode = item.Status.RspCod,
                             EDIId = item.InsId,
                             ClientId = item.ClientId
                         }, dbTransaction);
                    }
                    dbTransaction.Commit();
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

        public void UpdateTransList(IResResult ResResult)
        {
            using (IDbConnection conn = SqlConnectionFactory.CreateSqlConnection())
            {
                conn.Open();
                IDbTransaction dbTransaction = conn.BeginTransaction();
                try
                {
                    string updateSql = @"update T_EDF_Trans set TransCode = @TransCode where EDIId = @EDIId and ClientId = @ClientId";
                    foreach (var item in ResResult.Response)
                    {
                        conn.ExecuteScalar(updateSql,
                         new
                         {
                             TransCode = item.Status.RspCod,
                             EDIId = item.InsId,
                             ClientId = item.ClientId
                         }, dbTransaction);
                    }
                    dbTransaction.Commit();
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
