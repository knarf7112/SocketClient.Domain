using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL_Autoload_Lib
{
    [Serializable]
    public class Sign_Domain
    {
      
        /// <summary>
        /// 交易類別
        /// </summary>
        public string COM_Type { get; set; }
      /// <summary>
      /// 銀行碼
      /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 交易時間
        /// </summary>
        public string transDateTime { get; set; }
       /// <summary>
       /// 交易序號
       /// </summary>
        public string traceNumber { get; set; }
       /// <summary>
       /// Reture Code
       /// </summary>
        public string RC { get; set; }
       /// <summary>
        /// 071(Sign_On)/072(Sign_Off)/301(Echo Test)
       /// </summary>
        public string infCode { get; set; }

    }
}
