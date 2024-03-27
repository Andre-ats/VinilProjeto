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
        if (!File.Exists(path))
            throw new Exception($"Missed file");
                
        using FileStream fileStream = new FileStream(path, FileMode.Open);

        MemoryStream memoryStream = new MemoryStream();
        fileStream.CopyTo(memoryStream);
        
        fileStream.Flush();
        memoryStream.Position = 0;

        return memoryStream;
    }
    
    public bool IsImage(Stream content)
    {
        byte[] buffer = new byte[512]; 
        content.Read(buffer, 0, 512);

        string[] imageFormats = { "FFD8FF", "89504E47", "47494638", "424D" }; 
        string hexSignature = BitConverter.ToString(buffer.Take(4).ToArray()).Replace("-", "");

        return imageFormats.Any(signature => hexSignature.StartsWith(signature));
    }
}