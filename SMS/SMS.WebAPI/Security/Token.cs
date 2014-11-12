using System;
using Core.Common;

namespace SMS.WebAPI.Security
{
    public class Token
    {
        public Guid ID { get; private set; }

        public Token()
        {
            ID = Guid.NewGuid();
        }

        private Token(string data)
        {
            ID = Guid.Parse(data);
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