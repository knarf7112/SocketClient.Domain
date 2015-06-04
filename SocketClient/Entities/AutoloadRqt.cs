using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OL_Autoload_Lib
{
    public class AutoloadRqt:ICash
    {
        private String sM_KIND;                     //特約機構種類
        private String sMERCHANT_NO;     //特約機構代號
        private String sSTORE_NO;               //店號
        private String sREADER_ID;              //端末製作序號
        private String sREG_ID;                     //POS機號
        private String sICC_NO;                     //卡號
        private CTransType cTRANS_TYPE;  //交易別
        private int iTRANS_AMT = 0;             //加值金額
        private String sRETURN_CODE = "";   //中心端Return Code(六碼)
        private String sSN = "00000000";        //加值序號(八碼)

        /// <summary>
        /// M_KIND
        /// </summary>
        public String M_KIND
        {
            get
            { return sM_KIND; }
            set
            { sM_KIND = value; }
        }
        /// <summary>
        /// MERCHANT_NO
        /// </summary>
        public String MERCHANT_NO
        {
            get
            { return sMERCHANT_NO; }
            set
            { sMERCHANT_NO = value; }
        }
        /// <summary>
        /// STORE_NO
        /// </summary>
        public String STORE_NO
        {
            get
            { return sSTORE_NO; }
            set
            { sSTORE_NO = value; }
        }
        /// <summary>
        /// READER_ID
        /// </summary>
        public String READER_ID
        {
            get
            { return sREADER_ID; }
            set
            { sREADER_ID = value; }
        }
        /// <summary>
        /// POS機號
        /// </summary>
        public String REG_ID
        {
            get
            { return sREG_ID; }
            set
            { sREG_ID = value; }
        }
        /// <summary>
        /// 卡號
        /// </summary>
        public String ICC_NO
        {
            get
            { return sICC_NO; }
            set
            { sICC_NO = value; }
        }

        /// <summary>
        /// 交易別
        /// </summary>
        public CTransType TRANS_TYPE
        {
            get
            { return cTRANS_TYPE; }
            set
            { cTRANS_TYPE = value; }
        }

        /// <summary>
        /// 交易金額
        /// </summary>
        public int TRANS_AMT
        {
            get
            { return iTRANS_AMT; }
            set
            { iTRANS_AMT = value; }
        }
        /// <summary>
        /// 中心端Return Code(六碼)
        /// </summary>
        public String RETURN_CODE
        {
            get
            { return sRETURN_CODE; }
            set
            { sRETURN_CODE = value; }
        }
        /// <summary>
        /// 序號
        /// </summary>
        public String SN
        {
            get
            { return sSN; }
            set
            { sSN = value; }
        }
    }
}
