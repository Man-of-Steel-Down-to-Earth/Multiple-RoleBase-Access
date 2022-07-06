using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.Office.Interop.Word;
/// <summary>
/// Summary description for read_doc
/// </summary>
public class read_doc
{
    public string read_from_doc(string path)
    {
        //createting the object of application class  
        Application Objword = new Application();

        //creating the object of document class  
        Document objdoc = new Document();

        //get the uploaded file full path  

        string paths = path;
        //dynamic FilePath = Path.GetFullPath(FileUpload1.PostedFile.FileName);
        dynamic FilePath = paths;
        // the optional (missing) parameter to API  
        dynamic NA = System.Type.Missing;

        //open Word file document   
        objdoc = Objword.Documents.Open
                      (ref FilePath, ref NA, ref NA, ref NA, ref NA,
                       ref NA, ref NA, ref NA, ref NA,
                       ref NA, ref NA, ref NA, ref NA,
                       ref NA, ref NA, ref NA

                       );


        //creating the object of string builder class  
        StringBuilder sb = new StringBuilder();

        for (int Line = 0; Line < objdoc.Paragraphs.Count; Line++)
        {
            string Filedata = objdoc.Paragraphs[Line + 1].Range.Text.Trim();

            if (Filedata != string.Empty)
            {
                //Append word files data to stringbuilder  
                sb.AppendLine(Filedata);
            }

        }

        //closing document object   
        ((_Document)objdoc).Close();

        //Quit application object to end process  
        ((_Application)Objword).Quit();

        //assign stringbuilder object to show text in textbox  
        string content = Convert.ToString(sb);
        return content;
    }
}