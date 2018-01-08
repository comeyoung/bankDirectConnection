using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.Http
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 14:27:02
	===============================================================================================================================*/
    public class BaseHttpClient
    {
        private static string _Token;
        public static string Token
        {
            get
            {
                if (string.IsNullOrEmpty(_Token))
                {
                    var result = PostSignInAsync();
                    _Token = result.Result;
                }
                return _Token;
            }
            set { _Token = value; }
        }



        #region 异步方法

        /// <summary>
        /// 签到 返回token
        /// </summary>
        /// <returns></returns>
        public async static Task<string> PostSignInAsync()
        {
            return "";
        }

        /// <summary>
        /// 签退
        /// </summary>
        /// <returns></returns>
        public async static Task<string> PostSignOutAsync()
        {
            return "";
        }

        public async static Task<string> PostRequestAsync(string RequestXML)
        {
            HttpContent httpContent = new StringContent(RequestXML, Encoding.UTF8, "application/xml");
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            string result;
            using (var http = new HttpClient(handler))
            {
                // http.BaseAddress = new Uri(@BaseUrl);
                string url = "" + Token;
                var response = http.PostAsync(url, httpContent).Result;
                response.EnsureSuccessStatusCode();
                result = response.Content.ReadAsStringAsync().Result;
            }
            return result;
        }
        #endregion


        #region 同步方法

        /// <summary>
        /// 签到
        /// </summary>
        /// <returns></returns>
        public static string PostSignIn()
        {
            return "";
        }

        /// <summary>
        /// 签退
        /// </summary>
        /// <returns></returns>
        public static string PostSignOut()
        {
            return "";
        }
        #endregion


    }
}
