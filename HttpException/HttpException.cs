using System;
using System.Net;
using NETCore.Encrypt;

namespace HttpException
{
    public class HttpException : Exception
    {
        public HttpStatusCode CodeStatus { get; set; }
        public string traceID { get; set; }
        public string describe { get; set; }

        public HttpException(string Message, string describe, HttpStatusCode Code) : base(string.Format("{0}", Message))
        {
            this.CodeStatus = Code;
            this.describe = describe;
            this.traceID = EncryptProvider.Sha1(DateTime.Now.ToString());
        }
    }
}
