using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
/// <summary>
/// Summary description for read_txt
/// </summary>
public class read_txt
{
    public string readtxt(string path)
    {
        string content = File.ReadAllText(path);
        return content;
    }
}