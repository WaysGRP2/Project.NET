using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using MessageSerializable;

namespace Projet_Middleware.Couche_métier.Composant_technique
{
    class ReversibleEncryption
    {
        private static string skey = "22482984592";

        public static Message EncryptString(Message msg)
        {
            string toEncrypt = (string)msg.Data[0];
            byte[] encryptionKey = GenerateAESKey();

            var toEncryptBytes = Encoding.UTF8.GetBytes(toEncrypt);
            using (var provider = new AesCryptoServiceProvider())
            {
                provider.Key = encryptionKey;
                provider.Mode = CipherMode.CBC;
                provider.Padding = PaddingMode.PKCS7;
                using (var encryptor = provider.CreateEncryptor(provider.Key, provider.IV))
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(toEncryptBytes, 0, toEncryptBytes.Length);
                            cs.FlushFinalBlock();
                            var retVal = new byte[16 + ms.Length];
                            provider.IV.CopyTo(retVal, 0);
                            ms.ToArray().CopyTo(retVal, 16);
                            msg.Data[0] = retVal;
                            msg.Data[1] = encryptionKey;
                            msg.Statut = true;
                            return msg;
                        }
                    }
                }
            }
        }

        public static Message DecryptString(Message msg)
        {
            byte[] encryptedString = ((byte[])msg.Data[0]);
            byte[] encryptionKey = (byte[])msg.Data[1];

            using (var provider = new AesCryptoServiceProvider())
            {
                provider.Key = encryptionKey;
                provider.Mode = CipherMode.CBC;
                provider.Padding = PaddingMode.PKCS7;
                provider.IV = encryptedString.Take(16).ToArray();
                using (var ms = new MemoryStream(encryptedString, 16, encryptedString.Length - 16))
                {
                    using (var decryptor = provider.CreateDecryptor(provider.Key, provider.IV))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] decrypted = new byte[encryptedString.Length];
                            var byteCount = cs.Read(decrypted, 0, encryptedString.Length);
                            msg.Data[0] = Encoding.UTF8.GetString(decrypted, 0, byteCount);
                            msg.Data[1] = encryptionKey;
                            msg.Statut = true;
                            return msg;
                        }
                    }
                }
            }
        }

        public static byte[] GenerateAESKey()
        {
            using (var provider = new AesManaged())
            {
                provider.KeySize = 256;
                provider.GenerateKey();
                return provider.Key;
            }
        }

        public static void EncryptFile(string inputFile)
        {
            string outputFile = inputFile + ".new";
            try
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);

                    using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create))
                    {
                        using (ICryptoTransform encryptor = aes.CreateEncryptor(key, IV))
                        {
                            using (CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsIn.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                }
                RenameFile(outputFile, inputFile);
            }
            catch (Exception ex)
            {
                // failed to encrypt file
                Program.Debug(ex.Message);
            }
        }

        public static void DecryptFile(string inputFile)
        {
            string outputFile = inputFile + ".new";
            try
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

                    /* This is for demostrating purposes only.
                     * Ideally you will want the IV key to be different from your key and you should always generate a new one for each encryption in other to achieve maximum security*/
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);

                    using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
                    {
                        using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                        {
                            using (ICryptoTransform decryptor = aes.CreateDecryptor(key, IV))
                            {
                                using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                    {
                                        fsOut.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                }
                RenameFile(outputFile, inputFile);
            }
            catch (Exception ex)
            {
                // failed to decrypt file
                Program.Debug(ex.Message);
            }
        }

        public static void RenameFile(string oldName, string newName)
        {
            File.Delete(newName);
            File.Move(oldName, newName);
            return;
        }
    }
}
