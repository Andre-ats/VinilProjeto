namespace VinilProjeto.Service.FileService;

public class FileService
{
    public bool saveImagemService(string path, Stream content)
    {
        
        string directoryName = Path.GetDirectoryName(path)
                               ?? throw new Exception($"Diretório {path} não encontrado ou nulo!");

        if (!Directory.Exists(directoryName))
            Directory.CreateDirectory(directoryName);

        using FileStream file = new FileStream(path, FileMode.Create);
        content.CopyTo(file);
        
        return File.Exists(path);
    }
    
    public Stream loadDocContent(string path)
    {
                
        using FileStream fileStream = new FileStream(path, FileMode.Open);

        MemoryStream memoryStream = new MemoryStream();
        fileStream.CopyTo(memoryStream);
        
        fileStream.Flush();
        memoryStream.Position = 0;

        return memoryStream;
    }
    
}