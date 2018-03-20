using BankDirectConnection.Domain.Enterprise;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.DapperRepository
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/3/8 15:03:34
	===============================================================================================================================*/
    public class EnterpriseInfoDapperRepository
    {
        /// <summary>
        /// 获取前置机企业配置信息
        /// </summary>
        /// <param name="BankType"></param>
        /// <returns></returns>
        public async Task<IList<IEnterpriseInfo>> GetEnterpriseAsync(string BankType)
        {
            var enterpInfo = new List<IEnterpriseInfo>(); ;
            using (var conn = SqlConnectionFactory.CreateSqlConnection())
            {
                conn.Open();
                string sql = $"SELECT * FROM AVA_EP_VIEW_ENTERPRISEINFO WHERE BankType = '{BankType}'";
                try
                {
                    var coll = await conn.QueryAsync<IEnterpriseInfo>(sql);
                    enterpInfo = coll.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return enterpInfo;
            }
        }

        /// <summary>
        /// 获取前置机企业配置信息
        /// </summary>
        /// <param name="BankType"></param>
        /// <returns></returns>
        public  IList<EnterpriseInfo> GetEnterprise(string BankType)
        {
            var enterpInfo = new List<EnterpriseInfo>();
            using (var conn = SqlConnectionFactory.CreateSqlConnection())
            {
                conn.Open();
                string sql = $"SELECT * FROM AVA_EP_VIEW_ENTERPRISEINFO WHERE BankType = '{BankType}'";
                try
                {

                    var coll = conn.Query<EnterpriseInfo>(sql);
                    enterpInfo = coll.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return enterpInfo;
            }
        }
    }
}
