namespace server.Services.AI;

public interface IPdfTextExtractor
{
    string ExtractText(string filePath);
}