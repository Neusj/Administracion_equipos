using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_equipos.Security
{
    public static class AES_Helper
    {
        private const int KeySize = 256;
        private const int BlockSize = 128;
        public const string ENCRYP_KEY = "7n>N>7sgLQd%p3/z$:f5zDYolaakemw'";

        public static string Encrypt(string plainText, string key)
        {

            Console.WriteLine("Longitud de la clave proporcionada: " + key.Length);
            byte[] encryptedBytes;
            byte[] iv;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.KeySize = KeySize;
                aesAlg.BlockSize = BlockSize;
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.GenerateIV();
                iv = aesAlg.IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    encryptedBytes = msEncrypt.ToArray();
                }
            }

            return Convert.ToBase64String(iv) + ":" + Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string cipherText, string key)
        {
            string[] parts = cipherText.Split(':');

            // Verificar si la cadena cipherText contiene el carácter ':'
            if (parts.Length >= 2)
            {
                byte[] iv = Convert.FromBase64String(parts[0]);
                byte[] cipherBytes = Convert.FromBase64String(parts[1]);

                string plaintext;

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.KeySize = KeySize;
                    aesAlg.BlockSize = BlockSize;
                    aesAlg.Key = Encoding.UTF8.GetBytes(key);
                    aesAlg.IV = iv;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (var msDecrypt = new System.IO.MemoryStream(cipherBytes))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }

                return plaintext;
            }
            else
            {
                return cipherText;
            }
        }

    }
}
