#region License
/*
 *  Copyright © 2012 - 2016 Bankpro E-Service Technology Co., Ltd.
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
    ///    Pack and unpack hex string to other Type( uint, string )
    /// </summary>
    public interface IHexConverter
    {
        /// <summary>
        ///    unpack string(default encoding) to hex according to default encoding
        /// </summary>
        /// <param name="str">string data to be unpack(default encoding)</param>
        /// <returns>hex string</returns>
        string Str2Hex(string str);

        /// <summary>
        ///   pack hex to string(default encoding) according to default encoding
        /// </summary>
        /// <param name="hexStr">hex string to be packed</param>
        /// <returns>string data(default encoding)</returns>
        string Hex2Str(string hexStr);

        /// <summary>
        ///   pack hex string to byte array
        /// </summary>
        /// <param name="hexStr">hex string</param>
        /// <returns>byte[]</returns>
        byte[] Hex2Bytes(string hexStr);

        /// <summary>
        ///   unpack byte array to hex string
        /// </summary>
        /// <param name="dataBytes">byte array to be unpacked</param>
        /// <returns>Hex string</returns>
        string Bytes2Hex(byte[] dataBytes);      
    }
}