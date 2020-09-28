using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class Encrypt
    {
        public static string encryptMethod(string plainText)
        {
            if (plainText == null)
            {
                return null;
            }

            // Get the bytes of the string
            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var passwordBytes = Encoding.UTF8.GetBytes("BSQ4THRC0P");

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesEncrypted = Encrypt.encryptMethod(bytesToBeEncrypted, passwordBytes);

            return Convert.ToBase64String(bytesEncrypted);
        }

        private static byte[] encryptMethod(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            var saltBytes = new byte[8];

            using (MemoryStream ms = new MemoryStream())
            {
                for (int i = 1; i <= saltBytes.Length; i++)
                {
                    saltBytes[i - 1] = Convert.ToByte(i);
                }

                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var iterations = 1000;
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, iterations);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }
    }

}
