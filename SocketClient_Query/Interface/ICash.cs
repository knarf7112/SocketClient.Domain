using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OL_Autoload_Lib
{
    /// <summary>
    /// ICASH介面
    /// </summary>
    public interface ICash
    {
        /// <summary>
        /// 通訊種別
        /// </summary>
        //String COM_TYPE { get; set; }

        /// <summary>
        /// 特約機構種類
        /// </summary>
        String M_KIND { get; set; }

        /// <summary>
        /// 特約機構代號
        /// </summary>
        String MERCHANT_NO { get; set; }

        /// <summary>
        /// 店號
        /// </summary>
        String STORE_NO { get; set; }

        /// <summary>
        /// READER_ID
        /// </summary>
        String READER_ID { get; set; }

        /// <summary>
        /// POS機號
        /// </summary>
        String REG_ID { get; set; }

        /// <summary>
        /// 卡號
        /// </summary>
        String ICC_NO { get; set; }

        /// <summary>
        /// 交易別
        /// </summary>
        CTransType TRANS_TYPE { get; set; }

        /// <summary>
        /// 交易金額
        /// </summary>
        int TRANS_AMT { get; set; }

        /// <summary>
        /// 中心端Return Code(六碼)
        /// </summary>
        String RETURN_CODE { get; set; }

        /// <summary>
        /// 序號(八碼)
        /// </summary>
        String SN { get; set; }
    }
}
