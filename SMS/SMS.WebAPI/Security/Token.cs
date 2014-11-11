using System;
using System.Net;
using Core.Common;

namespace SMS.WebAPI.Security
{
    public class Token
    {
        public Guid TokenID { get; private set; }

        private Token(string data)
        {
            TokenID = Guid.Parse(data);
        }

        public string Encrypt()
        {
            return EncryptionHelper.Encrypt(ToString());
        }

        public static Token Decrypt(string encryptedToken)
        {
            return new Token(EncryptionHelper.Decrypt(encryptedToken));
        }
    }
}