#region License
/*
 *  Copyright © 2011 - 2015 Bankpro E-Service Technology Co., Ltd.
 *  Created by Dennis Chang
 */
#endregion

#region Version Record
/*
 * Ver 1.0.0 release 
 */
#endregion

#region Imports
using System;
using System.Text;
//using Common.Logging;
#endregion

namespace IM.Daemon.Utilities
{
    public class HexConverter : IHexConverter
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(HexConverter));

        public IHexWorker HexWorker { private get; set; }

        public HexConverter()
            : this(new HexWorkerByArr())
        {
        }

        public HexConverter(IHexWorker hexWorker)
        {
            this.HexWorker = hexWorker;
            //log.Debug("Use " + this.hexWorker.GetType().FullName);
        }       

        public string Bytes2Hex(byte[] bArr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bArr)
            {
                sb.Append(this.HexWorker.Byte2Hex(b));
            }
            return sb.ToString();
        }

        public byte[] Hex2Bytes(string hexStr)
        {
            byte[] bArr = new byte[hexStr.Length / AbsHexWorker.HexPerByte];
            for (int i = 0, p = 0; i < bArr.Length; i++, p+= AbsHexWorker.HexPerByte )
            {
                bArr[i] = this.HexWorker.Hex2Byte(
                    hexStr.Substring(p, AbsHexWorker.HexPerByte)
                );
            }
            return bArr;
        }

        public string Str2Hex(string str)
        {
            byte[] byteArr = Encoding.Default.GetBytes(str);
            return this.Bytes2Hex(byteArr);
        }

        public string Hex2Str(string hexStr)
        {
            byte[] byteArr = this.Hex2Bytes(hexStr);
            return Encoding.Default.GetString(byteArr);
        }

    }
}
