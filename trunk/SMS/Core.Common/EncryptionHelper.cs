using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Core.Common
{
    public static class EncryptionHelper
    {
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("!5h0pM@n@g3m3nt!");

        private const string passPhrase = "encryptionKey";

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        public static string Encrypt(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new PasswordDeriveBytes(passPhrase, null))
            {
                var keyBytes = password.GetBytes(keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            var cipherTextBytes = Convert.FromBase64String(cipherText);
            using (var password = new PasswordDeriveBytes(passPhrase, null))
            {
                var keyBytes = password.GetBytes(keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        public static string SHA256Hash(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            var bytes = Encoding.UTF8.GetBytes(plainText);
            var hashString = new SHA256Managed();

            var hashValue = hashString.ComputeHash(bytes);
            return hashValue.Aggregate("", (current, x) => current + String.Format("{0:x2}", x));
        }

        //public static X509Certificate2 GetX509Certificate(string subjectName)
        //{
        //    var certificateStore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
        //    certificateStore.Open(OpenFlags.ReadOnly);
        //    X509Certificate2 certificate;

        //    try
        //    {
        //        certificate = certificateStore.Certificates.OfType<X509Certificate2>()
        //            .FirstOrDefault(cert => cert.SubjectName.Name.Equals(subjectName, StringComparison.OrdinalIgnoreCase));
        //    }
        //    finally
        //    {
        //        certificateStore.Close();
        //    }

        //    if (certificate == null)
        //        throw new Exception(String.Format("Certificate '{0}' not found.", subjectName));

        //    return certificate;
        //}

        //public static string Encrypt(X509Certificate2 certificate, string plainToken)
        //{
        //    var cryptoProvidor = (RSACryptoServiceProvider)certificate.PublicKey.Key;
        //    byte[] encryptedTokenBytes = cryptoProvidor.Encrypt(Encoding.UTF8.GetBytes(plainToken), true);
        //    return Convert.ToBase64String(encryptedTokenBytes);
        //}

        //public static string Decrypt(X509Certificate2 certificate, string encryptedToken)
        //{
        //    var cryptoProvidor = (RSACryptoServiceProvider)certificate.PrivateKey;
        //    byte[] decryptedTokenBytes = cryptoProvidor.Decrypt(Convert.FromBase64String(encryptedToken), true);

        //    return Encoding.UTF8.GetString(decryptedTokenBytes);
        //}
    }
}
