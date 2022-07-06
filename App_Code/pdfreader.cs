using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for pdfreader
/// </summary>
public class pdfreader
{
    public string pdfText(string path)
    {
        PdfReader reader = new PdfReader(path);
        string text = string.Empty;
        for (int page = 1; page <= reader.NumberOfPages; page++)
        {
            text += PdfTextExtractor.GetTextFromPage(reader, page);
        }
        reader.Close();
        return text;
    }   
}