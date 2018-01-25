using BankDirectConnection.Application.Transfer;
using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.DapperRepository;
using BankDirectConnection.Domain.Model;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankDirectConnection.PushBankment.BankTransfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 12:04:28
	===============================================================================================================================*/
    /// <summary>
    /// 银行服务
    /// </summary>
    public class BankService : IBankService<ITranscations,ITranscation, ITransferQueryData, ITransferQueryDataList, IResResult>
    {
        public IResResult PaymentTransfer(ITranscations Transcation)
        {
            //检查transcation消息
            try
            {
                Transcation.InitData();
                Transcation.Check();
                SerialNumberDapperRepository serialrepository = new SerialNumberDapperRepository();
                Transcation.Transcations.ToList().ForEach(c => { c.NewEDIId(); c.EDIId = c.EDIId + serialrepository.GetSeqNumber(); });
                var trans = TransModel.Create(Transcation);
                TranscationDapperRepository repository = new TranscationDapperRepository();
                repository.SaveTransList(trans);
                ////获取银行信息，调用具体银行的服务
                var bankService = BankFactory.CreateBank(Transcation.TransWay);
                var rt = bankService.PaymentTransfer(Transcation);

                repository.UpdateTransList(rt);
                return rt;
            }
            catch (BusinessException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new BusinessException(ex.Message) { Code = "2002001" };
            }
        }

        public IResResult QueryTransStatus(ITransferQueryDataList Transcation)
        {
            try
            {
                //查询是根据客户端流水号和EDI流水号来查询，同一请求可能会涉及多个银行的交易查询
                // 取出各个银行的数据
                Dictionary<string, ITransferQueryDataList> dicTransList = new Dictionary<string, ITransferQueryDataList>();
                foreach(var item in Transcation.TransferQueryDatas)
                {
                    string key = Instruction.GetBankService(item.EDIId);
                    if (dicTransList.Keys.Contains(key))
                    {
                        ITransferQueryDataList query = dicTransList[key];
                        query.TransferQueryDatas.Add(item);
                    }
                    else
                    {
                        ITransferQueryDataList queryList = new TransferQueryDataList();
                        queryList.TransferQueryDatas.Add(item);
                        dicTransList.Add(key, queryList);
                    }
                }
                //遍历不同银行服务的查询
                IResResult result = new ResResult();
                foreach (var item in dicTransList)
                {
                    var bankService = BankFactory.CreateBank(item.Key);
                    var rt = bankService.QueryTransStatus(item.Value);
                    if (null == result)
                        result = rt;
                    else
                        result.MergeResResult(rt);
                }
                return result;
            }
            catch(Exception ex)
            {
                throw new BusinessException(ex.Message) { Code = "2002001" };
            }
            
        }
    }
}
