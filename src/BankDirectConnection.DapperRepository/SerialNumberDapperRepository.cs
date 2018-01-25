
using BankDirectConnection.DapperRepository;
using Dapper;
using System;
using System.Linq;
using System.Threading.Tasks;

public class SerialNumberDapperRepository
{

    /// <summary>
    /// ªÒ»°–Ú¡–∫≈
    /// </summary>
    /// <returns></returns>
    public async Task<string> GetSeqNumberAsync()
    {
        int seqNo;
        using (var conn = SqlConnectionFactory.CreateSqlConnection())
        {
            conn.Open();
            string sql = $"SELECT NEXT VALUE FOR seq_no ";
            try
            {
                var numList = await conn.QueryAsync<int>(sql);
                seqNo = numList.ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return seqNo.ToString("000");
        }
    }

    public string GetSeqNumber()
    {
        int seqNo;
        using (var conn = SqlConnectionFactory.CreateSqlConnection())
        {
            conn.Open();
            string sql = $"SELECT NEXT VALUE FOR seq_no ";
            try
            {
                var numList = conn.Query<int>(sql);
                seqNo = numList.ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return seqNo.ToString("000");
        }
    }

}