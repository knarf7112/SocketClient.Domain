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

namespace IM.Daemon.Utilities
{
    public abstract class AbsHexWorker : IHexWorker
    {
        public static readonly int HexPerByte = 2;
        public abstract string Byte2Hex(byte b);
        public abstract byte Hex2Byte(string hexStr);
    }
}

