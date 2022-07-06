using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for rsa_algorithm
/// </summary>
public class rsa_algorithm
{


    public static int currentBitStrength = 0;

    public void generatkey(string fname,string path,string public_path,string private_path)
    {
        RSACryptoServiceProvider RSAProvider = new RSACryptoServiceProvider(currentBitStrength);

        string publicAndPrivateKeys = "<xml>" + "<BitStrength>" + currentBitStrength.ToString() + "</BitStrength>" + RSAProvider.ToXmlString(true) + "< /xml >";
        string justPublicKey = "<xml>" + "<BitStrength>" + currentBitStrength.ToString() + "</BitStrength>" + RSAProvider.ToXmlString(false) + "< /xml >";

        string st = publicAndPrivateKeys.ToString();

        DirectoryInfo dir = new DirectoryInfo(path);
        dir.Create();
        FileStream Pri = new FileStream(private_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
        StreamWriter sw = new StreamWriter(Pri);
        sw.Write(st.ToString());
        sw.Close();
        FileStream Pub = new FileStream(public_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
        StreamWriter sw1 = new StreamWriter(Pub);
        sw1.Write(justPublicKey.ToString());
        sw1.Close();
    }
    public void emp_generatkey(string path, string public_path, string private_path)
    {
        RSACryptoServiceProvider RSAProvider = new RSACryptoServiceProvider(currentBitStrength);

        string publicAndPrivateKeys = "<xml>" + "<BitStrength>" + currentBitStrength.ToString() + "</BitStrength>" + RSAProvider.ToXmlString(true) + "< /xml >";
        string justPublicKey = "<xml>" + "<BitStrength>" + currentBitStrength.ToString() + "</BitStrength>" + RSAProvider.ToXmlString(false) + "< /xml >";

        string st = publicAndPrivateKeys.ToString();

        DirectoryInfo dir = new DirectoryInfo(path);
        dir.Create();
        FileStream Pri = new FileStream(private_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
        StreamWriter sw = new StreamWriter(Pri);
        sw.Write(st.ToString());
        sw.Close();
        FileStream Pub = new FileStream(public_path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
        StreamWriter sw1 = new StreamWriter(Pub);
        sw1.Write(justPublicKey.ToString());
        sw1.Close();
    }

    string pkey;
    public static int dtkeysize = 1024;

    public string RSAEncrypt(string data,string private_path)
    {
        StreamReader srr = new StreamReader(private_path);
        pkey = srr.ReadToEnd();
        srr.Close();

        RSACryptoServiceProvider RSAProvider = new RSACryptoServiceProvider();
        RSAProvider.FromXmlString(pkey);
        int keysize = dtkeysize / 8;
        byte[] bytes = Encoding.UTF32.GetBytes(data);
        byte[] byt = SHA1.Create().ComputeHash(bytes);
        string Hashvalue = Convert.ToBase64String(byt);
        int maxlength = (keysize) - 2 - (2 * SHA1.Create().ComputeHash(bytes).Length);
        int datalength = bytes.Length;
        int iteration = datalength / maxlength;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i <= iteration; i++)
        {
            byte[] tempbyte = new byte[(datalength - maxlength * i > maxlength) ? maxlength : datalength - maxlength * i];
            System.Buffer.BlockCopy(bytes, maxlength * i, tempbyte, 0, tempbyte.Length);
            byte[] encryptedBytes = RSAProvider.Encrypt(tempbyte, true);
            Array.Reverse(encryptedBytes);
            sb.Append(Convert.ToBase64String(encryptedBytes));
        }

        return sb.ToString();
    }

    string xmlstr;
    public string RSAdecryption(string ciper, string fname,string private_path)
    {
        try
        {
            string inputString = ciper;
            StreamReader sr2 = new StreamReader(private_path);
            xmlstr = sr2.ReadToEnd();
            sr2.Close();
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(dtkeysize);
            rsaCryptoServiceProvider.FromXmlString(xmlstr);
            int base64BlockSize = ((dtkeysize / 8) % 3 != 0) ? (((dtkeysize / 8) / 3) * 4) + 4 : ((dtkeysize / 8) / 3) * 4;
            int iterations = inputString.Length / base64BlockSize;
            ArrayList arrylst = new ArrayList();
            for (int i = 0; i < iterations; i++)
            {
                byte[] encryptedbyte = Convert.FromBase64String(inputString.Substring(base64BlockSize * i, base64BlockSize));
                Array.Reverse(encryptedbyte);
                arrylst.AddRange(rsaCryptoServiceProvider.Decrypt(encryptedbyte, true));
            }
            string Value = Encoding.UTF32.GetString(arrylst.ToArray(Type.GetType("System.Byte")) as byte[]);
            return Value;


        }
        catch
        {
            return "";
        }
    }
}