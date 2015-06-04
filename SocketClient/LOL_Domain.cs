using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOLCommon
{
    /// <summary>
    /// Contactless加值電文類別
    /// </summary>
    [Serializable]
    public class LOL_Domain
    {
        /// <summary>
        /// 通信種別
        /// </summary>
        public string COM_TYPE;
        /// <summary>
        /// 端末製造序號
        /// </summary>
        public string READER_ID;
        /// <summary>
        /// 端末區分
        /// </summary>
        public string POS_FLG;
        /// <summary>
        /// 顧客識別子
        /// </summary>
        public string MERC_FLG;
        /// <summary>
        /// 特店店號
        /// </summary>
        public string STORE_NO;
        /// <summary>
        /// POS機號
        /// </summary>
        public string REG_ID;
        /// <summary>
        /// icash卡號
        /// </summary>
        public string ICC_NO;
        /// <summary>
        /// 加值金額
        /// </summary>
        public int LOAD_AMT = 0;
        /// <summary>
        /// Return code
        /// </summary>
        public string LOAD_RC;
        /// <summary>
        /// 加值序號
        /// </summary>
        public string LOAD_SN;
    }

    /// <summary>
    /// Contactless購貨取消電文類別
    /// </summary>
    [Serializable]
    public class POL_Domain
    {
        /// <summary>
        /// 通信種別
        /// </summary>
        public string COM_TYPE;
        /// <summary>
        /// 端末製造序號
        /// </summary>
        public string READER_ID;
        /// <summary>
        /// 端末區分
        /// </summary>
        public string POS_FLG;
        /// <summary>
        /// 顧客識別子
        /// </summary>
        public string MERC_FLG;
        /// <summary>
        /// 特店店號
        /// </summary>
        public string STORE_NO;
        /// <summary>
        /// POS機號
        /// </summary>
        public string REG_ID;
        /// <summary>
        /// icash卡號
        /// </summary>
        public string ICC_NO;
        /// <summary>
        /// 購貨取消金額
        /// </summary>
        public int PCHR_AMT = 0;
        /// <summary>
        /// Return code
        /// </summary>
        public string PCHR_RC;
        /// <summary>
        /// 購貨取消序號
        /// </summary>
        public string PCHR_SN;
    }

    /// <summary>
    /// Contact 加值電文類別
    /// </summary>
    [Serializable]
    public class LOL_Ct_Domain //Loading Contact
    {
        /// <summary>
        /// Charge 情報
        /// </summary>
        public string CHARGE_INFO;
        /// <summary>
        /// 通信種別
        /// </summary>
        public string COM_TYPE;
        /// <summary>
        /// c tag
        /// </summary>
        public string CTAG;
        /// <summary>
        /// 配額額度
        /// </summary>
        public int LSM_BAL;
        /// <summary>
        /// 配額註記
        /// </summary>
        public string LSM_RQT_FLG;
        /// <summary>
        /// 端末製造序號
        /// </summary>
        public string READER_ID;
        /// <summary>
        /// 端末區分
        /// </summary>
        public string POS_FLG;
        /// <summary>
        /// 顧客識別子
        /// </summary>
        public string MERC_FLG;
        /// <summary>
        /// 特店店號
        /// </summary>
        public string STORE_NO;
        /// <summary>
        /// POS機號
        /// </summary>
        public string REG_ID;
        /// <summary>
        /// icash卡號
        /// </summary>
        public string ICC_NO;
        /// <summary>
        /// 加值金額
        /// </summary>
        public int LOAD_AMT = 0;
        /// <summary>
        /// Return code
        /// </summary>
        public string LOAD_RC;
        /// <summary>
        /// 加值序號
        /// </summary>
        public string LOAD_SN;
    }

    /// <summary>
    /// Contact 購貨取消電文類別
    /// </summary>
	[Serializable]
	public class POL_Ct_Domain
	{
        /// <summary>
        /// charge 情報
        /// </summary>
        public string CHARGE_INFO;
        /// <summary>
        /// 通信種別
        /// </summary>
        public string COM_TYPE;
        /// <summary>
        /// c tag
        /// </summary>
        public string CTAG;
        /// <summary>
        /// 配額額度
        /// </summary>
        public int LSM_BAL;
        /// <summary>
        /// 配額註記
        /// </summary>
        public string LSM_RQT_FLG;
        /// <summary>
        /// 端末製造序號
        /// </summary>
		public string READER_ID;
        /// <summary>
        /// 端末區分
        /// </summary>
        public string POS_FLG;
        /// <summary>
        /// 顧客識別子
        /// </summary>
        public string MERC_FLG;
        /// <summary>
        /// 特店店號
        /// </summary>
        public string STORE_NO;
        /// <summary>
        /// POS機號
        /// </summary>
        public string REG_ID;
        /// <summary>
        /// icash 卡號
        /// </summary>
        public string ICC_NO;
        /// <summary>
        /// 消費取消(contact)金額
        /// </summary>
        public int PCHR_AMT = 0;
        /// <summary>
        /// Return code
        /// </summary>
        public string PCHR_RC;
        /// <summary>
        /// 加值序號
        /// </summary>
        public string PCHR_SN;
	}
	
    /// <summary>
    /// Online Txlog電文類別
    /// </summary>
    [Serializable]
    public class Txlog_Domain
    {
        /// <summary>
        /// 通訊種別
        /// </summary>
        public string COM_TYPE;
        /// <summary>
        /// M_KIND
        /// </summary>
        public string M_KIND;
        /// <summary>
        /// 交易類別
        /// </summary>
        public string TRANS_TYPE;
        /// <summary>
        /// 特約機構代碼
        /// </summary>
        public string MERCHANT_NO;
        /// <summary>
        /// 端末製造序號
        /// </summary>
        public string READER_ID;
        /// <summary>
        /// 端末區分
        /// </summary>
        public string POS_FLG;
        /// <summary>
        /// 顧客識別子
        /// </summary>
        public string MERC_FLG;
        /// <summary>
        /// 特店店號
        /// </summary>
        public string STORE_NO;
        /// <summary>
        /// POS機號
        /// </summary>
        public string REG_ID;
        /// <summary>
        /// POS交易序號
        /// </summary>
        public string POS_SEQNO;
        /// <summary>
        /// 承認序號
        /// </summary>
        public string SN;
        /// <summary>
        /// TxLog
        /// </summary>
        public string TXLOG;
        /// <summary>
        /// TxLog Return Code
        /// </summary>
        public string TXLOG_RC;
    }

}
