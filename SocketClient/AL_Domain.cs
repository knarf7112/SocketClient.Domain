using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ALCommon
{
    /// <summary>
    /// 自動加值電文類別( toPOS)
    /// </summary>
    [Serializable]
    public class AL2POS_Domain
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
        public int AL_AMT = 0;
        /// <summary>
        /// Return code
        /// </summary>
        public string AL2POS_RC;
        /// <summary>
        /// 加值序號
        /// </summary>
        public string AL2POS_SN;
    }

    /// <summary>
    /// 自動加值Txlog電文類別
    /// </summary>
    [Serializable]
    public class ALTxlog_Domain
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



    /// <summary>
    /// 自動加值 Errorlog 類別
    /// </summary>
    [Serializable]
    public class ErrorLogger_Domain
    {
        /// <summary>
        /// Log Date 紀錄日期
        /// </summary>
        public String LOG_DATE { get; set; }
        /// <summary>
        /// Log Time 紀錄時間
        /// </summary>
        public DateTime LOG_TIME { get; set; }
        /// <summary>
        /// Title 表頭 (Max:50)
        /// </summary>
        public String TITLE { get; set; }
        /// <summary>
        /// Message 訊息 (Max:500)
        /// </summary>
        public String MSG { get; set; }
        /// <summary>
        /// Priority (數字)
        /// </summary>
        public int PRIORITY { get; set; }
        /// <summary>
        /// Event Id 事件序號 (Max:30)
        /// </summary>
        public String EVENT_ID { get; set; }
        /// <summary>
        /// Severity 重要性 (TraceEventType類別)
        /// </summary>
        public TraceEventType SEVERITY { get; set; }
        /// <summary>
        /// Machine Name 機器名 (Max:100)
        /// </summary>
        public String MACHINE_NAME { get; set; }
        /// <summary>
        /// Thread Name 執行序名稱 (Max:50)
        /// </summary>
        public String THREAD_NAME { get; set; }

    
    }



}
