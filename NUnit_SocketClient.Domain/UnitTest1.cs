using System;
using NUnit.Framework;
//
using SocketClient.Domain;
using ALCommon;
namespace NUnit_SocketClient.Domain
{
    [TestFixture]
    public class UnitTest1
    {
        private ISocketClient<AL2POS_Domain> socketClient { get; set; }
        private AL2POS_Domain poco { get; set; }
        [SetUp]
        public void Init()
        {
            string ip = "10.27.88.161";
            int port = 6102;
            this.socketClient = new GenSocketClient<AL2POS_Domain>(ip, port);

        }

        [Test]
        public void Test_ConnectToServer()
        {
            
        }
    }
}
