using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OL_Autoload_Lib
{
    public enum CTransType
    {
        /// <summary>
        /// 查詢聯名卡狀態
        /// </summary>
        CHECK_CC = 72,
        /// <summary>
        /// 開啟Autoload功能
        /// </summary>
        AL_ENABLE = 73,
        /// <summary>
        /// 自動加值授權
        /// </summary>
        AUTOLOAD = 74,
        /// <summary>
        /// 代行授權
        /// </summary>
        ADVICE = 75,
        /// <summary>
        /// 連線掛失/取消掛失
        /// </summary>
        CANCELCARD = 76,
        /// <summary>
        /// OFFLINE自動加值授權
        /// </summary>
        OFF_AUTOLOAD = 77,
        /// <summary>
        /// 拒絕代行授權名單
        /// </summary>
        REFUSE_ADVICE = 78

    }
}
