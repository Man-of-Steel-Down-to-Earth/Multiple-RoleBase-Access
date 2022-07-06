using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using SmartFile;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for cloud
/// </summary>
public class cloud
{
    public void cloud_upload(string path)
    {

        Environment.SetEnvironmentVariable("SMARTFILE_API_KEY", "k4njM2G4SdzXHgOfvYadLoRJpDZsNd");
        Environment.SetEnvironmentVariable("SMARTFILE_API_PASSWORD", "cjAmGYVsXKcGOFKKmLuGzbPB6fEbQx");
        Environment.SetEnvironmentVariable("SMARTFILE_API_URL", "http://keyproject1.smartfile.com/");



        string filepath = path;
        BasicClient api = new BasicClient();
        FileInfo FI = new FileInfo(filepath);//to know the filepath & also the type
        Hashtable ht = new Hashtable();
        HttpWebResponse HWR;
        try
        {
            ht.Add("file", FI);

            HWR = api.Post("path/data/role_base_access", null, ht);//path/data/doc is a format given by them

        }
        catch (Exception ex)
        {
        }

    }

    public string encrypt(string encryptString, string pass)
    {



        string EncryptionKey = pass;
       
        byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {  
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76  
        });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                encryptString = Convert.ToBase64String(ms.ToArray());
            }
        }
        return encryptString;
    }

    public string Decrypt(string cipherText,string key)
    {
        string EncryptionKey = key;
        cipherText = cipherText.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {  
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76  
        });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

    HttpWebResponse r;

    public string clouddownload(string fname)
    {
        string s;
        BasicClient api = new BasicClient("k4njM2G4SdzXHgOfvYadLoRJpDZsNd", "cjAmGYVsXKcGOFKKmLuGzbPB6fEbQx");
        Hashtable p = new Hashtable();
        p.Add("path", "role_base_access/" + fname);
        p.Add("list", true);
        p.Add("read", true);
        p.Add("name", "Screenshot");
        try
        {
            r = api.Post("/link", null, p);
        }
        catch { }
        using (var streamReader = new StreamReader(r.GetResponseStream()))
        {
            var responseText = streamReader.ReadLine();

            string lab1 = responseText.ToString();



            string furl = lab1.Substring(137, 12).ToString();


            //  HyperLink1.NavigateUrl = "https://file.ac" + furl + "/MyFile/"+forder[0].ToString();
            using (WebClient client = new WebClient())
            {
                s = client.DownloadString("https://file.ac" + furl + "/role_base_access/" + fname);

                //cloudkeypackets.Add(hashvalue);
            }

        }
        return s;
    }
}