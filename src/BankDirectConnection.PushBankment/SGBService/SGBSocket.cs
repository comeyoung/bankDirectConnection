using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.SGBService
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/3/9 14:56:37
	===============================================================================================================================*/
    public class SGBSocket
    {
        /// <summary>    
        /// 用来存放连接服务的IP地址和端口号，对应的Socket (这个为了以后的扩展用，现在暂时没用)    
        /// </summary>    
        Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();
        private readonly string ServerIP = ConfigurationManager.AppSettings["SGBIP"];
        private readonly string ServerPort = ConfigurationManager.AppSettings["SGBIP"];
        /// <summary>    
        /// 负责通信的Socket    
        /// </summary>    
        Socket socketSend;



        /// <summary>    
        /// 建立连接    
        /// </summary>    
        /// <param name="sender"></param>    
        /// <param name="e"></param>    
        public string PushMsg(string Message)
        {
            try
            {
                if(string.IsNullOrEmpty(ServerIP) || string.IsNullOrEmpty(ServerPort))
                {
                    throw new Exception("the IP Address of SG service is empty");
                }
                //创建负责通信的Socket
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //获取服务端的IP
                IPAddress ip = IPAddress.Parse(ServerIP);
                //获取服务端的端口号
                IPEndPoint port = new IPEndPoint(ip, Convert.ToInt32(ServerPort));
                //获得要连接的远程服务器应用程序的IP地址和端口号
                socketSend.Connect(port);
                byte[] buffer = Encoding.UTF8.GetBytes(Message);
                int rt = socketSend.Send(buffer);
                ////新建线程，去接收客户端发来的信息    
                //Thread td = new Thread(AcceptMgs);
                //td.IsBackground = true;
                //td.Start();
                string rtMsg = AcceptMgs();
                socketSend.Shutdown(SocketShutdown.Receive);
                return rtMsg;

            }
            catch(Exception ex) { throw ex; }
        }
        

        /// <summary>    
        /// 客户端接收服务器端返回的数据    
        /// </summary>    
        private string AcceptMgs()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 1024];
                    int r = socketSend.Receive(buffer);
                    if (r != 0)
                    {
                        string strMsg = Encoding.UTF8.GetString(buffer, 0, 1024);
                        Console.WriteLine(strMsg);
                        return strMsg;
                    }
                }
            }
            catch(Exception ex) { throw ex; }
        }


        /// <summary>      
        /// 将对象序列化为JSON格式      
        /// </summary>      
        /// <param name="o">对象</param>      
        /// <returns>json字符串</returns>      
        public string SerializeObject(object o)
        {
            // string json = JsonConvert.SerializeObject(o);
            //return json;
            return "";
        }

    }
}

