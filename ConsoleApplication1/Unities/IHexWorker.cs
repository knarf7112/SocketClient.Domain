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
    /// <summary>
    ///   Utility for pack and unpack a single byte
    /// </summary>
    public interface IHexWorker
    {
        /// <summary>
        ///   unpack 1 byte to 2 hex
        /// </summary>
        /// <param name="b">byte</param>
        /// <returns>hex</returns>
        string Byte2Hex(byte b);

        /// <summary>
        ///    pack 2 hex to 1 byte
        /// </summary>
        /// <param name="hexStr">hex string with 2 char</param>
        /// <returns>byte</returns>
        byte Hex2Byte(string hexStr);
    }
}
