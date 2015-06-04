using System;
using System.Text;
//
using Kms.Crypto;
using Common.Logging;

namespace Kms.PosClient
{
    public class SessionHandler //: ISessionHandler
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(SessionHandler));
        //
        public ISymCryptor AesCryptor = new Kms.Crypto.SymCryptor("AES");

        public IKeyDeriver KeyDeriver = new Kms.Crypto.Aes128KeyDeriver() 
        { 
            Aes128CMacWorker = new Kms.Crypto.Aes128CMacWorker() 
            {
                AesCryptor = new Kms.Crypto.SymCryptor("AES"), 
                BytesBitwiser = new Kms.Crypto.BytesBitwiser(), 
                ByteWorker = new Kms.Crypto.ByteWorker() , 
                HexConverter = new HexConverter( new Kms.Crypto.HexWorkerByArr()) 
            } 
        };


        public IHexConverter HexConverter = new HexConverter();

        public IByteWorker ByteWorker = new Kms.Crypto.ByteWorker();

        public IPaddingHelper PaddingHelper = new Kms.Crypto.Pkcs7PaddingHelper() 
        { 
            BlockSize = 16, 
            ByteWorker = new Kms.Crypto.ByteWorker() 
        };
        public IRandWorker RandWorker { private get; set; }
        public String SeedKeyHex = "5C9A1031BE73561663B393DBFEFDEE5A";
        public String RndA
        {
            get
            {
                return this.HexConverter.Bytes2Hex(this.rndA);
            }
            set
            {
                try
                {
                    this.rndA = this.HexConverter.Hex2Bytes(value);
                }
                catch (Exception ex)
                {
                    //log.Error(ex.StackTrace);
                    throw new Exception("RndA[" + value + "] 設定錯誤...");
                }
            }
        }
        private byte[] rndA;

        public String RndB
        {
            get
            {
                return this.HexConverter.Bytes2Hex(this.rndB);
            }
            set
            {
                try
                {
                    if (this.FixRndB)
                    {
                        this.rndB = this.HexConverter.Hex2Bytes(value);
                    }
                    else
                    {
                        this.rndB = this.RandWorker.GetBytes(16);
                    }
                }
                catch (Exception ex)
                {
                    //log.Error(ex.StackTrace);
                    throw new Exception("RndB[" + value + "] 設定錯誤...");
                }
            }
        }
        private byte[] rndB;
        private byte[] sesKey = null;
        private byte[] divKey;
        private byte[] tid;
        public bool FixRndB { get; set; }

        public SessionHandler()
        {
        }

        public byte[] Encrypt(byte[] decrypted)
        {
            try
            {
                if (this.sesKey == null)
                {
                    this.sesKey = this.getSesKey(this.rndA, this.rndB);
                }
                this.AesCryptor.SetIv(SymCryptor.ConstZero);
                this.AesCryptor.SetKey(this.sesKey);
                return this.AesCryptor.Encrypt( this.PaddingHelper.AddPadding(decrypted) );
            }
            catch (Exception ex)
            {
                //log.Error("Encrypt by session key error...." + ex.StackTrace);
                throw new Exception("Encrypt by session key error...." + ex.StackTrace);
            }
        }

        public byte[] Decrypt(byte[] encrypted)
        {
            try
            {
                if (this.sesKey == null)
                {
                    this.sesKey = this.getSesKey(this.rndA, this.rndB);
                }
                this.AesCryptor.SetIv(SymCryptor.ConstZero);
                this.AesCryptor.SetKey(this.sesKey);
                return this.PaddingHelper.RemovePadding(this.AesCryptor.Decrypt(encrypted));
            }
            catch (Exception ex)
            {
                //log.Error("Decrypt by session key error...." + ex.StackTrace);
                throw new Exception("Decrypt by session key error...." + ex.StackTrace);
            }
        }

        public byte[] Auth1Response(byte[] fromCenter)
        {
            this.AesCryptor.SetIv(SymCryptor.ConstZero);
            this.AesCryptor.SetKey(this.divKey);
            this.rndA = this.AesCryptor.Decrypt(fromCenter);
            return this.rndA;
        }

        public byte[] Auth2Request()
        {
            this.AesCryptor.SetIv(SymCryptor.ConstZero);
            this.AesCryptor.SetKey(this.divKey);
            byte[] decrypted = this.PaddingHelper.AddPadding
            (
                this.ByteWorker.Combine
                (
                    this.rndB
                  , this.ByteWorker.RotateLeft(this.rndA, 2)
                  , this.tid
                )
            );
            return this.AesCryptor.Encrypt(decrypted);
        }

        public byte[] Auth2Response( byte[] fromCenter )
        {
            this.AesCryptor.SetIv(SymCryptor.ConstZero);
            this.AesCryptor.SetKey(this.divKey); 
            byte[] decrypted = this.AesCryptor.Decrypt(fromCenter);
            byte[] qq = this.ByteWorker.RotateLeft(this.rndB, 2);
            string s1 = HexConverter.Bytes2Hex(qq);
            string s2 = HexConverter.Bytes2Hex(decrypted);
            if( !this.ByteWorker.AreEqual(qq, decrypted) )
            {
                throw new Exception
                ( 
                    "RndB[" + this.RndB + "] not match to Center response:[" 
                  + this.HexConverter.Bytes2Hex( this.ByteWorker.RotateRight( decrypted, 2 ) ) 
                  + "]..."
                );
            }
            this.sesKey = this.getSesKey(this.rndA, this.rndB);
            return decrypted;
        }

        public string TId
        {
            get
            {
                return this.HexConverter.Bytes2Hex(this.tid);
            }
            set
            {
                try
                {
                    this.tid = this.HexConverter.Hex2Bytes(value);
                    this.KeyDeriver.SetSeedKey(this.HexConverter.Hex2Bytes(this.SeedKeyHex));
                    this.KeyDeriver.DiverseInput(this.getDivInput(this.tid));
                    this.divKey = this.KeyDeriver.GetDerivedKey();
                    string ss = this.HexConverter.Bytes2Hex(this.divKey);
                }
                catch (Exception ex)
                {
                    //log.Error(ex.StackTrace);
                    Console.WriteLine(ex.StackTrace);
                    throw new Exception("TID[" + value + "] 設定錯誤...");
                }
            }
        }

        #region private member functions

        /// <summary>
        ///  Get Center KDF data
        /// </summary>
        /// <param name="tid">Terminal ID</param>
        /// <returns>KDF data bytes</returns>
        private byte[] getDivInput(byte[] tid)
        {
            return this.ByteWorker.Combine
            (
                tid
                , Encoding.ASCII.GetBytes("SEVEN")
                , tid
                , Encoding.ASCII.GetBytes("11")
                , tid
            );
        }

        /// <summary>
        ///  Get Session key from rndA and rndB
        /// </summary>
        /// <param name="rndA">Center rnd data</param>
        /// <param name="rndB">Msrw rnd Data</param>
        /// <returns>Session key</returns>
        private byte[] getSesKey(byte[] rndA, byte[] rndB)
        {
            return this.ByteWorker.Combine
            (
              this.ByteWorker.SubArray(rndA, 0, 4)
            , this.ByteWorker.SubArray(rndB, 4, 4)
            , this.ByteWorker.SubArray(rndA, 8, 4)
            , this.ByteWorker.SubArray(rndB, 12, 4)
            );
        }

        #endregion
    }
}
