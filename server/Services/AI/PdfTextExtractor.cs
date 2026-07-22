using UglyToad.PdfPig;


namespace server.Services.AI;


public class PdfTextExtractor : IPdfTextExtractor
{

    public string ExtractText(string filePath)
    {

        using var document =
            PdfDocument.Open(filePath);


        var text = "";


        foreach(var page in document.GetPages())
        {
            text += page.Text;
        }


        return text;

    }

}