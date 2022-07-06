﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

/// <summary>
/// Summary description for cryptography
/// </summary>
public class cryptography
{
    public void Decrypt(string inputFilePath, string outputfilePath, string ekey)
    {
        string EncryptionKey = ekey;
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
            {
                using (CryptoStream cs = new CryptoStream(fsInput, encryptor.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
                    {
                        int data;
                        while ((data = cs.ReadByte()) != -1)
                        {
                            fsOutput.WriteByte((byte)data);
                        }
                    }
                }
            }
        }
    }

    public void Encrypt(string inputFilePath, string outputfilePath, string ekey)
    {
        string EncryptionKey = ekey;
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (FileStream fsOutput = new FileStream(outputfilePath, FileMode.Create))
            {
                using (CryptoStream cs = new CryptoStream(fsOutput, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (FileStream fsInput = new FileStream(inputFilePath, FileMode.Open))
                    {
                        int data;
                        while ((data = fsInput.ReadByte()) != -1)
                        {
                            cs.WriteByte((byte)data);
                        }
                    }
                }
            }
        }
    }

    public string GetHashCode(string filePath, HashAlgorithm cryptoService)
    {
        // create or use the instance of the crypto service provider
        // this can be either MD5, SHA1, SHA256, SHA384 or SHA512
        using (cryptoService)
        {
            using (var fileStream = new FileStream(filePath,
                                                   FileMode.Open,
                                                   FileAccess.Read,
                                                   FileShare.ReadWrite))
            {
                var hash = cryptoService.ComputeHash(fileStream);
                var hashString = Convert.ToBase64String(hash);
                return hashString.TrimEnd('=');
            }
        }
    }

}